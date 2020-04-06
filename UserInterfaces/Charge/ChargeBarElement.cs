using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Terraria;
using Terraria.GameContent.UI.Elements;
using Terraria.UI;
using TheChaddening.Abilities;
using TheChaddening.Items;
using TheChaddening.Players;
using TheChaddening.UserInterfaces.Strength;

namespace TheChaddening.UserInterfaces.Charge
{
    public sealed class ChargeBarElement : UIElement
    {
        internal readonly UIText chargedStrengthLabel, chargedPercentageLabel, punchingModeLabel, abilityLabel;

        public ChargeBarElement()
        {
            chargedStrengthLabel = new UIText("");
            chargedStrengthLabel.Width.Set(300, 0f);
            chargedStrengthLabel.Height.Set(50, 0f);

            chargedStrengthLabel.Left.Set(125, 0);
            chargedStrengthLabel.Top.Set(0, 0);

            Append(chargedStrengthLabel);

            chargedPercentageLabel = new UIText("");
            chargedPercentageLabel.Width.Set(300, 0f);
            chargedPercentageLabel.Height.Set(15 + chargedStrengthLabel.GetDimensions().Height + 10, 0f);

            chargedPercentageLabel.Left.Set(125, 0);
            chargedPercentageLabel.Top.Set(15 + chargedStrengthLabel.Top.Pixels + 10, 0);

            Append(chargedPercentageLabel);

            punchingModeLabel = new UIText("");
            punchingModeLabel.Width.Set(300, 0f);
            punchingModeLabel.Height.Set(chargedStrengthLabel.GetDimensions().Height, 0f);

            punchingModeLabel.Left.Set(125, 0);
            punchingModeLabel.Top.Set(15 + chargedPercentageLabel.Height.Pixels + 10, 0);

            Append(punchingModeLabel);

            abilityLabel = new UIText("");
            abilityLabel.Width.Set(300, 0f);
            abilityLabel.Height.Set(chargedStrengthLabel.GetDimensions().Height, 0f);

            abilityLabel.Left.Set(125, 0);
            abilityLabel.Top.Set(15 + punchingModeLabel.Top.Pixels + 10, 0);

            Append(abilityLabel);
        }

        public override void Update(GameTime gameTime)
        {
            TheChaddeningPlayer tcp = Main.LocalPlayer.GetModPlayer<TheChaddeningPlayer>();

            chargedStrengthLabel.SetText(tcp.ChargedStrength + " / " + tcp.Strength);
            chargedPercentageLabel.SetText(tcp.ChargedStrength * 100 / tcp.Strength + "%, charging at " + (int)(tcp.ManualChargeRate * 100) + "%");
            punchingModeLabel.SetText(tcp.PunchingMode.ToString());

            if (tcp.ChargedStrength == 0)
                abilityLabel.SetText("");
            else if (tcp.player.HeldItem?.modItem is Fist fist)
            {
                Ability abilityToShow = fist.LockedInAbility ?? fist.CurrentAbility ?? null;

                if (abilityToShow != null)
                {
                    string nameToDisplay = abilityToShow.DisplayName;

                    if (fist.LockedInAbility != null)
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