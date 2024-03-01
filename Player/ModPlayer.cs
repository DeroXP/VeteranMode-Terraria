using System;
using Terraria;
using Terraria.ModLoader;
using Microsoft.Xna.Framework;
using Terraria.GameContent.UI.Elements;
using Terraria.ID;
using Terraria.GameContent.Drawing;
using Terraria.DataStructures;

namespace VeteranMode
{
    public class VeteranModePlayer : ModPlayer
    {
        public float HyperthermiaHue { get; set; }

        public static bool ThunderstormActive = false;
        private uint lastUpdateCount;
        private float hyperthermiaDamageMultiplier = 0.01f;

        private float hypothermiaDamageMultiplier = 0.005f;

        private uint lastHyperthermiaUpdateCount;

        private uint lastHypothermiaUpdateCount;

        public override void PostUpdate()
        {
            ThunderstormActive = Main.numClouds > 50;

            if (ThunderstormActive)
            {
                SimulateLightning();
            }

            base.PostUpdate();
        }

        private void SimulateLightning()
        {
            for (int i = 5 - 1; i >= 0; i--)
            {
                int explosionX = Main.rand.Next(0, Main.maxTilesX);
                int explosionY = Main.rand.Next(0, Main.maxTilesY);

                WorldGen.KillTile(explosionX, explosionY);
            }

            Player player = Main.LocalPlayer;
            if (player.active && !player.dead)
            {
                if (Main.rand.Next(100) < 10)
                {
                    player.Hurt(PlayerDeathReason.ByOther(player.whoAmI), 50, 0);
                }
            }
        }

        public override void PreUpdate()
        {
            bool inDesertBiome = Player.ZoneDesert; //hyperthermia

            if (inDesertBiome)
            {
                ProcessHyperthermia();
            }

            bool inSnowBiome = Player.ZoneSnow; //hypothermia

            if (inSnowBiome)
            {
                ProcessHypothermia();
            }
        }

        private void ProcessHyperthermia()
        {
            Player player = Main.LocalPlayer;

            if (player.active && !player.dead)
            {
                uint elapsedTime = Main.GameUpdateCount - lastHyperthermiaUpdateCount;

                float damage = (5 - (int)elapsedTime) * hyperthermiaDamageMultiplier;

                player.statLife -= (int)Math.Round(player.statLifeMax * damage);

                lastHyperthermiaUpdateCount = Main.GameUpdateCount;
            }
        }

        private void ProcessHypothermia()
       {
            Player player = Main.LocalPlayer;
            if (player.active && !player.dead)
           {
                uint elapsedTime = Main.GameUpdateCount - lastHypothermiaUpdateCount;

                float damage = (2 - (int)elapsedTime) * hypothermiaDamageMultiplier;

                player.statLife -= (int)Math.Round(player.statLifeMax * damage);

                lastHypothermiaUpdateCount = Main.GameUpdateCount;
            }
        }
    }
}
