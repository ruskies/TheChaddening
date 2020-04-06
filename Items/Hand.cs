using Terraria;
using Terraria.ID;
using TheChaddening.Commons;
using TheChaddening.Players;

namespace TheChaddening.Items
{
    public sealed class Hand : TheChaddeningItem
    {
        public Hand() : base("Your Hands", "These are your hands. By putting one in the shape of a claw, you're able to dig anything, as long as you're strength allows it.\nYou could drop them, but that wouldn't make any sense.", 30, 34, rarity: ItemRarityID.Expert)
        {
        }


        public override void SetDefaults()
        {
            base.SetDefaults();

            item.useStyle = ItemUseStyleID.Stabbing;

            item.useTime = 18;
            item.useAnimation = 18;
            item.noUseGraphic = true;

            item.autoReuse = true;
        }

        public override void UpdateInventory(Player player)
        {
            base.UpdateInventory(player);

            item.pick = TheChaddeningMath.GetPickaxePower(TheChaddeningPlayer.Get(player).Strength);
        }
    }
}
