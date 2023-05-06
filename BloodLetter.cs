using System;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace VeteranMode.Items.Weapons
{
    public class BloodLetter : ModItem
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Bloodletter");
            Tooltip.SetDefault("A sword made from the flesh of Crimson creatures, imbued with their deadly power");
        }

        public override void SetDefaults()
        {
            Item.damage = 24;
            Item.DamageType = DamageClass.Melee;
            Item.width = 40;
            Item.height = 40;
            Item.useTime = 16;
            Item.useAnimation = 16;
            Item.useStyle = ItemUseStyleID.Swing;
            Item.knockBack = 4;
            Item.value = Item.sellPrice(gold: 1);
            Item.rare = ItemRarityID.Blue;
            Item.crit = 10;
            Item.UseSound = SoundID.Item1;
            Item.autoReuse = true;
        }

        public override void OnHitNPC(Player player, NPC target, int damage, float knockback, bool crit)
        {
            if (Main.rand.NextBool(3))
            {
                target.AddBuff(BuffID.Bleeding, 60);
            }
        }

        public override bool AltFunctionUse(Player player)
        {
            return true;
        }

        public override bool CanUseItem(Player player)
        {
            if (player.altFunctionUse == 2)
            {
                Item.useStyle = ItemUseStyleID.Swing;
                Item.useTime = 40;
                Item.useAnimation = 20;
                Item.mana = 10;
            }
            else
            {
                Item.useStyle = ItemUseStyleID.Swing;
                Item.useTime = 16;
                Item.useAnimation = 16;
                Item.mana = 0;
            }
            return base.CanUseItem(player);
        }

        public override bool CanRightClick()
        {
            Player player = Main.LocalPlayer;
            return player.altFunctionUse == 2 && player.statLifeMax - player.statLife >= 5;
        }

        public override void RightClick(Player player)
        {
            player.HealEffect(5);
            player.statLife += 5;
            Item.damage += 20;
        }

        public override void AddRecipes()
        {
            Recipe recipe = CreateRecipe();
            //recipe.AddIngredient(ItemID.CrimtaneBar, 12);
            //recipe.AddIngredient(ItemID.TissueSample, 8);
            //recipe.AddIngredient(ItemID.Ruby, 1);

            // Replace with CrimtaneBar if in a Crimson world
            //int[] barsToCheck = Main.player[Main.myPlayer].GetModPlayer<VeteranModePlayer>().ZoneCrimson ? new int[] { ItemID.CrimtaneBar } : new int[] { ItemID.DemoniteBar };

            // Loop through each bar and add it to the recipe
            //foreach (int bar in barsToCheck)
            //{
                //for (int i = 0; i < 5; i++)
                //{
                    //recipe.AddIngredient(bar);
                //}
            //}       

            //recipe.AddTile(TileID.Anvils);
            recipe.AddIngredient(ItemID.DirtBlock, 1);
            recipe.Register();
        }
    }
}