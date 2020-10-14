using System.ComponentModel;
using Terraria.ModLoader.Config;
using Microsoft.Xna.Framework;

namespace AIDistort
{
    [Label("$Mods.AIDistort.Configs.Title.NPCAIScramblerConfig")]
    public class AIScramblerConfig : ModConfig
    {
        public override ConfigScope Mode => ConfigScope.ServerSide;
        public override void OnLoaded() => AIDistort.AIConfig = this;

        [Header("$Mods.AIDistort.GeneralConfig")]

        [DefaultValue(true)]
        [Label("$Mods.AIDistort.AIScrambleConfigLabel")]
        //[Tooltip("$Mods.AIDistort.AIScrambleConfigTooltip")]
        public bool AIScrambleBoolean;

        /*
        [DefaultValue(false)]
        [Label("$Mods.AIDistort.GameplayConfigLabel")]
        [Tooltip("$Mods.AIDistort.GameplayConfigTooltip")]
        public bool GameplayBoolean;
        }*/

        [DefaultValue(false)]
        [Label("$Mods.AIDistort.TownNPCConfigLabel")]
        //[Tooltip("$Mods.AIDistort.TownNPCConfigTooltip")]
        public bool TownNPCBoolean;

        [DefaultValue(false)]
        [Label("$Mods.AIDistort.ShopConfigLabel")]
        [Tooltip("$Mods.AIDistort.ShopConfigTooltip")]
        public bool ShopRandomBoolean;

        [Range(0, 20)]
        [DefaultValue(1)]
        [Label("$Mods.AIDistort.ShopTwoConfigLabel")]
        //[Tooltip("$Mods.AIDistort.ShopTwoConfigTooltip")]
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

        [Range(-1, 112)]
        [DefaultValue(-1)]
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
        //[Tooltip("$Mods.AIDistort.HotkeyTwoConfigTooltip")]
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

    [Label("$Mods.AIDistort.Configs.Title.PlayerRandomizerConfig")]
    public class PlayerRandomizeConfig : ModConfig
    {
        public override ConfigScope Mode => ConfigScope.ServerSide;
        public override void OnLoaded() => AIDistort.PlayerConfig = this;

        [Header("$Mods.AIDistort.HeadRandomConfig")]

        [DefaultValue(true)]
        [Label("$Mods.AIDistort.HairRandomLabel")]
        public bool RandomizeHair;

        [DefaultValue(true)]
        [Label("$Mods.AIDistort.HairTwoRandomLabel")]
        public bool RandomizeHairColor;

        [DefaultValue(true)]
        [Label("$Mods.AIDistort.EyeRandomLabel")]
        public bool RandomizeEyeColor;

        [Header("$Mods.AIDistort.BodyRandomConfig")]

        [DefaultValue(true)]
        [Label("$Mods.AIDistort.ShirtRandomLabel")]
        public bool RandomizeShirtColor;

        [DefaultValue(true)]
        [Label("$Mods.AIDistort.ShirtTwoRandomLabel")]
        public bool RandomizeUndershirtColor;

        [DefaultValue(true)]
        [Label("$Mods.AIDistort.SkinRandomLabel")]
        public bool RandomizeSkinColor;

        [Header("$Mods.AIDistort.LowerBodyRandomConfig")]

        [DefaultValue(true)]
        [Label("$Mods.AIDistort.PantsRandomLabel")]
        public bool RandomizePantsColor;

        [DefaultValue(true)]
        [Label("$Mods.AIDistort.ShoesRandomLabel")]
        public bool RandomizeShoeColor;

        [Header("$Mods.AIDistort.MiscCharRandomConfig")]

        [DefaultValue(true)]
        [Label("$Mods.AIDistort.GenderRandomLabel")]
        public bool RandomizeGender;

        [DefaultValue(false)]
        [Label("$Mods.AIDistort.GenderVLabel")]
        public bool IndicatorVGender;

        [DefaultValue(true)]
        [Label("$Mods.AIDistort.GenderALabel")]
        public bool IndicatorAGender;

        [DefaultValue(true)]
        [Label("$Mods.AIDistort.StyleRandomLabel")]
        public bool RandomizeClothes;

        [DefaultValue(false)]
        [Label("$Mods.AIDistort.NoRandomLabel")]
        [Tooltip("$Mods.AIDistort.NoRandomTooltip")]
        public bool NoRandom;

        [DefaultValue(typeof(Color), "1, 1, 1, 255")]
        [Label("$Mods.AIDistort.SetColorL")]
        public Color SetColor { get; set; }
    }
}
