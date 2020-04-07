using Terraria;

namespace TheChaddening.Items.Accessories
{
    public sealed class WorkoutStraps : ChadItem
    {
        public WorkoutStraps() : base("Workout Straps", "", 20, 26, defense: 1)
        {
        }


        public override void SetDefaults()
        {
            base.SetDefaults();

            item.accessory = true;
        }


        public override void UpdateEquip(Player player)
        {
            base.UpdateEquip(player);


        }
    }
}
