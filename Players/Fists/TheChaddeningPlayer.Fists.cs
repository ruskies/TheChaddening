using Terraria;
using Terraria.GameInput;
using TheChaddening.Abilities;

namespace TheChaddening.Players
{
    public sealed partial class TheChaddeningPlayer
    {
        private void ProcessTriggersFists(TriggersSet triggersSet)
        {
            if (TheChaddeningMod.Instance.SwitchMode.JustPressed)
                PunchingMode = triggersSet.SmartSelect ? PunchingMode.PreviousEnum() : PunchingMode.NextEnum();
        }


        public AbilityTypes PunchingMode { get; private set; }
    }
}
