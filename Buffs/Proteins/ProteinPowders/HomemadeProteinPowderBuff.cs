using TheChaddening.Items.Consumables.Proteins.ProteinPowders;

namespace TheChaddening.Buffs.Proteins.ProteinPowders
{
    public sealed class HomemadeProteinPowderBuff : ProteinPowderBuff
    {
        public HomemadeProteinPowderBuff() : base("Extra Gains", HomemadeProteinPowder.GAINS_MULTIPLIER)
        {
        }
    }
}