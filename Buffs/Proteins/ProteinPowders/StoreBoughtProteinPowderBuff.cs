using TheChaddening.Items.Consumables.Proteins.ProteinPowders;

namespace TheChaddening.Buffs.Proteins.ProteinPowders
{
    public sealed class StoreBoughtProteinPowderBuff : ProteinPowderBuff
    {
        public const float GAINS_MULTIPLIER = StoreBoughtProteinPowder.GAINS_MULTIPLIER;

        public StoreBoughtProteinPowderBuff() : base("Extra Gains", GAINS_MULTIPLIER)
        {
        }
    }
}