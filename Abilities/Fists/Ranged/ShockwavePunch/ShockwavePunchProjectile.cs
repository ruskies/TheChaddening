using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Terraria;
using TheChaddening.Projectiles;

namespace TheChaddening.Abilities.Fists.Ranged.ShockwavePunch
{
    public sealed class ShockwavePunchProjectile : ChadProjectile
    {
        public const int
            PROJ_FRAMES = 8,
            PROJ_FRAMECOUNTER = 4;


        public ShockwavePunchProjectile() : base("Shockwave", 42, 256, true)
        {
        }


        public override void SetStaticDefaults()
        {
            Main.projFrames[projectile.type] = PROJ_FRAMES;
        }

        public override void SetDefaults()
        {
            base.SetDefaults();

            projectile.height = 256 / PROJ_FRAMES;
            projectile.width = 42;
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
            StandardAnimateFrame(PROJ_FRAMES, PROJ_FRAMECOUNTER);

            projectile.rotation = projectile.velocity.ToRotation() + MathHelper.Pi;
        }
    }
}
