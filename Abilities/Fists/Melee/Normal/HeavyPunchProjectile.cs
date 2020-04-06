using TheChaddening.Projectiles;

namespace TheChaddening.Abilities.Fists.Melee.Normal
{
    public sealed class HeavyPunchProjectile : TheChaddeningProjectile
    {
        public HeavyPunchProjectile() : base("Punch", 10, 10, true)
        {
        }


        public override void SetDefaults()
        {
            base.SetDefaults();

            projectile.ignoreWater = false;
            projectile.tileCollide = false;
            projectile.alpha = 200;

            projectile.melee = true;
            projectile.timeLeft = (int) NormalPunchAbility.PROJECTILE_TIME;
            projectile.penetrate = 255;

            projectile.friendly = true;

            projectile.usesLocalNPCImmunity = true;
            projectile.localNPCHitCooldown = -1;
        }
    }
}
