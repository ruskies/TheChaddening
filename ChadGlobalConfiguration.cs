﻿using System.ComponentModel;
using Terraria.ModLoader.Config;
using TheChaddening.Commons;

namespace TheChaddening
{
    [Label("Global Configuration")]
    public class ChadGlobalConfiguration : ModConfig
    {
        [Label("Chad Challenge"), Tooltip("This allows to be part of the master race: the True Chad.\nDisabling this will permanently stop you from becoming a true chad on any character you play\nwhile this option is disabled."), DefaultValue(true)]
        public bool ChadChallenge { get; set; }


        [Label("Primordial Genes"), Tooltip("Turning this off will disable any benefits you get from being part of the primordials."), DefaultValue(true), ReloadRequired]
        public bool PrimordialGenes { get; set; }

        
        [Category("False Chad")]
        [Label("Melee Scaling"), Tooltip("The strength to damage ratio to add to melee weapons as flat damage.\nOnly active when Chad Challenge is disabled."), DefaultValue(ChadMath.STRENGTH_DAMAGE_RATIO)]
        public float MeleeScaling { get; set; }

        public override ConfigScope Mode => ConfigScope.ServerSide;
    }
}