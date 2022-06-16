using Terraria;
using Terraria.ModLoader;
using Terraria.ID;
using FirstMod.Content.Items.Placeables;
using Terraria.GameContent.Creative;
using FirstMod.Content.Projectiles.Weapons;

namespace FirstMod.Content.Items.Weapons
{
    internal class Murasama : ModItem
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
            Item.useTime = 20;
            Item.useAnimation = 20;
            Item.autoReuse = true;

            // Damage Values
            Item.DamageType = DamageClass.Melee;
            Item.damage = 3001;
            Item.knockBack = 6.5f;
            Item.crit = 50;

            // Misc
            Item.value = Item.buyPrice(platinum: 69);
            Item.rare = ItemRarityID.Master;

            Item.noUseGraphic = true;
            Item.noMelee = true;

            Item.shootSpeed = 0;
            Item.shoot = ModContent.ProjectileType<MurasamaProjectile>();

            // Sound
            Item.UseSound = SoundID.Item15;
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
