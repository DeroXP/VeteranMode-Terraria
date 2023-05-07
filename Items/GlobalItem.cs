using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using Microsoft.Xna.Framework;

namespace VeteranMode.Global
{
	public class GlobalItemList : GlobalItem
	{
		public override void SetDefaults(Item item)
		{
			if (item.type == ItemID.HallowedRepeater) item.shootSpeed = 55;
		}
	}
}