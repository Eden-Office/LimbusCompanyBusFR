using HarmonyLib;
using MainUI;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
using BattleUI.Typo;
using MainUI.Gacha;

namespace LimbusCompanyFR
{
    internal class EO_EventUI
    {
        #region Base Things
        [HarmonyPatch(typeof(BattleResultUIRewardSlot), nameof(BattleResultUIRewardSlot.SetRewardState))]
        [HarmonyPostfix]
        private static void ExchangeEffectSprite(BattleResultUIRewardSlot __instance)
        {
            __instance._effectTag.overrideSprite = EO_ReadmeManager.ReadmeSprites["UserInfo_Effect"];
        }
        #endregion

        #region New Manager Banner
        [HarmonyPatch(typeof(BannerSlot<GachaBannerSlot>), nameof(BannerSlot<GachaBannerSlot>.SetData))]
        [HarmonyPostfix]
        private static void GachaBannerSlot_SetData(BannerSlot<GachaBannerSlot> __instance)
        {
            if (__instance._name == "gacha_3_illust")
            {
                __instance._base._bannerImage.sprite = EO_ReadmeManager.ReadmeEventSprites["NewManagerGacha_Banner"];
            }
        }
        [HarmonyPatch(typeof(GachaUIPanel), nameof(GachaUIPanel.SetGachaInfoPanel))]
        [HarmonyPostfix]
        private static void GachaUIPanel_SetData(GachaUIPanel __instance)
        {
            Sprite safe = __instance.img_displayCharacterCG.sprite;
            if (__instance._lastSettingId == 3)
            {
                __instance.img_displayCharacterCG.overrideSprite = EO_ReadmeManager.ReadmeSprites["NewManagerGacha"];
                __instance._currentGachaTitleImage.sprite = EO_ReadmeManager.ReadmeSprites["NewManagerGacha_Typo"];
            }
            else
            {
                __instance.img_displayCharacterCG.overrideSprite = safe;
            }
        }
        [HarmonyPatch(typeof(ChanceCounter), nameof(ChanceCounter.SetData))]
        [HarmonyPostfix]
        private static void ChanceCounter_SetData(ChanceCounter __instance)
        {
            __instance.tmp_number_of_times.text = "fois";
        }
        #endregion

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
            __instance._bannerImage.overrideSprite = EO_ReadmeManager.ReadmeEventSprites["MOWE_EventBanner"];
        }
        [HarmonyPatch(typeof(MOWESubEventBanner), nameof(MOWESubEventBanner.Init))]
        [HarmonyPostfix]
        private static void MOWE_SubBanner(MOWESubEventBanner __instance)
        {
            __instance._bannerImage.overrideSprite = EO_ReadmeManager.ReadmeEventSprites["MOWE_ExchangeBanner"];
        }

        [HarmonyPatch(typeof(MOWEEventUIPanel), nameof(MOWEEventUIPanel.UpdateButtonState))]
        [HarmonyPostfix]
        private static void MOWE_MainEvent(MOWEEventUIPanel __instance)
        {
            var intro = __instance.transform.Find("MOWE_introgroup");
            Image text = intro.Find("[Image]Typo").GetComponent<Image>();
            text.m_OverrideSprite = EO_ReadmeManager.ReadmeEventSprites["MOWE_Intro"];

            Transform logo = __instance.transform.Find("[Rect]UIObjs/[Rect]Title/[Image]TitleLogo");
            if (logo != null)
            {
                if (logo.GetComponentInChildren<Image>(true).sprite.name.EndsWith("11"))
                    logo.GetComponentInChildren<Image>(true).overrideSprite = EO_ReadmeManager.ReadmeEventSprites["MOWE_Logo"];
                else if (logo.GetComponentInChildren<Image>(true).sprite.name.EndsWith("7"))
                    logo.GetComponentInChildren<Image>(true).overrideSprite = EO_ReadmeManager.ReadmeEventSprites["MOWE_Logo"];
                else if (logo.GetComponentInChildren<Image>(true).sprite.name.EndsWith("9"))
                    logo.GetComponentInChildren<Image>(true).overrideSprite = EO_ReadmeManager.ReadmeEventSprites["MOWE_Logo"];
                else
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
    }
}
