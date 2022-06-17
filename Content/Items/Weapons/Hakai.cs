using Terraria;
using Terraria.ModLoader;
using Terraria.ID;
using Terraria.GameContent.Creative;
using Microsoft.Xna.Framework;
using FirstMod.Content.Dusts;
using FirstMod.Content.Tiles;

namespace FirstMod.Content.Items.Weapons
{
    internal class Hakai : ModItem
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
            Item.useTime = 1;
            Item.useAnimation = 1;
            Item.autoReuse = true;

            // Damage Values
            Item.DamageType = DamageClass.Magic;
            Item.damage = 999999999;
            Item.knockBack = 6.5f;
            Item.crit = 50;

            // Misc
            Item.value = Item.buyPrice(platinum: 420);
            Item.rare = ItemRarityID.Purple;

            Item.noUseGraphic = true;
            Item.noMelee = true;
        }

        public void HakaiEffect()
        {
            for (int j = 0; j < 30; j++)
            {
                Dust.NewDust(Main.MouseWorld, 1, 1, ModContent.DustType<HakaiDust>(), 0f, 0f,
                        0, default(Color), 1f);
            }
        }

        public override bool? UseItem(Player player)
        {
            int tileTargetX = (int)(Main.MouseWorld.X) / 16;
            int tileTargetY = (int)(Main.MouseWorld.Y) / 16;

            Tile targetTile = Main.tile[tileTargetX, tileTargetY];

            if (targetTile.HasTile)
            {
                HakaiEffect();
                WorldGen.TileRunner(tileTargetX, tileTargetY, WorldGen.genRand.Next(5, 10), WorldGen.genRand.Next(5, 7), ModContent.TileType<HakaiTile>());
            }
            else
            {
                float targetXPos = Main.MouseWorld.X;
                float targetYPos = Main.MouseWorld.Y;

                for (int i = 0; i < 200; i++)
                {
                    NPC target = Main.npc[i];

                    float relativeX = target.Center.X + (float)target.width * 0.5f - targetXPos;
                    float relativeY = target.Center.Y - targetYPos;
                    float distance = (float)System.Math.Sqrt((double)(relativeX * relativeX + relativeY * relativeY));

                    if (distance <= 50f)
                    {
                        HakaiEffect();
                        player.ApplyDamageToNPC(target, Item.damage, Item.knockBack, 0, true);
                    }
                }
            }

            return false;
        }
    }
}
