namespace TheChaddening.Items.Dumbbells
{
    public sealed class LeechingLift : Dumbbell
    {
        public LeechingLift() : base("Leeching Lift Dumbbell", "After witnessing the Brain of Cthulhu' brain power, you were inspired to craft a dumbbell out of its carcass", 
            42, 38, BalanceConstants.AverageBossStrength.BRAIN_OF_CTHULHU, RottenDumbbell.GAINS_PER_CURL, value: RottenDumbbell.value, rarity: RottenDumbbell.RARITY)
        {
        }
    }
}