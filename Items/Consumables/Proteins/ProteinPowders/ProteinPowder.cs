using Terraria;
using TheChaddening.Buffs.Proteins.ProteinPowders;
using WebmilioCommons.Extensions;

namespace TheChaddening.Items.Consumables.Proteins.ProteinPowders
{
    public abstract class ProteinPowder<TBuff> : TheChaddeningConsumableItem where TBuff : ProteinPowderBuff
    {
        private const int DURATION = 20 * Constants.TICKS_PER_SECOND;


        protected ProteinPowder(string displayName, int width, int height, float curlingGainsMultiplier, int value, int rarity) : 
            base(displayName, $"An important ingredient in a protein shake\nYou can eat it raw to gain an extra {curlingGainsMultiplier * 100}% per curl", width, height, value: value, rarity: rarity)
        {
        }


        public override void SetDefaults()
        {
            base.SetDefaults();

            item.buffTime = DURATION;
        }


        public override bool CanUseItem(Player player) => !player.HasBuffSubclass<ProteinPowderBuff>();

        public override bool UseItem(Player player)
        {
            player.AddBuff<TBuff>(DURATION);
            return true;
        }
    }
}
