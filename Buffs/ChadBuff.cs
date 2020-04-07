using Terraria;
using Terraria.ModLoader;
using WebmilioCommons.Buffs;

namespace TheChaddening.Buffs
{
    public abstract class ChadBuff : StandardBuff
    {
        private readonly bool _longerExpertDebuff;


        protected ChadBuff(string displayName, string tooltip, bool hideTime = false, bool save = false, bool persistent = false, bool canBeCleared = true, bool longerExpertDebuff = false)
        : base(displayName, tooltip, hideTime, save, persistent, canBeCleared)
        {
            _longerExpertDebuff = longerExpertDebuff;
        }


        public override void SetDefaults()
        {
            base.SetDefaults();

            longerExpertDebuff = _longerExpertDebuff;
        }
    }
}
