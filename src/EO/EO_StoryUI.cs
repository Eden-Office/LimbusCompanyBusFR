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

        #region Diary
        [HarmonyPatch(typeof(BookPageContent), nameof(BookPageContent.GetShowTextSequence))]
        [HarmonyPrefix]
        private static void Diary_Book(BookPageContent __instance)
        {
            if (__instance.tmp_content != null)
            {
                __instance.tmp_content.m_fontAsset = LCB_French_Font.tmpfrenchfonts[1];
                __instance.tmp_content.m_sharedMaterial = LCB_French_Font.tmpfrenchfonts[1].material;
                __instance.tmp_content.SetAllDirty();
            }
            if (__instance.tmp_title != null)
            {
                __instance.tmp_title.m_fontAsset = LCB_French_Font.tmpfrenchfonts[1];
                __instance.tmp_title.m_sharedMaterial = LCB_French_Font.tmpfrenchfonts[1].material;
                __instance.tmp_title.SetAllDirty();
            }
            if (__instance.tmp_titleReference != null)
            {
                __instance.tmp_titleReference.m_fontAsset = LCB_French_Font.tmpfrenchfonts[1];
                __instance.tmp_titleReference.m_sharedMaterial = LCB_French_Font.tmpfrenchfonts[1].material;
                __instance.tmp_titleReference.SetAllDirty();
            }
        }
        #endregion

        #region Dante Ability
        [HarmonyPatch(typeof(DanteAbilityUIController), nameof(DanteAbilityUIController.SetActivePopup))]
        [HarmonyPostfix]
        private static void DanteAbilityUIController_Sefiroth(DanteAbilityUIController __instance)
        {
            Color yellowish = new Color(3.9533f, 1.097f, 0, 0.05f);
            foreach (var slot in __instance._showAbilitySlotList)
            {
                var caution = slot._graphicList[4].GetComponentInChildren<TextMeshProUGUI>();
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
            __instance._sinButton.tmp_text.text = "Affinités de Péché";
            __instance._enemyPassiveButton.tmp_text.text = "<size=70%><nobr>Passives</nobr>  ennemies</size>";
            __instance._enemyPassiveButton.tmp_text.lineSpacing = 10;
        }
        #endregion
    }
}
