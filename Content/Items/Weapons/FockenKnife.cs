using Terraria;
using Terraria.ModLoader;
using Terraria.ID;
using FirstMod.Content.Items.Placeables;
using Terraria.GameContent.Creative;
using FirstMod.Content.Projectiles.Weapons;

namespace FirstMod.Content.Items.Weapons
{
    internal class FockenKnife : ModItem
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
            Item.useStyle = ItemUseStyleID.Rapier;
            Item.useTime = 5;
            Item.useAnimation = 5;
            Item.autoReuse = true;

            // Damage Values
            Item.DamageType = DamageClass.Melee;
            Item.damage = 999999;
            Item.knockBack = 0f;
            Item.crit = 99;

            // Misc
            Item.value = Item.buyPrice(silver: 80, copper: 50);
            Item.rare = ItemRarityID.Yellow;

            Item.noUseGraphic = true;
            Item.noMelee = true;

            Item.shootSpeed = 3f;
            Item.shoot = ModContent.ProjectileType<FockenKnifeProjectile>();

            // Sound
            Item.UseSound = SoundID.Item1;
        }

        public override void AddRecipes()
        {
            CreateRecipe()
                .AddIngredient(ModContent.ItemType<SusBar>(), 100)
                .AddTile(TileID.TinkerersWorkbench)
                .Register();
        }
    }
}
