using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Terraria;
using TheChaddening.Projectiles;

namespace TheChaddening.Abilities.Fists.Ranged.ShockwavePunch
{
    public sealed class ShockwavePunchProjectile : ChadProjectile
    {
        public ShockwavePunchProjectile() : base("Shockwave", 42, 256, true)
        {
        }

        public override void SetStaticDefaults()
        {
            Main.projFrames[projectile.type] = 8;
        }

        public override void SetDefaults()
        {
            base.SetDefaults();

            projectile.height = 42;
            projectile.width = 32;
            projectile.ignoreWater = true;
            projectile.tileCollide = false;
            projectile.alpha = 40;

            projectile.melee = true;
            projectile.timeLeft = (int) ShockwavePunchAbility.PROJECTILE_TIME;
            projectile.penetrate = -1;

            projectile.friendly = true;

            projectile.usesLocalNPCImmunity = true;
            projectile.localNPCHitCooldown = -1;
        }

        public override void AI()
        {
            projectile.frameCounter++;
            if (projectile.frameCounter > 8)
            {
                projectile.frame++;
                projectile.frameCounter = 0;
            }
            if (projectile.frame >= 8)
            {
                projectile.frame = 0;
            }
            projectile.rotation = projectile.velocity.ToRotation() + MathHelper.Pi;
        }
    }
}
