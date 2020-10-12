using Terraria.ModLoader;
using Terraria;
using Terraria.ID;
using System;
using System.Collections.Generic;
using static Terraria.ModLoader.ModContent;

namespace AIDistort.NPCs
{
	public class AIDistortion : GlobalNPC
	{
        private bool aiChanged;
        public override bool InstancePerEntity => true;
        public readonly static List<int> dangerousAI = new List<int>()
        {
            20,
            27,
            28,
            37,
            51,
            52,
            53
        };
        public readonly static List<int> commonSlime = new List<int>()
        {
            1,
            -3,
            -4,
            -5,
            -6,
            -7,
            -8,
            -9,
            -10
        };
        public override void SetupShop(int type, Chest shop, ref int nextSlot)
        {
            bool randomShop = GetInstance<AIScramblerConfig>().ShopRandomBoolean;
            int priceScale = GetInstance<AIScramblerConfig>().ShopRandomScale;
            if (randomShop)
            {
                for (int i = 0; i < 49; i++)
                {
                    shop.item[nextSlot].SetDefaults(Main.rand.Next(0, 3630));
                    shop.item[nextSlot].value = Main.rand.Next(0, 1000000 * priceScale);
                    nextSlot++;
                }
            }
        }
        public override void AI(NPC npc)
        {
            bool doScramble = GetInstance<AIScramblerConfig>().AIScrambleBoolean;
            bool civilianScramble = GetInstance<AIScramblerConfig>().TownNPCBoolean;
            bool resetRare = GetInstance<AIScramblerConfig>().VersionTwoScrambler;
            bool crashPrevent = GetInstance<AIScramblerConfig>().CrashPreventBoolean;
            //bool gamer = GetInstance<AIScramblerConfig>().GameplayBoolean;
            bool slimeBox = GetInstance<AIScramblerConfig>().SlimeBoxBoolean;
            bool aiStyleChange = GetInstance<AIScramblerConfig>().AIStyleRandomizer;
            bool rainbow = GetInstance<AIScramblerConfig>().PrideBoolean;
            int aiDelay = GetInstance<AIScramblerConfig>().AIStyleRandomizerDelay; //Has been changed to an AI Style lock
            //Common Slime: if (npc.type == NPCID.BlueSlime || npc.type == NPCID.GreenSlime || npc.type == NPCID.PurpleSlime || npc.type == NPCID.YellowSlime || npc.type == NPCID.RedSlime || npc.type == NPCID.BlackSlime || npc.type == NPCID.JungleSlime || npc.type == NPCID.BabySlime || npc.type == NPCID.Pinky)
            //Dangerous AI Styles: if (npc.aiStyle != 20 || npc.aiStyle != 27 || npc.aiStyle != 28 || npc.aiStyle != 51 || npc.aiStyle != 52 || npc.aiStyle != 53)
            //Gameplay AI Styles: if (npc.aiStyle != 6 || npc.aiStyle != 37 || npc.aiStyle != 54 || npc.aiStyle != 77 || npc.aiStyle != 60 || npc.aiStyle != 84 || npc.aiStyle != 105 || npc.aiStyle != 106)

            #region npc.ai[#]
            /*
            float npc.ai[0] = npc.ai[0];
            float npc.ai[1] = npc.ai[1];
            float npc.ai[2] = npc.ai[2];
            float npc.ai[3] = npc.ai[3];
            }*/
            #endregion
            #region npc.localAI[#]
            /*
            float aiL0 = npc.localAI[0];
            float aiL1 = npc.localAI[1];
            float aiL2 = npc.localAI[2];
            float aiL3 = npc.localAI[3];
            }*/
            #endregion
            if (AIWorld.butcher)
            {
                npc.life = -9999;
                npc.checkDead();
                AIWorld.butcher = false;
            }

            if (!civilianScramble)
            {
                if (crashPrevent)
                {
                    if (!Main.dedServ && doScramble && !npc.townNPC && Main.frameRate > GetInstance<AIScramblerConfig>().FrameLockInt && !dangerousAI.Contains(npc.aiStyle))
                    {
                        #region Scrambler
                        npc.localAI[0] = (float)Math.Pow(npc.ai[0], npc.localAI[2]);
                        npc.localAI[1] = (float)Math.Sqrt(Main.rand.Next(1, 9999));
                        npc.localAI[2] = (float)Math.Pow(npc.localAI[1], 1 / Main.rand.Next(1, 99));
                        npc.localAI[3] = npc.ai[0] + npc.ai[1] * npc.ai[2] / npc.ai[3];
                        if (Main.rand.Next(699) == 0)
                        {
                            int localBub = Main.rand.Next(4);
                            if (localBub == 0)
                            {
                                npc.localAI[0] = 0;
                            }
                            if (localBub == 1)
                            {
                                npc.localAI[1] = 0;
                            }
                            if (localBub == 2)
                            {
                                npc.localAI[2] = 0;
                            }
                            if (localBub == 3)
                            {
                                npc.localAI[3] = 0;
                            }
                        }
                        /*
                        npc.ai[0] = npc.ai[0];
                        npc.ai[1] = npc.ai[1];
                        npc.ai[2] = npc.ai[2];
                        npc.ai[3] = npc.ai[3];
                        }*/
                        #region npc.ai[#] Scramble
                        /*
                         * npc.ai 0 to 3
                         * The formula could go as so:
                         }*/
                        #region npc.ai[0] Scramble
                        /* AI 0:
                        * Choose between the 7 following:
                        * 1) Multiply by the quotient of npc.ai[1] / 10 to 1080
                        * 2) Square root
                        * 3) Add by the sum of npc.ai[2] and npc
                        * 4) Divide by npc.ai[3] to the power of numbers 2 to 99
                        * 5) Subtract by npc.ai[1] times 15
                        * 6) set to the power of itself
                        * 7) set to 0
                        }*/
                        int blank = Main.rand.Next(7);
                        if (blank == 0)
                        {
                            //1) Multiply by the quotient of npc.ai[1] / 10 to 1080
                            npc.ai[0] *= npc.ai[1] / Main.rand.Next(10, 1080);
                        }
                        if (blank == 1)
                        {
                            //2) Square root
                            npc.ai[0] = (float)Math.Sqrt(npc.ai[0]);
                        }
                        if (blank == 2)
                        {
                            //3) Add by the sum of npc.ai[2] and npc
                            npc.ai[0] += npc.ai[2] + npc.ai[0];
                        }
                        if (blank == 3)
                        {
                            //4) Divide by npc.ai[3] to the power of numbers 2 to 99
                            npc.ai[0] /= (float)Math.Pow(npc.ai[3], Main.rand.Next(2, 99));
                        }
                        if (blank == 4)
                        {
                            //5) Subtract by npc.ai[1] times 15
                            npc.ai[0] -= npc.ai[1] * 15;
                        }
                        if (blank == 5)
                        {
                            //6) set to the power of itself
                            npc.ai[0] = (float)Math.Pow(npc.ai[0], npc.ai[0]);
                        }
                        if (blank == 6)
                        {
                            if (resetRare)
                            {
                                if (Main.rand.Next(9) == 0)
                                {
                                    //7) set to 0
                                    npc.ai[0] = 0;
                                }
                            }
                            else
                            {
                                npc.ai[0] = 0;
                            }
                        }
                        #endregion
                        #region npc.ai[1] Scramble
                        /* AI 1:
                        * 1) Multiply by either -1 or 1
                        * 2) to the root of npc.ai[0]
                        * 3) Multiply by the remainder of npc.ai[2] divided by 17
                        * 4) Add by the difference of npc.ai[3] and itself
                        * 5) Subtract by the product of npc.ai[0] by the numbers -999 to 999
                        * 6) Set to 0
                        * 7) Set equal to npc.ai[2]
                        }*/
                        if (!commonSlime.Contains(npc.type))
                        {
                            int uno = Main.rand.Next(7);
                            if (uno == 0)
                            {
                                //1) Multiply by either -1 or 1
                                npc.ai[1] *= Main.rand.Next(-2, 2);
                            }
                            if (uno == 1)
                            {
                                //2) to the root of npc.ai[0]
                                //Scalie: express it as a fractional exponent instead and use Math.Pow
                                npc.ai[1] = (float)Math.Pow(npc.ai[1], 1 / npc.ai[0]);
                            }
                            if (uno == 2)
                            {
                                //3) Multiply by the remainder of npc.ai[2] divided by 17
                                npc.ai[1] *= npc.ai[2] % 17;
                            }
                            if (uno == 3)
                            {
                                //4) Add by the difference of npc.ai[3] and itself
                                npc.ai[1] += npc.ai[3] - npc.ai[1];
                            }
                            if (uno == 4)
                            {
                                //5) Subtract by the product of npc.ai[0] by the numbers -999 to 999
                                npc.ai[1] -= npc.ai[0] * Main.rand.Next(-1000, 1000);
                            }
                            if (uno == 5)
                            {
                                if (resetRare)
                                {
                                    if (Main.rand.Next(9) == 0)
                                    {
                                        //6) set to 0
                                        npc.ai[1] = 0;
                                    }
                                }
                                else
                                {
                                    npc.ai[1] = 0;
                                }
                            }
                            if (uno == 6)
                            {
                                //7) Set equal to npc.ai[2]
                                npc.ai[1] = npc.ai[2];
                            }

                            #endregion
                        }

                        #region npc.ai[2] Scramble
                        /* AI 2:
                        * 1) Divide by either -2 or 2
                        * 2) to the power of npc.ai[3]
                        * 3) set to the remainder of npc.ai[1] divided by npc.ai[3]
                        * 4) add by the sum of npc.ai[0] and 69
                        * 5) Set to 0
                        * 6) set equal to the cube of npc.ai[0]
                        * 7) set to the square of numbers -190 or 190
                       }*/
                        int dos = Main.rand.Next(7);
                        if (dos == 0)
                        {
                            //1) Divide by either -2 or 2
                            npc.ai[2] /= Main.rand.Next(-3, 3);
                        }
                        if (dos == 1)
                        {
                            //2) to the power of npc.ai[3]
                            npc.ai[2] = (float)Math.Pow(npc.ai[2], npc.ai[3]);
                        }
                        if (dos == 2)
                        {
                            //3) set to the remainder of npc.ai[1] divided by npc.ai[3]
                            npc.ai[2] = npc.ai[1] % npc.ai[3];
                        }
                        if (dos == 3)
                        {
                            //4) add by the sum of npc.ai[0] and 69
                            npc.ai[2] += npc.ai[0] + 69;
                        }
                        if (dos == 4)
                        {
                            if (resetRare)
                            {
                                if (Main.rand.Next(9) == 0)
                                {
                                    //5) set to 0
                                    npc.ai[2] = 0;
                                }
                            }
                            else
                            {
                                npc.ai[2] = 0;
                            }

                        }
                        if (dos == 5)
                        {
                            //6) set equal to the cube of npc.ai[0]
                            npc.ai[2] = (float)Math.Pow(npc.ai[0], 3);
                        }
                        if (dos == 6)
                        {
                            //7) set to the square of numbers -190 or 190
                            npc.ai[2] = (float)Math.Pow(Main.rand.Next(-191, 191), 2);
                        }
                        #endregion
                        #region npc.ai[3] Scramble
                        /* AI 3:
                        * 1) Cube root or set to the cube
                        * 2) add by the remainder of npc.ai[2] and numbers -999 to 999
                        * 3) set to 0
                        * 4) Subtract by the sum of npc.ai[1], npc.ai[2] and the difference of npc.ai[0] and the numbers -9 to 9
                        * 5) set to the square root of numbers -190 to 190
                        * 6) set to 8
                        * 7) set to -8
                        * 
                       }*/
                        int trentos = Main.rand.Next(7);
                        if (trentos == 0)
                        {
                            //1) Cube root or set to the cube
                            int cubo = Main.rand.Next(2);
                            if (cubo == 0)
                            {
                                npc.ai[3] = (float)Math.Pow(npc.ai[3], 1 / 3);
                            }
                            if (cubo == 1)
                            {
                                npc.ai[3] = (float)Math.Pow(npc.ai[3], 3);
                            }
                        }
                        if (trentos == 1)
                        {
                            //2) add by the remainder of npc.ai[2] and numbers -999 to 999
                            npc.ai[3] += npc.ai[2] % Main.rand.Next(-1000, 1000);
                        }
                        if (trentos == 2)
                        {
                            if (resetRare)
                            {
                                if (Main.rand.Next(9) == 0)
                                {
                                    //3) set to 0
                                    npc.ai[3] = 0;
                                }
                            }
                            else
                            {
                                npc.ai[3] = 0;
                            }
                        }
                        if (trentos == 3)
                        {
                            //4) Subtract by the sum of npc.ai[1], npc.ai[2] and the difference of npc.ai[0] and the numbers -9 to 9
                            npc.ai[3] -= npc.ai[1] + npc.ai[2] + (npc.ai[0] - Main.rand.Next(-10, 10));
                        }
                        if (trentos == 4)
                        {
                            //5) set to the square root of numbers -190 to 190
                            npc.ai[3] = (float)Math.Sqrt(Main.rand.Next(-191, 191));
                        }
                        if (trentos == 5)
                        {
                            //6) set to npc.ai[1]
                        }
                        if (trentos == 6)
                        {
                            //7) if npc.ai[3] is the radius, find the area of an imaginary circle :kek:
                            npc.ai[3] = (float)(Math.PI * Math.Pow(npc.ai[3], 2));
                        }
                        #endregion
                        #endregion
                        #endregion
                    }
                }
                else if (!Main.dedServ && doScramble && !npc.townNPC && Main.frameRate > GetInstance<AIScramblerConfig>().FrameLockInt)
                {
                    #region Scrambler
                    npc.localAI[0] = (float)Math.Pow(npc.ai[0], npc.localAI[2]);
                    npc.localAI[1] = (float)Math.Sqrt(Main.rand.Next(1, 9999));
                    npc.localAI[2] = (float)Math.Pow(npc.localAI[1], 1 / Main.rand.Next(1, 99));
                    npc.localAI[3] = npc.ai[0] + npc.ai[1] * npc.ai[2] / npc.ai[3];
                    if (Main.rand.Next(699) == 0)
                    {
                        int localBub = Main.rand.Next(4);
                        if (localBub == 0)
                        {
                            npc.localAI[0] = 0;
                        }
                        if (localBub == 1)
                        {
                            npc.localAI[1] = 0;
                        }
                        if (localBub == 2)
                        {
                            npc.localAI[2] = 0;
                        }
                        if (localBub == 3)
                        {
                            npc.localAI[3] = 0;
                        }
                    }
                    /*
                    npc.ai[0] = npc.ai[0];
                    npc.ai[1] = npc.ai[1];
                    npc.ai[2] = npc.ai[2];
                    npc.ai[3] = npc.ai[3];
                    }*/
                    #region npc.ai[#] Scramble
                    /*
                     * npc.ai 0 to 3
                     * The formula could go as so:
                     }*/
                    #region npc.ai[0] Scramble
                    /* AI 0:
                    * Choose between the 7 following:
                    * 1) Multiply by the quotient of npc.ai[1] / 10 to 1080
                    * 2) Square root
                    * 3) Add by the sum of npc.ai[2] and npc
                    * 4) Divide by npc.ai[3] to the power of numbers 2 to 99
                    * 5) Subtract by npc.ai[1] times 15
                    * 6) set to the power of itself
                    * 7) set to 0
                    }*/
                    int blank = Main.rand.Next(7);
                    if (blank == 0)
                    {
                        //1) Multiply by the quotient of npc.ai[1] / 10 to 1080
                        npc.ai[0] *= npc.ai[1] / Main.rand.Next(10, 1080);
                    }
                    if (blank == 1)
                    {
                        //2) Square root
                        npc.ai[0] = (float)Math.Sqrt(npc.ai[0]);
                    }
                    if (blank == 2)
                    {
                        //3) Add by the sum of npc.ai[2] and npc
                        npc.ai[0] += npc.ai[2] + npc.ai[0];
                    }
                    if (blank == 3)
                    {
                        //4) Divide by npc.ai[3] to the power of numbers 2 to 99
                        npc.ai[0] /= (float)Math.Pow(npc.ai[3], Main.rand.Next(2, 99));
                    }
                    if (blank == 4)
                    {
                        //5) Subtract by npc.ai[1] times 15
                        npc.ai[0] -= npc.ai[1] * 15;
                    }
                    if (blank == 5)
                    {
                        //6) set to the power of itself
                        npc.ai[0] = (float)Math.Pow(npc.ai[0], npc.ai[0]);
                    }
                    if (blank == 6)
                    {
                        if (resetRare)
                        {
                            if (Main.rand.Next(9) == 0)
                            {
                                //7) set to 0
                                npc.ai[0] = 0;
                            }
                        }
                        else
                        {
                            npc.ai[0] = 0;
                        }
                    }
                    #endregion
                    #region npc.ai[1] Scramble
                    /* AI 1:
                    * 1) Multiply by either -1 or 1
                    * 2) to the root of npc.ai[0]
                    * 3) Multiply by the remainder of npc.ai[2] divided by 17
                    * 4) Add by the difference of npc.ai[3] and itself
                    * 5) Subtract by the product of npc.ai[0] by the numbers -999 to 999
                    * 6) Set to 0
                    * 7) Set equal to npc.ai[2]
                    }*/
                    if (!commonSlime.Contains(npc.type))
                    {
                        int uno = Main.rand.Next(7);
                        if (uno == 0)
                        {
                            //1) Multiply by either -1 or 1
                            npc.ai[1] *= Main.rand.Next(-2, 2);
                        }
                        if (uno == 1)
                        {
                            //2) to the root of npc.ai[0]
                            //Scalie: express it as a fractional exponent instead and use Math.Pow
                            npc.ai[1] = (float)Math.Pow(npc.ai[1], 1 / npc.ai[0]);
                        }
                        if (uno == 2)
                        {
                            //3) Multiply by the remainder of npc.ai[2] divided by 17
                            npc.ai[1] *= npc.ai[2] % 17;
                        }
                        if (uno == 3)
                        {
                            //4) Add by the difference of npc.ai[3] and itself
                            npc.ai[1] += npc.ai[3] - npc.ai[1];
                        }
                        if (uno == 4)
                        {
                            //5) Subtract by the product of npc.ai[0] by the numbers -999 to 999
                            npc.ai[1] -= npc.ai[0] * Main.rand.Next(-1000, 1000);
                        }
                        if (uno == 5)
                        {
                            if (resetRare)
                            {
                                if (Main.rand.Next(9) == 0)
                                {
                                    //6) set to 0
                                    npc.ai[1] = 0;
                                }
                            }
                            else
                            {
                                npc.ai[1] = 0;
                            }
                        }
                        if (uno == 6)
                        {
                            //7) Set equal to npc.ai[2]
                            npc.ai[1] = npc.ai[2];
                        }

                        #endregion
                    }
                    #region npc.ai[2] Scramble
                    /* AI 2:
                    * 1) Divide by either -2 or 2
                    * 2) to the power of npc.ai[3]
                    * 3) set to the remainder of npc.ai[1] divided by npc.ai[3]
                    * 4) add by the sum of npc.ai[0] and 69
                    * 5) Set to 0
                    * 6) set equal to the cube of npc.ai[0]
                    * 7) set to the square of numbers -190 or 190
                   }*/
                    int dos = Main.rand.Next(7);
                    if (dos == 0)
                    {
                        //1) Divide by either -2 or 2
                        npc.ai[2] /= Main.rand.Next(-3, 3);
                    }
                    if (dos == 1)
                    {
                        //2) to the power of npc.ai[3]
                        npc.ai[2] = (float)Math.Pow(npc.ai[2], npc.ai[3]);
                    }
                    if (dos == 2)
                    {
                        //3) set to the remainder of npc.ai[1] divided by npc.ai[3]
                        npc.ai[2] = npc.ai[1] % npc.ai[3];
                    }
                    if (dos == 3)
                    {
                        //4) add by the sum of npc.ai[0] and 69
                        npc.ai[2] += npc.ai[0] + 69;
                    }
                    if (dos == 4)
                    {
                        if (resetRare)
                        {
                            if (Main.rand.Next(9) == 0)
                            {
                                //5) set to 0
                                npc.ai[2] = 0;
                            }
                        }
                        else
                        {
                            npc.ai[2] = 0;
                        }

                    }
                    if (dos == 5)
                    {
                        //6) set equal to the cube of npc.ai[0]
                        npc.ai[2] = (float)Math.Pow(npc.ai[0], 3);
                    }
                    if (dos == 6)
                    {
                        //7) set to the square of numbers -190 or 190
                        npc.ai[2] = (float)Math.Pow(Main.rand.Next(-191, 191), 2);
                    }
                    #endregion
                    #region npc.ai[3] Scramble
                    /* AI 3:
                    * 1) Cube root or set to the cube
                    * 2) add by the remainder of npc.ai[2] and numbers -999 to 999
                    * 3) set to 0
                    * 4) Subtract by the sum of npc.ai[1], npc.ai[2] and the difference of npc.ai[0] and the numbers -9 to 9
                    * 5) set to the square root of numbers -190 to 190
                    * 6) set to 8
                    * 7) set to -8
                    * 
                   }*/
                    int trentos = Main.rand.Next(7);
                    if (trentos == 0)
                    {
                        //1) Cube root or set to the cube
                        int cubo = Main.rand.Next(2);
                        if (cubo == 0)
                        {
                            npc.ai[3] = (float)Math.Pow(npc.ai[3], 1 / 3);
                        }
                        if (cubo == 1)
                        {
                            npc.ai[3] = (float)Math.Pow(npc.ai[3], 3);
                        }
                    }
                    if (trentos == 1)
                    {
                        //2) add by the remainder of npc.ai[2] and numbers -999 to 999
                        npc.ai[3] += npc.ai[2] % Main.rand.Next(-1000, 1000);
                    }
                    if (trentos == 2)
                    {
                        if (resetRare)
                        {
                            if (Main.rand.Next(9) == 0)
                            {
                                //3) set to 0
                                npc.ai[3] = 0;
                            }
                        }
                        else
                        {
                            npc.ai[3] = 0;
                        }
                    }
                    if (trentos == 3)
                    {
                        //4) Subtract by the sum of npc.ai[1], npc.ai[2] and the difference of npc.ai[0] and the numbers -9 to 9
                        npc.ai[3] -= npc.ai[1] + npc.ai[2] + (npc.ai[0] - Main.rand.Next(-10, 10));
                    }
                    if (trentos == 4)
                    {
                        //5) set to the square root of numbers -190 to 190
                        npc.ai[3] = (float)Math.Sqrt(Main.rand.Next(-191, 191));
                    }
                    if (trentos == 5)
                    {
                        //6) set to npc.ai[1]
                    }
                    if (trentos == 6)
                    {
                        //7) if npc.ai[3] is the radius, find the area of an imaginary circle :kek:
                        npc.ai[3] = (float)(Math.PI * Math.Pow(npc.ai[3], 2));
                    }
                    #endregion
                    #endregion
                    #endregion
                }
            }
            else
            {
                if (crashPrevent)
                {
                    if (!Main.dedServ && doScramble && Main.frameRate > GetInstance<AIScramblerConfig>().FrameLockInt && !dangerousAI.Contains(npc.aiStyle))
                    {
                        #region Scrambler
                        npc.localAI[0] = (float)Math.Pow(npc.ai[0], npc.localAI[2]);
                        npc.localAI[1] = (float)Math.Sqrt(Main.rand.Next(1, 9999));
                        npc.localAI[2] = (float)Math.Pow(npc.localAI[1], 1 / Main.rand.Next(1, 99));
                        npc.localAI[3] = npc.ai[0] + npc.ai[1] * npc.ai[2] / npc.ai[3];
                        if (Main.rand.Next(699) == 0)
                        {
                            int localBub = Main.rand.Next(4);
                            if (localBub == 0)
                            {
                                npc.localAI[0] = 0;
                            }
                            if (localBub == 1)
                            {
                                npc.localAI[1] = 0;
                            }
                            if (localBub == 2)
                            {
                                npc.localAI[2] = 0;
                            }
                            if (localBub == 3)
                            {
                                npc.localAI[3] = 0;
                            }
                        }
                        /*
                        npc.ai[0] = npc.ai[0];
                        npc.ai[1] = npc.ai[1];
                        npc.ai[2] = npc.ai[2];
                        npc.ai[3] = npc.ai[3];
                        }*/
                        #region npc.ai[#] Scramble
                        /*
                         * npc.ai 0 to 3
                         * The formula could go as so:
                         }*/
                        #region npc.ai[0] Scramble
                        /* AI 0:
                        * Choose between the 7 following:
                        * 1) Multiply by the quotient of npc.ai[1] / 10 to 1080
                        * 2) Square root
                        * 3) Add by the sum of npc.ai[2] and npc
                        * 4) Divide by npc.ai[3] to the power of numbers 2 to 99
                        * 5) Subtract by npc.ai[1] times 15
                        * 6) set to the power of itself
                        * 7) set to 0
                        }*/
                        int blank = Main.rand.Next(7);
                        if (blank == 0)
                        {
                            //1) Multiply by the quotient of npc.ai[1] / 10 to 1080
                            npc.ai[0] *= npc.ai[1] / Main.rand.Next(10, 1080);
                        }
                        if (blank == 1)
                        {
                            //2) Square root
                            npc.ai[0] = (float)Math.Sqrt(npc.ai[0]);
                        }
                        if (blank == 2)
                        {
                            //3) Add by the sum of npc.ai[2] and npc
                            npc.ai[0] += npc.ai[2] + npc.ai[0];
                        }
                        if (blank == 3)
                        {
                            //4) Divide by npc.ai[3] to the power of numbers 2 to 99
                            npc.ai[0] /= (float)Math.Pow(npc.ai[3], Main.rand.Next(2, 99));
                        }
                        if (blank == 4)
                        {
                            //5) Subtract by npc.ai[1] times 15
                            npc.ai[0] -= npc.ai[1] * 15;
                        }
                        if (blank == 5)
                        {
                            //6) set to the power of itself
                            npc.ai[0] = (float)Math.Pow(npc.ai[0], npc.ai[0]);
                        }
                        if (blank == 6)
                        {
                            if (resetRare)
                            {
                                if (Main.rand.Next(9) == 0)
                                {
                                    //7) set to 0
                                    npc.ai[0] = 0;
                                }
                            }
                            else
                            {
                                npc.ai[0] = 0;
                            }
                        }
                        #endregion
                        #region npc.ai[1] Scramble
                        /* AI 1:
                        * 1) Multiply by either -1 or 1
                        * 2) to the root of npc.ai[0]
                        * 3) Multiply by the remainder of npc.ai[2] divided by 17
                        * 4) Add by the difference of npc.ai[3] and itself
                        * 5) Subtract by the product of npc.ai[0] by the numbers -999 to 999
                        * 6) Set to 0
                        * 7) Set equal to npc.ai[2]
                        }*/
                        if (!commonSlime.Contains(npc.type))
                        {
                            int uno = Main.rand.Next(7);
                            if (uno == 0)
                            {
                                //1) Multiply by either -1 or 1
                                npc.ai[1] *= Main.rand.Next(-2, 2);
                            }
                            if (uno == 1)
                            {
                                //2) to the root of npc.ai[0]
                                //Scalie: express it as a fractional exponent instead and use Math.Pow
                                npc.ai[1] = (float)Math.Pow(npc.ai[1], 1 / npc.ai[0]);
                            }
                            if (uno == 2)
                            {
                                //3) Multiply by the remainder of npc.ai[2] divided by 17
                                npc.ai[1] *= npc.ai[2] % 17;
                            }
                            if (uno == 3)
                            {
                                //4) Add by the difference of npc.ai[3] and itself
                                npc.ai[1] += npc.ai[3] - npc.ai[1];
                            }
                            if (uno == 4)
                            {
                                //5) Subtract by the product of npc.ai[0] by the numbers -999 to 999
                                npc.ai[1] -= npc.ai[0] * Main.rand.Next(-1000, 1000);
                            }
                            if (uno == 5)
                            {
                                if (resetRare)
                                {
                                    if (Main.rand.Next(9) == 0)
                                    {
                                        //6) set to 0
                                        npc.ai[1] = 0;
                                    }
                                }
                                else
                                {
                                    npc.ai[1] = 0;
                                }
                            }
                            if (uno == 6)
                            {
                                //7) Set equal to npc.ai[2]
                                npc.ai[1] = npc.ai[2];
                            }

                            #endregion
                        }
                        #region npc.ai[2] Scramble
                        /* AI 2:
                        * 1) Divide by either -2 or 2
                        * 2) to the power of npc.ai[3]
                        * 3) set to the remainder of npc.ai[1] divided by npc.ai[3]
                        * 4) add by the sum of npc.ai[0] and 69
                        * 5) Set to 0
                        * 6) set equal to the cube of npc.ai[0]
                        * 7) set to the square of numbers -190 or 190
                       }*/
                        int dos = Main.rand.Next(7);
                        if (dos == 0)
                        {
                            //1) Divide by either -2 or 2
                            npc.ai[2] /= Main.rand.Next(-3, 3);
                        }
                        if (dos == 1)
                        {
                            //2) to the power of npc.ai[3]
                            npc.ai[2] = (float)Math.Pow(npc.ai[2], npc.ai[3]);
                        }
                        if (dos == 2)
                        {
                            //3) set to the remainder of npc.ai[1] divided by npc.ai[3]
                            npc.ai[2] = npc.ai[1] % npc.ai[3];
                        }
                        if (dos == 3)
                        {
                            //4) add by the sum of npc.ai[0] and 69
                            npc.ai[2] += npc.ai[0] + 69;
                        }
                        if (dos == 4)
                        {
                            if (resetRare)
                            {
                                if (Main.rand.Next(9) == 0)
                                {
                                    //5) set to 0
                                    npc.ai[2] = 0;
                                }
                            }
                            else
                            {
                                npc.ai[2] = 0;
                            }

                        }
                        if (dos == 5)
                        {
                            //6) set equal to the cube of npc.ai[0]
                            npc.ai[2] = (float)Math.Pow(npc.ai[0], 3);
                        }
                        if (dos == 6)
                        {
                            //7) set to the square of numbers -190 or 190
                            npc.ai[2] = (float)Math.Pow(Main.rand.Next(-191, 191), 2);
                        }
                        #endregion
                        #region npc.ai[3] Scramble
                        /* AI 3:
                        * 1) Cube root or set to the cube
                        * 2) add by the remainder of npc.ai[2] and numbers -999 to 999
                        * 3) set to 0
                        * 4) Subtract by the sum of npc.ai[1], npc.ai[2] and the difference of npc.ai[0] and the numbers -9 to 9
                        * 5) set to the square root of numbers -190 to 190
                        * 6) set to 8
                        * 7) set to -8
                        * 
                       }*/
                        int trentos = Main.rand.Next(7);
                        if (trentos == 0)
                        {
                            //1) Cube root or set to the cube
                            int cubo = Main.rand.Next(2);
                            if (cubo == 0)
                            {
                                npc.ai[3] = (float)Math.Pow(npc.ai[3], 1 / 3);
                            }
                            if (cubo == 1)
                            {
                                npc.ai[3] = (float)Math.Pow(npc.ai[3], 3);
                            }
                        }
                        if (trentos == 1)
                        {
                            //2) add by the remainder of npc.ai[2] and numbers -999 to 999
                            npc.ai[3] += npc.ai[2] % Main.rand.Next(-1000, 1000);
                        }
                        if (trentos == 2)
                        {
                            if (resetRare)
                            {
                                if (Main.rand.Next(9) == 0)
                                {
                                    //3) set to 0
                                    npc.ai[3] = 0;
                                }
                            }
                            else
                            {
                                npc.ai[3] = 0;
                            }
                        }
                        if (trentos == 3)
                        {
                            //4) Subtract by the sum of npc.ai[1], npc.ai[2] and the difference of npc.ai[0] and the numbers -9 to 9
                            npc.ai[3] -= npc.ai[1] + npc.ai[2] + (npc.ai[0] - Main.rand.Next(-10, 10));
                        }
                        if (trentos == 4)
                        {
                            //5) set to the square root of numbers -190 to 190
                            npc.ai[3] = (float)Math.Sqrt(Main.rand.Next(-191, 191));
                        }
                        if (trentos == 5)
                        {
                            //6) set to npc.ai[1]
                        }
                        if (trentos == 6)
                        {
                            //7) if npc.ai[3] is the radius, find the area of an imaginary circle :kek:
                            npc.ai[3] = (float)(Math.PI * Math.Pow(npc.ai[3], 2));
                        }
                        #endregion
                        #endregion
                        #endregion
                    }
                }
                else if (!Main.dedServ && doScramble && Main.frameRate > GetInstance<AIScramblerConfig>().FrameLockInt)
                {
                    #region Scrambler
                    npc.localAI[0] = (float)Math.Pow(npc.ai[0], npc.localAI[2]);
                    npc.localAI[1] = (float)Math.Sqrt(Main.rand.Next(1, 9999));
                    npc.localAI[2] = (float)Math.Pow(npc.localAI[1], 1 / Main.rand.Next(1, 99));
                    npc.localAI[3] = npc.ai[0] + npc.ai[1] * npc.ai[2] / npc.ai[3];
                    if (Main.rand.Next(699) == 0)
                    {
                        int localBub = Main.rand.Next(4);
                        if (localBub == 0)
                        {
                            npc.localAI[0] = 0;
                        }
                        if (localBub == 1)
                        {
                            npc.localAI[1] = 0;
                        }
                        if (localBub == 2)
                        {
                            npc.localAI[2] = 0;
                        }
                        if (localBub == 3)
                        {
                            npc.localAI[3] = 0;
                        }
                    }
                    /*
                    npc.ai[0] = npc.ai[0];
                    npc.ai[1] = npc.ai[1];
                    npc.ai[2] = npc.ai[2];
                    npc.ai[3] = npc.ai[3];
                    }*/
                    #region npc.ai[#] Scramble
                    /*
                     * npc.ai 0 to 3
                     * The formula could go as so:
                     }*/
                    #region npc.ai[0] Scramble
                    /* AI 0:
                    * Choose between the 7 following:
                    * 1) Multiply by the quotient of npc.ai[1] / 10 to 1080
                    * 2) Square root
                    * 3) Add by the sum of npc.ai[2] and npc
                    * 4) Divide by npc.ai[3] to the power of numbers 2 to 99
                    * 5) Subtract by npc.ai[1] times 15
                    * 6) set to the power of itself
                    * 7) set to 0
                    }*/
                    int blank = Main.rand.Next(7);
                    if (blank == 0)
                    {
                        //1) Multiply by the quotient of npc.ai[1] / 10 to 1080
                        npc.ai[0] *= npc.ai[1] / Main.rand.Next(10, 1080);
                    }
                    if (blank == 1)
                    {
                        //2) Square root
                        npc.ai[0] = (float)Math.Sqrt(npc.ai[0]);
                    }
                    if (blank == 2)
                    {
                        //3) Add by the sum of npc.ai[2] and npc
                        npc.ai[0] += npc.ai[2] + npc.ai[0];
                    }
                    if (blank == 3)
                    {
                        //4) Divide by npc.ai[3] to the power of numbers 2 to 99
                        npc.ai[0] /= (float)Math.Pow(npc.ai[3], Main.rand.Next(2, 99));
                    }
                    if (blank == 4)
                    {
                        //5) Subtract by npc.ai[1] times 15
                        npc.ai[0] -= npc.ai[1] * 15;
                    }
                    if (blank == 5)
                    {
                        //6) set to the power of itself
                        npc.ai[0] = (float)Math.Pow(npc.ai[0], npc.ai[0]);
                    }
                    if (blank == 6)
                    {
                        if (resetRare)
                        {
                            if (Main.rand.Next(9) == 0)
                            {
                                //7) set to 0
                                npc.ai[0] = 0;
                            }
                        }
                        else
                        {
                            npc.ai[0] = 0;
                        }
                    }
                    #endregion
                    #region npc.ai[1] Scramble
                    /* AI 1:
                    * 1) Multiply by either -1 or 1
                    * 2) to the root of npc.ai[0]
                    * 3) Multiply by the remainder of npc.ai[2] divided by 17
                    * 4) Add by the difference of npc.ai[3] and itself
                    * 5) Subtract by the product of npc.ai[0] by the numbers -999 to 999
                    * 6) Set to 0
                    * 7) Set equal to npc.ai[2]
                    }*/
                    if (!commonSlime.Contains(npc.type))
                    {
                        int uno = Main.rand.Next(7);
                        if (uno == 0)
                        {
                            //1) Multiply by either -1 or 1
                            npc.ai[1] *= Main.rand.Next(-2, 2);
                        }
                        if (uno == 1)
                        {
                            //2) to the root of npc.ai[0]
                            //Scalie: express it as a fractional exponent instead and use Math.Pow
                            npc.ai[1] = (float)Math.Pow(npc.ai[1], 1 / npc.ai[0]);
                        }
                        if (uno == 2)
                        {
                            //3) Multiply by the remainder of npc.ai[2] divided by 17
                            npc.ai[1] *= npc.ai[2] % 17;
                        }
                        if (uno == 3)
                        {
                            //4) Add by the difference of npc.ai[3] and itself
                            npc.ai[1] += npc.ai[3] - npc.ai[1];
                        }
                        if (uno == 4)
                        {
                            //5) Subtract by the product of npc.ai[0] by the numbers -999 to 999
                            npc.ai[1] -= npc.ai[0] * Main.rand.Next(-1000, 1000);
                        }
                        if (uno == 5)
                        {
                            if (resetRare)
                            {
                                if (Main.rand.Next(9) == 0)
                                {
                                    //6) set to 0
                                    npc.ai[1] = 0;
                                }
                            }
                            else
                            {
                                npc.ai[1] = 0;
                            }
                        }
                        if (uno == 6)
                        {
                            //7) Set equal to npc.ai[2]
                            npc.ai[1] = npc.ai[2];
                        }

                        #endregion
                    }
                    #region npc.ai[2] Scramble
                    /* AI 2:
                    * 1) Divide by either -2 or 2
                    * 2) to the power of npc.ai[3]
                    * 3) set to the remainder of npc.ai[1] divided by npc.ai[3]
                    * 4) add by the sum of npc.ai[0] and 69
                    * 5) Set to 0
                    * 6) set equal to the cube of npc.ai[0]
                    * 7) set to the square of numbers -190 or 190
                   }*/
                    int dos = Main.rand.Next(7);
                    if (dos == 0)
                    {
                        //1) Divide by either -2 or 2
                        npc.ai[2] /= Main.rand.Next(-3, 3);
                    }
                    if (dos == 1)
                    {
                        //2) to the power of npc.ai[3]
                        npc.ai[2] = (float)Math.Pow(npc.ai[2], npc.ai[3]);
                    }
                    if (dos == 2)
                    {
                        //3) set to the remainder of npc.ai[1] divided by npc.ai[3]
                        npc.ai[2] = npc.ai[1] % npc.ai[3];
                    }
                    if (dos == 3)
                    {
                        //4) add by the sum of npc.ai[0] and 69
                        npc.ai[2] += npc.ai[0] + 69;
                    }
                    if (dos == 4)
                    {
                        if (resetRare)
                        {
                            if (Main.rand.Next(9) == 0)
                            {
                                //5) set to 0
                                npc.ai[2] = 0;
                            }
                        }
                        else
                        {
                            npc.ai[2] = 0;
                        }

                    }
                    if (dos == 5)
                    {
                        //6) set equal to the cube of npc.ai[0]
                        npc.ai[2] = (float)Math.Pow(npc.ai[0], 3);
                    }
                    if (dos == 6)
                    {
                        //7) set to the square of numbers -190 or 190
                        npc.ai[2] = (float)Math.Pow(Main.rand.Next(-191, 191), 2);
                    }
                    #endregion
                    #region npc.ai[3] Scramble
                    /* AI 3:
                    * 1) Cube root or set to the cube
                    * 2) add by the remainder of npc.ai[2] and numbers -999 to 999
                    * 3) set to 0
                    * 4) Subtract by the sum of npc.ai[1], npc.ai[2] and the difference of npc.ai[0] and the numbers -9 to 9
                    * 5) set to the square root of numbers -190 to 190
                    * 6) set to 8
                    * 7) set to -8
                    * 
                   }*/
                    int trentos = Main.rand.Next(7);
                    if (trentos == 0)
                    {
                        //1) Cube root or set to the cube
                        int cubo = Main.rand.Next(2);
                        if (cubo == 0)
                        {
                            npc.ai[3] = (float)Math.Pow(npc.ai[3], 1 / 3);
                        }
                        if (cubo == 1)
                        {
                            npc.ai[3] = (float)Math.Pow(npc.ai[3], 3);
                        }
                    }
                    if (trentos == 1)
                    {
                        //2) add by the remainder of npc.ai[2] and numbers -999 to 999
                        npc.ai[3] += npc.ai[2] % Main.rand.Next(-1000, 1000);
                    }
                    if (trentos == 2)
                    {
                        if (resetRare)
                        {
                            if (Main.rand.Next(9) == 0)
                            {
                                //3) set to 0
                                npc.ai[3] = 0;
                            }
                        }
                        else
                        {
                            npc.ai[3] = 0;
                        }
                    }
                    if (trentos == 3)
                    {
                        //4) Subtract by the sum of npc.ai[1], npc.ai[2] and the difference of npc.ai[0] and the numbers -9 to 9
                        npc.ai[3] -= npc.ai[1] + npc.ai[2] + (npc.ai[0] - Main.rand.Next(-10, 10));
                    }
                    if (trentos == 4)
                    {
                        //5) set to the square root of numbers -190 to 190
                        npc.ai[3] = (float)Math.Sqrt(Main.rand.Next(-191, 191));
                    }
                    if (trentos == 5)
                    {
                        //6) set to npc.ai[1]
                    }
                    if (trentos == 6)
                    {
                        //7) if npc.ai[3] is the radius, find the area of an imaginary circle :kek:
                        npc.ai[3] = (float)(Math.PI * Math.Pow(npc.ai[3], 2));
                    }
                    #endregion
                    #endregion
                    #endregion
                }
            }
            if (!Main.dedServ && aiStyleChange && Main.frameRate > GetInstance<AIScramblerConfig>().FrameLockInt)
            {
                if (!aiChanged && aiDelay == -1)
                {
                    npc.aiStyle = Main.rand.Next(0, 112);
                    aiChanged = true;
                }
                else if (aiDelay != -1)
                {
                    npc.aiStyle = aiDelay;
                }
            }
            if (!Main.dedServ && rainbow && Main.frameRate > GetInstance<AIScramblerConfig>().FrameLockInt)
            {
                #region Rainbow Slime Code
                float num2 = (float)Main.DiscoR / 255f;
                float num3 = (float)Main.DiscoG / 255f;
                float num4 = (float)Main.DiscoB / 255f;
                num2 *= 1f;
                num3 *= 1f;
                num4 *= 1f;
                //Lighting.AddLight((int)((npc.position.X + (float)(npc.width / 2)) / 16f), (int)((npc.position.Y + (float)(npc.height / 2)) / 16f), num2, num3, num4);
                npc.color.R = (byte)Main.DiscoR;
                npc.color.G = (byte)Main.DiscoG;
                npc.color.B = (byte)Main.DiscoB;
                npc.color.A = 100;
                //npc.alpha = 175;
                #endregion
            }
            
            if (!Main.dedServ && slimeBox && Main.frameRate > GetInstance<AIScramblerConfig>().FrameLockInt && commonSlime.Contains(npc.type))
            {
                npc.ai[1] = Main.rand.Next(0, 3930);
            }
        }
        public override bool CheckDead(NPC npc)
        {
            if (AIWorld.butcher)
            {
                return true;
            }
            return base.CheckDead(npc);
        }
    }
}
