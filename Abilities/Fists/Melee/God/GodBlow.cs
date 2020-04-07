using TheChaddening.Players;

namespace TheChaddening.Abilities.Fists.Melee.God
{
    public class GodBlow : Ability
    {
        public GodBlow() : base("fist.godBlow", "God Blow", BalanceConstants.AverageBossStrength.MOON_LORD, AbilityTypes.Melee)
        {
        }


        public override bool OnChargeRelease(TheChaddeningPlayer chad, int chargedForFrames, ulong strengthCharged, bool local)
        {
            throw new System.NotImplementedException();
        }
    }
}