﻿using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using Terraria.UI;
using Microsoft.Xna.Framework;
using IL.Terraria.GameInput;

namespace AIDistort
{
    class CHT : ModCommand //Clear Head Texture
    {
        public override CommandType Type
        {
            get { return CommandType.Chat; }
        }

        public override string Command
        {
            get { return "ClearHead"; }
        }

        public override string Description
        {
            get { return "Clears the player's head texture. Only works in Singleplayer"; }
        }

        public override void Action(CommandCaller caller, string input, string[] args)
        {
            if (Main.netMode == NetmodeID.SinglePlayer)
            {
                Player player = Main.player[Main.myPlayer];
                if (!player.GetModPlayer<PIPlayer>().cht)
                {
                    player.GetModPlayer<PIPlayer>().cht = true;
                }
                else if (player.GetModPlayer<PIPlayer>().cht)
                {
                    player.GetModPlayer<PIPlayer>().cht = false;
                }
            }
        }
    }
    class CBT : ModCommand //Clear Body Texture
    {
        public override CommandType Type
        {
            get { return CommandType.Chat; }
        }

        public override string Command
        {
            get { return "ClearBody"; }
        }

        public override string Description
        {
            get { return "Clears the player's body texture. Only works in Singleplayer"; }
        }

        public override void Action(CommandCaller caller, string input, string[] args)
        {
            if (Main.netMode == NetmodeID.SinglePlayer)
            {
                Player player = Main.player[Main.myPlayer];
                if (!player.GetModPlayer<PIPlayer>().cbt)
                {
                    if (player.Male)
                    {
                        player.GetModPlayer<PIPlayer>().cbt = true;
                    }
                    else
                    {
                        Main.NewText("No.");
                    }
                }
                else if (player.GetModPlayer<PIPlayer>().cbt)
                {
                    player.GetModPlayer<PIPlayer>().cbt = false;
                }
            }
        }
    }
    class CLT : ModCommand //Clear Leg Texture
    {
        public override CommandType Type
        {
            get { return CommandType.Chat; }
        }

        public override string Command
        {
            get { return "ClearLeg"; }
        }

        public override string Description
        {
            get { return "Clears the player's leg texture. Only works in Singleplayer"; }
        }

        public override void Action(CommandCaller caller, string input, string[] args)
        {
            if (Main.netMode == NetmodeID.SinglePlayer)
            {
                Player player = Main.player[Main.myPlayer];
                if (!player.GetModPlayer<PIPlayer>().clt)
                {
                    player.GetModPlayer<PIPlayer>().clt = true;
                }
                else if (player.GetModPlayer<PIPlayer>().clt)
                {
                    player.GetModPlayer<PIPlayer>().clt = false;
                }
            }
        }
    }
    class RainbowChar : ModCommand //Rainbow Character lol
    {
        public override CommandType Type
        {
            get { return CommandType.Chat; }
        }

        public override string Command
        {
            get { return "RainbowChar"; }
        }

        public override string Description
        {
            get { return "Your character will be infused with rainbow"; }
        }

        public override void Action(CommandCaller caller, string input, string[] args)
        {
            Player player = Main.player[Main.myPlayer];
            if (!player.GetModPlayer<PIPlayer>().rainbow)
            {
                player.GetModPlayer<PIPlayer>().rainbow = true;
            }
            else if (player.GetModPlayer<PIPlayer>().rainbow)
            {
                player.GetModPlayer<PIPlayer>().recoverState = 2;
            }
        }
    }
    class ResetChar : ModCommand //Reset Character to Original state
    {
        public override CommandType Type
        {
            get { return CommandType.Chat; }
        }

        public override string Command
        {
            get { return "Reset"; }
        }

        public override string Description
        {
            get { return "Resets your character to it's original state"; }
        }

        public override void Action(CommandCaller caller, string input, string[] args)
        {
            Player player = Main.player[Main.myPlayer];
            player.GetModPlayer<PIPlayer>().reset = true;
            Main.NewText("Left Click to change clothes style.");
            Main.NewText("Right Click to stop");
        }
    }
    class SetEye : ModCommand
    {
        public override CommandType Type
        {
            get { return CommandType.Chat; }
        }

        public override string Command
        {
            get { return "seteye"; }
        }

        public override void Action(CommandCaller caller, string input, string[] args)
        {
            Main.player[Main.myPlayer].eyeColor = ModContent.GetInstance<PlayerRandomizeConfig>().SetColor;
        }
    }
    class SetSkin : ModCommand
    {
        public override CommandType Type
        {
            get { return CommandType.Chat; }
        }

        public override string Command
        {
            get { return "setskin"; }
        }

        public override void Action(CommandCaller caller, string input, string[] args)
        {
            Main.player[Main.myPlayer].skinColor = ModContent.GetInstance<PlayerRandomizeConfig>().SetColor;
        }
    }
    #region Feces Posterior
    class Speedrun : ModCommand
    {
        public override CommandType Type
        {
            get { return CommandType.Chat; }
        }

        public override string Command
        {
            get { return "speedrun"; }
        }

        public override void Action(CommandCaller caller, string input, string[] args)
        {
            if (!AIWorld.speedrun)
            {
                AIWorld.speedrun = true;
                Player player = Main.player[Main.myPlayer];
                CombatText.NewText(player.getRect(), Color.Yellow, "Hey Feces Posterior, wanna see me speedrun?", false, false);
            }
            else
            {
                AIWorld.speedrun = false;
            }
        }
    }
    class ResetFlag : ModCommand
    {
        public override CommandType Type
        {
            get { return CommandType.Chat; }
        }

        public override string Command
        {
            get { return "resetflag"; }
        }

        public override void Action(CommandCaller caller, string input, string[] args)
        {
            NPC.downedSlimeKing = false;
            NPC.downedBoss1 = false;
            NPC.downedBoss2 = false;
            NPC.downedQueenBee = false;
            NPC.downedBoss3 = false;
            Main.hardMode = false;
            NPC.downedMechBoss1 = false;
            NPC.downedMechBoss2 = false;
            NPC.downedMechBoss3 = false;
            NPC.downedFishron = false;
            NPC.downedPlantBoss = false;
            NPC.downedGolemBoss = false;
            NPC.downedAncientCultist = false;
            NPC.downedMoonlord = false;
        }
    }
    #endregion
}