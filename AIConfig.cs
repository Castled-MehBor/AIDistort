using System.ComponentModel;
using Terraria.ModLoader.Config;
using Microsoft.Xna.Framework;

namespace AIDistort
{
    public class AIConfig : ModConfig
    {
        public override ConfigScope Mode => ConfigScope.ServerSide;
        public override void OnLoaded() => AIDistort.modConfig = this;

        [Header("$Mods.AIDistort.GeneralConfig")]

        [DefaultValue(true)]
        [Label("$Mods.AIDistort.AIScrambleConfigLabel")]
        [Tooltip("$Mods.AIDistort.AIScrambleConfigTooltip")]
        public bool AIScrambleBoolean;

        /*
        [DefaultValue(false)]
        [Label("$Mods.AIDistort.GameplayConfigLabel")]
        [Tooltip("$Mods.AIDistort.GameplayConfigTooltip")]
        public bool GameplayBoolean;
        }*/

        [DefaultValue(false)]
        [Label("$Mods.AIDistort.TownNPCConfigLabel")]
        [Tooltip("$Mods.AIDistort.TownNPCConfigTooltip")]
        public bool TownNPCBoolean;

        [DefaultValue(false)]
        [Label("$Mods.AIDistort.ShopConfigLabel")]
        [Tooltip("$Mods.AIDistort.ShopConfigTooltip")]
        public bool ShopRandomBoolean;

        [Range(0, 20)]
        [DefaultValue(1)]
        [Label("$Mods.AIDistort.ShopTwoConfigLabel")]
        [Tooltip("$Mods.AIDistort.ShopTwoConfigTooltip")]
        public int ShopRandomScale;

        [DefaultValue(false)]
        [Label("$Mods.AIDistort.SlimeConfigLabel")]
        [Tooltip("$Mods.AIDistort.SlimeConfigTooltip")]
        public bool SlimeBoxBoolean;

        [DefaultValue(false)]
        [Label("$Mods.AIDistort.PrideConfigLabel")]
        [Tooltip("$Mods.AIDistort.PrideConfigTooltip")]
        public bool PrideBoolean;

        [Header("$Mods.AIDistort.AIStyleRandomConfig")]

        [DefaultValue(false)]
        [Label("$Mods.AIDistort.AIStyleRandomConfigLabel")]
        [Tooltip("$Mods.AIDistort.AIStyleRandomConfigTooltip")]
        public bool AIStyleRandomizer;

        [Range(0, 240)]
        [DefaultValue(0)]
        [Label("$Mods.AIDistort.AIStyleRandomDelayConfigLabel")]
        [Tooltip("$Mods.AIDistort.AIStyleRandomDelayConfigTooltip")]
        public int AIStyleRandomizerDelay;

        [Header("$Mods.AIDistort.MachinePerformanceConfig")]

        [Range(1, 60)]
        [DefaultValue(20)]
        [Label("$Mods.AIDistort.FrameLockConfigLabel")]
        [Tooltip("$Mods.AIDistort.FrameLockConfigTooltip")]
        public int FrameLockInt;

        [DefaultValue(true)]
        [Label("$Mods.AIDistort.CrashPreventConfigLabel")]
        [Tooltip("$Mods.AIDistort.CrashPreventConfigTooltip")]
        public bool CrashPreventBoolean;

        [Header("$Mods.AIDistort.MiscConfig")]

        [DefaultValue(false)]
        [Label("$Mods.AIDistort.ScramblerTwoConfigLabel")]
        [Tooltip("$Mods.AIDistort.ScramblerTwoConfigTooltip")]
        public bool VersionTwoScrambler;

        [DefaultValue(false)]
        [Label("$Mods.AIDistort.HotkeyConfigLabel")]
        [Tooltip("$Mods.AIDistort.HotkeyConfigTooltip")]
        public bool ClientHotkeyPermission;

        [DefaultValue(true)]
        [Label("$Mods.AIDistort.HotkeyTwoConfigLabel")]
        [Tooltip("$Mods.AIDistort.HotkeyTwoConfigTooltip")]
        public bool HotkeyCooldown;

        public override bool AcceptClientChanges(ModConfig pendingConfig, int whoAmI, ref string message)
        {
            if (whoAmI == 0)
            {
                message = "Changes accepted!";
                return true;
            }
            if (whoAmI != 0)
            {
                message = "You are not allowed to change AIConfig.modConfig";
                return false;
            }
            return false;
        }
    }
}
