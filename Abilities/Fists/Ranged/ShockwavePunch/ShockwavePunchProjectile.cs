using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Terraria;
using TheChaddening.Projectiles;

namespace TheChaddening.Abilities.Fists.Ranged.ShockwavePunch
{
    public sealed class ShockwavePunchProjectile : TheChaddeningProjectile
    {
        public ShockwavePunchProjectile() : base("Shockwave", 32, 32, true)
        {
        }


        public override void SetDefaults()
        {
            base.SetDefaults();

            projectile.ignoreWater = true;
            projectile.tileCollide = false;
            projectile.alpha = 255;

            projectile.melee = true;
            projectile.timeLeft = (int) ShockwavePunchAbility.PROJECTILE_TIME;
            projectile.penetrate = 255;

            projectile.friendly = true;

            projectile.usesLocalNPCImmunity = true;
            projectile.localNPCHitCooldown = -1;
        }


        public override bool PreDraw(SpriteBatch spriteBatch, Color lightColor)
        {
            Texture2D texture = Main.projectileTexture[projectile.type];

            spriteBatch.Draw(texture, projectile.position, new Rectangle(0, 0, texture.Width, texture.Height), Color.White, projectile.velocity.X == -1 ? -90f : 90f, Vector2.Zero, Vector2.One, SpriteEffects.None, 0);

            return false;
        }
    }
}
