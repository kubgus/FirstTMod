using Terraria;
using Terraria.ModLoader;
using Microsoft.Xna.Framework;
using Terraria.DataStructures;
using FirstMod.Content.Dusts;
using Terraria.ID;

namespace FirstMod.Content.Projectiles.Weapons
{
    internal class TestBoomerangProjectile1 : ModProjectile
    {
        public override void SetDefaults()
        {
            Projectile.width = 32;
            Projectile.height = 32;

            Projectile.friendly = true;
            Projectile.ignoreWater = true;

            Projectile.DamageType = DamageClass.Melee;

            Projectile.aiStyle = ProjAIStyleID.Boomerang;

            Projectile.penetrate = -1;
        }

        public override void AI()
        {
            base.AI();

            Projectile.ai[1]++;
            if (Projectile.ai[1] % 5 == 0)
            {
                Projectile.NewProjectile(new EntitySource_Misc("TestBoomerangProjectile2"), new Vector2(Projectile.Center.X, Projectile.Center.Y), new Vector2(Projectile.velocity.X * 0.2f, Projectile.velocity.X * 0.2f), ModContent.ProjectileType<TestBoomerangProjectile2>(), Projectile.damage, Projectile.knockBack, Projectile.owner);
            }

            Dust.NewDust(Projectile.position, Projectile.width, Projectile.height, ModContent.DustType<TestBoomerangDust>(), Projectile.velocity.X * 0.1f, Projectile.velocity.Y * 0.1f,
                        0, default(Color), 1f);
        }
    }
}
