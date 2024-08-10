using BattleUI;
using HarmonyLib;
using StorySystem;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TMPro;
using UnityEngine;
using UtilityUI;

namespace LimbusCompanyFR.EO
{
    internal class EO_StoryUI
    {
        #region Kill Count Green Dawn
        [HarmonyPatch(typeof(KillCountUI), nameof(KillCountUI.Init))]
        [HarmonyPostfix]
        private static void KillCount(KillCountUI __instance)
        {
            __instance._testTitleText.m_fontAsset = LCB_French_Font.GetFrenchFonts(3);
            __instance._testTitleText.m_sharedMaterial = LCB_French_Font.GetFrenchMats(12);

            __instance._testkillCountNameText.m_fontAsset = LCB_French_Font.GetFrenchFonts(4);
            __instance._testkillCountNameText.m_sharedMaterial = LCB_French_Font.GetFrenchMats(17);
        }
        #endregion

        #region Dairy
        [HarmonyPatch(typeof(StoryNotePage), nameof(StoryNotePage.SetData))]
        [HarmonyPostfix]
        private static void Diary_Init(StoryNotePage __instance)
        {
            __instance.tmp_title.GetComponentInChildren<TextMeshProLanguageSetter>(true).enabled = false;
            __instance.tmp_title.font = LCB_French_Font.GetFrenchFonts(1);
            __instance.tmp_title.fontMaterial = LCB_French_Font.GetFrenchFonts(1).material;

            __instance.tmp_content.GetComponentInChildren<TextMeshProLanguageSetter>(true).enabled = false;
            __instance.tmp_content.font = LCB_French_Font.GetFrenchFonts(1);
            __instance.tmp_content.fontMaterial = LCB_French_Font.GetFrenchFonts(1).material;
        }
        public static void Handwriting(Transform transform)
        {
            transform.GetComponentInChildren<TextMeshProLanguageSetter>(true).enabled = false;
            transform.GetComponentInChildren<TextMeshProUGUI>(true).m_fontAsset = LCB_French_Font.GetFrenchFonts(1);
            transform.GetComponentInChildren<TextMeshProUGUI>(true).m_sharedMaterial = LCB_French_Font.GetFrenchFonts(1).material;
            transform.GetComponentInChildren<TextMeshProUGUI>(true).lineSpacing = -40;
            if (transform.GetComponentInChildren<TextMeshProUGUI>(true).fontSize == 30)
                transform.GetComponentInChildren<TextMeshProUGUI>(true).fontSize = 46;
        }
        public static void HandwritingStroke(List<Transform> diary)
        {
            foreach (Transform stroke in diary)
            {
                Handwriting(stroke);
            }
        }
        [HarmonyPatch(typeof(StoryManager), nameof(StoryManager.Init))]
        [HarmonyPostfix]
        private static void DiaryHandwriting(StoryManager __instance)
        {
            List<Transform> le_diary = new List<Transform>()
            {
                __instance._noteEffect._diary.currentLeft.contentParent.transform.Find("[Rect]Content/[Text]Title"),
                __instance._noteEffect._diary.currentLeft.contentParent.transform.Find("[Rect]Content/[Text]Text"),
                __instance._noteEffect._diary.currentRight.contentParent.transform.Find("[Rect]Content/[Text]Title"),
                __instance._noteEffect._diary.currentRight.contentParent.transform.Find("[Rect]Content/[Text]Text")
            };
            foreach (Transform stroke in le_diary)
            {
                HandwritingStroke(le_diary);
            }
        }
        #endregion
    }
}
