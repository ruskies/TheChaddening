using Terraria;
using Terraria.ID;

namespace TheChaddening.Items.Dumbbells
{
    public sealed class Barbell200Kg : Dumbbell
    {
        public Barbell200Kg() : base("200KG Barbell", 
            "You treat this barbell as a dumbbell, effectively lifting 200KG (or 440LBs for you imperials) with a single arm.", 
            58, 58, 100000, 100, value: Item.sellPrice(gold: 10), rarity: ItemRarityID.Yellow)
        {
        }
    }
}