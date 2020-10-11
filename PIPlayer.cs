using Terraria.GameInput;
using Terraria.ModLoader;
using Terraria;
using Terraria.Localization;
using Microsoft.Xna.Framework;
using Terraria.ID;

namespace AIDistort
{
    public class PIPlayer : ModPlayer
    {
        public int hotkeyCooldown;
        public override void PostUpdateEquips()
        {
            if (hotkeyCooldown < 1)
            {
                hotkeyCooldown = 0;
            }
            if (hotkeyCooldown > 0)
            {
                hotkeyCooldown--;
            }
        }
        public override void ProcessTriggers(TriggersSet triggersSet)
        {
            if (AIDistort.AIScrambleHotKey.JustPressed && hotkeyCooldown == 0)
            {
                if (Main.netMode != NetmodeID.MultiplayerClient)
                {
                    #region Hotkey
                    if (!ModContent.GetInstance<AIConfig>().AIScrambleBoolean)
                    {
                        ModContent.GetInstance<AIConfig>().AIScrambleBoolean = true;
                        if (Main.dedServ)
                        {
                            NetworkText text = NetworkText.FromFormattable("[c/0AFF00:AI Scramble is ON!]");
                            NetMessage.BroadcastChatMessage(text, Color.White);
                        }
                        else
                        {
                            Main.NewText("[c/0AFF00:AI Scramble is ON!]");
                        }
                        if (ModContent.GetInstance<AIConfig>().HotkeyCooldown)
                        {
                            hotkeyCooldown = 600;
                        }
                    }
                    else if (ModContent.GetInstance<AIConfig>().AIScrambleBoolean)
                    {
                        ModContent.GetInstance<AIConfig>().AIScrambleBoolean = false;
                        if (Main.dedServ)
                        {
                            NetworkText text = NetworkText.FromFormattable("[c/FF0000:AI Scramble is OFF!]");
                            NetMessage.BroadcastChatMessage(text, Color.White);
                        }
                        else
                        {
                            Main.NewText("[c/FF0000:AI Scramble is OFF!]");
                        }
                        if (ModContent.GetInstance<AIConfig>().HotkeyCooldown)
                        {
                            hotkeyCooldown = 600;
                        }
                    }
                    #endregion
                }
                else if (Main.netMode == NetmodeID.MultiplayerClient && ModContent.GetInstance<AIConfig>().ClientHotkeyPermission)
                {
                    #region Hotkey
                    if (!ModContent.GetInstance<AIConfig>().AIScrambleBoolean)
                    {
                        ModContent.GetInstance<AIConfig>().AIScrambleBoolean = true;
                        if (Main.dedServ)
                        {
                            NetworkText text = NetworkText.FromFormattable("[c/0AFF00:AI Scramble is ON!]");
                            NetMessage.BroadcastChatMessage(text, Color.White);
                        }
                        else
                        {
                            Main.NewText("[c/0AFF00:AI Scramble is ON!]");
                        }
                        hotkeyCooldown = 600;
                    }
                    else if (ModContent.GetInstance<AIConfig>().AIScrambleBoolean)
                    {
                        ModContent.GetInstance<AIConfig>().AIScrambleBoolean = false;
                        if (Main.dedServ)
                        {
                            NetworkText text = NetworkText.FromFormattable("[c/FF0000:AI Scramble is OFF!]");
                            NetMessage.BroadcastChatMessage(text, Color.White);
                        }
                        else
                        {
                            Main.NewText("[c/FF0000:AI Scramble is OFF!]");
                        }
                        hotkeyCooldown = 600;
                    }
                    #endregion
                }
            }
        }
    }
}