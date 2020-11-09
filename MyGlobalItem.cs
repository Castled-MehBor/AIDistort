using Terraria;
using Terraria.ModLoader;

namespace AIDistort
{
    public class MyGlobalItem : GlobalItem
    {
        public override bool InstancePerEntity => true;
        public override GlobalItem NewInstance(Item item)
        {
            int boxType = ModContent.GetInstance<AIScramblerConfig>().SlimeBoxType;

            if (boxType > 1)
            {
                if (!AIDistort.accessoryList.Contains(item.type))
                {
                    //"None", "Any Item", "Accessories", "Consumable", "Weapons", "Placeables", "Miscellaneous"
                    if (boxType == 2 && item.accessory)
                        AIDistort.accessoryList.Add(item.type);
                    if (boxType == 3 && item.consumable)
                        AIDistort.accessoryList.Add(item.type);
                    if (boxType == 4 && item.damage > 0)
                        AIDistort.accessoryList.Add(item.type);
                    if (boxType == 5 && item.createTile != -1)
                        AIDistort.accessoryList.Add(item.type);
                    if (boxType == 6)
                        AIDistort.accessoryList.Add(item.type);
                }
            }

            return base.NewInstance(item);
        }
    }
}
