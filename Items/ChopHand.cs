using Terraria;
using Terraria.ID;
using TheChaddening.Commons;
using TheChaddening.Players;

namespace TheChaddening.Items
{
    public sealed class ChopHand : TheChaddeningItem
    {
        public ChopHand() : base("Your Choppy Hands", "These are your hands. By constricting your hand, you're able to chop down anything, as long as you're strength allows it.\nComes with the added bonus of being able to taket down walls.\nYou could drop them, but that wouldn't make any sense.", 34, 30, rarity: ItemRarityID.Expert)
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

            int power = TheChaddeningMath.GetAxePower(TheChaddeningPlayer.Get(player).Strength);

            item.axe = power / 5;
            item.hammer = power;
        }
    }
}
