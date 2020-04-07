using Terraria;
using Terraria.ID;

namespace TheChaddening.Items.Dumbbells
{
    public sealed class EyeDumbbell : Dumbbell
    {
        public EyeDumbbell() : base("Eye Dumbbell", 
            "You can SEE it helps you get stronger.\n" +
            "You feel your retina tingle.", 
            38, 38, BalanceConstants.AverageBossStrength.EYE_OF_CTHULHU, 2f, value: Item.sellPrice(silver: 10), rarity: ItemRarityID.Blue)
        {
        }
    }
}
