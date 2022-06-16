using Terraria;
using Terraria.ModLoader;
using Terraria.ID;
using Terraria.GameContent.Creative;
using FirstMod.Content.Dusts;
using FirstMod.Content.Items.Placeables;
using Microsoft.Xna.Framework;

namespace FirstMod.Content.Items.Weapons
{
    internal class MomSlayer : ModItem
    {
        public override void SetStaticDefaults()
        {
            CreativeItemSacrificesCatalog.Instance.SacrificeCountNeededByItemId[Type] = 1;
        }

        public override void SetDefaults()
        {
            // Hitbox
            Item.width = 104;
            Item.height = 121;

            // Use and Animation Style
            Item.useStyle = ItemUseStyleID.Swing;
            Item.useTime = 25;
            Item.useAnimation = 25;
            Item.reuseDelay = 10;

            // Damage Values
            Item.DamageType = DamageClass.Melee;
            Item.damage = 279;
            Item.knockBack = 10f;
            Item.crit = 30;

            // Misc
            Item.value = Item.buyPrice(gold: 69);
            Item.rare = ItemRarityID.Purple;

            // Sound
            Item.UseSound = SoundID.Item15;
        }

        public override void AddRecipes()
        {
            CreateRecipe()
                .AddIngredient(ItemID.Amethyst, 30)
                .AddIngredient(ItemID.AdamantiteBar, 20)
                .AddIngredient(ModContent.ItemType<ObamiumOre>(), 200)
                .AddTile(TileID.Anvils)
                .Register();
        }

        public override bool? UseItem(Player player)
        {
            float floatTargetX = (Main.MouseWorld.X - player.Center.X);
            float floatTargetY = (Main.MouseWorld.Y - player.Center.Y);
            float distance = (float)System.Math.Sqrt((double)(floatTargetX * floatTargetX + floatTargetY * floatTargetY));

            distance = 3f / distance;

            //Multiply the distance by a multiplier if you wish the projectile to have go faster
            floatTargetX *= distance * 10;
            floatTargetY *= distance * 12;

            player.velocity = new Vector2(floatTargetX, floatTargetY);
            if (Main.MouseWorld.X - player.Center.X < 0)
            {
                player.direction = -1;
            } else
            {
                player.direction = 1;
            }

            for (int i = 0; i < 20; i++)
            {
                Dust.NewDust(player.position, player.width, player.height, ModContent.DustType<TutorialDust>(), player.velocity.X * 0.1f, player.velocity.Y * 0.1f,
                    0, default(Color), 1f);
            }

            return false;
        }
    }
}
