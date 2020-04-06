using Terraria;
using TheChaddening.Players;

namespace TheChaddening.Buffs.Proteins.ProteinPowders
{
    public abstract class ProteinPowderBuff : ProteinBuff
    {
        protected ProteinPowderBuff(string displayName, float curlingGainsMultiplier) : base(displayName, curlingGainsMultiplier)
        {
            CurlingGainsMultiplier = curlingGainsMultiplier;
        }


        public override void Update(Player player, ref int buffIndex) => TheChaddeningPlayer.Get(player).CurlingGainsMultiplier += CurlingGainsMultiplier;


        public float CurlingGainsMultiplier { get; }
    }
}