
using System.Collections.Generic;
using System.Linq;
using Pwnsaw.Draft;

namespace Pwnsaw
{
    public class DraftManager
    {
	    private const int MAX_DRAFTS = 10;

	    public int RoundCount = 5;

		private readonly Stack<DraftData> _draftDataPool = new Stack<DraftData>( MAX_DRAFTS ); 
		private readonly List< DraftData > _previousDrafts = new List< DraftData >();

	    private readonly Dictionary< HeroType, Hero > _heroPool = new Dictionary< HeroType, Hero >(); 

	    private DraftData _currentDraft;

	    public int CurrentRound
	    {
		    get
		    {
				return _previousDrafts.Count + 1;
		    }
	    }

	    public DraftData.DraftPhase CurrentDraftPhase
	    {
		    get { return _currentDraft.CurrentPhase; }
	    }

	    public DraftManager()
	    {
			InitializeHeroPool();

		    for( var x = 0; x < MAX_DRAFTS; x++ )
		    {
				_draftDataPool.Push( new DraftData( _heroPool.Values.ToList() ) );
		    }
	    }

		private void InitializeHeroPool()
	    {
			// TODO: Get the .csv or whatever and create heroes based off averages.

			tempInitializeHeroData();
	    }

	    public void Reset( TeamColor playerTeamColor )
	    {
		    if( _currentDraft != null )
		    {
				_previousDrafts.Add( _currentDraft );
		    }

		    if( CurrentRound >= RoundCount )
		    {
				var heroes = _heroPool.Values;
			    foreach( var draft in _previousDrafts )
			    {
					draft.Reset( heroes );
				    _draftDataPool.Push( draft );
			    }

				_previousDrafts.Clear();   
		    }

			_currentDraft = _draftDataPool.Pop();
	    }

	    public void SubmitDraftAction( HeroType heroType )
	    {
			var actionType = _currentDraft.CurrentPhase <= DraftData.DraftPhase.SecondBan ? DraftActionType.Ban : DraftActionType.Pick;
			_currentDraft.SubmitDraftAction( new DraftAction( TeamColor.Blue, actionType, _heroPool[ heroType ] ) );   
	    }

		private void tempInitializeHeroData()
		{
			var heroList = Util.DeserializeHeroList("Data/CombinedHeroFile.xml");

			foreach( var hero in heroList )
			{
				_heroPool[ hero.HType ] = hero;
			}
		}
    }
}
