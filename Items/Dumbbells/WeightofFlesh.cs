using Terraria;
using Terraria.ID;

namespace TheChaddening.Items.Dumbbells
{
    public sealed class WeightofFlesh : Dumbbell
    {
        public WeightofFlesh() : base("Last Night's Dinner", 
            "The leftovers you didn't want to eat: mostly the eyes and some tentacles.",
            38, 36, BalanceConstants.AverageBossStrength.WALL_OF_FLESH, 10f, value: Item.sellPrice(gold: 3), rarity: ItemRarityID.LightRed)
        {
        }
    }
}
