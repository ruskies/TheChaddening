using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using TheChaddening.Items.Dumbbells;
using TheChaddening.Players;

namespace TheChaddening.Items
{
    public sealed class ChadGlobalItem : GlobalItem
    {
        public override void ModifyWeaponDamage(Item item, Player player, ref float add, ref float mult, ref float flat)
        {
            TheChaddeningPlayer tcp = TheChaddeningPlayer.Get(player);

            if (tcp.TrueChad)
            {
                if (!(item.modItem is Fist))
                {
                    mult = 0;
                    flat = 0;
                    add = 0;
                }
            }
            else if (item.melee)
                flat = ModContent.GetInstance<ChadGlobalConfiguration>().MeleeScaling * tcp.Strength;
        }

        public override void UpdateInventory(Item item, Player player)
        {
            if (item?.modItem is ChadItem || !TheChaddeningPlayer.Get(player).TrueChad)
                return;

            item.pick = 0;
            item.axe = 0;
            item.hammer = 0;
        }


        public override void OpenVanillaBag(string context, Player player, int type)
        {
            if (context == "bossBag")
            {
                if (type == ItemID.KingSlimeBossBag && Main.rand.NextBool(5))
                    Item.NewItem(player.getRect(), ModContent.ItemType<SlimeyDumbbell>());
                if (type == ItemID.EyeOfCthulhuBossBag && Main.rand.NextBool(5))
                    Item.NewItem(player.getRect(), ModContent.ItemType<EyeDumbbell>());
                else if (type == ItemID.BrainOfCthulhuBossBag && Main.rand.NextBool(5))
                    Item.NewItem(player.getRect(), ModContent.ItemType<LeechingLift>());
                else if (type == ItemID.EaterOfWorldsBossBag && Main.rand.NextBool(5))
                    Item.NewItem(player.getRect(), ModContent.ItemType<RottenDumbbell>());
                else if (type == ItemID.QueenBeeBossBag && Main.rand.NextBool(5))
                    Item.NewItem(player.getRect(), ModContent.ItemType<HoneyHandle>());
                else if (type == ItemID.SkeletronBossBag && Main.rand.NextBool(5))
                    Item.NewItem(player.getRect(), ModContent.ItemType<BoneShatteringDumbbell>());
                else if (type == ItemID.WallOfFleshBossBag && Main.rand.NextBool(5))
                    Item.NewItem(player.getRect(), ModContent.ItemType<WeightofFlesh>());

                else if (Main.rand.NextBool(3) && (type == ItemID.TwinsBossBag || type == ItemID.DestroyerBossBag || type == ItemID.SkeletronPrimeBossBag))
                    Item.NewItem(player.getRect(), ModContent.ItemType<CaravanCarry>());
                else if (type == ItemID.PlanteraBossBag && Main.rand.NextBool(5))
                    Item.NewItem(player.getRect(), ModContent.ItemType<JungoBungoLifto>());
                else if (type == ItemID.GolemBossBag)
                    Item.NewItem(player.getRect(), ModContent.ItemType<PrimordialRock>());
                else if (type == ItemID.MoonLordBossBag && Main.rand.NextBool(10))
                    Item.NewItem(player.getRect(), ModContent.ItemType<Barbell200Kg>());
            }
        }
    }
}
