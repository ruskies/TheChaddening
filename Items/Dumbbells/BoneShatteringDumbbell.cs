using Terraria;
using Terraria.ID;

namespace TheChaddening.Items.Dumbbells
{
    public sealed class BoneShatteringDumbbell : Dumbbell
    {
        public BoneShatteringDumbbell() : base("Bone Shattering Dumbbell", "Every time you curl this, you feel calcium coursing through your veins.\nYou don't know if you should be concerned by this.",
            30, 28, BalanceConstants.AverageBossStrength.SKELETRON, 4f, value: Item.sellPrice(gold: 1), rarity: ItemRarityID.Orange)
        {
        }
    }
}
