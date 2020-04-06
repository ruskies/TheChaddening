namespace TheChaddening
{
    public static class BalanceConstants
    {
        public static class AverageBossStrength
        {
            public const ulong
                KING_SLIME = 2500,
                EYE_OF_CTHULHU = 4500,

                GOBLIN_INVASTION = 3000,

                EATER_OF_WORLDS = 10000,
                BRAIN_OF_CTHULHU = EATER_OF_WORLDS,

                QUEEN_BEE = 8000,
                SKELETRON = 20000,

                WALL_OF_FLESH = 50000,


                THE_TWINS = 100000,
                THE_DESTROYER = THE_TWINS,
                SKELETRON_PRIME = THE_DESTROYER,

                PLANTERA = 350000,

                PUMPKIN_MOON = 0,
                FROST_MOON = 0,

                GOLEM = 0,

                MARTIAN_INVASTION = 0,

                THE_DUMBEST_INVASION_IN_TERRARIA = 0,

                DUKE_FISHRON = 0,

                LUNAR_CULTIST = 0,
                FOUR_PILLARS = 0,
                MOON_LORD = 1000000;
        }

        public static class AbilityRequiredStrength
        {
            public const ulong
                NORMAL_PUNCH = 0,

                HEAVY_PUNCH = 500,
                WIND_BLOW = 500,

                SHOCKWAVE_BLOW = AverageBossStrength.EATER_OF_WORLDS,
                
                GOD_BLOW = AverageBossStrength.MOON_LORD;
        }
    }
}