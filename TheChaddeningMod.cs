using System.IO;
using Terraria;
using Terraria.ModLoader;
using Terraria.ModLoader.Config;
using TheChaddening.Textures;
using WebmilioCommons.Networking;

namespace TheChaddening
{
    [Label("The Chaddening")]
	public sealed partial class TheChaddeningMod : Mod
	{
        public TheChaddeningMod()
        {
            Instance = this;
        }


        public override void Load()
        {
            TexturesManager.Load(this);

            if (!Main.dedServ)
            {
                LoadClient();
            }
        }

        public override void Unload()
        {
            if (!Main.dedServ)
            {
                UnloadClient();
            }

            TexturesManager.Unload();
        }


        public override void HandlePacket(BinaryReader reader, int whoAmI) => NetworkPacketLoader.Instance.HandlePacket(reader, whoAmI);


        public static TheChaddeningMod Instance { get; private set; }
	}
}