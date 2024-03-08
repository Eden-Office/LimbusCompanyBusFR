using HarmonyLib;
using MainUI;
using UnityEngine.EventSystems;
using TMPro;
using static UI.Utility.InfoModels;
using UnityEngine;
using UnityEngine.UI;
using UI;

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
                date.GetComponentInChildren<TextMeshProUGUI>(true).text = "04:00 22.02.2024(Jeu) - 02:00 21.03.2024(Jeu) (CET)";
                date.GetComponentInChildren<TextMeshProUGUI>(true).font = LCB_French_Font.tmpfrenchfonts[2];
                date.GetComponentInChildren<TextMeshProUGUI>(true).fontMaterial = LCB_French_Font.tmpfrenchfonts[2].material;
            }
        }
        [HarmonyPatch(typeof(YCGDRewardUIPopup), nameof(YCGDRewardUIPopup.Initialize))]
        [HarmonyPostfix]
        private static void YCGD_RewardUI(YCGDRewardUIPopup __instance)
        {
            __instance.img_logo.sprite = EO_ReadmeManager.ReadmeEventSprites["EO_YCGD_Logo"];
            __instance.tmp_eventDate.text = "04:00 22.02.2024(Jeu) - 02:00 28.03.2024(Jeu) (CET)";
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
    }
}
