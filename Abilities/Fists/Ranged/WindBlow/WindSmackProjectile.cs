using TheChaddening.Projectiles;

namespace TheChaddening.Abilities.Fists.Ranged.WindBlow
{
    public class WindSmackProjectile : ChadProjectile
    {
        public WindSmackProjectile() : base("Wind Blow", 10, 10, true)
        {
        }


        public override void SetDefaults()
        {
            base.SetDefaults();

            projectile.ignoreWater = false;
            projectile.tileCollide = true;
            projectile.alpha = 200;

            projectile.melee = true;
            projectile.timeLeft = (int)WindSmackAbility.PROJECTILE_TIME;
            projectile.penetrate = 1;

            projectile.friendly = true;

            projectile.usesLocalNPCImmunity = true;
            projectile.localNPCHitCooldown = -1;
        }
    }
}