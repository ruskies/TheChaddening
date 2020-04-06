using Microsoft.Xna.Framework;
using Terraria;

namespace TheChaddening.Commons
{
    public static class TheChaddeningMath
    {
        public const float
            STRENGTH_HEALTH_RATIO = 5 / 1000f,
            STRENGTH_DAMAGE_RATIO = 2.5f / 100,
            STRENGTH_PICKAXE_POWER_RATIO = 0.75f / 100,
            STRENGTH_AXE_POWER_RATIO = 0.7f / 100,
            STRENGTH_KNOCKBACK_RATIO = 1f / 10000,
            
            SPEED_SCALING_RATIO = 1f / 1000;

        public static int GetPickaxePower(ulong strength) => (int) (35 + strength * STRENGTH_PICKAXE_POWER_RATIO);

        public static int GetAxePower(ulong strength) => (int) (35 + strength * STRENGTH_AXE_POWER_RATIO);

        public static int GetExtraHealth(ulong strength)
        {
            ulong resultingHealth = (ulong)(strength * STRENGTH_HEALTH_RATIO);

            if (resultingHealth > int.MaxValue)
                resultingHealth = int.MaxValue;

            return (int) resultingHealth;
        }


        // Credit to Rebmiami and Kazzymodus from tModLoader.
        public static Vector2 CalculateSpeedForMouse(Player player, float fireSpeed) => Vector2.Normalize(Main.MouseWorld - player.Center) * fireSpeed;
        /*
         * float fireSpeed = 10f; // Tweak to your leisure.
         * Vector2 cursorDirection = Vector2.Normalize(Main.MouseWorld - player.Center);
         * Vector2 fireVelocity = cursorDirection * fireSpeed;
         */
    }
}