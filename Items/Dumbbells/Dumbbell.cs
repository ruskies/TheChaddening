using System.Collections.Generic;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using TheChaddening.Players;

namespace TheChaddening.Items.Dumbbells
{
    public abstract class Dumbbell : ChadItem
    {
        public const string
            TERRARIA_DESCRIPTION_TOOLTIP = "Tooltip0",
            DUMBBELL_STRENGTH_REQUIREMENT = "DumbbellStrengthRequirements",
            DUMBBELL_CURL_GAIN = "DumbbellCurlGain";

        protected Dumbbell(string displayName, string tooltip, int width, int height, ulong requiredStrength, float gainsPerCurl, int value = 0, int defense = 0, int rarity = ItemRarityID.White) : base(displayName, tooltip, width, height, value, defense, rarity)
        {
            RequiredStrength = requiredStrength;
            GainsPerCurl = gainsPerCurl;
        }


        public override void SetDefaults()
        {
            base.SetDefaults();

            item.autoReuse = true;
            item.useStyle = ItemUseStyleID.EatingUsing;
            item.useAnimation = 60;
            item.useTime = 60;
        }

        public override void ModifyTooltips(List<TooltipLine> tooltips)
        {
            base.ModifyTooltips(tooltips);

            TheChaddeningPlayer tcp = TheChaddeningPlayer.Get(Main.LocalPlayer);

            if (tcp.Strength < RequiredStrength)
                tooltips.Add(new TooltipLine(mod, DUMBBELL_STRENGTH_REQUIREMENT, $"You need at least {RequiredStrength} to use this dumbbell!")
                {
                    overrideColor = Color.Red
                });

            float gains = tcp.GetGainsFromCurl(GainsPerCurl);
            tooltips.Add(new TooltipLine(mod, DUMBBELL_CURL_GAIN, $"You gain {gains} (rounded to {(ulong) gains}) strength each time you curl."));
        }


        public override bool UseItem(Player player)
        {
            TheChaddeningPlayer.Get(player).Curl(GainsPerCurl);

            return true;
        }

        public override bool CanUseItem(Player player)
        {
            return base.CanUseItem(player);
        }


        public ulong RequiredStrength { get; }
        public float GainsPerCurl { get; }
    }
}