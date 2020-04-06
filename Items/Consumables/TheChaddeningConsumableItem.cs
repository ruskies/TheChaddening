using Terraria.ID;

namespace TheChaddening.Items.Consumables
{
    public abstract class TheChaddeningConsumableItem : TheChaddeningItem
    {
        protected TheChaddeningConsumableItem(string displayName, string tooltip, int width, int height, int value = 0, int defense = 0, int rarity = ItemRarityID.White) : base(displayName, tooltip, width, height, value, defense, rarity)
        {
        }


        public override void SetDefaults()
        {
            base.SetDefaults();

            item.consumable = true;

            item.useStyle = ItemUseStyleID.EatingUsing;
            item.useAnimation = 15;
            item.useTime = 15;
        }
    }
}