using Terraria;
using Terraria.ID;
using WebmilioCommons.Extensions;
using TheChaddening.Buffs.Preworkout;
using TheChaddening.Buffs.Proteins.ProteinPowders;

namespace TheChaddening.Items.Consumables.Preworkouts
{
    public abstract class PreworkoutPowder<TBuff> : ChadConsumableItem where TBuff : PreworkoutBuff
    {
        private const int DURATION = 20 * Constants.TICKS_PER_SECOND;


        protected PreworkoutPowder(string displayName, string tooltip, int width, int height, float curlSpeedMultiplier, int value = 0, int rarity = ItemRarityID.White) : base(displayName, tooltip, width, height, value, rarity)
        {
            CurlSpeedMultiplier = curlSpeedMultiplier;
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


        public float CurlSpeedMultiplier { get; set; }
    }
}