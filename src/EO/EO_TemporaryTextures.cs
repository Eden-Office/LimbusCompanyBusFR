using BattleUI.Information;
using HarmonyLib;
using MainUI;
using MainUI.VendingMachine;
using TMPro;
using UnityEngine;
using MainUI.Gacha;
using BattleUI.Typo;
using BattleUI.BattleUnit;
using System.Collections.Generic;
using UtilityUI;
using MainUI.BattleResult;
using BattleUI;

namespace LimbusCompanyFR
{
    internal class EO_TemporaryTextures
    {
        #region Details
        [HarmonyPatch(typeof(GacksungLevelUpCompletionPopup), nameof(GacksungLevelUpCompletionPopup.UpdateAcquiredContentsLayout))]
        [HarmonyPostfix]
        private static void GacksungLevelUpCompletionPopup_Init(GacksungLevelUpCompletionPopup __instance)
        {
            __instance.tmp_contentTitle.transform.GetComponentInChildren<TextMeshProUGUI>().characterSpacing = 2;
            __instance.tmp_contentTitle.characterSpacing = 2;
        }
        [HarmonyPatch(typeof(Formation_PortraitEventSlotUI), nameof(Formation_PortraitEventSlotUI.OnPointerEnter))]
        [HarmonyPostfix]
        private static void ChangeSinner(Formation_PortraitEventSlotUI __instance)
        {
            __instance.tmp_text.lineSpacing = -30;
            __instance.tmp_text.characterSpacing = 3;
        }
        [HarmonyPatch(typeof(Formation_SelectParticipatedEventSlotUI), nameof(Formation_SelectParticipatedEventSlotUI.UpdateData))]
        [HarmonyPostfix]
        private static void ChangeSinner_Dungeon(Formation_SelectParticipatedEventSlotUI __instance)
        {
            __instance._materialSetter._text.lineSpacing = -30;
            __instance._materialSetter._text.characterSpacing = 3;
        }
        #endregion
    }
}
