using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ModLoader;
using TheChaddening.Commons;
using TheChaddening.Players;
using WebmilioCommons.Extensions;
using WebmilioCommons.Managers;
using WebmilioCommons.Networking;

namespace TheChaddening.Abilities
{
    public abstract class Ability : IHasUnlocalizedName
    {
        protected Ability(string unlocalizedName, string displayName, ulong requiredStrengthToUnlock, AbilityTypes abilityType)
        {
            UnlocalizedName = unlocalizedName;
            DisplayName = displayName;

            RequiredStrengthToUnlock = requiredStrengthToUnlock;

            AbilityType = abilityType;
        }


        public virtual void DoOnChargeRelease(TheChaddeningPlayer chad, int chargedForFrames, ulong strengthCharged)
        {
            bool local = chad.IsLocalPlayer();

            if (local)
                NetworkPacketLoader.Instance.SendPacket(new AbilityChargeReleasedPacket(this, chargedForFrames, strengthCharged));

            OnChargeRelease(chad, chargedForFrames, strengthCharged, local);
        }

        public abstract bool OnChargeRelease(TheChaddeningPlayer chad, int chargedForFrames, ulong strengthCharged, bool local);


        protected void FireProjectile<T>(TheChaddeningPlayer chad, ulong strengthCharged, float speed, float damageScaling, float knockbackScaling) where T : ModProjectile
        {
            Projectile.NewProjectile(new Vector2(chad.player.position.X + chad.player.width / 2, chad.player.position.Y + chad.player.height / 2), 
                TheChaddeningMath.CalculateSpeedForMouse(chad.player, speed), ModContent.ProjectileType<T>(), 
                (int)(strengthCharged * damageScaling), strengthCharged * knockbackScaling, chad.player.whoAmI);
        }


        public virtual ulong GetRequiredStrengthToUse(TheChaddeningPlayer chad) => RequiredStrengthToUnlock;


        public virtual bool CanUse(TheChaddeningPlayer chad) => true;


        public string UnlocalizedName { get; }
        public string DisplayName { get; }

        public ulong RequiredStrengthToUnlock { get; }

        public AbilityTypes AbilityType { get; }
    }
}
