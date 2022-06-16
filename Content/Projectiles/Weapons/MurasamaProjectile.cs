using Terraria;
using Terraria.ModLoader;
using Microsoft.Xna.Framework;

namespace FirstMod.Content.Projectiles.Weapons
{
    internal class MurasamaProjectile : ModProjectile
    {
        public override void SetStaticDefaults()
        {
            Main.projFrames[Projectile.type] = 13; //The number of frames the sprite sheet has
        }

        public override void SetDefaults()
        {
            Projectile.width = 480;
            Projectile.height = 392;

            Projectile.friendly = true;
            Projectile.ignoreWater = true;
            Projectile.tileCollide = false;

            Projectile.DamageType = DamageClass.Melee;

            Projectile.aiStyle = -1;

            Projectile.penetrate = -1;
        }

        public override void AI()
        {
            Projectile.ai[0]++;
            //This will cycle through all of the frames in the sprite sheet
            int frameSpeed = 2; //How fast you want it to animate
            Projectile.frameCounter++;
            if (Projectile.frameCounter >= frameSpeed)
            {
                Projectile.frameCounter = 0;
                Projectile.frame++;
                if (Projectile.frame >= Main.projFrames[Projectile.type])
                {
                    Projectile.frame = 0;
                }
            }

            
            if (Main.player[Projectile.owner].direction < 0)
            {
                Projectile.position.X = Main.player[Projectile.owner].position.X - Projectile.width + Main.player[Projectile.owner].width * 4;
            } else {
                Projectile.position.X = Main.player[Projectile.owner].position.X - Main.player[Projectile.owner].width * 4;
            }
            Projectile.position.Y = Main.player[Projectile.owner].position.Y - Projectile.height / 2;
            Projectile.spriteDirection = Main.player[Projectile.owner].direction;
            Projectile.rotation = Projectile.velocity.ToRotation() + MathHelper.PiOver2 - MathHelper.PiOver4 * Projectile.spriteDirection;

            if (Projectile.ai[0] >= 20)
            {
                Projectile.Kill();
            }
        }
    }
}
