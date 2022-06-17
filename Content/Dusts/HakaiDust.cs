using Terraria;
using Terraria.ModLoader;

namespace FirstMod.Content.Dusts
{
    internal class HakaiDust : ModDust
    {
        public override void OnSpawn(Dust dust)
        {
            dust.noGravity = true;
            dust.noLight = true;
        }

        public override bool Update(Dust dust)
        {
            dust.velocity.Y -= 0.05f;
            dust.position += dust.velocity;
            dust.scale *= 0.99f;
            if (dust.scale < 0.5f)
            {
                dust.active = false;
            }

            Lighting.AddLight(dust.position, 1f, 1f, 1f);

            return false;
        }
    }
}