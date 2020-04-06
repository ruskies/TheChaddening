using Terraria;
using Terraria.UI;

namespace TheChaddening.UserInterfaces
{
    public class GenericInterfaceLayer : GameInterfaceLayer
    {
        private readonly IHasVisibility _hasVisibility;
        private readonly UserInterface _userInterface;
        private readonly UIState _uiState;

        public GenericInterfaceLayer(string name, InterfaceScaleType interfaceScaleType, IHasVisibility hasVisibility, UserInterface userInterface, UIState uiState) : base(name, interfaceScaleType)
        {
            _hasVisibility = hasVisibility;
            _userInterface = userInterface;
            _uiState = uiState;
        }

        protected override bool DrawSelf()
        {
            if (_hasVisibility.Visible)
            {
                _userInterface.Update(Main._drawInterfaceGameTime);
                _uiState.Draw(Main.spriteBatch);
            }

            return true;
        }
    }
}
