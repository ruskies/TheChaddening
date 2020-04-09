using System;
using System.Collections.Generic;
using System.Text;
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


        private float _lastGains = 0;
        private string _lastTooltip = null;


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


            var chad = TheChaddeningPlayer.Get(Main.LocalPlayer);

            if (chad.Strength < RequiredStrength)
                tooltips.Add(new TooltipLine(mod, DUMBBELL_STRENGTH_REQUIREMENT, $"You need at least {RequiredStrength} to use this dumbbell!")
                {
                    overrideColor = Color.Red
                });


            var gains = chad.GetGainsFromCurl(GainsPerCurl);
            var uGains = (ulong)gains;

            var builder = new StringBuilder("You gain ").Append(uGains).Append(' ');


            bool
                gainsNotEqual = gains != GainsPerCurl,
                uGainsSmaller = uGains < gains;


            if (gainsNotEqual)
                builder.AppendFormat("({0} + {1}", GainsPerCurl, gains - GainsPerCurl);

            if (uGainsSmaller)
                builder.Append(", rounded down");

            if (gainsNotEqual || uGainsSmaller)
                builder.Append(") ");


            builder.Append("strength each time you curl.");


            _lastTooltip = builder.ToString();
            _lastGains = gains;


            tooltips.Add(new TooltipLine(mod, DUMBBELL_CURL_GAIN, _lastTooltip));
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