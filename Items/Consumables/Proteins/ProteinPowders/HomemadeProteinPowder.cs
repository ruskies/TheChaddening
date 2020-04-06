using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using TheChaddening.Buffs.Proteins.ProteinPowders;

namespace TheChaddening.Items.Consumables.Proteins.ProteinPowders
{
    public sealed class HomemadeProteinPowder : ProteinPowder<HomemadeProteinPowderBuff>
    {
        public const float GAINS_MULTIPLIER = 5f;


        public HomemadeProteinPowder() : base("Homemade Protein Powder", 22, 14, GAINS_MULTIPLIER, value: Item.sellPrice(copper: 4), rarity: ItemRarityID.Orange)
        {
        }


        public override void AddRecipes()
        {
            ModRecipe recipe = new ModRecipe(mod);

            recipe.AddIngredient(ItemID.RottenChunk, 2);
            recipe.AddTile(TileID.Anvils);

            recipe.SetResult(this);
            recipe.AddRecipe();

            recipe = new ModRecipe(mod);

            recipe.AddIngredient(ItemID.Vertebrae, 2);
            recipe.AddTile(TileID.Anvils);

            recipe.SetResult(this);
            recipe.AddRecipe();
        }
    }
}