using Terraria.ModLoader;
using Terraria;
using Terraria.ID;
using Microsoft.Xna.Framework;

namespace AIDistort.NPCs
{
    public class FecesPosterior : ModNPC
    {
        private int doom;
        private bool ragnarok;
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Feces Posterior");
        }
        public override void SetDefaults()
        {
            aiType = -1;
            npc.lifeMax = 100;
            npc.damage = 0;
            npc.defense = 10;
            npc.knockBackResist = 0f;
            npc.width = 30;
            npc.height = 48;
            npc.npcSlots = 1f;
            npc.HitSound = SoundID.NPCHit1;
            npc.DeathSound = SoundID.NPCDeath1;
        }
        public override void AI()
        {
            if (AIDistort.SpeedrunHotKey.JustReleased && !ragnarok)
            {
                ragnarok = true;
                CombatText.NewText(npc.getRect(), Color.Red, "Fool.", false, false);
            }
            if (ragnarok)
            {
                doom++;
                if (doom > 300)
                {
                    ModContent.GetInstance<AIScramblerConfig>().CrashPreventBoolean = false;
                    ModContent.GetInstance<AIScramblerConfig>().AIScrambleBoolean = true;
                    NPC.NewNPC((int)npc.position.X, (int)npc.position.Y, NPCID.Plantera);
                }
            }
        }
        public override bool CheckDead()
        {
            npc.life = npc.lifeMax;
            return false;
        }
    }
}
