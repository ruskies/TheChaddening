using TheChaddening.Items.Consumables.Preworkouts.PreworkoutPowders;

namespace TheChaddening.Buffs.Preworkout.PreworkoutPowders
{
    public sealed class BloodRushPowderBuff : PreworkoutBuff
    {
        public BloodRushPowderBuff() : base("BloodRush", BloodRushPowder.SPEED_MULTIPLIER)
        {
        }
    }
}