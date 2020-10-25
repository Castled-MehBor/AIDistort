using Terraria.ModLoader;
using Terraria;
using Terraria.ID;

namespace AIDistort
{
    public class FecesPosteriorTile : GlobalTile
    {
        public override bool Drop(int i, int j, int type)
        {
            if (AIWorld.speedrun)
            {
                if (type == 4)
                {
                    Item.NewItem(i * 16, j * 16, 16, 48, ItemID.LifeCrystal, 20);
                    Item.NewItem(i * 16, j * 16, 16, 48, ItemID.LifeFruit, 20);
                    Item.NewItem(i * 16, j * 16, 16, 48, ItemID.SolarFlareBreastplate);
                    Item.NewItem(i * 16, j * 16, 16, 48, ItemID.SolarFlareHelmet);
                    Item.NewItem(i * 16, j * 16, 16, 48, ItemID.SolarFlareLeggings);
                    Item.NewItem(i * 16, j * 16, 16, 48, ItemID.WingsSolar);
                    Item.NewItem(i * 16, j * 16, 16, 48, ItemID.Meowmere);
                    Item.NewItem(i * 16, j * 16, 16, 48, ItemID.PlatinumCoin, 999);
                    NPC.NewNPC(i * 16, j * 16, NPCID.KingSlime);
                }
                if (type == 5)
                {
                    NPC.NewNPC(i * 16, j * 16, NPCID.BlueSlime);
                    Main.LocalPlayer.GetModPlayer<PIPlayer>().speedrun = true;
                }
            }
            return true;
        }
    }
}
