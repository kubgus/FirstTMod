using Terraria;
using Terraria.ModLoader;
using Microsoft.Xna.Framework;
using Terraria.DataStructures;
using Terraria.ObjectData;
using Terraria.Localization;

namespace FirstMod.Content.Tiles
{
    internal class SusBars : ModTile
    {
        public override void SetStaticDefaults()
        {
            Main.tileSolid[Type] = true;
            Main.tileSolidTop[Type] = true;
            Main.tileFrameImportant[Type] = true;
            Main.tileShine[Type] = 1100;

            TileObjectData.newTile.CopyFrom(TileObjectData.Style1x1);
            TileObjectData.newTile.StyleHorizontal = true;
            TileObjectData.newTile.LavaDeath = false;
            TileObjectData.addTile(Type);

            AddMapEntry(new Color(200, 200, 200), Language.GetText("MapObject.MetalBar"));

            MineResist = 1.5f;
            MinPick = 60;
        }

        public override bool Drop(int i, int j)
        {
            Tile t = Main.tile[i, j];
            int style = t.TileFrameX / 18;

            switch(style)
            {
                case 0: Item.NewItem(new EntitySource_TileBreak(i, j), i * 16, j * 16, 16, 16, ModContent.ItemType<Items.Placeables.SusBar>()); break;
            }

            return base.Drop(i, j);
        }
    }
}