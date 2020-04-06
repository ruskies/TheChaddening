using Terraria;
using Terraria.ID;
using TheChaddening.Buffs.Preworkout.PreworkoutPowders;

namespace TheChaddening.Items.Consumables.Preworkouts.PreworkoutPowders
{
    public sealed class BloodRushPowder : PreworkoutPowder<BloodRushPowderBuff>
    {
        public const float SPEED_MULTIPLIER = 5f;


        public BloodRushPowder() : base("BloodRush Preworkout", "Engineered by one of the smartest minds of our generation, preworkout gives a significant boost to your curling speed\n" +
                                                                "loltyler1.com discout code: alpha\nloltyler1.com discout code: alpha\nloltyler1.com discout code: alpha\nloltyler1.com discout code: alpha\n",
            18, 18, SPEED_MULTIPLIER, value: Item.buyPrice(silver: 50), rarity: ItemRarityID.LightRed)
        {
        }
    }
}