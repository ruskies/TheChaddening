using System;
using System.IO;
using Terraria;
using TheChaddening.Networking;
using WebmilioCommons.Networking;
using WebmilioCommons.Networking.Packets;

namespace TheChaddening.Players
{
    public sealed class PlayerSynchronizationPacket : ModPlayerNetworkPacket<TheChaddeningPlayer>
    {
        public PlayerSynchronizationPacket()
        {
        }

        public PlayerSynchronizationPacket(TheChaddeningPlayer chad) : base(chad)
        {
        }


        protected override bool PostReceive(BinaryReader reader, int fromWho)
        {
            string msg = $"{ModPlayer.player.name} just received player synchronization packet.\n" +
                         $"{PrimordialLifter} {PrimordialChild} {PrimordialGeneration} {TrueChad}";


            if (Main.dedServ)
                Console.WriteLine(msg);
            else
                System.Diagnostics.Debug.WriteLine(msg);


            return true;
        }


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


        public override NetworkPacketBehavior Behavior => NetworkPacketBehavior.SendToClient;
    }
}