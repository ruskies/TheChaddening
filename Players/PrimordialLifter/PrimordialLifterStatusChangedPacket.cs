using WebmilioCommons.Networking.Packets;

namespace TheChaddening.Players
{
    public sealed class PrimordialLifterStatusChangedPacket : ModPlayerNetworkPacket<TheChaddeningPlayer>
    {
        public bool IsPrimordialLifter
        {
            get => ModPlayer.IsPrimordialLifter;
            set => ModPlayer.IsPrimordialLifter = value;
        }
    }
}