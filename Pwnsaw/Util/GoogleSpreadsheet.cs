
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using Google.GData.Client;
using Google.GData.Spreadsheets;

namespace PwnsawLib
{
	public class SpreadsheetManager
	{
		private OAuth2Parameters oAuthParams;
		private SpreadsheetsService _spreadsheetsService;
		private string applicationName;

		private readonly List<SpreadsheetEntry> _spreadsheetEntries = new List<SpreadsheetEntry>(); 

		private SpreadsheetEntry _currentEntry = null;

		public SpreadsheetManager( string userName, string password, string applicationName, string clientId, string clientSecret, string redirectUri, string scope )
		{
			oAuthParams = new OAuth2Parameters()
			{
				ClientId = clientId,
				ClientSecret = clientSecret,
				RedirectUri = redirectUri,
				Scope = scope
			};

			_spreadsheetsService = new SpreadsheetsService( applicationName );
			_spreadsheetsService.setUserCredentials( userName, password );
		}

		public void Authenticate( string refreshToken, string spreadsheetName )
		{
			var authorizationUrl = OAuthUtil.CreateOAuth2AuthorizationUrl( oAuthParams );

			Console.WriteLine( authorizationUrl );

			/*if( !string.IsNullOrEmpty( accessCode ) )
			{
				oAuthParams.AccessCode = accessCode;
			}*/

			if( !string.IsNullOrEmpty( refreshToken ) )
			{
				oAuthParams.RefreshToken = refreshToken;

				OAuthUtil.RefreshAccessToken( oAuthParams );
			}
			else
			{
				OAuthUtil.GetAccessToken( oAuthParams );
			}

			var accessToken = oAuthParams.AccessToken;
			var requestFactory = new GOAuth2RequestFactory( null, applicationName, oAuthParams );

			_spreadsheetsService.RequestFactory = requestFactory;

			var spreadsheetFeed = _spreadsheetsService.Query( new SpreadsheetQuery() );

			_spreadsheetEntries.Clear();

			foreach( var entry in spreadsheetFeed.Entries )
			{
				var spreadsheetEntry = entry as SpreadsheetEntry;

				if( spreadsheetEntry == null )
				{
					continue;
				}

				_spreadsheetEntries.Add( spreadsheetEntry );

				if( spreadsheetName.Equals( spreadsheetEntry.Title.Text ) )
				{
					_currentEntry = spreadsheetEntry;
				}
			}
		}

		public void SetSpreadsheet( string spreadsheetName )
		{
			_currentEntry = _spreadsheetEntries.FirstOrDefault( s => s.Title.Text.Equals( spreadsheetName ));
		}

		public void SetHeroPollData( string userName, IEnumerable<Hero> heroes )
		{
			if( _currentEntry == null )
			{
				return;
			}

			// TODO: Find an existing user.

			var userExists = UpdateExistingUserData( userName, heroes );

			if( userExists )
			{
				return;
			}

			// Create our new user
			SetNewUserData( userName, heroes );
		}

		private bool UpdateExistingUserData( string userName, IEnumerable<Hero> heroes )
		{
			if( _currentEntry == null )
			{
				return false;
			}

			var userNameToLower = userName.ToLower();

			var worksheetFeed = (WorksheetEntry)_currentEntry.Worksheets.Entries[ 0 ];

			var listFeedLink = worksheetFeed.Links.FindService( GDataSpreadsheetsNameTable.ListRel, null );
			var listQuery = new ListQuery( listFeedLink.HRef.ToString() );
			var listFeed = _spreadsheetsService.Query( listQuery );

			ListEntry existingRow = null;

			foreach( var entry in listFeed.Entries )
			{
				var row = entry as ListEntry;
				if( row == null )
				{
					continue;
				}

				foreach( ListEntry.Custom rowElement in row.Elements )
				{
					if( rowElement.LocalName != Constants.IgnHeader )
					{
						continue;
					}

					if( rowElement.Value.ToLower() == userNameToLower )
					{
						existingRow = row;
						break;
					}
				}

				if( existingRow != null )
				{
					break;
				}
			}

			if( existingRow == null )
			{
				return false;
			}

			foreach( ListEntry.Custom rowElement in existingRow.Elements )
			{
				switch( rowElement.LocalName )
				{
					case Constants.IgnHeader:
						rowElement.Value = userName;
						continue;

					case Constants.TierRankingsHeader:
						rowElement.Value = GetTierRankings( heroes );
						continue;

					default:
						break;
				}

				var elementName = rowElement.LocalName;
				var heroName = elementName.Replace( Constants.ThreatMatrixHeading, string.Empty );

				// If the string didn't change, it's because it's a compatibility matrix, not a threat matrix.
				var isCompatibilityMatrix = heroName == elementName;
				if( isCompatibilityMatrix )
				{
					heroName = elementName.Replace( Constants.CompatibilityMatrixHeading, string.Empty );
				}

				// Find which hero this is.
				var matchingHero =  heroes.FirstOrDefault( ( h ) => h.HType.ToString().ToLower() == heroName );
				if( matchingHero == null )
				{
					continue;
				}

				var newData = isCompatibilityMatrix ? GetCompatibilityMatrix( matchingHero ) : GetThreatMatrix( matchingHero );
				rowElement.Value = newData;
			}

			existingRow.Update();

			return true;
		}

