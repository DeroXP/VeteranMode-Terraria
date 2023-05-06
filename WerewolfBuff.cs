using Terraria;
using Terraria.ModLoader;

namespace VeteranMode.Buffs
{
    public class WerewolfBuff : ModBuff
    {
        private int duration;

        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Werewolf");
            Description.SetDefault("Increased melee damage, defense, and speed");
            Main.buffNoSave[Type] = true;
            Main.buffNoTimeDisplay[Type] = false;
            duration = 25 * 60; // 25 seconds
        }

        public override void Update(Player player, ref int buffIndex)
        {
            player.statDefense += 8;
            player.moveSpeed += 0.3f;

            // Decrement the duration counter each tick
            duration--;
            if (duration <= 0)
            {
                // Remove the buff once the duration has elapsed
                player.DelBuff(buffIndex);
                buffIndex--;
            }
        }
    }
}