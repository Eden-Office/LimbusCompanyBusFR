using HarmonyLib;
using MainUI;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
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
            //Transform logo = __instance.transform.Find("[Rect]UIObjs/[Image]TitleLogo");
            //if (logo != null)
            //    logo.GetComponentInChildren<Image>(true).sprite = EO_ReadmeManager.ReadmeEventSprites["EO_YCGD_Logo"];
            Transform date = __instance.transform.Find("[Rect]UIObjs/[Image]TitleLogo/[Rect]EventPeriod/tmp_period");
            if (date != null)
            {
                //date.GetComponentInChildren<TextMeshProUGUI>(true).text = "04:00 22.02.2024(JEU) - 02:00 21.03.2024(JEU) (CET)";
                date.GetComponentInChildren<TextMeshProUGUI>(true).font = LCB_French_Font.tmpfrenchfonts[2];
                date.GetComponentInChildren<TextMeshProUGUI>(true).fontMaterial = LCB_French_Font.tmpfrenchfonts[2].material;
            }
        }
        [HarmonyPatch(typeof(YCGDRewardUIPopup), nameof(YCGDRewardUIPopup.Initialize))]
        [HarmonyPostfix]
        private static void YCGD_RewardUI(YCGDRewardUIPopup __instance)
        {
            //__instance.img_logo.sprite = EO_ReadmeManager.ReadmeEventSprites["EO_YCGD_Logo"];
            //__instance.tmp_eventDate.text = "04:00 22.02.2024(JEU) - 02:00 28.03.2024(JEU) (CET)";
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

        #region Murder on the Warp Express
        [HarmonyPatch(typeof(MOWEMainEventBanner), nameof(MOWEMainEventBanner.Init))]
        [HarmonyPostfix]
        private static void MOWE_MainBanner(MOWEMainEventBanner __instance)
        {
            __instance._bannerImage.overrideSprite = EO_ReadmeManager.ReadmeEventSprites["MOWE_lateBanner"];
        }
        [HarmonyPatch(typeof(MOWESubEventBanner), nameof(MOWESubEventBanner.Init))]
        [HarmonyPostfix]
        private static void MOWE_SubBanner(MOWESubEventBanner __instance)
        {
            __instance._bannerImage.overrideSprite = EO_ReadmeManager.ReadmeEventSprites["MOWE_lateBannerExchange"];
        }

        [HarmonyPatch(typeof(MOWEEventUIPanel), nameof(MOWEEventUIPanel.Initialize))]
        [HarmonyPostfix]
        private static void MOWE_MainEvent(MOWEEventUIPanel __instance)
        {
            var intro = __instance.transform.Find("MOWE_introgroup");
            Image text = intro.Find("[Image]Typo").GetComponent<Image>();
            text.m_OverrideSprite = EO_ReadmeManager.ReadmeEventSprites["MOWE_Intro"];

            Transform logo = __instance.transform.Find("[Rect]UIObjs/[Rect]Title/[Image]TitleLogo");
            if (logo != null)
            {
                if (logo.GetComponentInChildren<Image>(true).sprite.name.EndsWith("11") || logo.GetComponentInChildren<Image>(true).sprite.name.EndsWith("07") || logo.GetComponentInChildren<Image>(true).sprite.name.EndsWith("09"))
                    logo.GetComponentInChildren<Image>(true).overrideSprite = EO_ReadmeManager.ReadmeEventSprites["MOWE_Logo"];
                else if (logo.GetComponentInChildren<Image>(true).sprite.name.EndsWith("24") || logo.GetComponentInChildren<Image>(true).sprite.name.EndsWith("25") || logo.GetComponentInChildren<Image>(true).sprite.name.EndsWith("26"))
                    logo.GetComponentInChildren<Image>(true).overrideSprite = EO_ReadmeManager.ReadmeEventSprites["MOWE_Logo_Blood"];
            }
            Transform date = __instance.transform.Find("[Rect]UIObjs/[Rect]Title/[Image]TitleLogo/tmp_period");
            if (date != null)
            {
                date.GetComponentInChildren<TextMeshProUGUI>(true).text = "04:00 08.08.2024(JEU) - 02:00 05.09.2024(JEU) (CET)";
                date.GetComponentInChildren<TextMeshProUGUI>(true).font = LCB_French_Font.tmpfrenchfonts[2];
                date.GetComponentInChildren<TextMeshProUGUI>(true).fontMaterial = LCB_French_Font.tmpfrenchfonts[2].material;
            }
            __instance.btn_theater.tmp_buttonText.lineSpacing = -30;
        }
        [HarmonyPatch(typeof(MOWERewardUIPopup), nameof(MOWERewardUIPopup.SetData))]
        [HarmonyPostfix]
        private static void MOWE_RewardUI(MOWERewardUIPopup __instance)
        {
            __instance.img_logo.overrideSprite = EO_ReadmeManager.ReadmeEventSprites["MOWE_Logo"];
            __instance.tmp_eventDate.text = "04:00 08.08.2024(JEU) - 02:00 12.09.2024(JEU) (CET)";
            __instance.tmp_eventDate.font = LCB_French_Font.tmpfrenchfonts[2];
            __instance.tmp_eventDate.fontMaterial = LCB_French_Font.tmpfrenchfonts[2].material;
        }
        [HarmonyPatch(typeof(MOWERewardButton), nameof(MOWERewardButton.SetData))]
        [HarmonyPostfix]
        private static void MOWE_ExchangeButton(MOWERewardButton __instance)
        {
            GameObject MOWE = GameObject.Find("[Canvas]RatioMainUI/[Rect]PopupRoot/[UIPopup]MOWE_Reward(Clone)/EventDescriptionPanel/[Image]ItemCounterPanel/tmp_label_itemCounter");
            MOWE.GetComponentInChildren<UITextDataLoader>(true).enabled = false;
            if (__instance.tmp_number.text == "1")
                MOWE.GetComponentInChildren<TextMeshProUGUI>(true).text = "Pack Possédé";
            else
                MOWE.GetComponentInChildren<TextMeshProUGUI>(true).text = "Packs Possédés";

            __instance.transform.Find("Image").GetComponentInChildren<Image>(true).overrideSprite = EO_ReadmeManager.ReadmeEventSprites["MOWE_Exchange"];
        }
        #endregion

        #region 4th Walpurgisnacht

        [HarmonyPatch(typeof(WalpuEventRewardUIPopupBase), nameof(WalpuEventRewardUIPopupBase.InitEventStataicData))]
        [HarmonyPostfix]
        private static void Walpurgisnacht_Lobotomy_Missions(WalpuEventRewardUIPopupBase __instance)
        {
            Image description = __instance.transform.Find("EventDescriptionPanel").GetComponentInChildren<Image>(true);
            description.overrideSprite = EO_ReadmeManager.ReadmeEventSprites["WN_LC_Desc"];

            Image background = __instance.transform.Find("[Image]Background").GetComponentInChildren<Image>(true);
            background.overrideSprite = EO_ReadmeManager.ReadmeEventSprites["WN4_BG"];
        }
        [HarmonyPatch(typeof(WalpuEventRewardUIPopupBase), nameof(WalpuEventRewardUIPopupBase.InitDateText))]
        [HarmonyPostfix]
        private static void Walpurgisnacht_Lobotomy_Date(WalpuEventRewardUIPopupBase __instance)
        {
            __instance.tmp_eventDate.m_fontAsset = LCB_French_Font.GetFrenchFonts(2);
            __instance.tmp_eventDate.m_sharedMaterial = LCB_French_Font.GetFrenchMats(7);
            __instance.tmp_eventDate.text = "<size=60>06:00 5.09.2024(ЧТ) - 04:00 26.09.2024(ЧТ) (МСК)</size>";
            __instance.tmp_eventDate.GetComponentInChildren<RectTransform>(true).anchoredPosition = new Vector2(__instance.tmp_eventDate.GetComponentInChildren<RectTransform>(true).anchoredPosition.x, __instance.tmp_eventDate.GetComponentInChildren<RectTransform>(true).anchoredPosition.y - 12);
        }
        [HarmonyPatch(typeof(WalpuEventRewardButtonBase), nameof(WalpuEventRewardButtonBase.SetData))]
        [HarmonyPostfix]
        private static void Walpurgisnacht_Lobotomy_CompleteLabel(WalpuEventRewardButtonBase __instance)
        {
            __instance._completeImage.overrideSprite = EO_ReadmeManager.ReadmeEventSprites["WN_LC_Clear"];
        }

        [HarmonyPatch(typeof(WalpuEventPanelBase), nameof(WalpuEventPanelBase.Initialize))]
        [HarmonyPostfix]
        private static void Walpurgis_4th(WalpuEventPanelBase __instance)
        {
            __instance._dateText.m_fontAsset = LCB_French_Font.GetFrenchFonts(0);
            __instance._dateText.m_sharedMaterial = LCB_French_Font.GetFrenchMats(3);
            __instance._dateText.text = "06:00 5.09.2024(ЧТ) - 04:00 19.09.2024(ЧТ) (МСК)";
        }

        [HarmonyPatch(typeof(Walpu3SubEventBanner), nameof(Walpu3SubEventBanner.UpdateBanner))]
        [HarmonyPostfix]
        private static void Walpu_Missions(Walpu3SubEventBanner __instance)
        {
            __instance._bannerImage.overrideSprite = EO_ReadmeManager.ReadmeEventSprites["WN4_Mission_Banner"];
        }

        #endregion
    }
}
