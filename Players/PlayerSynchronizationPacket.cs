using System;
using System.IO;
using Terraria;
using Terraria.ID;
using WebmilioCommons.Networking.Packets;

namespace TheChaddening.Players
{
    public class PlayerSynchronizationPacket : ModPlayerNetworkPacket<TheChaddeningPlayer>
    {
        protected override bool PostReceive(BinaryReader reader, int fromWho)
        {
            if (!IsResponse && Main.netMode == NetmodeID.MultiplayerClient)
            {
                IsResponse = true;
                Send(Main.myPlayer, Player.whoAmI);
            }

            return true;
        }


        public bool IsResponse { get; set; }

        public bool PrimordialLifter
        {
            get => ModPlayer.IsPrimordialLifter;
            set => ModPlayer.IsPrimordialLifter = value;
        }

        public bool PrimordialChild
        {
            get => ModPlayer.IsPrimordialChild;
            set => ModPlayer.IsPrimordialChild = value;
        }

        public int PrimordialGeneration
        {
            get => ModPlayer.PrimordialGeneration;
            set => ModPlayer.PrimordialGeneration = value;
        }

        public bool TrueChad
        {
            get => ModPlayer.TrueChad;
            set => ModPlayer.TrueChad = value;
        }
    }
}