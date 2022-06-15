using Terraria;
using Terraria.ModLoader;
using Terraria.IO;
using Terraria.WorldBuilding;
using FirstMod.Content.Tiles;
using Terraria.ID;

namespace FirstMod.Common.Systems.GenPasses
{
    internal class OreGenPass : GenPass
    {
        public OreGenPass(string name, float weight) : base(name, weight) { }

        protected override void ApplyPass(GenerationProgress progress, GameConfiguration configuration)
        {
            progress.Message = "Spawning Sussy Ores";

            int maxToSpawn;
            int numSpawned;
            int attempts;

            // Sus Ore
            maxToSpawn = (int)(Main.maxTilesX * Main.maxTilesY * 3E-04);
            for (int i = 0; i < maxToSpawn; i++)
            {
                int x = WorldGen.genRand.Next(100, Main.maxTilesX - 100);
                int y = WorldGen.genRand.Next((int)WorldGen.worldSurface, Main.maxTilesY - 300);

                WorldGen.TileRunner(x, y, WorldGen.genRand.Next(3, 6), WorldGen.genRand.Next(2, 5), ModContent.TileType<SusOre>());
            }

            // Obamium Ore
            maxToSpawn = WorldGen.genRand.Next(750, 1000);
            numSpawned = 0;
            attempts = 0;
            while (numSpawned < maxToSpawn)
            {
                int x = WorldGen.genRand.Next(0, Main.maxTilesX);
                int y = WorldGen.genRand.Next(0, (int)WorldGen.worldSurface);

                Tile tile = Framing.GetTileSafely(x, y);
                if (tile.TileType == TileID.Cloud)
                {
                    WorldGen.TileRunner(x, y, WorldGen.genRand.Next(5, 10), WorldGen.genRand.Next(10, 15), ModContent.TileType<ObamiumOre>());
                    numSpawned++;
                }

                attempts++;
                if (attempts >= 10000000)
                {
                    break;
                }
            }
        }
    }
}