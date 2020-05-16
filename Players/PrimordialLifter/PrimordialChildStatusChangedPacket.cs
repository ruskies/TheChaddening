using WebmilioCommons.Networking.Packets;

namespace TheChaddening.Players
{
    public sealed class PrimordialChildStatusChangedPacket : ModPlayerNetworkPacket<TheChaddeningPlayer>
    {
        public bool IsPrimordialChild
        {
            get => ModPlayer.IsPrimordialChild;
            set => ModPlayer.IsPrimordialChild = value;
        }

        public int PrimordialGeneration
        {
            get => ModPlayer.PrimordialGeneration;
            set => ModPlayer.PrimordialGeneration = value;
        }
    }
}