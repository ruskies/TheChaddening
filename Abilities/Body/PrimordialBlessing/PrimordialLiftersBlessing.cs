using System;
using System.IO;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.DataStructures;
using Terraria.ID;
using TheChaddening.Items;
using TheChaddening.Players;

namespace TheChaddening.Abilities.Body.PrimordialBlessing
{
    public class PrimordialLiftersBlessing : ChadItem
    {
        public PrimordialLiftersBlessing() : base("Primordial Lifter's Blessing", "", 22, 28, value: ItemRarityID.Expert)
        {
        }


        public override void SetDefaults()
        {
            base.SetDefaults();

            Item reference = new Item();
            reference.SetDefaults(ItemID.SoulofFlight);

            item.width = reference.width;
            item.height = reference.height;

            item.maxStack = 1;
            item.consumable = true;
        }

        public override void SetStaticDefaults()
        {
            base.SetStaticDefaults();

            ItemID.Sets.ItemNoGravity[item.type] = true;
            ItemID.Sets.AnimatesAsSoul[item.type] = true;
            ItemID.Sets.ItemIconPulse[item.type] = true;

            Main.RegisterItemAnimation(item.type, new DrawAnimationVertical(5, 4));
        }


        public override void NetSend(BinaryWriter writer)
        {
            writer.Write(PrimordialGeneration);
        }

        public override void NetRecieve(BinaryReader reader)
        {
            PrimordialGeneration = reader.ReadInt32();
        }


        public override void GrabRange(Player player, ref int grabRange) => grabRange = 2;

        public override bool ItemSpace(Player player) => true;

        public override bool OnPickup(Player player)
        {
            TheChaddeningPlayer tcp = TheChaddeningPlayer.Get(player);

            if (!tcp.TrueChad || tcp.IsPrimordial())
                return false;

            tcp.IsPrimordialChild = true;
            tcp.PrimordialGeneration = PrimordialGeneration;

            return false;
        }


        public override void PostUpdate() => Lighting.AddLight(item.Center, Color.WhiteSmoke.ToVector3() * 0.55f * Main.essScale);


        public int PrimordialGeneration { get; set; }
    }
}