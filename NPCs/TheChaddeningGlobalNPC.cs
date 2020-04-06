using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using TheChaddening.Items;
using TheChaddening.Items.Consumables.Proteins.ProteinShakes;
using TheChaddening.Items.Dumbbells;
using WebmilioCommons.Extensions;
using WebmilioCommons.Globals;

namespace TheChaddening.NPCs
{
    public sealed class TheChaddeningGlobalNPC : BetterGlobalNPC
    {
        public override void NPCLoot(NPC npc)
        {
            if (!Main.expertMode)
            {
                if (npc.type == NPCID.KingSlime && Main.rand.NextBool(5))
                    Item.NewItem(npc.getRect(), ModContent.ItemType<SlimeyDumbbell>());
                else if (npc.type == NPCID.BrainofCthulhu && Main.rand.NextBool(5))
                    Item.NewItem(npc.getRect(), ModContent.ItemType<LeechingLift>());
                else if (npc.type == NPCID.MoonLordCore && Main.rand.NextBool(10))
                    Item.NewItem(npc.getRect(), ModContent.ItemType<Barbell200Kg>());
                else if (npc.type == NPCID.EaterofWorldsHead || npc.type == NPCID.EaterofWorldsBody || npc.type == NPCID.EaterofWorldsTail)
                {
                    bool anyLeft = false;

                    foreach (NPC currentNPC in Main.npc)
                        if (currentNPC.type == NPCID.EaterofWorldsHead || currentNPC.type == NPCID.EaterofWorldsBody || currentNPC.type == NPCID.EaterofWorldsTail)
                        {
                            anyLeft = true;
                            break;
                        }


                    if (anyLeft && Main.rand.NextBool(5))
                        Item.NewItem(npc.getRect(), ModContent.ItemType<RottenDumbbell>());
                }
            }
        }


        public override void SetupArmsDealerShop(Chest shop, ref int nextSlot)
        {
            shop.AddShop<StoreBoughtBlueberryProteinShake>(ref nextSlot);
            shop.AddShop<StoreBoughtPumpkinPieProteinShake>(ref nextSlot);
        }

        public override void SetupMerchantShop(Chest shop, ref int nextSlot)
        {
            shop.AddShop<BlenderBottle>(ref nextSlot);
        }

        public override void SetupTravelShop(int[] shop, ref int nextSlot)
        {
            base.SetupTravelShop(shop, ref nextSlot);
        }
    }
}