using Terraria;
using Terraria.ModLoader;
using Terraria.ID;
using FirstMod.Content.Items.Placeables;
using Terraria.GameContent.Creative;
using FirstMod.Content.Projectiles.Weapons;

namespace FirstMod.Content.Items.Weapons
{
    internal class TestBoomerang : ModItem
    {
        public override void SetStaticDefaults()
        {
            CreativeItemSacrificesCatalog.Instance.SacrificeCountNeededByItemId[Type] = 1;
        }

        public override void SetDefaults()
        {
            // Hitbox
            Item.width = 32;
            Item.height = 32;

            // Use and Animation Style
            Item.useStyle = ItemUseStyleID.Swing;
            Item.useTime = 30;
            Item.useAnimation = 30;
            Item.autoReuse = true;

            // Damage Values
            Item.DamageType = DamageClass.Melee;
            Item.damage = 300;
            Item.knockBack = 1;
            Item.crit = 35;

            // Misc
            Item.value = Item.buyPrice(silver: 69);
            Item.rare = ItemRarityID.Purple;

            Item.noUseGraphic = true;
            Item.noMelee = true;

            Item.shootSpeed = 15f;
            Item.shoot = ModContent.ProjectileType<TestBoomerangProjectile1>();

            // Sound
            Item.UseSound = SoundID.Item1;
        }

        public override void AddRecipes()
        {
            CreateRecipe()
                .AddIngredient(ModContent.ItemType<ObamiumOre>(), 10)
                .AddIngredient(ItemID.Amethyst, 8)
                .AddTile(TileID.WorkBenches)
                .Register();
        }

        public override bool CanUseItem(Player player)
        {
            for (int i = 0; i < 1000; ++i)
            {
                if (Main.projectile[i].active && Main.projectile[i].owner == Main.myPlayer && Main.projectile[i].type == Item.shoot)
                {
                    return false;
                }
            }
            return true;
        }
    }
}
