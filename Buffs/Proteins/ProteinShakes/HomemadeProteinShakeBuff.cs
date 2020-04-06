using TheChaddening.Items.Consumables.Proteins.ProteinShakes;

namespace TheChaddening.Buffs.Proteins.ProteinShakes
{
    public sealed class HomemadeProteinShakeBuff : ProteinShakeBuff
    {
        public const float GAINS_MULTIPLIER = HomemadeQualityProteinShake.GAINS_MULTIPLIER;


        public HomemadeProteinShakeBuff() : base("Homemade Protein Shake", GAINS_MULTIPLIER)
        {
        }
    }
}