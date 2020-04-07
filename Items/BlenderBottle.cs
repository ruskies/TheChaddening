using Terraria;
using Terraria.ID;

namespace TheChaddening.Items
{
    public sealed class BlenderBottle : ChadItem
    {
        public BlenderBottle() : base("Blender Bottle", "Able to contain various protein shakes\nReusable", 18, 28, value: Item.sellPrice(silver: 25), rarity: ItemRarityID.Blue)
        {
        }


        public override void SetDefaults()
        {
            base.SetDefaults();

            item.maxStack = 8;
        }
    }
}
