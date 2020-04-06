using System.Collections.Generic;
using Terraria.ModLoader;
using Terraria.UI;
using TheChaddening.Helpers;
using TheChaddening.UserInterfaces;
using TheChaddening.UserInterfaces.Charge;
using TheChaddening.UserInterfaces.Strength;

namespace TheChaddening
{
    public sealed partial class TheChaddeningMod : Mod
    {
        internal StrengthBar strengthBar;
        internal UserInterface strengthBarInterface;

        internal ChargeBar chargeBar;
        internal UserInterface chargeBarInterface;


        private void LoadClient()
        {
            SteamHelper.Initialize();

            strengthBar = new StrengthBar();
            strengthBar.Activate();
            
            strengthBarInterface = new UserInterface();
            strengthBarInterface.SetState(strengthBar);

            strengthBar.Visible = true;


            chargeBar = new ChargeBar();
            chargeBar.Activate();

            chargeBarInterface = new UserInterface();
            chargeBarInterface.SetState(chargeBar);

            chargeBar.Visible = true;


            ChargeSpeedToggle = RegisterHotKey("Toggle Charge Speed", "C");
            SwitchMode = RegisterHotKey("Toggle Melee/Ranged", "X");
        }

        private void UnloadClient()
        {
            strengthBar.Visible = false;

            ChargeSpeedToggle = null;
        }


        public override void ModifyInterfaceLayers(List<GameInterfaceLayer> layers)
        {
            int strengthBarLayerIndex = layers.FindIndex(l => l.Name.Contains("Resource Bars"));

            if (strengthBarLayerIndex != -1)
            {
                layers.Insert(strengthBarLayerIndex, new GenericInterfaceLayer(typeof(StrengthBar).FullName, InterfaceScaleType.UI, strengthBar, strengthBarInterface, strengthBar));
                layers.Insert(strengthBarLayerIndex, new GenericInterfaceLayer(typeof(ChargeBar).FullName, InterfaceScaleType.UI, chargeBar, chargeBarInterface, chargeBar));
            }
        }


        public ModHotKey ChargeSpeedToggle { get; private set; }
        public ModHotKey SwitchMode { get; private set; }
    }
}
