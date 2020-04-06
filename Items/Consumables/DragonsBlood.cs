using Terraria;
using Terraria.ID;
using TheChaddening.Players;

namespace TheChaddening.Items.Consumables
{
    public sealed class DragonsBlood : TheChaddeningConsumableItem
    {
        public DragonsBlood() : base("Dragon's Blood", "The blood of a dragon", 22, 34, rarity: ItemRarityID.Red)
        {
        }


        public override bool UseItem(Player player)
        {
            TheChaddeningPlayer tcp = TheChaddeningPlayer.Get(player);

            return true;
        }
    }
}