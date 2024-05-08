using HarmonyLib;
using MainUI;
using UnityEngine.EventSystems;
using TMPro;
using static UI.Utility.InfoModels;
using UnityEngine;
using UnityEngine.UI;
using UI;
using BattleUI.Typo;

namespace LimbusCompanyFR
{
    internal class EO_EventUI
    {
        #region Yield My Flesh
        [HarmonyPatch(typeof(YCGDEventUIPanel), nameof(YCGDEventUIPanel.Initialize))]
        [HarmonyPostfix]
        private static void YCGD_MainEvent(YCGDEventUIPanel __instance)
        {
            Transform loading = __instance.transform.Find("[Rect]OpenProduceObj/[Image]EventLogo");
            if (loading != null)
                loading.GetComponentInChildren<Image>(true).sprite = EO_ReadmeManager.ReadmeEventSprites["EO_YCGD_Logo"];
            Transform logo = __instance.transform.Find("[Rect]UIObjs/[Image]TitleLogo");
            if (logo != null)
                logo.GetComponentInChildren<Image>(true).sprite = EO_ReadmeManager.ReadmeEventSprites["EO_YCGD_Logo"];
            Transform date = __instance.transform.Find("[Rect]UIObjs/[Image]TitleLogo/[Rect]EventPeriod/tmp_period");
            if (date != null)
            {
                date.GetComponentInChildren<TextMeshProUGUI>(true).text = "04:00 22.02.2024(JEU) - 02:00 21.03.2024(JEU) (CET)";
                date.GetComponentInChildren<TextMeshProUGUI>(true).font = LCB_French_Font.tmpfrenchfonts[2];
                date.GetComponentInChildren<TextMeshProUGUI>(true).fontMaterial = LCB_French_Font.tmpfrenchfonts[2].material;
            }
        }
        [HarmonyPatch(typeof(YCGDRewardUIPopup), nameof(YCGDRewardUIPopup.Initialize))]
        [HarmonyPostfix]
        private static void YCGD_RewardUI(YCGDRewardUIPopup __instance)
        {
            __instance.img_logo.sprite = EO_ReadmeManager.ReadmeEventSprites["EO_YCGD_Logo"];
            __instance.tmp_eventDate.text = "04:00 22.02.2024(JEU) - 02:00 28.03.2024(JEU) (CET)";
            __instance.tmp_eventDate.font = LCB_French_Font.tmpfrenchfonts[2];
            __instance.tmp_eventDate.fontMaterial = LCB_French_Font.tmpfrenchfonts[2].material;
        }
        [HarmonyPatch(typeof(YCGDMainEventBanner), nameof(YCGDMainEventBanner.Init))]
        [HarmonyPostfix]
        private static void YCGD_MainBanner(YCGDMainEventBanner __instance)
        {
            __instance._bannerImage.sprite = EO_ReadmeManager.ReadmeEventSprites["EO_YCGD_EventBanner"];
        }
        [HarmonyPatch(typeof(YCGDSubEventBanner), nameof(YCGDSubEventBanner.Init))]
        [HarmonyPostfix]
        private static void YCGD_SubBanner(YCGDSubEventBanner __instance)
        {
            __instance._bannerImage.sprite = EO_ReadmeManager.ReadmeEventSprites["EO_YCGD_ExchangeBanner"];
        }
        #endregion

