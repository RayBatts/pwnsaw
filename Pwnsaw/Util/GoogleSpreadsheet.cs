
using System;
using System.Collections.Generic;
using System.Linq;
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

			var userExists = UpdateExistingUserData();

			if( userExists )
			{
				return;
			}

			// Create our new user
			SetNewUserData( userName, heroes );
		}

		private bool UpdateExistingUserData()
		{
			return false;
		}

		private void SetNewUserData( string userName, IEnumerable<Hero> heroes )
		{
			if( _currentEntry == null )
			{
				return;
			}

			var newRow = new ListEntry();
			var row = newRow.Elements;
			var delimitingChar = ',';

			row.Add( new ListEntry.Custom() { LocalName = Constants.IgnHeader, Value = userName } );

			// get our tier rankings
			var tierRankings = new StringBuilder();

			foreach( var hero in heroes )
			{
				tierRankings.AppendFormat( "{0}{1}", hero.Ranking, delimitingChar );
			}

			row.Add( new ListEntry.Custom() { LocalName = Constants.TierRankingsHeader, Value = tierRankings.ToString().TrimEnd( delimitingChar ) } );

			foreach( var hero in heroes )
			{
				var heroThreatMatrix = new StringBuilder();
				var heroCompatibilityMatrix = new StringBuilder();

				foreach( var threatValue in hero.ThreatMatrix.Values )
				{
					heroThreatMatrix.AppendFormat( "{0}{1}", threatValue, delimitingChar );
				}

				foreach( var compatibilityValue in hero.CompatibilityMatrix.Values )
				{
					heroCompatibilityMatrix.AppendFormat( "{0}{1}", compatibilityValue, delimitingChar );
				}

				var threatMatrixName = string.Format( Constants.ThreatMatrixFormatString, hero.HType).ToLower();
				var compMatrixName = string.Format( Constants.CompatibilityMatrixFormatString, hero.HType ).ToLower();

				row.Add( new ListEntry.Custom() { LocalName = threatMatrixName, Value = heroThreatMatrix.ToString().TrimEnd( delimitingChar ) } );
				row.Add( new ListEntry.Custom() { LocalName = compMatrixName, Value = heroCompatibilityMatrix.ToString().TrimEnd( delimitingChar ) } );
			}

			var worksheetFeed = (WorksheetEntry)_currentEntry.Worksheets.Entries[0];

			var listFeedLink = worksheetFeed.Links.FindService( GDataSpreadsheetsNameTable.ListRel, null );
			var listQuery = new ListQuery( listFeedLink.HRef.ToString() );
			var listFeed = _spreadsheetsService.Query( listQuery );

			_spreadsheetsService.Insert( listFeed, newRow );
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
