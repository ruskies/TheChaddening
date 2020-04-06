using Terraria.ModLoader;
using Terraria.ModLoader.IO;

namespace TheChaddening.Players
{
    public sealed partial class TheChaddeningPlayer : ModPlayer
    {
        private void LoadCharge(TagCompound tag)
        {
            if (tag.ContainsKey(nameof(ManualChargeRate)))
                ManualChargeRate = tag.GetFloat(nameof(ManualChargeRate));
        }

        private void SaveCharge(TagCompound tag)
        {
            tag.Add(nameof(ManualChargeRate), ManualChargeRate);
        }
    }
}
