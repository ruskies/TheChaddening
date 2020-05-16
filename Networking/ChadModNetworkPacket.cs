using System;
using Terraria;
using TheChaddening.Players;
using WebmilioCommons.Networking.Packets;

namespace TheChaddening.Networking
{
    public abstract class ChadModNetworkPacket : ModPlayerNetworkPacket<TheChaddeningPlayer>
    {
        protected ChadModNetworkPacket()
        {
        }

        protected ChadModNetworkPacket(TheChaddeningPlayer chad) : base(chad)
        {
        }
        

        public override Func<Player, TheChaddeningPlayer> ModPlayerGetter { get; } = TheChaddeningPlayer.Get;
    }
}