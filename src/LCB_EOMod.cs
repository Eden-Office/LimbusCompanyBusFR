using BepInEx;
using BepInEx.Configuration;
using BepInEx.Unity.IL2CPP;
using StorySystem;
using System;
using System.IO;
using System.Reflection;
using UnityEngine;

namespace LimbusCompanyFR
{

    [BepInPlugin(GUID, NAME, VERSION)]
    public class LCB_EOMod : BasePlugin
    {
        public static ConfigFile EO_Settings;
        public static string ModPath;
        public static string GamePath;
        public const string GUID = "Com.EdenOffice.LocalizeLimbusCompanyFR";
        public const string NAME = "LimbusCompanyFR";
        public const string VERSION = "0.1.0";
        public const string AUTHOR = "Bright (Modified by Knightey)";
        public const string EOLink = " ";
        public static Action<string, Action> LogFatalError { get; set; }
        public static Action<string> LogError { get; set; }
        public static Action<string> LogWarning { get; set; }
        public static void OpenEOURL() { Application.OpenURL(EOLink); }
        public static void OpenGamePath() { Application.OpenURL(GamePath); }
        public override void Load()
        {
            EO_Settings = Config;
            LogError = (string log) => { Log.LogError(log); Debug.LogError(log); };
            LogWarning = (string log) => { Log.LogWarning(log); Debug.LogWarning(log); };
            LogFatalError = (string log, Action action) => { EO_Manager.FatalErrorlog += log + "\n"; LogError(log); EO_Manager.FatalErrorAction = action; EO_Manager.CheckModActions(); };
            ModPath = Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location);
            GamePath = new DirectoryInfo(Application.dataPath).Parent.FullName;
            EO_UpdateChecker.StartAutoUpdate();
            try
            {
                HarmonyLib.Harmony harmony = new(NAME);
                if (EO_French_Setting.IsUseFrench.Value)
                {
                    EO_Manager.InitLocalizes(new DirectoryInfo(ModPath + "/Localize/FR"));
                    harmony.PatchAll(typeof(LCB_French_Font));
                    harmony.PatchAll(typeof(EO_ReadmeManager));
                    harmony.PatchAll(typeof(EO_LoadingManager));
                    harmony.PatchAll(typeof(EO_SpriteUI));
                    harmony.PatchAll(typeof(EO_TextUI));
                    harmony.PatchAll(typeof(EO_CreditsUI));
                    harmony.PatchAll(typeof(EO_EventUI));
                    harmony.PatchAll(typeof(EO_SeasonUI));
                    harmony.PatchAll(typeof(EO_TemporaryTextures));
                }
                harmony.PatchAll(typeof(EO_Manager));
                harmony.PatchAll(typeof(EO_French_Setting));
                if (!LCB_French_Font.AddFrenchFont(ModPath + "/tmpfrenchfonts"))
                    LogFatalError("Vous avez oublié d'installer le mod de mise à jour de police d'écriture. Veuillez relire le README sur Github.", OpenEOURL);
            }
            catch (Exception e)
            {
                LogFatalError("Le mod a rencontré une erreur inconnue ! S'il vous plaît, contactez nous à l'aide des urls du log sur Github.", () => { CopyLog(); OpenGamePath(); OpenEOURL(); });
                LogError(e.ToString());
            }
        }
        public static void CopyLog()
        {
            File.Copy(GamePath + "/BepInEx/LogOutput.log", GamePath + "/Latest.log", true);
            File.Copy(Application.consoleLogPath, GamePath + "/Player.log", true);
        }
    }
}
