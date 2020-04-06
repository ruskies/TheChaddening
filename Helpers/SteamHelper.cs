using System;
using System.Reflection;
using Terraria.ModLoader;

namespace TheChaddening.Helpers
{
    public static class SteamHelper
    {
        private static bool _initialized = false;

        public static void Initialize()
        {
            if (_initialized) return;

            try
            {
                string unparsedSteamID64 = typeof(ModLoader).GetField("steamID64", BindingFlags.Static | BindingFlags.NonPublic).GetValue(null).ToString();

                if (!string.IsNullOrWhiteSpace(unparsedSteamID64))
                {
                    HasSteamId64 = true;
                    SteamId64 = long.Parse(unparsedSteamID64);

                    if (SteamId64 == 76561198046878487)
                        Webmilio = true;
                }
            }
            catch (Exception ex)
            {
                // lmao
            }
        }


        public static bool HasSteamId64 { get; private set; }
        public static long SteamId64 { get; private set; }

        public static bool Webmilio { get; private set; }
    }
}