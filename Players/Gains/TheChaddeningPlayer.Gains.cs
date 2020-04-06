using Terraria.ModLoader;

namespace TheChaddening.Players
{
    public sealed partial class TheChaddeningPlayer : ModPlayer
    {
        private void ResetEffectsGains()
        {
            CurlingGainsMultiplier = 1f;
            OverallCurlingGainsMultiplier = 1f;
            CurlingSpeedMultiplier = 1f;
        }


        public float CurlingGainsMultiplier { get; set; }
        public float OverallCurlingGainsMultiplier { get; set; }
        public float CurlingSpeedMultiplier { get; set; }
    }
}
