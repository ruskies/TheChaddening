using Terraria;
using Terraria.ID;

namespace TheChaddening.Items.Dumbbells
{
    public sealed class CaravanCarry : Dumbbell
    {
        public CaravanCarry() : base("Caravan Carry", 
            "Since you've had trouble stopping trains, you've decided to take the matter in your own hands.",
            46, 38, BalanceConstants.AverageBossStrength.SKELETRON_PRIME, 20f, value: Item.sellPrice(gold: 8), rarity: ItemRarityID.Pink)
        {
        }
    }
}
