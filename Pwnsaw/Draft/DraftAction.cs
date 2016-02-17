namespace PwnsawLib.Draft
{
	public class DraftAction
	{
		public DraftActionType ActionType { get; private set; }
		public Hero Hero { get; private set; }
		public TeamColor Owner { get; private set; }

		public DraftAction( TeamColor owner, DraftActionType actionType, Hero hero )
		{
			ActionType = actionType;
			Hero = hero;
			Owner = owner;
		}
	}
}
