using System.ComponentModel;
using Terraria.ModLoader.Config;
using TheChaddening.Commons;

namespace TheChaddening
{
    [Label("Global Configuration")]
    public class TheChaddeningGlobalConfiguration : ModConfig
    {
        [Label("Chad Challenge"), Tooltip("This allows to be part of the master race: the True Chad.\nDisabling this will permanently stop you from becoming a true chad on any character you play\nwhile this option is disabled."), DefaultValue(true)]
        public bool ChadChallenge { get; set; }

        
        [Category("False Chad")]
        [Label("Melee Scaling"), Tooltip("The strength to damage ratio to add to melee weapons as flat damage.\nOnly active when Chad Challenge is disabled."), DefaultValue(TheChaddeningMath.STRENGTH_DAMAGE_RATIO)]
        public float MeleeScaling { get; set; }

        public override ConfigScope Mode => ConfigScope.ServerSide;
    }
}