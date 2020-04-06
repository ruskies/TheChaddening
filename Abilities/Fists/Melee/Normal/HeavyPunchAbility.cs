using TheChaddening.Players;

namespace TheChaddening.Abilities.Fists.Melee.Normal
{
    public sealed class HeavyPunchAbility : Ability
    {
        public HeavyPunchAbility() : base("melee.heavyPunch", "Heavy Punch", BalanceConstants.AbilityRequiredStrength.HEAVY_PUNCH, AbilityTypes.Melee)
        {
        }


        public override bool OnChargeRelease(TheChaddeningPlayer chad, int chargedForFrames, ulong strengthCharged, bool local)
        {
            FireProjectile<HeavyPunchProjectile>(chad, strengthCharged, NormalPunchAbility.SPEED, 0.30f, 0.22f);
            return true;
        }


        public override ulong GetRequiredStrengthToUse(TheChaddeningPlayer chad) => (ulong) (chad.Strength * 0.5f);
    }
}
