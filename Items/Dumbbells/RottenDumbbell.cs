using Terraria;
using Terraria.ID;

namespace TheChaddening.Items.Dumbbells
{
    public sealed class RottenDumbbell : Dumbbell
    {
        public const float GAINS_PER_CURL = 3f;

        public const ulong REQUIRED_STRENGTH = BalanceConstants.AverageBossStrength.EATER_OF_WORLDS;
        public const int RARITY = ItemRarityID.Green;

        public static readonly int value = Item.sellPrice(silver: 80);

        public RottenDumbbell() : base("Rotten Dumbbell", "After witnessing the Eater of Worlds' strength, you were inspired to craft a dumbbell out of its carcass\nThe smell trains your nose", 
            40, 42, REQUIRED_STRENGTH, GAINS_PER_CURL, value: value, rarity: RARITY)
        {
        }
    }
}