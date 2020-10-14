using Terraria.ModLoader;
using Terraria.Localization;
using Terraria.UI;
using Terraria.ID;
using Terraria;
using Terraria.DataStructures;
using Microsoft.Xna.Framework;

namespace AIDistort
{
	public class AIDistort : Mod
	{
        public static AIDistort Instance;
        internal static ModHotKey AIScrambleHotKey;
        internal static ModHotKey PlayerRandomize;
        internal static ModHotKey ButcherHotKey;
        static internal AIDistort instance;
        internal static AIScramblerConfig AIConfig;
        internal static PlayerRandomizeConfig PlayerConfig;
        public override void Load()
        {
            Instance = this;
            AIScrambleHotKey = RegisterHotKey("AI Scramble Toggle", "P");
            ButcherHotKey = RegisterHotKey("Butcher", "T");
            PlayerRandomize = RegisterHotKey("Randomize Player", "O");

            #region Config Translations
            ModTranslation text = CreateTranslation("AIScrambleConfigLabel");
            text.SetDefault("AI Scrambling");
            text.AddTranslation(GameCulture.French, "Brouillage d'IA");
            AddTranslation(text);

            text = CreateTranslation("AIScrambleConfigTooltip");
            text.SetDefault("Toggle the scrambling of the AI.");
            text.AddTranslation(GameCulture.French, "Basculer la grande m�lange d'IA.");
            AddTranslation(text);

            text = CreateTranslation("Configs.Title.NPCAIScramblerConfig");
            text.SetDefault("NPC AI Scrambler");
            text.AddTranslation(GameCulture.French, "Brouilleur PNJ AI");
            AddTranslation(text);

            text = CreateTranslation("Configs.Title.PlayerRandomizerConfig");
            text.SetDefault("Randomize Player Hotkey");
            text.AddTranslation(GameCulture.French, "Raccourci clavier du lecteur al�atoire");
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

            text = CreateTranslation("SlimeConfigLabel");
            text.SetDefault("Loot Box Slimes");
            text.AddTranslation(GameCulture.French, "Gele�s des Bo�te � butin");
            AddTranslation(text);

            text = CreateTranslation("SlimeConfigTooltip");
            text.SetDefault("'Common' Slimes will now become loot boxes, being able to drop any vanilla item");
            text.AddTranslation(GameCulture.French, "Les gele�s 'communs' deviendront d�sormais des coffres � butin, permettant de d�poser n'importe quel objet vanille");
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
            text.SetDefault("AI Style Lock");
            text.AddTranslation(GameCulture.French, "Verrouillage de Style IA");
            AddTranslation(text);

            text = CreateTranslation("AIStyleRandomDelayConfigTooltip");
            text.SetDefault("Every NPC will have this AI Style, set to -1 to disable this");
            text.AddTranslation(GameCulture.French, "Chaque PNJ aura ce style d'IA, r�gl� sur -1 pour le d�sactiver");
            AddTranslation(text);

            text = CreateTranslation("PrideConfigLabel");
            text.SetDefault("Rainbow NPCs");
            text.AddTranslation(GameCulture.French, "PNJs d'arc-en-ciel");
            AddTranslation(text);

            text = CreateTranslation("PrideConfigTooltip");
            text.SetDefault("Every NPC will have a rainbow color");
            text.AddTranslation(GameCulture.French, "Tous les PNJs aura une couleur arc-en-ciel");
            AddTranslation(text);

            text = CreateTranslation("ShopConfigLabel");
            text.SetDefault("Randomized NPC Shops");
            text.AddTranslation(GameCulture.French, "Boutiques de PNJ al�atoires");
            AddTranslation(text);

            text = CreateTranslation("ShopConfigTooltip");
            text.SetDefault("Town NPCs will sell random vanilla items for randomized prices");
            text.AddTranslation(GameCulture.French, "Les PNJ de la ville vendront des objets vanille al�atoires pour des prix al�atoires");
            AddTranslation(text);

            text = CreateTranslation("ShopTwoConfigLabel");
            text.SetDefault("Randomized NPC Shops Price Scale");
            text.AddTranslation(GameCulture.French, "�chelle de prix des boutiques de PNJ al�atoire");
            AddTranslation(text);

            text = CreateTranslation("ShopTwoConfigTooltip");
            text.SetDefault("Scales the prices of randomized shops if the above config is enabled");
            text.AddTranslation(GameCulture.French, "Met � l'�chelle les prix des magasins al�atoires si la configuration ci-dessus est activ�e");
            AddTranslation(text);

            #region Player Randomize 
            text = CreateTranslation("HairRandomLabel");
            text.SetDefault("Randomize Hairstyle");
            text.AddTranslation(GameCulture.French, "Style de Cheveux Al�atoire");
            AddTranslation(text);

            text = CreateTranslation("HairTwoRandomLabel");
            text.SetDefault("Randomize Hair Color");
            text.AddTranslation(GameCulture.French, "Couleur de Cheveux Al�atoire");
            AddTranslation(text);

            text = CreateTranslation("EyeRandomLabel");
            text.SetDefault("Randomize Eye Color");
            text.AddTranslation(GameCulture.French, "Couleur des yeux Al�atoire");
            AddTranslation(text);

            text = CreateTranslation("ShirtRandomLabel");
            text.SetDefault("Randomize Shirt Color");
            text.AddTranslation(GameCulture.French, "Couleur de Chemise Al�atoire");
            AddTranslation(text);

            text = CreateTranslation("ShirtTwoRandomLabel");
            text.SetDefault("Randomize Undershirt Color");
            text.AddTranslation(GameCulture.French, "Couleur de Maillot de Corps Al�atoire");
            AddTranslation(text);

            text = CreateTranslation("SkinRandomLabel");
            text.SetDefault("Randomize Skin Color");
            text.AddTranslation(GameCulture.French, "Couleur de Peau Al�atoire");
            AddTranslation(text);

            text = CreateTranslation("PantsRandomLabel");
            text.SetDefault("Randomize Pants Color");
            text.AddTranslation(GameCulture.French, "Couleur de Pantalons Al�atoire");
            AddTranslation(text);

            text = CreateTranslation("ShoesRandomLabel");
            text.SetDefault("Randomize Shoe Color");
            text.AddTranslation(GameCulture.French, "Couleur de Chaussures Al�atoire");
            AddTranslation(text);

            text = CreateTranslation("GenderRandomLabel");
            text.SetDefault("Randomize Gender");
            text.AddTranslation(GameCulture.French, "Genre al�atoire");
            AddTranslation(text);

            text = CreateTranslation("StyleRandomLabel");
            text.SetDefault("Randomize Clothes Style");
            text.AddTranslation(GameCulture.French, "Style de V�tements Al�atoire");
            AddTranslation(text);

            text = CreateTranslation("GenderVLabel");
            text.SetDefault("Visual Gender Indicator");
            text.AddTranslation(GameCulture.French, "Indicateur Visuel de Genre");
            AddTranslation(text);

            text = CreateTranslation("GenderALabel");
            text.SetDefault("Audio-based Gender Indicator");
            text.AddTranslation(GameCulture.French, "Indicateur de Genre bas� sur l'audio");
            AddTranslation(text);

            text = CreateTranslation("NoRandomLabel");
            text.SetDefault("Prevent Randomization");
            text.AddTranslation(GameCulture.French, "Emp�cher la Randomisation");
            AddTranslation(text);

            text = CreateTranslation("NoRandomTooltip");
            text.SetDefault("Your character will not change at all");
            text.AddTranslation(GameCulture.French, "Votre personnage ne changera pas du tout");
            AddTranslation(text);

            text = CreateTranslation("SetColorL");
            text.SetDefault("Set Color Command Output");
            text.AddTranslation(GameCulture.French, "Sans Translationne sur la momente");
            AddTranslation(text);
            #endregion

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

            text = CreateTranslation("AIStyleRandomConfig");
            text.SetDefault("[i:3663] [c/ff0000:AI Style Randomizer Configuration]");
            text.AddTranslation(GameCulture.French, "[i:3663] [c/ff0000:Configuration Randomiser de Style AI]");
            AddTranslation(text);

            text = CreateTranslation("HeadRandomConfig");
            text.SetDefault("[i:271] [c/ff0000:Head]");
            text.AddTranslation(GameCulture.French, "[i:271] [c/ff0000:T�te]");
            AddTranslation(text);

            text = CreateTranslation("BodyRandomConfig");
            text.SetDefault("[i:269] [c/ff8f00:Body]");
            text.AddTranslation(GameCulture.French, "[i:269] [c/ff8f00:Corps]");
            AddTranslation(text);

            text = CreateTranslation("LowerBodyRandomConfig");
            text.SetDefault("[i:270] [c/ffff00:Lower Body]");
            text.AddTranslation(GameCulture.French, "[i:270] [c/ffff00:Corps D'inf�rieure]");
            AddTranslation(text);

            text = CreateTranslation("MiscCharRandomConfig");
            text.SetDefault("[i:2756] [c/00fff3:Miscellaneous]");
            text.AddTranslation(GameCulture.French, "[i:2756] [c/00fff3:Diverse]");
            AddTranslation(text);
            #endregion

            if (!Main.dedServ)
            {
                LoadClient();
            }
        }
        private void LoadClient()
        {
            AddEquipTexture(null, EquipType.Head, "EmptyHead", "AIDistort/Items/EmptyTexture/EmptyHead_Head");
            AddEquipTexture(null, EquipType.Body, "EmptyBody", "AIDistort/Items/EmptyTexture/EmptyBody_Body", "AIDistort/Items/EmptyTexture/EmptyBody_Arms");
            AddEquipTexture(null, EquipType.Legs, "EmptyLegs", "AIDistort/Items/EmptyTexture/EmptyLegs_Legs");
        }

        public override void Unload()
        {
            Instance = null;
            AIConfig = null;
            PlayerConfig = null;
        }
    }
}