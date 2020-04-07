using Terraria;
using Terraria.ID;
using TheChaddening.Buffs.Proteins.ProteinShakes;
using WebmilioCommons.Extensions;

namespace TheChaddening.Items.Consumables.Proteins.ProteinShakes
{
    public abstract class ProteinShake<TBuff> : ChadConsumableItem where TBuff : ProteinShakeBuff
    {
        protected ProteinShake(string displayName, string tooltip, float curlingGainMultiplier, int value) : base(displayName, tooltip + $"Makes your curling {curlingGainMultiplier * 100}% more efficient", 34, 34, value: value, rarity: ItemRarityID.Orange)
        {
            CurlingGainMultiplier = curlingGainMultiplier;
        }


        public override void SetDefaults()
        {
            base.SetDefaults();

            item.buffTime = 3 * 60 * Constants.TICKS_PER_SECOND;
        }


        public override bool CanUseItem(Player player) => !player.HasBuffSubclass<ProteinShakeBuff>();

        public override bool UseItem(Player player)
        {
            player.AddBuff<TBuff>(item.buffTime);
            return true;
        }


        public float CurlingGainMultiplier { get; }
    }
}