		private void SetNewUserData( string userName, IEnumerable<Hero> heroes )
		{
			if( _currentEntry == null )
			{
				return;
			}

			var newRow = new ListEntry();
			var row = newRow.Elements;

			row.Add( new ListEntry.Custom() { LocalName = Constants.IgnHeader, Value = userName } );

			// set our tier rankings
			row.Add( new ListEntry.Custom() { LocalName = Constants.TierRankingsHeader, Value = GetTierRankings( heroes ) } );

			foreach( var hero in heroes )
			{
				var heroThreatMatrix = new StringBuilder();
				var heroCompatibilityMatrix = new StringBuilder();

				foreach( var threatValue in hero.ThreatMatrix.Values )
				{
					heroThreatMatrix.AppendFormat( "{0}{1}", threatValue, Constants.DelimitingCharacter );
				}

				foreach( var compatibilityValue in hero.CompatibilityMatrix.Values )
				{
					heroCompatibilityMatrix.AppendFormat( "{0}{1}", compatibilityValue, Constants.DelimitingCharacter );
				}

				var threatMatrixName = string.Format( Constants.ThreatMatrixFormatString, hero.HType).ToLower();
				var compMatrixName = string.Format( Constants.CompatibilityMatrixFormatString, hero.HType ).ToLower();

				row.Add( new ListEntry.Custom() { LocalName = threatMatrixName, Value = GetThreatMatrix( hero ) } );
				row.Add( new ListEntry.Custom() { LocalName = compMatrixName, Value = GetCompatibilityMatrix( hero ) } );
			}

			var worksheetFeed = (WorksheetEntry)_currentEntry.Worksheets.Entries[0];

			var listFeedLink = worksheetFeed.Links.FindService( GDataSpreadsheetsNameTable.ListRel, null );
			var listQuery = new ListQuery( listFeedLink.HRef.ToString() );
			var listFeed = _spreadsheetsService.Query( listQuery );

			_spreadsheetsService.Insert( listFeed, newRow );
		}

		private string GetCompatibilityMatrix( Hero hero )
		{
			var outputString = new StringBuilder();
			foreach( var value in hero.CompatibilityMatrix.Values )
			{
				outputString.AppendFormat( "{0}{1}", value, Constants.DelimitingCharacter );
			}

			return outputString.ToString().TrimEnd( Constants.DelimitingCharacter );
		}

		private string GetThreatMatrix( Hero hero )
		{
			var outputString = new StringBuilder();
			foreach( var value in hero.ThreatMatrix.Values )
			{
				outputString.AppendFormat( "{0}{1}", value, Constants.DelimitingCharacter );
			}

			return outputString.ToString().TrimEnd( Constants.DelimitingCharacter );
		}

		private string GetTierRankings( IEnumerable<Hero> heroes )
		{
			var tierRankings = new StringBuilder();

			foreach( var hero in heroes )
			{
				tierRankings.AppendFormat( "{0}{1}", hero.Ranking, Constants.DelimitingCharacter );
			}

			return tierRankings.ToString().TrimEnd( Constants.DelimitingCharacter );
		}

		public void InitializeHeaders( )
		{
			var heroTypes = Enum.GetValues( typeof(HeroType) );

			var sb = new StringBuilder();

			sb.AppendFormat( "{0},", Constants.IgnHeader );
			sb.AppendFormat( "{0},", Constants.TierRankingsHeader );

			foreach( var hType in heroTypes )
			{
				var heroType = (HeroType) hType;

				var lowerHeroName = heroType.ToString().ToLower();
				sb.AppendFormat( Constants.ThreatMatrixFormatString, lowerHeroName  );
				sb.Append( ',' );
				sb.AppendFormat( Constants.CompatibilityMatrixFormatString, lowerHeroName );
				sb.Append( ',' );
			}

			Console.WriteLine(sb.ToString());
		}
	}
}
