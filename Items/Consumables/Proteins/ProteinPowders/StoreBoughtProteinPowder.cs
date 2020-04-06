using Terraria;
using Terraria.ID;
using TheChaddening.Buffs.Proteins.ProteinPowders;

namespace TheChaddening.Items.Consumables.Proteins.ProteinPowders
{
    public sealed class StoreBoughtProteinPowder : ProteinPowder<StoreBoughtProteinPowderBuff>
    {
        public const float GAINS_MULTIPLIER = 2.5f;


        public StoreBoughtProteinPowder() : base("Store-bought Protein Powder", 18, 18, GAINS_MULTIPLIER, value: Item.buyPrice(silver: 1), rarity: ItemRarityID.Green)
        {
        }
    }
}