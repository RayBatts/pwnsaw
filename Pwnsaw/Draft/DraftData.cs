using System;
using System.Collections.Generic;

namespace PwnsawLib.Draft
{
    public class DraftData
    {
	    public enum DraftPhase
	    {
			FirstBan,
			SecondBan,
			BluePick1,
			RedPick1,
			RedPick2,
			BluePick2,
			BluePick3,
			RedPick3,
			Complete,
	    }

		public static readonly Dictionary<DraftPhase, TeamColor> TurnOrder = new Dictionary<DraftPhase, TeamColor>()
		{
			{ DraftPhase.FirstBan, TeamColor.Blue },
			{ DraftPhase.SecondBan, TeamColor.Red },
			{ DraftPhase.BluePick1, TeamColor.Blue },
			{ DraftPhase.RedPick1, TeamColor.Red },
			{ DraftPhase.RedPick2, TeamColor.Red },
			{ DraftPhase.BluePick2, TeamColor.Blue },
			{ DraftPhase.BluePick3, TeamColor.Blue },
			{ DraftPhase.RedPick3, TeamColor.Red },
		}; 

	    public DraftPhase CurrentPhase { get; private set; }

	    public List< DraftAction > DraftActions { get; private set; }
	    public List< Hero > AvailableHeroes { get; private set; }

		private Random _rng;

	    public DraftData( Random rng, IEnumerable<Hero> validHeroes )
	    {
		    _rng = rng;
			DraftActions = new List< DraftAction >();
			Reset( validHeroes );
	    }

	    public void SubmitDraftAction( DraftAction action )
	    {
		    if( CurrentPhase == DraftPhase.Complete )
		    {
				Console.WriteLine( "Can't submit an action to a completed draft." );
			    return;
		    }

			DraftActions.Add( action );

		    var heroIdx = AvailableHeroes.FindIndex( h => h.HType == action.Hero.HType );
			AvailableHeroes.RemoveAt( heroIdx );

		    CurrentPhase++;
	    }

	    public HeroType SelectRandomHero()
	    {
		    var randomIdx =_rng.Next( 0, AvailableHeroes.Count );

			return AvailableHeroes[ randomIdx ].HType;
	    }

		public void Reset( IEnumerable<Hero> validHeroes )
	    {
			CurrentPhase = DraftPhase.FirstBan;

			AvailableHeroes = new List<Hero>( validHeroes );
		    DraftActions.Clear();
	    }
    }
}
