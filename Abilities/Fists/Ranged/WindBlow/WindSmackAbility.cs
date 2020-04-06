using TheChaddening.Players;

namespace TheChaddening.Abilities.Fists.Ranged.WindBlow
{
    public sealed class WindSmackAbility : Ability
    {
        public const float
            DISTANCE_TRAVELED = 500f,
            SPEED = 15f,
            PROJECTILE_TIME = DISTANCE_TRAVELED / SPEED + 1;


        public WindSmackAbility() : base("ranged.windSmack", "Wind Smack", BalanceConstants.AverageBossStrength.KING_SLIME, AbilityTypes.Ranged)
        {
        }


        public override bool OnChargeRelease(TheChaddeningPlayer chad, int chargedForFrames, ulong strengthCharged, bool local)
        {
            FireProjectile<WindSmackProjectile>(chad, strengthCharged, SPEED, 0.15f, 0.07f);
            return true;
        }


        public override ulong GetRequiredStrengthToUse(TheChaddeningPlayer chad) => (ulong) (BalanceConstants.AverageBossStrength.KING_SLIME / 2f);
    }
}