using Terraria;
using Terraria.ModLoader;
using Microsoft.Xna.Framework;

namespace FirstMod.Content.Projectiles.Weapons
{
    internal class TestBoomerangProjectile2 : ModProjectile
    {
        public override void SetDefaults()
        {
            Projectile.width = 32;
            Projectile.height = 32;

            Projectile.friendly = true;
            Projectile.ignoreWater = true;

            Projectile.DamageType = DamageClass.Melee;

            Projectile.aiStyle = 8;

            Projectile.penetrate = -1;
        }

        public override void AI()
        {
            Projectile.ai[1]++;

            float rotateSpeed = 0.35f * (float)Projectile.direction - (Projectile.ai[1] * 0.001f);
            Projectile.rotation += rotateSpeed;

            if (Projectile.ai[1] >= 200)
            {
                Projectile.Kill();
            }

            Lighting.AddLight(Projectile.Center, 1f, 1f, 1f);
        }
    }
}
