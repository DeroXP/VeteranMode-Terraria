using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace VeteranMode.Projectiles.Minions
{
    public class WerewolfMinion : ModProjectile
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Werewolf Minion");
            Main.projFrames[Projectile.type] = 4;
            ProjectileID.Sets.MinionTargettingFeature[Projectile.type] = true;
            ProjectileID.Sets.MinionSacrificable[Projectile.type] = true;
        }

        public override void SetDefaults()
        {
            Projectile.width = 64;
            Projectile.height = 64;
            Projectile.friendly = true;
            Projectile.minion = true;
            Projectile.netImportant = true;
            Projectile.timeLeft = 18000;
            Projectile.penetrate = -1;
            Projectile.tileCollide = false;
            Projectile.ignoreWater = true;
            Projectile.damage = 40;
            Projectile.knockBack = 4f;
        }

        public override bool? CanCutTiles()
        {
            return false;
        }

        public override void AI()
        {
            Player player = Main.player[Projectile.owner];

            if (player.dead || !player.active)
            {
                Projectile.Kill();
                return;
            }

            if (player.HasBuff(ModContent.BuffType<Buffs.WerewolfBuff>()))
            {
                Projectile.timeLeft = 2;
            }

            // Minion follows the player
            Vector2 targetPosition = player.Center - new Vector2(0, 48);
            Projectile.Center = Vector2.Lerp(Projectile.Center, targetPosition, 0.2f);

            // Attack enemies on sight
            float detectionRadius = 400f;
            NPC target = null;
            for (int i = 0; i < Main.maxNPCs; i++)
            {
                NPC npc = Main.npc[i];
                if (npc.CanBeChasedBy() && Vector2.Distance(npc.Center, Projectile.Center) < detectionRadius && Collision.CanHitLine(Projectile.Center, 1, 1, npc.Center, 1, 1))
                {
                    target = npc;
                    break;
                }
            }

            if (target != null)
            {
                Vector2 direction = target.Center - Projectile.Center;
                direction.Normalize();
                Projectile.velocity = direction * 8f;

                if (Projectile.frameCounter % 10 == 0)
                {
                    Projectile.frame = (Projectile.frame + 1) % 4;
                }
            }
            else
            {
                Projectile.velocity *= 0.9f;

                if (Projectile.frameCounter % 20 == 0)
                {
                    Projectile.frame = (Projectile.frame + 1) % 4;
                }
            }

            Projectile.rotation = Projectile.velocity.ToRotation() + MathHelper.PiOver2;
        }
    }
}