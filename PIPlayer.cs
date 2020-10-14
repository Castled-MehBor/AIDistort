﻿using Terraria.GameInput;
using Terraria.ModLoader;
using Terraria;
using Terraria.Localization;
using Microsoft.Xna.Framework;
using Terraria.ID;

namespace AIDistort
{
    public class PIPlayer : ModPlayer
    {
        public bool cht;
        public bool cbt;
        public bool clt;
        public bool rainbow;
        public bool reset;
        public bool resetClick;
        #region 1.4 Dresser Commands
        public bool skinC;
        public bool eyeC;
        #endregion
        #region Recovery of color state
        public int recoverState;
        public Color oldShirt;
        public Color oldunderShirt;
        public Color oldEye;
        public Color oldShoe;
        public Color oldPant;
        public Color oldHair;
        public Color oldSkin;
        #endregion
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
            if (rainbow)
            {
                if (recoverState == 0)
                {
                    recoverState = 1;
                    oldEye = player.eyeColor;
                    oldShirt = player.shirtColor;
                    oldunderShirt = player.underShirtColor;
                    oldSkin = player.skinColor;
                    oldHair = player.hairColor;
                    oldShoe = player.shoeColor;
                    oldPant = player.pantsColor;
                }
                else if (recoverState == 1)
                {
                    float num2 = (float)Main.DiscoR / 255f;
                    float num3 = (float)Main.DiscoG / 255f;
                    float num4 = (float)Main.DiscoB / 255f;
                    num2 *= 1f;
                    num3 *= 1f;
                    num4 *= 1f;
                    player.shirtColor.R = (byte)Main.DiscoR;
                    player.shirtColor.G = (byte)Main.DiscoG;
                    player.shirtColor.B = (byte)Main.DiscoB;
                    player.shirtColor.A = 100;
                    player.eyeColor.R = (byte)Main.DiscoR;
                    player.eyeColor.G = (byte)Main.DiscoG;
                    player.eyeColor.B = (byte)Main.DiscoB;
                    player.eyeColor.A = 100;
                    player.underShirtColor.R = (byte)Main.DiscoR;
                    player.underShirtColor.G = (byte)Main.DiscoG;
                    player.underShirtColor.B = (byte)Main.DiscoB;
                    player.underShirtColor.A = 100;
                    player.pantsColor.R = (byte)Main.DiscoR;
                    player.pantsColor.G = (byte)Main.DiscoG;
                    player.pantsColor.B = (byte)Main.DiscoB;
                    player.pantsColor.A = 100;
                    player.shoeColor.R = (byte)Main.DiscoR;
                    player.shoeColor.G = (byte)Main.DiscoG;
                    player.shoeColor.B = (byte)Main.DiscoB;
                    player.shoeColor.A = 100;
                    player.skinColor.R = (byte)Main.DiscoR;
                    player.skinColor.G = (byte)Main.DiscoG;
                    player.skinColor.B = (byte)Main.DiscoB;
                    player.skinColor.A = 100;
                    player.hairColor.R = (byte)Main.DiscoR;
                    player.hairColor.G = (byte)Main.DiscoG;
                    player.hairColor.B = (byte)Main.DiscoB;
                    player.hairColor.A = 100;
                }
                else if (recoverState == 2)
                {
                    player.eyeColor = oldEye;
                    player.shirtColor = oldShirt;
                    player.underShirtColor = oldunderShirt;
                    player.skinColor = oldSkin;
                    player.hairColor = oldHair;
                    player.shoeColor = oldShoe;
                    player.pantsColor = oldPant;
                    rainbow = false;
                    recoverState = 0;
                }
            }
            if (reset)
            {
                player.delayUseItem = true;
                player.hairColor = new Color(215, 90, 55);
                player.skinColor = new Color(255, 125, 90);
                player.eyeColor = new Color(105, 90, 75);
                player.shirtColor = new Color(175, 165, 140);
                player.underShirtColor = new Color(160, 180, 215);
                player.pantsColor = new Color(255, 230, 175);
                player.shoeColor = new Color(160, 105, 60);
                if (player.Male)
                    player.hair = 0;
                else
                    player.hair = 5;
                if (Main.mouseLeft && !resetClick)
                {
                    resetClick = true;
                    CycleClothingStyle(player);
                }
                if (Main.mouseLeftRelease && resetClick)
                {
                    resetClick = false;
                }
                if (Main.mouseRight)
                {
                    reset = false;
                    player.delayUseItem = false;
                    Main.NewText("Reset Finished!");
                }
            }
        }
        public override void ProcessTriggers(TriggersSet triggersSet)
        {
            if (AIDistort.AIScrambleHotKey.JustPressed && hotkeyCooldown == 0)
            {
                if (Main.netMode != NetmodeID.MultiplayerClient)
                {
                    #region Hotkey
                    if (!ModContent.GetInstance<AIScramblerConfig>().AIScrambleBoolean)
                    {
                        ModContent.GetInstance<AIScramblerConfig>().AIScrambleBoolean = true;
                        if (Main.dedServ)
                        {
                            NetworkText text = NetworkText.FromFormattable("[c/0AFF00:AI Scramble is ON!]");
                            NetMessage.BroadcastChatMessage(text, Color.White);
                        }
                        else
                        {
                            Main.NewText("[c/0AFF00:AI Scramble is ON!]");
                        }
                        if (ModContent.GetInstance<AIScramblerConfig>().HotkeyCooldown)
                        {
                            hotkeyCooldown = 600;
                        }
                    }
                    else if (ModContent.GetInstance<AIScramblerConfig>().AIScrambleBoolean)
                    {
                        ModContent.GetInstance<AIScramblerConfig>().AIScrambleBoolean = false;
                        if (Main.dedServ)
                        {
                            NetworkText text = NetworkText.FromFormattable("[c/FF0000:AI Scramble is OFF!]");
                            NetMessage.BroadcastChatMessage(text, Color.White);
                        }
                        else
                        {
                            Main.NewText("[c/FF0000:AI Scramble is OFF!]");
                        }
                        if (ModContent.GetInstance<AIScramblerConfig>().HotkeyCooldown)
                        {
                            hotkeyCooldown = 600;
                        }
                    }
                    #endregion
                }
                else if (Main.netMode == NetmodeID.MultiplayerClient && ModContent.GetInstance<AIScramblerConfig>().ClientHotkeyPermission)
                {
                    #region Hotkey
                    if (!ModContent.GetInstance<AIScramblerConfig>().AIScrambleBoolean)
                    {
                        ModContent.GetInstance<AIScramblerConfig>().AIScrambleBoolean = true;
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
                    else if (ModContent.GetInstance<AIScramblerConfig>().AIScrambleBoolean)
                    {
                        ModContent.GetInstance<AIScramblerConfig>().AIScrambleBoolean = false;
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
            #region Randomize Player Hotkey
            if (AIDistort.PlayerRandomize.JustPressed && !ModContent.GetInstance<PlayerRandomizeConfig>().NoRandom && !reset)
            {
                ItemLoader.UpdateVanitySet(player);
                if (ModContent.GetInstance<PlayerRandomizeConfig>().RandomizeEyeColor)
                    player.eyeColor = randomizeColor();
                if (ModContent.GetInstance<PlayerRandomizeConfig>().RandomizeSkinColor)
                    player.skinColor = randomizeColor();
                if (ModContent.GetInstance<PlayerRandomizeConfig>().RandomizeShoeColor)
                    player.shoeColor = randomizeColor();
                if (ModContent.GetInstance<PlayerRandomizeConfig>().RandomizePantsColor)
                    player.pantsColor = randomizeColor();
                if (ModContent.GetInstance<PlayerRandomizeConfig>().RandomizeShirtColor)
                    player.shirtColor = randomizeColor();
                if (ModContent.GetInstance<PlayerRandomizeConfig>().RandomizeUndershirtColor)
                    player.underShirtColor = randomizeColor();
                if (ModContent.GetInstance<PlayerRandomizeConfig>().RandomizeHairColor)
                    player.hairColor = randomizeColor();
                if (ModContent.GetInstance<PlayerRandomizeConfig>().RandomizeHair)
                {
                    if (player.name == "The Chosen One")
                    {
                        player.hair = Main.rand.Next(0, 134);
                    }
                    else
                    {
                        if (NPC.savedStylist)
                        {
                            player.hair = Main.rand.Next(0, 124);
                        }
                        else if (NPC.savedStylist && NPC.downedMartians)
                        {
                            player.hair = Main.rand.Next(0, 134);
                        }
                        else if (NPC.savedStylist && NPC.downedMartians && NPC.downedMoonlord)
                        {
                            player.hair = Main.rand.Next(0, 135);
                        }
                        else
                        {
                            player.hair = Main.rand.Next(0, 52);
                        }
                    }
                }
                if (ModContent.GetInstance<PlayerRandomizeConfig>().RandomizeClothes)
                    CycleClothingStyle(player);
                if (ModContent.GetInstance<PlayerRandomizeConfig>().RandomizeGender)
                {
                    int gender = Main.rand.Next(2);
                    if (gender == 0)
                    {
                        player.Male = true;
                        if (ModContent.GetInstance<PlayerRandomizeConfig>().IndicatorAGender)
                            Main.PlaySound(SoundID.PlayerHit, player.position);
                        if (ModContent.GetInstance<PlayerRandomizeConfig>().IndicatorVGender)
                        {
                            for (int i = 0; i < 25; i++)
                            {
                                Vector2 position = player.Center + Vector2.UnitX.RotatedBy(MathHelper.ToRadians(360f / 25 * i));
                                Dust dust = Dust.NewDustPerfect(position, DustID.BlueCrystalShard);
                                dust.noGravity = true;
                                dust.velocity = Vector2.Normalize(dust.position - player.Center) * 4;
                                dust.noLight = false;
                                dust.fadeIn = 1f;
                            }
                        }
                    }
                    if (gender == 1)
                    {
                        player.Male = false;
                        if (ModContent.GetInstance<PlayerRandomizeConfig>().IndicatorAGender)
                            Main.PlaySound(SoundID.FemaleHit, player.position);
                        if (ModContent.GetInstance<PlayerRandomizeConfig>().IndicatorVGender)
                        {
                            for (int i = 0; i < 25; i++)
                            {
                                Vector2 position = player.Center + Vector2.UnitX.RotatedBy(MathHelper.ToRadians(360f / 25 * i));
                                Dust dust = Dust.NewDustPerfect(position, DustID.PinkCrystalShard);
                                dust.noGravity = true;
                                dust.velocity = Vector2.Normalize(dust.position - player.Center) * 4;
                                dust.noLight = false;
                                dust.fadeIn = 1f;
                            }
                        }
                    }
                }
            }
            #endregion
            if (AIDistort.ButcherHotKey.JustReleased && !AIWorld.butcher)
            {
                AIWorld.butcher = true;
            }
        }
        #region Clear Texture Command
        public override void FrameEffects()
        {
            if (cbt)
                if (player.Male)
                {
                    player.body = mod.GetEquipSlot("EmptyBody", EquipType.Body);
                }
            if (clt)
                player.legs = mod.GetEquipSlot("EmptyLegs", EquipType.Legs);
            if (cht)
                player.head = mod.GetEquipSlot("EmptyHead", EquipType.Head);
        }
        #endregion
        public Color randomizeColor()
        {
            int num = 0;
            int num2 = 0;
            int num3 = 0;
            while (num + num3 + num2 <= 150)
            {
                num = Main.rand.Next(256);
                num2 = Main.rand.Next(256);
                num3 = Main.rand.Next(256);
            }
            return new Color(num, num2, num3, 255);
        }
        private static void CycleClothingStyle(Player plr)
        {
            if (plr.Male)
            {
                int num = 0;
                int[] variantOrderMale = PlayerVariantID.Sets.VariantOrderMale;
                int num2 = 0;
                while (num2 < variantOrderMale.Length)
                {
                    if (variantOrderMale[num2] != plr.skinVariant)
                    {
                        num2++;
                        continue;
                    }
                    num = num2;
                    break;
                }
                if (num == variantOrderMale.Length - 1)
                {
                    plr.skinVariant = variantOrderMale[0];
                }
                else
                {
                    plr.skinVariant = variantOrderMale[num + 1];
                }
            }
            else
            {
                int num3 = 0;
                int[] variantOrderFemale = PlayerVariantID.Sets.VariantOrderFemale;
                int num4 = 0;
                while (num4 < variantOrderFemale.Length)
                {
                    if (variantOrderFemale[num4] != plr.skinVariant)
                    {
                        num4++;
                        continue;
                    }
                    num3 = num4;
                    break;
                }
                if (num3 == variantOrderFemale.Length - 1)
                {
                    plr.skinVariant = variantOrderFemale[0];
                }
                else
                {
                    plr.skinVariant = variantOrderFemale[num3 + 1];
                }
            }
        }
    }
}