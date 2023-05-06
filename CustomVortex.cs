using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using Microsoft.Xna.Framework;

namespace VeteranMode.Projectiles
{
	public class CustomVortex : ModProjectile
	{
		public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("A Fling Of Thunder"); // Set the display name
        }

        public override void SetDefaults()
        {
            Projectile.width = 32; // Set the Projectile's width
            Projectile.height = 32; // Set the Projectile's height
            Projectile.friendly = true; // Set the Projectile to be friendly
            Projectile.penetrate = -1; // Make the Projectile pierce through enemies
            Projectile.timeLeft = 100; // Set the Projectile's lifespan in frames
            Projectile.tileCollide = false; // Make the Projectile pass through tiles
            Projectile.ignoreWater = true; // Make the Projectile pass through water
            Projectile.aiStyle = -1; // Don't use any built-in AI behavior
            Projectile.scale = 1.2f; // Set the Projectile's scale
            Projectile.light = 10f; // Set the Projectile's light level
            Projectile.damage = 50; // Set the Projectile's damage
            Projectile.Opacity = 0; // Set the Projectile's opacity
        }

        public override void AI()
        {
            if (Projectile.ai[0] == 0f)
            {
                Projectile.ai[0] = 1f; // Set the initial AI state to 1
                Projectile.netUpdate = true; // Update the Projectile on the server
            }
            if (Projectile.ai[0] == 1f)
            {
                // Target and damage enemies
                for (int i = 0; i < 200; i++)
                {
                    NPC target = Main.npc[i];
                    if (!target.friendly && target.active && !target.dontTakeDamage)
                    {
                        float distance = Vector2.Distance(target.Center, Projectile.Center);
                        if (distance < 400f)
                        {
                            Projectile.velocity = Vector2.Normalize(target.Center - Projectile.Center) * 20f;
                            if (distance < 20f)
                            {
                                target.StrikeNPC(Projectile.damage, 0f, 0, false, false, false); // Damage the enemy
                                Projectile.Kill(); // Destroy the Projectile
                            }
                        }
                    }
                }
            }

            // Animate the Projectile
            Projectile.frameCounter++;
            if (Projectile.frameCounter >= 4)
            {
                Projectile.frame++;
                Projectile.frameCounter = 0;
                if (Projectile.frame >= 4)
                {
                    Projectile.frame = 0;
                }
            }
        }

        public override void Kill(int timeLeft)
        {
            // Create a dust effect when the Projectile is destroyed
            for (int i = 0; i < 10; i++)
            {
                Dust.NewDust(Projectile.position, Projectile.width, Projectile.height, DustID.Electric);
            }
        }
	}
}