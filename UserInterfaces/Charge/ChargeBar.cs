using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Terraria;
using Terraria.GameContent.UI.Elements;
using Terraria.UI;
using WebmilioCommons.Extensions;

namespace TheChaddening.UserInterfaces.Charge
{
    public class ChargeBar : UIState, IHasVisibility
    {
        public const float 
            HALIGN = 0.8f,
            VALIGN = 0.9f;

        public const int 
            HEIGHT = 150,
            WIDTH = 300;

        private static readonly string _barTexturePath = typeof(ChargeBar).GetPath();

        private UIPanel _mainPanel;

        private bool _dragging = false;
        private Vector2 _mouseOffset;

        public override void OnInitialize()
        {
            _mainPanel = new UIPanel();

            _mainPanel.VAlign = HALIGN;
            _mainPanel.HAlign = VALIGN;
            _mainPanel.Height.Set(HEIGHT, 0);
            _mainPanel.Width.Set(WIDTH, 0);

            _mainPanel.BackgroundColor = new Color(40, 40, 40, 100);

            Append(_mainPanel);


            ChargeBarElement = new ChargeBarElement();

            ChargeBarElement.OnMouseDown += DragStart;
            ChargeBarElement.OnMouseUp += DragEnd;

            _mainPanel.Append(ChargeBarElement);
        }


        protected override void DrawSelf(SpriteBatch spriteBatch)
        {
            Vector2 mousePosition = new Vector2(Main.mouseX, Main.mouseY);

            if (ChargeBarElement.ContainsPoint(mousePosition))
                Main.LocalPlayer.mouseInterface = true;

            if (_dragging)
            {
                ChargeBarElement.Left.Set(mousePosition.X - _mouseOffset.X, 0);
                ChargeBarElement.Top.Set(mousePosition.Y - _mouseOffset.Y, 0);

                Recalculate();
            }
        }

        public void DragStart(UIMouseEvent evt, UIElement listeningElement)
        {
            _mouseOffset = new Vector2(evt.MousePosition.X - ChargeBarElement.Left.Pixels, evt.MousePosition.Y - ChargeBarElement.Top.Pixels);
            _dragging = true;
        }

        public void DragEnd(UIMouseEvent evt, UIElement listeningElement)
        {
            Vector2 end = evt.MousePosition;
            _dragging = false;

            ChargeBarElement.Left.Set(end.X - _mouseOffset.X, 0);
            ChargeBarElement.Top.Set(end.Y - _mouseOffset.Y, 0);

            Recalculate();
        }


        public ChargeBarElement ChargeBarElement { get; private set; }

        public bool Visible { get; internal set; }
    }
}