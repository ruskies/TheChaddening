using Terraria;
using TheChaddening.Buffs.Proteins.ProteinShakes;

namespace TheChaddening.Items.Consumables.Proteins.ProteinShakes
{
    public sealed class StoreBoughtBlueberryProteinShake : ProteinShake<StoreBoughtProteinShakeBuff>
    {
        public const float GAINS_MULTIPLIER = 0.5f;

        public StoreBoughtBlueberryProteinShake() : base("Store-Bought Blueberry Protein Shake", "A cheap store-bought protein shake that tastes like blueberries\n", GAINS_MULTIPLIER, Item.buyPrice(silver: 5))
        {
        }
    }
}