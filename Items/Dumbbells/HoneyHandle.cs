using Terraria;
using Terraria.ID;

namespace TheChaddening.Items.Dumbbells
{
    public sealed class HoneyHandle : Dumbbell
    {
        public HoneyHandle() : base("Honey Handle", 
            "Its so sticky that you have no trouble hanging onto it upside down.\n" +
            "Tastes sweet",
            40, 48, BalanceConstants.AverageBossStrength.QUEEN_BEE, 3.5f, value: Item.sellPrice(silver: 75), rarity: ItemRarityID.Green)
        {
        }
    }
}
