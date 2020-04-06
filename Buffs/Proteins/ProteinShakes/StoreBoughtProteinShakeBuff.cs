using TheChaddening.Items.Consumables.Proteins.ProteinShakes;

namespace TheChaddening.Buffs.Proteins.ProteinShakes
{
    public sealed class StoreBoughtProteinShakeBuff : ProteinShakeBuff
    {
        public const float GAINS_MULTIPLIER = StoreBoughtBlueberryProteinShake.GAINS_MULTIPLIER;


        public StoreBoughtProteinShakeBuff() : base("Store-Bought Protein Shake", GAINS_MULTIPLIER)
        {
        }
    }
}