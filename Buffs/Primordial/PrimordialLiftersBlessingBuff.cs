using Terraria;
using TheChaddening.Players;

namespace TheChaddening.Buffs.Primordial
{
    public sealed class PrimordialLiftersBlessingBuff : ChadBuff
    {
        public PrimordialLiftersBlessingBuff() : base("Primordial Lifter's Blessing", 
            "You are one of the many children of the primordial lifter and can share this blessing with others.\n")
        {
        }


        public override void ModifyBuffTip(ref string tip, ref int rare)
        {
            TheChaddeningPlayer tcp = TheChaddeningPlayer.Get(Main.LocalPlayer);

            tip += $"Your curling gains multiplier is multiplied by {tcp.GetPrimordialBlessingMultiplier()}\nYou are part of generation #{tcp.PrimordialGeneration}";
        }


        public override void Update(Player player, ref int buffIndex)
        {
            TheChaddeningPlayer tcp = TheChaddeningPlayer.Get(player);

            tcp.OverallCurlingGainsMultiplier *= 2;
        }
    }
}