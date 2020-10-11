using Terraria.ModLoader;
using Terraria.Localization;

namespace AIDistort
{
	public class AIDistort : Mod
	{
        public static AIDistort Instance;
        internal static ModHotKey AIScrambleHotKey;
        static internal AIDistort instance;
        internal static AIConfig modConfig;
        public override void Load()
        {
            Instance = this;
            AIScrambleHotKey = RegisterHotKey("AI Scramble Toggle Hotkey", "P");

            #region Config Translations
            ModTranslation text = CreateTranslation("AIScrambleConfigLabel");
            text.SetDefault("AI Scrambling");
            text.AddTranslation(GameCulture.French, "Brouillage d'IA");
            AddTranslation(text);

            text = CreateTranslation("AIScrambleConfigTooltip");
            text.SetDefault("Toggle the scrambling of the AI.");
            text.AddTranslation(GameCulture.French, "Basculer la grande mélange d'IA.");
            AddTranslation(text);

            text = CreateTranslation("TownNPCConfigLabel");
            text.SetDefault("Town NPC AI Scramble");
            text.AddTranslation(GameCulture.French, "Brouillage de civilian IA");
            AddTranslation(text);

            text = CreateTranslation("TownNPCConfigTooltip");
            text.SetDefault("Toggle the scrambling of Town NPC AI. NPC's will self combust if this is set to true, due to unspecified scrambling.");
            text.AddTranslation(GameCulture.French, "Activez le brouillage de l'IA civile. Les civils mourront immédiatement si c'est défini vrai, en raison d'un brouillage mal.");
            AddTranslation(text);

            text = CreateTranslation("FrameLockConfigLabel");
            text.SetDefault("Frame Lock");
            text.AddTranslation(GameCulture.French, "Verrouillage du Cadre");
            AddTranslation(text);

            text = CreateTranslation("FrameLockConfigTooltip");
            text.SetDefault("Set a value to prevent AI Scramble from occurring if frame rate is at or below this value. Used to tranquilize lag during dire situations.");
            text.AddTranslation(GameCulture.French, "Définissez une valeur pour empêcher AI Scramble de se produire si la fréquence d'images est égale ou inférieure à cette valeur. Utilisé pour calmer retard d'ordinateur durant les situations difficiles.");
            AddTranslation(text);

            text = CreateTranslation("HotkeyConfigLabel");
            text.SetDefault("Server-Wide Hotkey Permission");
            text.AddTranslation(GameCulture.French, "Autorisation de Raccourci clavier à l'échelle du serveur");
            AddTranslation(text);

            text = CreateTranslation("HotkeyConfigTooltip");
            text.SetDefault("If you are the server host, toggle this to enable or disable server-wide authorization of the 'AI Scramble Hotkey'");
            text.AddTranslation(GameCulture.French, "Si vous êtes l'hôte du serveur, activez cette option pour activer ou désactiverd'autorisation à l'échelle du serveur du 'AI Scramble Hotkey'");
            AddTranslation(text);

            text = CreateTranslation("HotkeyTwoConfigLabel");
            text.SetDefault("AI Scramble Hotkey Cooldown");
            text.AddTranslation(GameCulture.French, "Temps de Récupération de la Touche de Raccourci AI Scramble");
            AddTranslation(text);

            text = CreateTranslation("HotkeyTwoConfigTooltip");
            text.SetDefault("Set to true to add a six second cooldown to the 'AI Scramble Hotkey'");
            text.AddTranslation(GameCulture.French, "Réglez sur true pour ajouter un temps de recharge de six secondes à le 'AI Scramble Hotkey'");
            AddTranslation(text);

            text = CreateTranslation("CrashPreventConfigLabel");
            text.SetDefault("Crash Prevention");
            text.AddTranslation(GameCulture.French, "Prévention des Erreurs Fatales");
            AddTranslation(text);

            text = CreateTranslation("CrashPreventConfigTooltip");
            text.SetDefault("AI Scrambler crashes the game for certain AI Styles. Turn this on to prevent AI Scrambler from affecting any NPC with said AI.");
            text.AddTranslation(GameCulture.French, "AI Scrambler plante le jeu pour certains Types d'IAs. Activer cette option pour empêcher AI Scrambler d'affecter un PNJ avec ladite IA.");
            AddTranslation(text);

            text = CreateTranslation("ScramblerTwoConfigLabel");
            text.SetDefault("Altered Scrambler");
            text.AddTranslation(GameCulture.French, "Scrambler Modifié");
            AddTranslation(text);

            text = CreateTranslation("ScramblerTwoConfigTooltip");
            text.SetDefault("Resets AI less frequently, resulting in a more unique outcome.");
            text.AddTranslation(GameCulture.French, "Réinitialise l'IA moins fréquemment, ce qui donne un résultat plus unique.");
            AddTranslation(text);

            text = CreateTranslation("SlimeConfigLabel");
            text.SetDefault("Loot Box Slimes");
            text.AddTranslation(GameCulture.French, "Geleés des Boîte à butin");
            AddTranslation(text);

            text = CreateTranslation("SlimeConfigTooltip");
            text.SetDefault("'Common' Slimes will now become loot boxes, being able to drop any vanilla item");
            text.AddTranslation(GameCulture.French, "Les geleés 'communs' deviendront désormais des coffres à butin, permettant de déposer n'importe quel objet vanille");
            AddTranslation(text);

            text = CreateTranslation("SlimeConfigLabel");
            text.SetDefault("Loot Box Slimes");
            text.AddTranslation(GameCulture.French, "Geleés des Boîte à butin");
            AddTranslation(text);

            text = CreateTranslation("SlimeConfigTooltip");
            text.SetDefault("'Common' Slimes will now become loot boxes, being able to drop any vanilla item");
            text.AddTranslation(GameCulture.French, "Les geleés 'communs' deviendront désormais des coffres à butin, permettant de déposer n'importe quel objet vanille");
            AddTranslation(text);

            text = CreateTranslation("AIStyleRandomConfigLabel");
            text.SetDefault("AI Style Randomizer");
            text.AddTranslation(GameCulture.French, "Randomiseur de Style AI");
            AddTranslation(text);

            text = CreateTranslation("AIStyleRandomConfigTooltip");
            text.SetDefault("Randomizes the AI Style of every NPC");
            text.AddTranslation(GameCulture.French, "Randomiser le style IA de tous les PNJs");
            AddTranslation(text);

            text = CreateTranslation("AIStyleRandomDelayConfigLabel");
            text.SetDefault("AI Style Randomizer Delay");
            text.AddTranslation(GameCulture.French, "Délai de Randomisation de Style AI");
            AddTranslation(text);

            text = CreateTranslation("AIStyleRandomDelayConfigTooltip");
            text.SetDefault("Add a delay for the randomization of AI Styles, set to 0 to not change aiStyle more than once. This is measured in seconds.");
            text.AddTranslation(GameCulture.French, "Ajoutez un délai pour la randomisation des Styles AI, mis à 0 pour ne pas changer aiStyle plus d'une fois. Ceci est mesuré en secondes.");
            AddTranslation(text);

            text = CreateTranslation("PrideConfigLabel");
            text.SetDefault("Rainbow NPCs");
            text.AddTranslation(GameCulture.French, "PNJs d'arc-en-ciel");
            AddTranslation(text);

            text = CreateTranslation("PrideConfigTooltip");
            text.SetDefault("Every NPC will have a rainbow color");
            text.AddTranslation(GameCulture.French, "Tous les PNJs aura une couleur arc-en-ciel");
            AddTranslation(text);

            /*
            text = CreateTranslation("GameplayConfigLabel");
            text.SetDefault("Playthrough Mode");
            text.AddTranslation(GameCulture.French, "Mode de Jouer");
            AddTranslation(text);

            text = CreateTranslation("GameplayConfigTooltip");
            text.SetDefault("Disables AI Scramble for NPC's which are either important for progression, or playthroughs, that break when AI Scramble is on.");
            text.AddTranslation(GameCulture.French, "Désactive AI Scramble pour les PNJ qui sont soit importants pour la progression, soit le temp de jou, qui se cassent lorsque AI Scramble est activé.");
            AddTranslation(text);
            }*/
            #endregion
            #region Config Header Translations
            text = CreateTranslation("GeneralConfig");
            text.SetDefault("[i:3625] [c/00fff0:General Configuration]");
            text.AddTranslation(GameCulture.French, "[i:3625] [c/00fff0:Configuration Générale]");
            AddTranslation(text);

            text = CreateTranslation("MiscConfig");
            text.SetDefault("[i:3620] [c/ff8b00:Miscellaneous Configuration]");
            text.AddTranslation(GameCulture.French, "[i:3620] [c/FF8B00:Configuration Diverse]");
            AddTranslation(text);

            text = CreateTranslation("MachinePerformanceConfig");
            text.SetDefault("[i:3649] [c/ff0090:Machine Performance Configuration]");
            text.AddTranslation(GameCulture.French, "[i:3649] [c/ff0090:Configuration de Performance de la Machine]");
            AddTranslation(text);

            text = CreateTranslation("AIStyleRandomConfig");
            text.SetDefault("[i:3663] [c/ff0000:AI Style Randomizer Configuration]");
            text.AddTranslation(GameCulture.French, "[i:3663] [c/ff0000:Configuration Randomiser de Style AI]");
            AddTranslation(text);
            #endregion
        }
        
        public override void Unload()
        {
            Instance = null;
            modConfig = null;
        }
    }
}