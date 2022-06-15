using Terraria;
using Terraria.ModLoader;
using FirstMod.Content.Dusts;
using Microsoft.Xna.Framework;

namespace FirstMod.Content.Projectiles.Weapons
{
    internal class ObamiumWandProjectile : ModProjectile
    {
        public override void SetDefaults()
        {
            Projectile.width = 52;
            Projectile.height = 52;

            Projectile.friendly = true;
            Projectile.tileCollide = false;
            Projectile.ignoreWater = true;

            Projectile.DamageType = DamageClass.Magic;

            Projectile.aiStyle = -1;

            Projectile.penetrate = -1;
        }

        public override void AI()
        {
            Projectile.ai[0]++;
            Projectile.velocity *= 1.03f;
            for (int i = 0; i < 200; i++)
            {
                NPC target = Main.npc[i];
                //If the npc is hostile
                if (!target.friendly)
                {
                    //Get the shoot trajectory from the projectile and target
                    float shootToX = target.position.X + (float)target.width * 0.5f - Projectile.Center.X;
                    float shootToY = target.position.Y - Projectile.Center.Y;
                    float distance = (float)System.Math.Sqrt((double)(shootToX * shootToX + shootToY * shootToY));

                    //If the distance between the live targeted npc and the projectile is less than 480 pixels
                    if (distance < 480f && !target.friendly && target.active)
                    {
                        //Divide the factor, 3f, which is the desired velocity
                        distance = 3f / distance;

                        //Multiply the distance by a multiplier if you wish the projectile to have go faster
                        shootToX *= distance * 3;
                        shootToY *= distance * 3;

                        //Set the velocities to the shoot values
                        Projectile.velocity.X = shootToX;
                        Projectile.velocity.Y = shootToY;
                    }
                }
            }
            if (Projectile.ai[0] >= 300)
            {
                Projectile.Kill();
            }

            float rotateSpeed = 0.25f * (float)Projectile.direction;
            Projectile.rotation += rotateSpeed;

            Lighting.AddLight(Projectile.Center, 1f, 1f, 1f);

            if (Main.rand.NextBool(2))
            {
                int numToSpawn = Main.rand.Next(3);
                for (int i = 0; i < numToSpawn; i++)
                {
                    Dust.NewDust(Projectile.position, Projectile.width, Projectile.height, ModContent.DustType<TutorialDust>(), Projectile.velocity.X * 0.1f, Projectile.velocity.Y * 0.1f,
                        0, default(Color), 1f);
                }
            }
        }
    }
}
