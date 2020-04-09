using Terraria;
using Terraria.ModLoader;

namespace TheChaddening.Players
{
    public sealed partial class TheChaddeningPlayer : ModPlayer
    {
        private void ResetEffectsGains()
        {
            CurlingGainsMultiplier = 1f;
            BiomeCurlingGainsMultiplier = 1f;
            
            GlobalCurlingGainsMultiplier = 1f;
            
            CurlingSpeedMultiplier = 1f;
        }


        private void PreUpdateMovementGains()
        {
            if (player.ZoneSnow)
                BiomeCurlingGainsMultiplier += 0.15f;
            else if (player.ZoneUnderworldHeight)
                BiomeCurlingGainsMultiplier += 0.22f;

            if (player.breath <= 0)
                CurlingGainsMultiplier += 0.10f;
        }


        public float CurlingGainsMultiplier { get; set; }
        public float BiomeCurlingGainsMultiplier { get; set; }
        public float TotalCurlingGainsMultiplier => CurlingGainsMultiplier * BiomeCurlingGainsMultiplier;

        public float GlobalCurlingGainsMultiplier { get; set; }

        public float CurlingSpeedMultiplier { get; set; }
    }
}
