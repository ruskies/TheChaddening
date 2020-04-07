using Terraria;
using Terraria.ID;

namespace TheChaddening.Items.Dumbbells
{
    public class JungoBungoLifto : Dumbbell
    {
        public JungoBungoLifto() : base("Jungo Bungo Lifto", 
            "Most would use these bungos as a musical instrument, and so do you:\n" +
            "the sound of your muscles getting stronger is music to your ears.",
            36, 32, 32500, 32.5f, value: Item.sellPrice(gold: 5), rarity: ItemRarityID.LightPurple)
        {
        }
    }
}