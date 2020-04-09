using Terraria.ModLoader;

namespace TheChaddening.Players
{
    public sealed partial class TheChaddeningPlayer : ModPlayer
    {
        public float GetGainsFromCurl(float gainsPerCurl) => (gainsPerCurl * TotalCurlingGainsMultiplier) * GlobalCurlingGainsMultiplier;

        public void Curl(float gainsPerCurl)
        {
            TotalCurls++;
            AddStrength((ulong) GetGainsFromCurl(gainsPerCurl));
        }


        public int TotalCurls { get; private set; }
    }
}
