using Microsoft.Xna.Framework.Graphics;
using Terraria.ModLoader;

namespace TheChaddening.Textures
{
    public static class TexturesManager
    {
        internal static void Load(Mod mod)
        {
            //Menacing = mod.GetTexture("Textures/Menacing");
        }


        internal static void Unload()
        {
            //Menacing = null;
        }


        public static Texture2D Menacing { get; private set; }
    }
}