        #region 3rd Walpurgisnacht
        [HarmonyPatch(typeof(Walpu3EventUIPanel), nameof(Walpu3EventUIPanel.Initialize))]
        [HarmonyPostfix]
        private static void ThirdWalpurgisDate(Walpu3EventUIPanel __instance)
        {
            GameObject thirdWalpurgisDate = GameObject.Find("[Canvas]RatioMainUI/[Rect]PanelRoot/[UIPanel]Walpu3_MainEvent(Clone)/[Image]DateBox/[Text]Date");
            if (thirdWalpurgisDate != null)
            {
                thirdWalpurgisDate.GetComponentInChildren<TextMeshProUGUI>(true).text = "04:00 02.05.2024 (JEU) - 00:00 16.05.2024 (JEU) (CET)";
                thirdWalpurgisDate.GetComponentInChildren<TextMeshProUGUI>(true).font = LCB_French_Font.tmpfrenchfonts[0];
                thirdWalpurgisDate.GetComponentInChildren<TextMeshProUGUI>(true).fontMaterial = LCB_French_Font.tmpfrenchfonts[0].material;
                __instance._logoImage.GetComponentInChildren<Image>(true).overrideSprite = EO_ReadmeManager.ReadmeEventSprites["EO_WN3_Logo"];
            }
        }
        [HarmonyPatch(typeof(Walpu3EventRewardPopup), nameof(Walpu3EventRewardPopup.Initialize))]
        [HarmonyPostfix]
        private static void ThirdWalpurgisReward(Walpu3EventUIPanel __instance)
        {
            GameObject thirdWalpurgisDate = GameObject.Find("[Canvas]RatioMainUI/[Rect]PopupRoot/[UIPopup]Walpu3_RewardEvent(Clone)/EventDescriptionPanel/[Text]EventPeriod");
            if (thirdWalpurgisDate != null)
            {
                thirdWalpurgisDate.GetComponentInChildren<TextMeshProUGUI>(true).text = "04:00 02.05.2024 (JEU) - 02:00 24.05.2024 (JEU) (CET)";
                thirdWalpurgisDate.GetComponentInChildren<TextMeshProUGUI>(true).font = LCB_French_Font.tmpfrenchfonts[0];
                thirdWalpurgisDate.GetComponentInChildren<TextMeshProUGUI>(true).fontMaterial = LCB_French_Font.tmpfrenchfonts[0].material;
            }
            GameObject logoImage = GameObject.Find("[Canvas]RatioMainUI/[Rect]PopupRoot/[UIPopup]Walpu3_RewardEvent(Clone)/EventDescriptionPanel/[Image]LocalizeLogo");
            if (logoImage != null)
                logoImage.GetComponentInChildren<Image>(true).sprite = EO_ReadmeManager.ReadmeEventSprites["EO_WN3_Logo"];
            GameObject namePopup = GameObject.Find("[Canvas]RatioMainUI/[Rect]PopupRoot/[UIPopup]Walpu3_RewardEvent(Clone)/[Image]PopupNameTag/[Text]PopupName");
            if (namePopup != null)
            {
                namePopup.GetComponentInChildren<UITextDataLoader>(true).enabled = false;
                namePopup.GetComponentInChildren<TextMeshProUGUI>(true).text = "Missions";
            }
        }
        [HarmonyPatch(typeof(Walpu3EventRewardButton), nameof(Walpu3EventRewardButton.SetData))]
        [HarmonyPostfix]
        private static void ThirdWalpuClear_Init(Walpu3EventRewardButton __instance)
        {
            __instance.cg_check.transform.Find("[Image]Complete").GetComponentInChildren<Image>(true).sprite = EO_ReadmeManager.ReadmeEventSprites["EO_WN3_Clear"];
        }
        [HarmonyPatch(typeof(ActTypoLORBattleResultUI), nameof(ActTypoLORBattleResultUI.Open))]
        [HarmonyPostfix]
        private static void LoR_Finisher(ActTypoLORBattleResultUI __instance)
        {
            __instance._stageResultText.font = LCB_French_Font.GetFrenchFonts(4);
            __instance._stageResultText.fontMaterial = LCB_French_Font.GetFrenchFonts(4).material;
            __instance._stageResultAlphaText.font = LCB_French_Font.GetFrenchFonts(4);
            __instance._stageResultAlphaText.fontMaterial = LCB_French_Font.GetFrenchFonts(4).material;
            if (__instance._isWin)
                __instance._resultTypoImage.overrideSprite = EO_ReadmeManager.ReadmeEventSprites["EO_WP3_Victory"];
            else
                __instance._resultTypoImage.overrideSprite = EO_ReadmeManager.ReadmeEventSprites["EO_WP3_Defeat"];
        }
        #endregion
    }
}
