using Terraria;
using Terraria.ID;

namespace TheChaddening.Items.Dumbbells
{
    public sealed class SlimeyDumbbell : Dumbbell
    {
        public SlimeyDumbbell() : base("Slimy Dumbbell", "A token of respect from the King of Slimes itself. His dying wish: for you to get more GAAAAAAAAAAAAINS\nIts slippery-ness helps you train your fingers", 
            36, 42, BalanceConstants.AverageBossStrength.KING_SLIME, 1.5f, value: Item.sellPrice(silver: 40), rarity: ItemRarityID.Blue)
        {
        }
    }
}