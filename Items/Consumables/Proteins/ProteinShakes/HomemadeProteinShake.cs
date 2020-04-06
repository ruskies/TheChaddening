using Terraria;
using Terraria.ModLoader;
using TheChaddening.Buffs.Proteins.ProteinShakes;

namespace TheChaddening.Items.Consumables.Proteins.ProteinShakes
{
    public abstract class HomemadeProteinShake<T> : ProteinShake<T> where T : ProteinShakeBuff
    {
        protected HomemadeProteinShake(string displayName, string tooltip, float curlingGainMultiplier, int value) : base(displayName, tooltip, curlingGainMultiplier, value)
        {
        }


        public override bool UseItem(Player player)
        {
            player.PutItemInInventory(ModContent.ItemType<BlenderBottle>());

            return base.UseItem(player);
        }
    }
}