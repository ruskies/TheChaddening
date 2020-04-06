using Terraria;

namespace TheChaddening.Buffs.Proteins
{
    public abstract class ProteinBuff : TheChaddeningBuff
    {
        protected ProteinBuff(string displayName, float curlingGainsMultiplier) : base(displayName, $"Curling gives you {curlingGainsMultiplier * 100}% more strength", save: true, persistent: false, canBeCleared: false)
        {
            CurlingGainsMultiplier = curlingGainsMultiplier;
        }


        public override void SetDefaults()
        {
            base.SetDefaults();

            Main.debuff[Type] = true;
        }


        public float CurlingGainsMultiplier { get; }
    }
}