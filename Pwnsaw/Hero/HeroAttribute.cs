
namespace PwnsawLib
{
    public enum AttributeType
    {
        Burst,
        SustainedDamage,
        Squishy,
        Tanky,
        Kiter,
        GapCloser,
        Channel,
        Interrupt
    }

    public struct HeroAttribute
    {
        #region Fields

        public AttributeType AttType;

        #endregion

    }
}
