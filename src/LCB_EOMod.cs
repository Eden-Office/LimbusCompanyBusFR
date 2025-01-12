using BepInEx;
using BepInEx.Configuration;
using BepInEx.Unity.IL2CPP;
using HarmonyLib;
using Il2CppSystem.Runtime.Remoting.Messaging;
using LimbusCompanyFR.EO;
using StorySystem;
using System;
using System.IO;
using System.Linq;
using System.Reflection;
using TMPro;
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
        public const string VERSION = "0.6.0";
        public const string VERSION_STATE = "";
        public const string AUTHOR = "Base: Bright\nFR version: Knightey, abcdcode, Disaer";
        public const string EOLink = "https://github.com/Eden-Office/LimbusCompanyBusFR";
        public static Action<string, Action> LogFatalError { get; set; }
        public static Action<string> LogInfo { get; set; }
        public static Action<string> LogError { get; set; }
        public static Action<string> LogWarning { get; set; }
        public static void OpenEOURL() { Application.OpenURL(EOLink); }
        public static void OpenGamePath() { Application.OpenURL(GamePath); }
        public override void Load()
        {
            EO_Settings = Config;
            LogInfo = (string log) => { Log.LogInfo(log); Debug.Log(log); };
            LogError = (string log) => { Log.LogError(log); Debug.LogError(log); };
            LogWarning = (string log) => { Log.LogWarning(log); Debug.LogWarning(log); };
            LogFatalError = (string log, Action action) => { EO_Manager.FatalErrorlog += log + "\n"; LogError(log); EO_Manager.FatalErrorAction = action; EO_Manager.CheckModActions(); };
            GamePath = new DirectoryInfo(Application.dataPath).Parent.FullName;
            var matchingFiles = Directory.EnumerateFiles(GamePath + "\\BepInEx\\plugins", "LimbusCompanyFR_BIE.dll", SearchOption.AllDirectories);
            foreach (var filePath in matchingFiles)
            {
                ModPath = Path.GetDirectoryName(filePath);
            }
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

                    ApplyPatches(harmony, typeof(EO_TemporaryTextures));
                    ApplyPatches(harmony, typeof(EO_TextUI));
                    ApplyPatches(harmony, typeof(EO_SpriteUI));
                    ApplyPatches(harmony, typeof(EO_StoryUI));
                    ApplyPatches(harmony, typeof(EO_CreditsUI));
                    ApplyPatches(harmony, typeof(EO_EventUI));
                    ApplyPatches(harmony, typeof(EO_SeasonUI));
                }
                harmony.PatchAll(typeof(EO_Manager));
                harmony.PatchAll(typeof(EO_French_Setting));
                if (!LCB_French_Font.AddFrenchFont(ModPath + "/tmpfrenchfonts"))
                    LogFatalError("Vous avez oublié d'installer le mod de mise à jour de police d'écriture. Veuillez relire le README sur Github.", OpenEOURL);
                LogInfo("-------------------------\n");
                TMP_FontAsset pretendard = Resources.Load<TMP_FontAsset>("Font/EN/Pretendard/Pretendard-Regular SDF");
                LCB_French_Font.tmpfrenchfonts[4].fallbackFontAssetTable.Add(pretendard);
                LogInfo("Startup" + DateTime.Now);
            }
            catch (Exception e)
            {
                LogFatalError("Le mod a rencontré une erreur inconnue ! S'il vous plaît, contactez nous à l'aide des urls du log sur Github.", () => { CopyLog(); OpenGamePath(); OpenEOURL(); });
                LogError(e.ToString());
            }
        }
        public static void ApplyPatches(Harmony harmony, Type patchContainer)
        {
            var methods = patchContainer.GetMethods(BindingFlags.Public | BindingFlags.NonPublic | BindingFlags.Static);
            foreach (var method in methods)
            {
                var harmonyPatchAttributes = method.GetCustomAttributes(typeof(HarmonyPatch), false);
                if (harmonyPatchAttributes.Length > 0)
                {
                    try
                    {
                        ApplyPatch(harmony, method);
                    }
                    catch (Exception ex)
                    {
                        LogWarning($"Failed to apply patch for method {method.Name}: {ex.Message}");
                    }
                }
            }
        }

        private static void ApplyPatch(Harmony harmony, MethodInfo patchMethod)
        {
            var harmonyPatchAttributes = (HarmonyPatch[])patchMethod.GetCustomAttributes(typeof(HarmonyPatch), false);
            foreach (var patchAttribute in harmonyPatchAttributes)
            {
                var targetType = patchAttribute.info.declaringType;
                var targetMethodName = patchAttribute.info.methodName;
                var targetMethod = AccessTools.Method(targetType, targetMethodName);
                var prefix = patchMethod.GetCustomAttributes(typeof(HarmonyPrefix), false).Any() ? new HarmonyMethod(patchMethod) : null;
                var postfix = patchMethod.GetCustomAttributes(typeof(HarmonyPostfix), false).Any() ? new HarmonyMethod(patchMethod) : null;
                if (targetType == null || string.IsNullOrEmpty(targetMethodName))
                {
                    continue;
                }
                if (targetMethod == null)
                {
                    continue;
                }
                try
                {
                    harmony.Patch(targetMethod, prefix, postfix);
                }
                catch (Exception ex)
                {
                    LogError($"Failed to patch {targetMethodName} in {targetType.FullName}: {ex.Message}");
                }
            }
        }
        public static void CopyLog()
        {
            File.Copy(GamePath + "/BepInEx/LogOutput.log", GamePath + "/Latest.log", true);
            File.Copy(Application.consoleLogPath, GamePath + "/Player.log", true);
        }
    }
}
