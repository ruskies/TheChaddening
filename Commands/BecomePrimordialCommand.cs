using Terraria;
using Terraria.ModLoader;
using TheChaddening.Identities;
using TheChaddening.Players;
using WebmilioCommons.Commands;
using WebmilioCommons.Identity;

namespace TheChaddening.Commands
{
    public sealed class BecomePrimordialCommand : StandardCommand
    {
        public BecomePrimordialCommand() : base("becomePrimordial", CommandType.Chat)
        {
        }


        protected override void ActionLocal(CommandCaller caller, Player player, string input, string[] args)
        {
            if (!IdentityManager.Is<WebmilioIdentity>())
                return;


            TheChaddeningPlayer.Get(player).IsPrimordialLifter = true;
        }
    }
}