using HarmonyLib;
using MainUI;
using MainUI.Gacha;
using TMPro;
using Il2CppInterop.Runtime.Injection;
using System;
using System.Collections.Generic;
using System.IO;
using UnityEngine;
using ILObject = Il2CppSystem.Object;
using UObject = UnityEngine.Object;
using ULogger = UnityEngine.Logger;

namespace LimbusCompanyFR
{
    public class EO_Manager : MonoBehaviour
    {
        static EO_Manager()
        {
            ClassInjector.RegisterTypeInIl2Cpp<EO_Manager>();
            GameObject obj = new(nameof(EO_Manager));
            DontDestroyOnLoad(obj);
            obj.hideFlags |= HideFlags.HideAndDontSave;
            Instance = obj.AddComponent<EO_Manager>();
        }
        public static EO_Manager Instance;
        public EO_Manager(IntPtr ptr) : base(ptr) { }
        void OnApplicationQuit() => LCB_EOMod.CopyLog();

        public static void OpenGlobalPopup(string description, string title = null, string close = "Annuler", string confirm = "Confirmer", Action confirmEvent = null, Action closeEvent = null)
        {
            if (!GlobalGameManager.Instance) { return; }
            TextOkUIPopup globalPopupUI = GlobalGameManager.Instance.globalPopupUI;
            TMP_FontAsset fontAsset = LCB_French_Font.tmpfrenchfonts[5];
            if (fontAsset)
            {
                TextMeshProUGUI btn_canceltmp = globalPopupUI.btn_cancel.GetComponentInChildren<TextMeshProUGUI>(true);
                btn_canceltmp.font = fontAsset;
                btn_canceltmp.fontMaterial = fontAsset.material;
                UITextDataLoader btn_canceltl = globalPopupUI.btn_cancel.GetComponentInChildren<UITextDataLoader>(true);
                btn_canceltl.enabled = false;
                btn_canceltmp.text = close;
                TextMeshProUGUI btn_oktmp = globalPopupUI.btn_ok.GetComponentInChildren<TextMeshProUGUI>(true);
                btn_oktmp.font = fontAsset;
                btn_oktmp.fontMaterial = fontAsset.material;
                UITextDataLoader btn_oktl = globalPopupUI.btn_ok.GetComponentInChildren<UITextDataLoader>(true);
                btn_oktl.enabled = false;
                btn_oktmp.text = confirm;
                globalPopupUI.tmp_title.font = fontAsset;
                globalPopupUI.tmp_title.fontMaterial = fontAsset.material;
                void TextLoaderEnabled() { btn_canceltl.enabled = true; btn_oktl.enabled = true; }
                confirmEvent += TextLoaderEnabled;
                closeEvent += TextLoaderEnabled;
            }
            globalPopupUI._titleObject.SetActive(!string.IsNullOrEmpty(title));
            globalPopupUI.tmp_title.text = title;
            globalPopupUI.tmp_description.text = description;
            globalPopupUI._confirmEvent = confirmEvent;
            globalPopupUI._closeEvent = closeEvent;
            globalPopupUI.btn_cancel.gameObject.SetActive(!string.IsNullOrEmpty(close));
            globalPopupUI._gridLayoutGroup.cellSize = new Vector2(!string.IsNullOrEmpty(close) ? 500 : 700, 100f);
            globalPopupUI.Open();
        }
        public static void InitLocalizes(DirectoryInfo directory)
        {
            foreach (FileInfo fileInfo in directory.GetFiles())
            {
                var value = File.ReadAllText(fileInfo.FullName);
                string fileNameWithoutExtension = Path.GetFileNameWithoutExtension(fileInfo.FullName);
                Localizes[fileNameWithoutExtension] = value;
            }
            foreach (DirectoryInfo directoryInfo in directory.GetDirectories())
            {
                InitLocalizes(directoryInfo);
            }

        }
        public static Dictionary<string, string> Localizes = new();
        public static Action FatalErrorAction;
        public static string FatalErrorlog;
        #region Запрет предупреждений
        [HarmonyPatch(typeof(UnityEngine.Logger), nameof(UnityEngine.Logger.Log), typeof(LogType), typeof(ILObject))]
        [HarmonyPrefix]
        private static bool Log(UnityEngine.Logger __instance, LogType logType, ILObject message)
        {
            if (logType != LogType.Warning) return true;
            var logString = UnityEngine.Logger.GetString(message);
            if (!logString.StartsWith("<color=#0099bc><b>DOTWEEN"))
                __instance.logHandler.LogFormat(logType, null, "{0}", logString);
            return false;
        }

        [HarmonyPatch(typeof(UnityEngine.Logger), nameof(UnityEngine.Logger.Log), typeof(LogType), typeof(ILObject), typeof(UObject))]
        [HarmonyPrefix]
        private static bool Log(UnityEngine.Logger __instance, LogType logType, ILObject message, UObject context)
        {
            if (logType != LogType.Warning) return true;
            var logString = UnityEngine.Logger.GetString(message);
            if (!logString.StartsWith("Material"))
                __instance.logHandler.LogFormat(logType, context, "{0}", logString);
            return false;
        }
        #endregion
        #region Исправление некоторых ошибок
        [HarmonyPatch(typeof(GachaEffectEventSystem), nameof(GachaEffectEventSystem.LinkToCrackPosition))]
        [HarmonyPrefix]
        private static bool LinkToCrackPosition(GachaEffectEventSystem __instance, GachaCrackController[] crackList)
        => __instance._parent.EffectChainCamera;
        #endregion
        [HarmonyPatch(typeof(LoginSceneManager), nameof(LoginSceneManager.SetLoginInfo))]
        [HarmonyPostfix]
        public static void CheckModActions()
        {
            if (EO_UpdateChecker.UpdateCall != null)
                OpenGlobalPopup("Le mod a une mise à jour " + EO_UpdateChecker.Updatelog + "!\nOuvrez le chemin de téléchargement et quittez le jeu." + EO_UpdateChecker.Updatelog + "Décompressez l'archive .zip de la mise à jour", "Mod a une mise à jour", null, "OK", () =>
                {
                    EO_UpdateChecker.UpdateCall.Invoke();
                    EO_UpdateChecker.UpdateCall = null;
                    EO_UpdateChecker.Updatelog = string.Empty;
                });
            else if (FatalErrorAction != null)
                OpenGlobalPopup(FatalErrorlog, "Le mod a rencontré une erreur fatale!", null, "Ouvrir l'URL de \"Eden Office\"", () =>
                {
                    FatalErrorAction.Invoke();
                    FatalErrorAction = null;
                    FatalErrorlog = string.Empty;
                });
        }
    }
}
