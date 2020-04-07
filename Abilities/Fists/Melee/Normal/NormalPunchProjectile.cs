using TheChaddening.Projectiles;

namespace TheChaddening.Abilities.Fists.Melee.Normal
{
    public sealed class NormalPunchProjectile : TheChaddeningProjectile
    {
        public NormalPunchProjectile() : base("Punch", 10, 10, true)
        {
            DamageScalesDownWithHits = false;
        }


        public override void SetDefaults()
        {
            base.SetDefaults();

            projectile.ignoreWater = true;
            projectile.tileCollide = true;
            projectile.alpha = 200;

            projectile.melee = true;
            projectile.timeLeft = (int) NormalPunchAbility.PROJECTILE_TIME;
            projectile.penetrate = 1;

            projectile.friendly = true;
        }
    }
}
