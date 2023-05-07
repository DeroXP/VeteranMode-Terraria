using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace VeteranMode.Items
{
    public class ShadowfangBlade : ModItem
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Shadowfang Blade");
            Tooltip.SetDefault("The darkness howls within this blade");
        }

        public override void SetDefaults()
        {
            Item.damage = 90;
            Item.DamageType = DamageClass.Melee;
            Item.width = 40;
            Item.height = 40;
            Item.useTime = 20;
            Item.useAnimation = 20;
            Item.useStyle = ItemUseStyleID.Swing;
            Item.knockBack = 7f;
            Item.value = Item.sellPrice(gold: 5);
            Item.rare = ItemRarityID.Yellow;
            Item.UseSound = SoundID.Item1;
            Item.shoot = ModContent.ProjectileType<Projectiles.Minions.WerewolfMinion>();
            Item.autoReuse = true;
            Item.shootSpeed = 15f;
        }

        public override void AddRecipes()
        {
            Recipe recipe = CreateRecipe();
            recipe.AddIngredient(ItemID.DirtBlock, 1);
            //recipe.AddIngredient(ItemID.NightsEdge, 1);
            //recipe.AddIngredient(ModContent.ItemType<DarkWolfFang>(), 10);
            //if (Main.hardMode)
            //{
                //recipe.AddIngredient(ItemID.ShadowScale, 15);
            //}
            //else
            //{
                //recipe.AddIngredient(ItemID.TissueSample, 15);
            //}
            //recipe.AddIngredient(ItemID.Obsidian, 20);
            //recipe.AddTile(TileID.MythrilAnvil);
            recipe.Register();
        }

        public override void OnHitNPC(Player player, NPC target, int damage, float knockBack, bool crit)
        {
            if (Main.rand.Next(4) == 0)
            {
                target.AddBuff(BuffID.ShadowFlame, 300);
            }
        }
    }

    public class DarkWolfFang : ModItem
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Dark Wolf Fang");
            Tooltip.SetDefault("Sharp and deadly");
        }

        public override void SetDefaults()
        {
            Item.width = 16;
            Item.height = 16;
            Item.maxStack = 99;
            Item.value = Item.sellPrice(gold: 1);
            Item.rare = ItemRarityID.Blue;
        }

        public override void AddRecipes()
        {
            Recipe recipe = CreateRecipe();
            recipe.AddIngredient(ItemID.DirtBlock, 1);
            // Replace with CrimtaneBar if in a Crimson world
            //int[] barsToCheck = Main.player[Main.myPlayer].GetModPlayer<VeteranModePlayer>().ZoneCrimson ? new int[] { ItemID.Vertebrae } : new int[] { ItemID.RottenChunk };

            // Loop through each bar and add it to the recipe
            //foreach (int bar in barsToCheck)
            //{
                //for (int i = 0; i < 5; i++)
                //{
                    //recipe.AddIngredient(bar);
                //}
            //}
            //recipe.AddTile(TileID.Anvils);
            recipe.Register();
        }
    }
}