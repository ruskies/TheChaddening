using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using TheChaddening.Buffs.Proteins.ProteinShakes;
using TheChaddening.Items.Consumables.Proteins.ProteinPowders;

namespace TheChaddening.Items.Consumables.Proteins.ProteinShakes
{
    public sealed class HomemadeProteinShakeLesser : HomemadeProteinShake<HomemadeProteinShakeLesserBuff>
    {
        public const float GAINS_MULTIPLIER = 1f;


        public HomemadeProteinShakeLesser() : base("Cheap Homemade Protein Shaker", "A protein shake made by hand using cheap store-bought ingredients\n", GAINS_MULTIPLIER, Item.sellPrice(silver: 25 + 1))
        {
        }


        public override void AddRecipes()
        {
            ModRecipe recipe = new ModRecipe(mod);

            recipe.AddIngredient(ModContent.ItemType<BlenderBottle>());
            recipe.AddIngredient(ModContent.ItemType<StoreBoughtProteinPowder>());

            recipe.AddTile(TileID.Kegs);

            recipe.SetResult(this);
            recipe.AddRecipe();
        }
    }
}