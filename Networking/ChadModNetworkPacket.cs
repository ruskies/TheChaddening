using System;
using Terraria;
using TheChaddening.Players;
using WebmilioCommons.Networking.Packets;

namespace TheChaddening.Networking
{
    public abstract class ChadModNetworkPacket : ModPlayerNetworkPacket<TheChaddeningPlayer>
    {
        public override Func<Player, TheChaddeningPlayer> ModPlayerGetter { get; } = TheChaddeningPlayer.Get;
    }
}