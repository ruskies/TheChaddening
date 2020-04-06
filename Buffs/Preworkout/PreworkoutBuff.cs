using Terraria;

namespace TheChaddening.Buffs.Preworkout
{
    public abstract class PreworkoutBuff : TheChaddeningBuff
    {
        protected PreworkoutBuff(string displayName, float curlingSpeedMultiplier) : base(displayName, $"You curl {curlingSpeedMultiplier * 100}% faster", save: true, persistent: false, canBeCleared: false)
        {
            CurlingSpeedMultiplier = curlingSpeedMultiplier;
        }


        public override void SetDefaults()
        {
            base.SetDefaults();

            Main.debuff[Type] = true;
        }


        public float CurlingSpeedMultiplier { get; }
    }
}