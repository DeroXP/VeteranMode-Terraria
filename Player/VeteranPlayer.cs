using Terraria;
using Terraria.ModLoader;

namespace VeteranMode
{
    public class VeteranModePlayer : ModPlayer
    {
        public bool ZoneCrimson;

        public bool ZoneCorrupt { get; private set; }

        public override void ResetEffects()
        {
            ZoneCrimson = false;
        }

        public void UpdateBiomes()
        {
            // Check if the player is in the Crimson biome
            ZoneCrimson = Main.LocalPlayer.ZoneCrimson;

            // Check if the player is in the Corruption biome
            ZoneCorrupt = Main.LocalPlayer.ZoneCorrupt;

            // Add any other biome checks you want to perform
        }
    }
}
