using Terraria;
using Terraria.ID;

namespace TheChaddening.Items.Dumbbells
{
    public sealed class PrimordialRock : Dumbbell
    {
        public PrimordialRock() : base("Primordial Rock", "It works", 
            50, 52, 50000, 50, value: Item.sellPrice(gold: 10), rarity: ItemRarityID.Lime)
        {
        }
    }
}