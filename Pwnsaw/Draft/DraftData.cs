using System;
using System.Collections.Generic;

namespace Pwnsaw.Draft
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
			Complete
	    }

	    public DraftPhase CurrentPhase { get; private set; }

	    public List< DraftAction > DraftActions { get; private set; }
	    public List< Hero > AvailableHeroes { get; private set; }

	    public DraftData( IEnumerable<Hero> validHeroes )
	    {
			DraftActions = new List< DraftAction >();
			AvailableHeroes = new List<Hero>( validHeroes );
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
    }
}
