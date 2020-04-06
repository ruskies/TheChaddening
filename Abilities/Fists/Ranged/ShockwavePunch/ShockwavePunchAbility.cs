using TheChaddening.Players;

namespace TheChaddening.Abilities.Fists.Ranged.ShockwavePunch
{
    public sealed class ShockwavePunchAbility : Ability
    {
        public const float
            DISTANCE_TRAVELED = 750f,
            SPEED = 20f,
            PROJECTILE_TIME = DISTANCE_TRAVELED / SPEED + 1;


        public ShockwavePunchAbility() : base("ranged.shockwavePunch", "Shockwave Punch", BalanceConstants.AverageBossStrength.EATER_OF_WORLDS, AbilityTypes.Ranged)
        {
        }


        public override bool OnChargeRelease(TheChaddeningPlayer chad, int chargedForFrames, ulong strengthCharged, bool local)
        {
            FireProjectile<ShockwavePunchProjectile>(chad, strengthCharged, SPEED, 0.15f, 0.07f);
            return true;
        }


        public override ulong GetRequiredStrengthToUse(TheChaddeningPlayer chad) => (ulong)(BalanceConstants.AverageBossStrength.EATER_OF_WORLDS / 2f);
    }
}
