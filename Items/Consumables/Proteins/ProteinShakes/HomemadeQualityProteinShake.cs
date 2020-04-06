using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using TheChaddening.Buffs.Proteins.ProteinShakes;
using TheChaddening.Items.Consumables.Proteins.ProteinPowders;

namespace TheChaddening.Items.Consumables.Proteins.ProteinShakes
{
    public sealed class HomemadeQualityProteinShake : HomemadeProteinShake<HomemadeProteinShakeBuff>
    {
        public const float GAINS_MULTIPLIER = 1.5f;


        public HomemadeQualityProteinShake() : base("Homemade Protein Shake" ,"A strong protein shake made by hand using quality ingredients\n", GAINS_MULTIPLIER, Item.sellPrice(silver: 25, copper: 4))
        {
        }


        public override void AddRecipes()
        {
            ModRecipe recipe = new ModRecipe(mod);

            recipe.AddIngredient(ModContent.ItemType<BlenderBottle>());
            recipe.AddIngredient(ModContent.ItemType<HomemadeProteinPowder>());

            recipe.AddTile(TileID.Kegs);

            recipe.SetResult(this);
            recipe.AddRecipe();
        }
    }
}