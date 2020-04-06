using Terraria.GameInput;
using Terraria.ModLoader;

namespace TheChaddening.Players
{
    public sealed partial class TheChaddeningPlayer : ModPlayer
    {
        private const float MANUAL_CHARGE_RATE_PER_SECOND_GAIN = 0.01f;


        public void ChargeStrength(ulong strength = 0, float percentagePerSecond = 0, bool minimum1 = true)
        {
            ChargedStrength += strength;

            ulong charge = (ulong) (Strength * percentagePerSecond * ManualChargeRate) / Constants.TICKS_PER_SECOND;

            if (charge < 1 && minimum1)
                charge = 1;

            ChargedStrength += charge;
        }


        public void CycleManualChargeRateUp()
        {
            if (ManualChargeRate >= 1f)
                ManualChargeRate = MANUAL_CHARGE_RATE_PER_SECOND_GAIN;
            else if (ManualChargeRate + MANUAL_CHARGE_RATE_PER_SECOND_GAIN >= 1f)
                ManualChargeRate = 1f;
            else
                ManualChargeRate = ManualChargeRate + MANUAL_CHARGE_RATE_PER_SECOND_GAIN;
        }

        public void CycleManualChargeRateDown()
        {
            if (ManualChargeRate <= 0)
                ManualChargeRate = 1f;
            else if (ManualChargeRate - MANUAL_CHARGE_RATE_PER_SECOND_GAIN <= 0f)
                ManualChargeRate = 0f;
            else
                ManualChargeRate = ManualChargeRate - MANUAL_CHARGE_RATE_PER_SECOND_GAIN;
        }


        public void ResetChargedStrength() => ChargedStrength = 0;


        private void InitializeCharge()
        {
            ManualChargeRate = 1f;
        }

        private void ProcessTriggersCharge(TriggersSet triggersSet)
        {
            if (TheChaddeningMod.Instance.ChargeSpeedToggle.Current)
            {
                if (TriggersSet.SmartSelect)
                {
                    if (ManualChargeRate <= 0 && TheChaddeningMod.Instance.ChargeSpeedToggle.Old)
                        // Do Nothing
                        ;
                    else
                        CycleManualChargeRateDown();
                }
                else
                {
                    if (ManualChargeRate >= 1f && TheChaddeningMod.Instance.ChargeSpeedToggle.Old)
                        // Do nothing
                        ;
                    else
                        CycleManualChargeRateUp();
                }
            }
        }

        private void ResetEffectsCharge()
        {
            
        }


        public float ManualChargeRate { get; private set; }
        public ulong ChargedStrength { get; private set; }
    }
}
