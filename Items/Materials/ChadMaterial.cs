using Terraria.ID;

namespace TheChaddening.Items.Materials
{
    public abstract class ChadMaterial : ChadItem
    {
        protected ChadMaterial(string displayName, string tooltip, int width, int height, int value = 0, int rarity = ItemRarityID.White) : base(displayName, tooltip, width, height, value, rarity: rarity)
        {
        }


        
    }
}