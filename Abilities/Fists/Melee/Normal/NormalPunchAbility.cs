using TheChaddening.Players;

namespace TheChaddening.Abilities.Fists.Melee.Normal
{
    public sealed class NormalPunchAbility : Ability
    {
        public const float 
            DISTANCE_TRAVELED = 50f,
            SPEED = 30f,
            PROJECTILE_TIME = DISTANCE_TRAVELED / SPEED + 1;

        public NormalPunchAbility() : base("melee.normalPunch", "Normal Punch", BalanceConstants.AbilityRequiredStrength.NORMAL_PUNCH, AbilityTypes.Melee)
        {
        }


        public override bool OnChargeRelease(TheChaddeningPlayer chad, int chargedForFrames, ulong strengthCharged, bool local)
        {
            FireProjectile<NormalPunchProjectile>(chad, strengthCharged, SPEED, 0.15f, 0.07f);
            return true;
        }


        public override ulong GetRequiredStrengthToUse(TheChaddeningPlayer chad) => 0;
    }
}
