using Terraria;
using TheChaddening.Players;

namespace TheChaddening.Buffs.Proteins.ProteinShakes
{
    public abstract class ProteinShakeBuff : ProteinBuff
    {
        protected ProteinShakeBuff(string displayName, float curlingGainsMultiplier) : base(displayName, curlingGainsMultiplier)
        {
        }


        public override void Update(Player player, ref int buffIndex) => TheChaddeningPlayer.Get(player).CurlingGainsMultiplier += CurlingGainsMultiplier;
    }
}