using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Terraria;
using Terraria.GameContent.UI.Elements;
using Terraria.UI;
using TheChaddening.Abilities;
using TheChaddening.Items;
using TheChaddening.Items.Dumbbells;
using TheChaddening.Players;
using TheChaddening.UserInterfaces.Strength;

namespace TheChaddening.UserInterfaces.Charge
{
    public sealed class ChargeBarElement : UIElement
    {
        public const int 
            STANDARD_LEFT = 125, 
            STANDARD_HEIGHT_PADDING =25;

        internal readonly UIText chargedStrengthLabel, chargedPercentageLabel, extraInfoLabel, punchingModeLabel, abilityLabel;


        public ChargeBarElement()
        {
            // First Block

            chargedStrengthLabel = new UIText("");
            chargedStrengthLabel.Width.Set(ChargeBar.WIDTH, 0f);
            chargedStrengthLabel.Height.Set(50, 0f);

            chargedStrengthLabel.Left.Set(STANDARD_LEFT, 0);
            chargedStrengthLabel.Top.Set(0, 0);

            Append(chargedStrengthLabel);

            float chargeStrengthLabelHeight = chargedStrengthLabel.GetDimensions().Height;


            chargedPercentageLabel = new UIText("");
            chargedPercentageLabel.Width.Set(ChargeBar.WIDTH, 0f);
            chargedPercentageLabel.Height.Set(STANDARD_HEIGHT_PADDING + chargeStrengthLabelHeight, 0f);

            chargedPercentageLabel.Left.Set(STANDARD_LEFT, 0);
            chargedPercentageLabel.Top.Set(STANDARD_HEIGHT_PADDING + chargedStrengthLabel.Top.Pixels, 0);

            Append(chargedPercentageLabel);


            extraInfoLabel = new UIText("");
            extraInfoLabel.Width.Set(ChargeBar.WIDTH, 0f);
            extraInfoLabel.Height.Set(STANDARD_HEIGHT_PADDING + chargeStrengthLabelHeight, 0);

            extraInfoLabel.Left.Set(STANDARD_LEFT, 0);
            extraInfoLabel.Top.Set(STANDARD_HEIGHT_PADDING + chargedPercentageLabel.Top.Pixels, 0);

            Append(extraInfoLabel);


            // Second Block

            punchingModeLabel = new UIText("");
            punchingModeLabel.Width.Set(ChargeBar.WIDTH, 0f);
            punchingModeLabel.Height.Set(chargeStrengthLabelHeight, 0f);

            punchingModeLabel.Left.Set(STANDARD_LEFT, 0);
            punchingModeLabel.Top.Set(STANDARD_HEIGHT_PADDING + extraInfoLabel.Top.Pixels + 5, 0);

            Append(punchingModeLabel);


            abilityLabel = new UIText("");
            abilityLabel.Width.Set(ChargeBar.WIDTH, 0f);
            abilityLabel.Height.Set(chargeStrengthLabelHeight, 0f);

            abilityLabel.Left.Set(STANDARD_LEFT, 0);
            abilityLabel.Top.Set(STANDARD_HEIGHT_PADDING + punchingModeLabel.Top.Pixels, 0);

            Append(abilityLabel);
        }

        public override void Update(GameTime gameTime)
        {
            TheChaddeningPlayer chad = Main.LocalPlayer.GetModPlayer<TheChaddeningPlayer>();

            
            chargedStrengthLabel.SetText(chad.ChargedStrength.ToString());
            chargedPercentageLabel.SetText(chad.ChargedStrength * 100 / chad.Strength + "%, charging at " + (int)(chad.ManualChargeRate * 100) + "%");

            if (chad.player?.HeldItem?.modItem is Dumbbell db)
            {
                float gains = chad.GetGainsFromCurl(db.GainsPerCurl);
                ulong uGains = (ulong) gains;

                extraInfoLabel.SetText($"Gains: {uGains} -> ({db.GainsPerCurl} * {chad.TotalCurlingGainsMultiplier}) * {chad.GlobalCurlingGainsMultiplier}{(uGains < gains ? ", rounded down" : "")})");
            }


            punchingModeLabel.SetText(chad.PunchingMode.ToString());


            if (chad.ChargedStrength == 0)
                abilityLabel.SetText("");
            else if (chad.player.HeldItem?.modItem is Fist fist)
            {
                Ability abilityToShow = fist.LockedInAbility ?? fist.CurrentAbility ?? null;

                if (abilityToShow != null)
                {
                    string nameToDisplay = abilityToShow.DisplayName;

                    if (fist.LockedInAbility == abilityToShow)
                        nameToDisplay += " (Locked)";

                    abilityLabel.SetText(nameToDisplay);
                }
                else
                    abilityLabel.SetText("");
            }


            base.Update(gameTime);
        }

        public Texture2D Texture => StrengthBar.muscleTexture;
    }
}