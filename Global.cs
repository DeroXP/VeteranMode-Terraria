using System.Collections.Generic;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using System.Linq;

namespace VeteranMode
{
    public class npcGlobal : GlobalNPC
    {
        public override void SetDefaults(NPC npc)
        {
            int[] bosses = { NPCID.KingSlime, NPCID.EyeofCthulhu, NPCID.EaterofWorldsHead, NPCID.BrainofCthulhu, NPCID.QueenBee, NPCID.SkeletronHead, NPCID.WallofFlesh, NPCID.Retinazer, NPCID.Spazmatism, NPCID.TheDestroyer, NPCID.SkeletronPrime, NPCID.Plantera, NPCID.Golem, NPCID.DukeFishron, NPCID.CultistBoss, NPCID.MoonLordCore };
            int[] slimes = { NPCID.BlueSlime, NPCID.GreenSlime, NPCID.PurpleSlime, NPCID.RedSlime, NPCID.YellowSlime, NPCID.BlackSlime, NPCID.Pinky, NPCID.SlimeSpiked };
            int[] zombies = { NPCID.Zombie, NPCID.BaldZombie, NPCID.FemaleZombie, NPCID.PincushionZombie, NPCID.SlimedZombie, NPCID.SwampZombie, NPCID.TwiggyZombie };
            int[] demons = { NPCID.Demon, NPCID.VoodooDemon, NPCID.BoneSerpentHead };

            int npcType = npc.type;

            if (npc.lifeMax > 5 && !npc.townNPC && npc.damage > 0 && !npc.friendly || bosses.Contains(npcType) || slimes.Contains(npcType) || zombies.Contains(npcType) || demons.Contains(npcType))
            {
                npc.damage = (int)(npc.damage + Main.rand.NextFloat(20f, 80f));
                npc.defense = (int)(npc.defense + Main.rand.NextFloat(20f, 80f));
                npc.lifeMax = (int)(npc.lifeMax + Main.rand.NextFloat(20f, 80f));
                npc.life = npc.lifeMax;
                npc.lifeRegen += 5;
            }
        }

        // Use a dictionary to keep track of whether each NPC has already been processed or not
        private static Dictionary<int, bool> processedNPCs = new Dictionary<int, bool>();

        public override void PostAI(NPC npc)
        {
            // Check if the flag is already set for this NPC
            if (processedNPCs.ContainsKey(npc.whoAmI) && processedNPCs[npc.whoAmI])
            {
                return;
            }

            //int[] bosses = { NPCID.KingSlime, NPCID.EyeofCthulhu, NPCID.EaterofWorldsHead, NPCID.BrainofCthulhu, NPCID.QueenBee, NPCID.SkeletronHead, NPCID.WallofFlesh, NPCID.Retinazer, NPCID.Spazmatism, NPCID.TheDestroyer, NPCID.SkeletronPrime, NPCID.Plantera, NPCID.Golem, NPCID.DukeFishron, NPCID.CultistBoss, NPCID.MoonLordCore };
            //int[] slimes = { NPCID.BlueSlime, NPCID.GreenSlime, NPCID.PurpleSlime, NPCID.RedSlime, NPCID.YellowSlime, NPCID.BlackSlime, NPCID.Pinky, NPCID.SlimeSpiked };
            //int[] zombies = { NPCID.Zombie, NPCID.BaldZombie, NPCID.FemaleZombie, NPCID.PincushionZombie, NPCID.SlimedZombie, NPCID.SwampZombie, NPCID.TwiggyZombie };
            //int[] demons = { NPCID.Demon, NPCID.VoodooDemon, NPCID.BoneSerpentHead };

            //int npcType = npc.type;

            //if (!Main.dedServ && !Main.gamePaused && npc.active && !npc.friendly && npc.damage > 0 || bosses.Contains(npcType) || slimes.Contains(npcType) || zombies.Contains(npcType) || demons.Contains(npcType))
            //{
                //npc.damage = npc.damage + 200;
                //npc.defense = npc.defense + 400;
                //npc.lifeMax = npc.lifeMax + 200;
                //npc.life = npc.life + 200;
            //}

            // Loop through all players and remove their buffs
            for (int i = 0; i < Main.player.Length; i++)
            {
                Player player = Main.player[i];
                if (player.active && !player.dead)
                {
                    // Loop through all buff types and remove them from the player
                    //for (int j = 1; j < BuffLoader.BuffCount; j++)
                    //{
                        //if (player.HasBuff(j))
                        //player
                            //player.ClearBuff(j);
                        //}
                    //}
                    // Remove player's immunity frames
                    player.immuneTime = 1;
                    player.immuneNoBlink = true;
                    player.immune = false;
                }
            }
            
            // Set the flag for this NPC to true so it doesn't get processed again
            processedNPCs[npc.whoAmI] = true;
        }
    }
}