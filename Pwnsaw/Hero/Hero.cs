using System;
using System.Collections.Generic;
using System.Linq;

namespace PwnsawLib
{
    [Flags]
    public enum HeroRole
    {
        None = 0,
        Support = 1,
        LaneCarry = 2,
        JungleCarry = 4
    }

    [Flags]
    public enum HeroBuild
    {
        None = 0,
        CrystalPower = 1,
        WeaponPower = 2,
        Utility = 4
    }

    [Flags]
    public enum AttackRange
    {
        None = 0,
        Melee = 1,
        Ranged = 2
    }

    [Serializable]
    public class Hero : IComparable
    {

        #region Properties

        private string _displayName = string.Empty;
        public string DisplayName
        {
            get
            {
                if ( string.IsNullOrEmpty( _displayName ) )
                {
                    _displayName = HType.ToString();
                }

                return _displayName;
            }
        }

        public HeroType HType { get; set; }

        public AttackRange Range { get; set; }

        public HeroRole Role { get; set; }

        public HeroBuild Build { get; set; }

        public float Ranking { get; set; }

        public Dictionary<HeroType, float> ThreatMatrix { get; set; }

        public Dictionary<HeroType, float> CompatibilityMatrix { get; set; }

        #endregion

        public Hero()
        {
            ThreatMatrix = new Dictionary<HeroType, float>();
            CompatibilityMatrix = new Dictionary<HeroType, float>();

	        ResetThreatMatrix();
			ResetCompatibilityMatrix();
        }

        #region Public API

        public int CompareTo( object obj )
        {
            var hero = obj as Hero;
            if ( hero == null )
            {
                throw new ArgumentException();
            }

            return CompareTo( hero );
        }

        public int CompareTo( Hero hero )
        {
            return 0;
        }

		public void ResetThreatMatrix()
		{
			foreach( var key in ThreatMatrix.Keys.ToList() )
			{
				ThreatMatrix[ key ] = 0;
			}
		}

	    public void ResetCompatibilityMatrix()
	    {
			foreach( var key in CompatibilityMatrix.Keys.ToList() )
			{
				CompatibilityMatrix[ key ] = 0;
			}
	    }

	    public void RandomizeThreatMatrix( Random rng = null )
	    {
		    if( rng == null )
		    {
			    rng = new Random();
		    }

			foreach( var key in ThreatMatrix.Keys.ToList() )
			{
				ThreatMatrix[ key ] = rng.Next(1, 6);
			}
	    }

		public void RandomizeCompatibilityMatrix( Random rng )
		{
			if( rng == null )
			{
				rng = new Random();
			}

			foreach( var key in CompatibilityMatrix.Keys.ToList() )
			{
				CompatibilityMatrix[ key ] = rng.Next( 1, 4 );
			}
		}

	    #endregion

    }
}
