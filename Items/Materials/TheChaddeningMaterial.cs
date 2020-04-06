using Terraria.ID;

namespace TheChaddening.Items.Materials
{
    public abstract class TheChaddeningMaterial : TheChaddeningItem
    {
        protected TheChaddeningMaterial(string displayName, string tooltip, int width, int height, int value = 0, int rarity = ItemRarityID.White) : base(displayName, tooltip, width, height, value, rarity: rarity)
        {
        }


        
    }
}