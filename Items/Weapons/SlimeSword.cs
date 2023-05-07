using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace VeteranMode.Items.Weapons
{
    public class SlimeSword : ModItem
    {
        public override void SetStaticDefaults()
		{
			Tooltip.SetDefault("Let's Get Sticky!");
            DisplayName.SetDefault("Bluby");
		}

		public override void SetDefaults()
		{
			Item.damage = 20;
			Item.DamageType = DamageClass.Melee;
			Item.width = 45;
			Item.height = 80;
			Item.useTime = 20;
			Item.useAnimation = 20;
			Item.useStyle = 1;
			Item.knockBack = 6;
			Item.value = 1;
			Item.rare = 1;
			Item.UseSound = SoundID.Item1;
			Item.autoReuse = true;
		}

        public override void UpdateEquip(Player player)
        {
            player.GetModPlayer<MyPlayer>().slimeDamageReduction += 0.1f;
        }

		public override void AddRecipes()
		{
			Recipe recipe = CreateRecipe();
			recipe.AddIngredient(ItemID.Gel, 15);
			recipe.Register();
		}
    }

    public class MyPlayer : ModPlayer
    {
        public float slimeDamageReduction = 0f;

        public override void ResetEffects()
        {
            slimeDamageReduction = 0f;
        }

        public override void ModifyHitByNPC(NPC npc, ref int damage, ref bool crit)
        {
            if (npc.type == NPCID.BlueSlime || npc.type == NPCID.Pinky || npc.type == NPCID.RedSlime || npc.type == NPCID.GreenSlime || npc.type == NPCID.BabySlime)
            {
                damage = (int)(damage * (1f - slimeDamageReduction));
            }
        }
    }
}