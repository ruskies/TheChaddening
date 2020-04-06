using Terraria;
using TheChaddening.Buffs.Proteins.ProteinShakes;

namespace TheChaddening.Items.Consumables.Proteins.ProteinShakes
{
    public class StoreBoughtPumpkinPieProteinShake : ProteinShake<StoreBoughtProteinShakeBuff>
    {
        public const float GAINS_MULTIPLIER = 0.5f;


        public StoreBoughtPumpkinPieProteinShake() : base("Stored-Bought Pumpkin Protein Shake", "A cheap store-bought protein shake that tastes like pumpkin pie\n", GAINS_MULTIPLIER, value: Item.buyPrice(silver: 5))
        {
        }
    }
}