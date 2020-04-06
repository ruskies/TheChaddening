using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Terraria;
using Terraria.GameContent.UI.Elements;
using Terraria.UI;
using WebmilioCommons.Extensions;

namespace TheChaddening.UserInterfaces.Strength
{
    internal class StrengthBar : UIState, IHasVisibility
    {
        private static readonly string _barTexturePath = typeof(StrengthBar).GetPath();

        internal static Texture2D muscleTexture = TheChaddeningMod.Instance.GetTexture(_barTexturePath);

        private UIPanel _mainPanel;

        private bool _dragging = false;
        private Vector2 _mouseOffset;

        public override void OnInitialize()
        {
            _mainPanel = new UIPanel();

            _mainPanel.VAlign = 0.85f;
            _mainPanel.HAlign = 0.9f;
            _mainPanel.Height.Set(muscleTexture.Height * 2, 0);
            _mainPanel.Width.Set(300, 0);
            _mainPanel.SetPadding(15f);
            _mainPanel.BackgroundColor = new Color(40, 40, 40, 100);

            Append(_mainPanel);

            UIImage muscleImage = new UIImage(muscleTexture);
            _mainPanel.Append(muscleImage);

            StrengthBarElement = new StrengthBarElement();

            StrengthBarElement.OnMouseDown += DragStart;
            StrengthBarElement.OnMouseUp += DragEnd;

            _mainPanel.Append(StrengthBarElement);
        }

        
        protected override void DrawSelf(SpriteBatch spriteBatch)
        {
            Vector2 mousePosition = new Vector2(Main.mouseX, Main.mouseY);

            if (StrengthBarElement.ContainsPoint(mousePosition))
                Main.LocalPlayer.mouseInterface = true;

            if (_dragging)
            {
                StrengthBarElement.Left.Set(mousePosition.X - _mouseOffset.X, 0);
                StrengthBarElement.Top.Set(mousePosition.Y - _mouseOffset.Y, 0);

                Recalculate();
            }
        }

        public void DragStart(UIMouseEvent evt, UIElement listeningElement)
        {
            _mouseOffset = new Vector2(evt.MousePosition.X - StrengthBarElement.Left.Pixels, evt.MousePosition.Y - StrengthBarElement.Top.Pixels);
            _dragging = true;
        }

        public void DragEnd(UIMouseEvent evt, UIElement listeningElement)
        {
            Vector2 end = evt.MousePosition;
            _dragging = false;

            StrengthBarElement.Left.Set(end.X - _mouseOffset.X, 0);
            StrengthBarElement.Top.Set(end.Y - _mouseOffset.Y, 0);

            Recalculate();
        }


        public StrengthBarElement StrengthBarElement { get; private set; }

        public bool Visible { get; internal set; }
    }
}