using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Terraria;
using Terraria.GameContent.UI.Elements;
using Terraria.UI;
using TheChaddening.Players;

namespace TheChaddening.UserInterfaces.Strength
{
    public sealed class StrengthBarElement : UIElement
    {
        private ulong _displayedStrength;
        private readonly UIText _label;
        
        public StrengthBarElement()
        {
            _label = new UIText(_displayedStrength.ToString());
            _label.Width.Set(StrengthBar.muscleTexture.Width + 300, 0f);
            _label.Height.Set(StrengthBar.muscleTexture.Height, 0f);

            _label.Left.Set(StrengthBar.muscleTexture.Width + 20, 0);
            _label.Top.Set(5, 0);

            Append(_label);
        }

        public override void Update(GameTime gameTime)
        {
            TheChaddeningPlayer player = Main.LocalPlayer.GetModPlayer<TheChaddeningPlayer>();

            ulong strengthDifference = player.Strength - _displayedStrength;
            ulong tenMultiplier = strengthDifference / 100;

            if (tenMultiplier == 0 && strengthDifference > 0)
                _displayedStrength++;
            else
                _displayedStrength += 10 * tenMultiplier;

            _label.SetText(_displayedStrength.ToString());

            base.Update(gameTime);
        }

        public Vector2 Position { get; private set; }
        public Texture2D Texture => StrengthBar.muscleTexture;
    }
}