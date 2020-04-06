using TheChaddening.Items.Consumables.Proteins.ProteinShakes;

namespace TheChaddening.Buffs.Proteins.ProteinShakes
{
    public sealed class HomemadeProteinShakeLesserBuff : ProteinShakeBuff
    {
        public const float GAINS_MULTIPLIER = HomemadeProteinShakeLesser.GAINS_MULTIPLIER;

        public HomemadeProteinShakeLesserBuff() : base("Homemade Lesser Protein Shake", GAINS_MULTIPLIER)
        {
        }
    }
}