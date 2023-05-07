using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using VeteranMode.Projectiles;

namespace VeteranMode.Items.Armor
{
	[AutoloadEquip(EquipType.Body)]
	public class DevChest : ModItem
	{
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Dev Armor");
            Tooltip.SetDefault("Only For Testing Remove From Public Build(s)");
        }

        public override void SetDefaults()
        {
            Item.width = 12;
            Item.height = 12;
            Item.value = 2000;
            Item.rare = 1;
            Item.defense = 9999;
        }
        public override void UpdateEquip(Player player)
        {
            player.GetCritChance(DamageClass.Ranged) += Main.rand.NextFloat(20f, 40f);

            player.statManaMax2 = 999999;
            player.statLifeMax2 = 999999;
            player.lifeRegen = 999999;
            player.manaRegen = 999999;
            player.moveSpeed = 8f;
            player.jumpSpeedBoost = 8f;
            player.wingTimeMax = 999999;
            player.maxMinions = 9999;
            player.maxTurrets = 9999;
            player.lightOrb = true;
        }

        public override void AddRecipes()
        {
            Recipe recipe = CreateRecipe();
            recipe.AddIngredient(ItemID.DirtBlock, 1);
            recipe.Register();
        }
    }
}
