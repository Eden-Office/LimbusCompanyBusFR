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
        #region Story
        [HarmonyPatch(typeof(StoryManager), nameof(StoryManager.Init))]
        [HarmonyPostfix]
        private static void StoryManager_SetData(StoryManager __instance)
        {
            __instance._dialogCon.tmp_name.lineSpacing = -25;
        }
        #endregion

        #region Introduction
        [HarmonyPatch(typeof(StoryIntroduceCharacterDescription), nameof(StoryIntroduceCharacterDescription.SetData))]
        [HarmonyPostfix]
        private static void IntroductionDescription(StoryIntroduceCharacterDescription __instance)
        {
            foreach (TextMeshProUGUI desc in __instance._textList)
            {
                Color glow = new Color(desc.color.r, desc.color.g, desc.color.b, 0.25f);
                desc.m_sharedMaterial = LCB_French_Font.GetFrenchMats(16);
                desc.m_sharedMaterial.SetFloat("_GlowInner", (float)0.4);
                desc.m_sharedMaterial.SetFloat("_GlowOuter", (float)0.6);
                desc.m_sharedMaterial.SetFloat("_GlowPower", 3);
                desc.m_sharedMaterial.SetColor("_GlowColor", glow);
            }
        }
        #endregion

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

        #region Dante Ability
        [HarmonyPatch(typeof(DanteAbilityUIController), nameof(DanteAbilityUIController.UpdatePopup))]
        [HarmonyPostfix]
        private static void DanteAbilityUI_TitleChanger(DanteAbilityUIController __instance)
        {
            Color yellowish = new Color(1.0f, 0.306f, 0, 0.502f);

            TextMeshProUGUI title = __instance._titleText;
            title.color = Color.yellow;
            title.m_sharedMaterial = LCB_French_Font.GetFrenchMats(11);
            title.fontMaterial.EnableKeyword("GLOW_ON");
            title.fontMaterial.SetColor("_GlowColor", yellowish);
            title.fontMaterial.SetFloat("_GlowInner", (float)0.6);
            title.fontMaterial.SetFloat("_GlowPower", 0.8f);
            title.characterSpacing = 2;
        }

        [HarmonyPatch(typeof(DanteAbilityUIController), nameof(DanteAbilityUIController.SetActivePopup))]
        [HarmonyPostfix]
        private static void DanteAbilityUIController_Sefiroth(DanteAbilityUIController __instance)
        {
            Color yellowish = new Color(3.9533f, 1.097f, 0, 0.05f);
            foreach (var slot in __instance._showAbilitySlotList)
            {
                slot._nameText.m_fontAsset = LCB_French_Font.GetFrenchFonts(0);
                slot._nameText.m_sharedMaterial = LCB_French_Font.GetFrenchMats(1);
                slot._nameText.m_sharedMaterial.SetColor("_GlowColor", yellowish);
                var caution = slot._graphicList[4].GetComponentInChildren<TextMeshProUGUI>();
                caution.m_fontAsset = LCB_French_Font.GetFrenchFonts(0);
                caution.m_sharedMaterial = LCB_French_Font.GetFrenchMats(2);
                caution.text = "Attention";
            }
        }
        [HarmonyPatch(typeof(DanteAbilitySlot), nameof(DanteAbilitySlot.SetDescActive))]
        [HarmonyPostfix]
        private static void DanteAbilityUIController_Description(DanteAbilitySlot __instance)
        {
            if (__instance._nameText.enabled)
            {
                __instance._rawDescText.color = __instance._nameText.color;
            }
        }
        [HarmonyPatch(typeof(EnemyHudToggle), nameof(EnemyHudToggle.SetCurrentState))]
        [HarmonyPostfix]
        private static void DanteAbility_KillCount_Enemy(EnemyHudToggle __instance)
        {
            __instance._sinButton.tmp_text.m_fontAsset = LCB_French_Font.GetFrenchFonts(0);
            __instance._sinButton.tmp_text.m_sharedMaterial = LCB_French_Font.GetFrenchMats(2);
            __instance._sinButton.tmp_text.text = "Affinités de Péché";

            __instance._enemyPassiveButton.tmp_text.m_fontAsset = LCB_French_Font.GetFrenchFonts(0);
            __instance._enemyPassiveButton.tmp_text.m_sharedMaterial = LCB_French_Font.GetFrenchMats(2);
            __instance._enemyPassiveButton.tmp_text.text = "<size=70%><nobr>Passives</nobr>  ennemies</size>";
            __instance._enemyPassiveButton.tmp_text.lineSpacing = 10;
        }
        #endregion
    }
}
