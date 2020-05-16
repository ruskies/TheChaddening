using Terraria;
using Terraria.ModLoader;
using TheChaddening.Players;
using WebmilioCommons.Tinq;

namespace TheChaddening.Commands
{
    public class ShowPrimordialsCommand : ChadDebugCommand
    {
        public ShowPrimordialsCommand() : base("primordials", CommandType.Chat)
        {
        }


        protected override void ActionLocal(CommandCaller caller, Player player, string input, string[] args)
        {
            Main.player.DoActive(plr =>
            {
                var chad = TheChaddeningPlayer.Get(plr);

                Main.NewText($"{plr.name} (Lift., Child, Gen., True Chad):");
                Main.NewText($"{chad.IsPrimordial()} ({chad.IsPrimordialLifter}, {chad.IsPrimordialChild}, {chad.PrimordialGeneration}, {chad.TrueChad})");
            });
        }
    }
}