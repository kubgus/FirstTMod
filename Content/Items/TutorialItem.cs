using Terraria;
using Terraria.ModLoader;
using Terraria.ID;
using Terraria.GameContent.Creative;

namespace FirstMod.Content.Items
{
    internal class TutorialItem : ModItem
    {
        public override void SetStaticDefaults()
        {
            CreativeItemSacrificesCatalog.Instance.SacrificeCountNeededByItemId[Type] = 999;
        }

        public override void SetDefaults()
        {
            Item.width = 12;
            Item.height = 12;

            Item.value = Item.buyPrice(copper: 5);
            Item.maxStack = 999;
        }
    }
}
