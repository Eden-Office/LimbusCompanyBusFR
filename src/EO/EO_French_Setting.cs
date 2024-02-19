using HarmonyLib;
using LocalSave;
using MainUI;
using BepInEx.Configuration;
using TMPro;
using System;
using UnityEngine;
using UnityEngine.UI;

namespace LimbusCompanyFR
{
    public static class EO_French_Setting
    {
        public static ConfigEntry<bool> IsUseFrench = LCB_EOMod.EO_Settings.Bind("EO Settings", "IsUseFrench", true, "Utilisez \"true\", \"false\" est optionnel.");
        static bool _isusefrench;
        static Toggle French_Setting;
        [HarmonyPatch(typeof(SettingsPanelGame), nameof(SettingsPanelGame.InitLanguage))]
        [HarmonyPrefix]
        private static bool InitLanguage(SettingsPanelGame __instance, LocalGameOptionData option)
        {
            if (!French_Setting)
            {
                Toggle original = __instance._languageToggles[0];
                Transform parent = original.transform.parent;
                var _languageToggle = UnityEngine.Object.Instantiate(original, parent);
                var frtmp = _languageToggle.GetComponentInChildren<TextMeshProUGUI>(true);
                frtmp.font = LCB_French_Font.GetFrenchFonts(4);
                frtmp.fontMaterial = LCB_French_Font.GetFrenchFonts(4).material;
                frtmp.text = "<size=42><cspace=-2px>Français</cspace></size>";
                French_Setting = _languageToggle;
                parent.localPosition = new Vector3(parent.localPosition.x - 306f, parent.localPosition.y, parent.localPosition.z);
                while (__instance._languageToggles.Count > 3)
                    __instance._languageToggles.RemoveAt(__instance._languageToggles.Count - 1);
                __instance._languageToggles.Add(_languageToggle);
            }
            foreach (Toggle tg in __instance._languageToggles)
            {
                tg.onValueChanged.RemoveAllListeners();
                Action<bool> onValueChanged = (bool isOn) =>
                {
                    if (!isOn)
                        return;
                    __instance.OnClickLanguageToggleEx(__instance._languageToggles.IndexOf(tg));
                };
                tg.onValueChanged.AddListener(onValueChanged);
                tg.SetIsOnWithoutNotify(false);
            }
            LOCALIZE_LANGUAGE language = option.GetLanguage();
            if (_isusefrench = IsUseFrench.Value)
                French_Setting.SetIsOnWithoutNotify(true);
            else if (language == LOCALIZE_LANGUAGE.KR)
                __instance._languageToggles[0].SetIsOnWithoutNotify(true);
            else if (language == LOCALIZE_LANGUAGE.EN)
                __instance._languageToggles[1].SetIsOnWithoutNotify(true);
            else if (language == LOCALIZE_LANGUAGE.JP)
                __instance._languageToggles[2].SetIsOnWithoutNotify(true);
            __instance._lang = language;
            return false;
        }
        [HarmonyPatch(typeof(SettingsPanelGame), nameof(SettingsPanelGame.ApplySetting))]
        [HarmonyPostfix]
        private static void ApplySetting()
        {
            IsUseFrench.Value = _isusefrench;
        }
        private static void OnClickLanguageToggleEx(this SettingsPanelGame __instance, int tgIdx)
        {
            if (tgIdx == 3)
            {
                _isusefrench = true;
                return;
            }
            _isusefrench = false;
            if (tgIdx == 0)
                __instance._lang = LOCALIZE_LANGUAGE.KR;
            else if (tgIdx == 1)
                __instance._lang = LOCALIZE_LANGUAGE.EN;
            else if (tgIdx == 2)
                __instance._lang = LOCALIZE_LANGUAGE.JP;
        }
    }
}