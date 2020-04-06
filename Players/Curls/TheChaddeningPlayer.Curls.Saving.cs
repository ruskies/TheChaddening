using Terraria.ModLoader;
using Terraria.ModLoader.IO;

namespace TheChaddening.Players
{
    public sealed partial class TheChaddeningPlayer : ModPlayer
    {
        private void LoadCurls(TagCompound tag)
        {
            TotalCurls = tag.GetAsInt(nameof(TotalCurls));
        }

        private void SaveCurls(TagCompound tag)
        {
            tag.Add(nameof(TotalCurls), TotalCurls);
        }
    }
}
