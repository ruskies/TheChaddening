using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ModLoader;

namespace TheChaddening.Players
{
    public sealed partial class TheChaddeningPlayer : ModPlayer
    {
        private void OnStrengthGainedVisuals(ulong strengthGain)
        {
            CombatText.NewText(new Rectangle((int) player.position.X, (int) player.position.Y - player.height / 2, player.width, player.height / 2), new Color(255, 0, 0), strengthGain.ToString(), true);
        }
    }
}
