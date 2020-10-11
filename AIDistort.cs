using Terraria.ModLoader;
using Terraria.Localization;

namespace AIDistort
{
	public class AIDistort : Mod
	{
        public static Mod Instance;
        internal static ModHotKey AIScrambleHotKey;
        static internal AIDistort instance;
        internal static AIConfig modConfig;
        public override void Load()
        {
            instance = this;
            AIScrambleHotKey = RegisterHotKey("AI Scramble Toggle Hotkey", "P");

            #region Config Translations
            ModTranslation text = CreateTranslation("AIScrambleConfigLabel");
            text.SetDefault("AI Scrambling");
            text.AddTranslation(GameCulture.French, "Brouillage d'IA");
            AddTranslation(text);

            text = CreateTranslation("AIScrambleConfigTooltip");
            text.SetDefault("Toggle the scrambling of the AI.");
            text.AddTranslation(GameCulture.French, "Basculer la grande m�lange d'IA.");
            AddTranslation(text);

            text = CreateTranslation("TownNPCConfigLabel");
            text.SetDefault("Town NPC AI Scramble");
            text.AddTranslation(GameCulture.French, "Brouillage de civilian IA");
            AddTranslation(text);

            text = CreateTranslation("TownNPCConfigTooltip");
            text.SetDefault("Toggle the scrambling of Town NPC AI. NPC's will self combust if this is set to true, due to unspecified scrambling.");
            text.AddTranslation(GameCulture.French, "Activez le brouillage de l'IA civile. Les civils mourront imm�diatement si c'est d�fini vrai, en raison d'un brouillage mal.");
            AddTranslation(text);

            text = CreateTranslation("FrameLockConfigLabel");
            text.SetDefault("Frame Lock");
            text.AddTranslation(GameCulture.French, "Verrouillage du Cadre");
            AddTranslation(text);

            text = CreateTranslation("FrameLockConfigTooltip");
            text.SetDefault("Set a value to prevent AI Scramble from occurring if frame rate is at or below this value. Used to tranquilize lag during dire situations.");
            text.AddTranslation(GameCulture.French, "D�finissez une valeur pour emp�cher AI Scramble de se produire si la fr�quence d'images est �gale ou inf�rieure � cette valeur. Utilis� pour calmer retard d'ordinateur durant les situations difficiles.");
            AddTranslation(text);

            text = CreateTranslation("HotkeyConfigLabel");
            text.SetDefault("Server-Wide Hotkey Permission");
            text.AddTranslation(GameCulture.French, "Autorisation de Raccourci clavier � l'�chelle du serveur");
            AddTranslation(text);

            text = CreateTranslation("HotkeyConfigTooltip");
            text.SetDefault("If you are the server host, toggle this to enable or disable server-wide authorization of the 'AI Scramble Hotkey'");
            text.AddTranslation(GameCulture.French, "Si vous �tes l'h�te du serveur, activez cette option pour activer ou d�sactiverd'autorisation � l'�chelle du serveur du 'AI Scramble Hotkey'");
            AddTranslation(text);

            text = CreateTranslation("HotkeyTwoConfigLabel");
            text.SetDefault("AI Scramble Hotkey Cooldown");
            text.AddTranslation(GameCulture.French, "Temps de R�cup�ration de la Touche de Raccourci AI Scramble");
            AddTranslation(text);

            text = CreateTranslation("HotkeyTwoConfigTooltip");
            text.SetDefault("Set to true to add a six second cooldown to the 'AI Scramble Hotkey'");
            text.AddTranslation(GameCulture.French, "R�glez sur true pour ajouter un temps de recharge de six secondes � le 'AI Scramble Hotkey'");
            AddTranslation(text);

            text = CreateTranslation("CrashPreventConfigLabel");
            text.SetDefault("Crash Prevention");
            text.AddTranslation(GameCulture.French, "Pr�vention des Erreurs Fatales");
            AddTranslation(text);

            text = CreateTranslation("CrashPreventConfigTooltip");
            text.SetDefault("AI Scrambler crashes the game for certain AI Styles. Turn this on to prevent AI Scrambler from affecting any NPC with said AI.");
            text.AddTranslation(GameCulture.French, "AI Scrambler plante le jeu pour certains Types d'IAs. Activer cette option pour emp�cher AI Scrambler d'affecter un PNJ avec ladite IA.");
            AddTranslation(text);

            text = CreateTranslation("ScramblerTwoConfigLabel");
            text.SetDefault("Altered Scrambler");
            text.AddTranslation(GameCulture.French, "Scrambler Modifi�");
            AddTranslation(text);

            text = CreateTranslation("ScramblerTwoConfigTooltip");
            text.SetDefault("Resets AI less frequently, resulting in a more unique outcome.");
            text.AddTranslation(GameCulture.French, "R�initialise l'IA moins fr�quemment, ce qui donne un r�sultat plus unique.");
            AddTranslation(text);

            text = CreateTranslation("SlimeConfigLabel");
            text.SetDefault("Loot Box Slimes");
            text.AddTranslation(GameCulture.French, "Gele�s des Bo�te � butin");
            AddTranslation(text);

            text = CreateTranslation("SlimeConfigTooltip");
            text.SetDefault("'Common' Slimes will now become loot boxes, being able to drop any vanilla item");
            text.AddTranslation(GameCulture.French, "Les gele�s 'communs' deviendront d�sormais des coffres � butin, permettant de d�poser n'importe quel objet vanille");
            AddTranslation(text);

            /*
            text = CreateTranslation("GameplayConfigLabel");
            text.SetDefault("Playthrough Mode");
            text.AddTranslation(GameCulture.French, "Mode de Jouer");
            AddTranslation(text);

            text = CreateTranslation("GameplayConfigTooltip");
            text.SetDefault("Disables AI Scramble for NPC's which are either important for progression, or playthroughs, that break when AI Scramble is on.");
            text.AddTranslation(GameCulture.French, "D�sactive AI Scramble pour les PNJ qui sont soit importants pour la progression, soit le temp de jou, qui se cassent lorsque AI Scramble est activ�.");
            AddTranslation(text);
            }*/
            #endregion
            #region Config Header Translations
            text = CreateTranslation("GeneralConfig");
            text.SetDefault("[i:3625] [c/00fff0:General Configuration]");
            text.AddTranslation(GameCulture.French, "[i:3625] [c/00fff0:Configuration G�n�rale]");
            AddTranslation(text);

            text = CreateTranslation("MiscConfig");
            text.SetDefault("[i:3620] [c/ff8b00:Miscellaneous Configuration]");
            text.AddTranslation(GameCulture.French, "[i:3620] [c/FF8B00:Configuration Diverse]");
            AddTranslation(text);

            text = CreateTranslation("MachinePerformanceConfig");
            text.SetDefault("[i:3649] [c/ff0090:Machine Performance Configuration]");
            text.AddTranslation(GameCulture.French, "[i:3649] [c/ff0090:Configuration de Performance de la Machine]");
            AddTranslation(text);
            #endregion
        }
        
        public override void Unload()
        {
            modConfig = null;
        }
    }
}