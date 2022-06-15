using Terraria;
using Terraria.ModLoader;
using Terraria.ID;
using FirstMod.Content.Items.Placeables;
using Terraria.GameContent.Creative;
using FirstMod.Content.Projectiles.Weapons;

namespace FirstMod.Content.Items.Weapons
{
    internal class ObamiumWand : ModItem
    {
        public override void SetStaticDefaults()
        {
            CreativeItemSacrificesCatalog.Instance.SacrificeCountNeededByItemId[Type] = 1;
        }

        public override void SetDefaults()
        {
            Item.width = 32;
            Item.height = 32;
            Item.useStyle = ItemUseStyleID.HoldUp;
            Item.autoReuse = true;

            Item.DamageType = DamageClass.Magic;
            Item.noMelee = true;
            Item.mana = 5;
            Item.damage = 137;
            Item.knockBack = 10f;

            Item.useTime = 20;
            Item.useAnimation = 15;

            Item.value = Item.buyPrice(gold: 1);
            Item.rare = ItemRarityID.Expert;

            Item.UseSound = SoundID.Item71;

            Item.shoot = ModContent.ProjectileType<ObamiumWandProjectile>();
            Item.shootSpeed = 1f;
        }

        public override void AddRecipes()
        {
            CreateRecipe()
                .AddIngredient(ModContent.ItemType<ObamiumOre>(), 10)
                .AddIngredient(ItemID.Amethyst, 8)
                .AddTile(TileID.WorkBenches)
                .Register();
        }
    }
}
