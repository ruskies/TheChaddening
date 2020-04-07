using Terraria;
using TheChaddening.Players;

namespace TheChaddening.Buffs.Primordial
{
    public sealed class PrimordialLifterBuff : ChadBuff
    {
        public PrimordialLifterBuff() : base("Primordial Lifter", "You are the first one to ever lift.\n", true, canBeCleared: false)
        {
        }


        public override void Update(Player player, ref int buffIndex)
        {
            TheChaddeningPlayer tcp = TheChaddeningPlayer.Get(player);

            tcp.OverallCurlingGainsMultiplier *= 4;
        }


        public override void ModifyBuffTip(ref string tip, ref int rare)
        {
            TheChaddeningPlayer tcp = TheChaddeningPlayer.Get(Main.LocalPlayer);

            tip += $"Your curling gains multiplier is multiplied by {tcp.GetPrimordialBlessingMultiplier()}\nYou are part of generation #{tcp.PrimordialGeneration}";
        }
    }
}