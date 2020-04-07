using Terraria.GameInput;
using Terraria.ModLoader;
using TheChaddening.Commons;

namespace TheChaddening.Players
{
    public sealed partial class TheChaddeningPlayer : ModPlayer
    {
        public float GetMoveSpeed(ulong strength)
        {
            return strength * ChadMath.SPEED_SCALING_RATIO;
        }


        private void ProcessTriggersMovements(TriggersSet triggersSet)
        {

        }

        private void ResetEffectsMovements()
        {
            player.moveSpeed += GetMoveSpeed(Strength);
        }
    }
}
