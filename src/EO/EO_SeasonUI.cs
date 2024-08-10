using HarmonyLib;
using MainUI;
using MainUI.VendingMachine;
using UnityEngine;

namespace LimbusCompanyFR
{
    internal class EO_SeasonUI
    {
        [HarmonyPatch(typeof(MainLobbyBannerSlot), nameof(MainLobbyBannerSlot.Update))]
        [HarmonyPostfix]
        private static void MainLobbyUIPanel_Init(MainLobbyBannerSlot __instance)
        {
            //MAIN MENU
            Sprite banner = __instance.img_main.sprite;
            if (banner.name.Contains("banner_battlepass_season4"))
                __instance.img_main.overrideSprite = EO_ReadmeManager.ReadmeEventSprites["Season4_Banner"];
        }
        [HarmonyPatch(typeof(VendingMachineBannerSlot), nameof(VendingMachineBannerSlot.SetData))]
        [HarmonyPostfix]
        private static void VendingMachineBannerSlot_Init(BannerSlot<VendingMachineStaticDataList> __instance)
        {
            if (__instance._id == 4)
            {
                __instance._base._bannerImage.m_OverrideSprite = EO_ReadmeManager.ReadmeEventSprites["Season4_Shop"];
            }
            else if (__instance._id == 3)
            {
                __instance._base._bannerImage.m_OverrideSprite = EO_ReadmeManager.ReadmeEventSprites["Season3_Shop"];
            }
            else if (__instance._id == 2)
            {
                __instance._base._bannerImage.m_OverrideSprite = EO_ReadmeManager.ReadmeEventSprites["Season2_Shop"];
            }
            else if (__instance._id == 1)
            {
                __instance._base._bannerImage.m_OverrideSprite = EO_ReadmeManager.ReadmeEventSprites["Season1_Shop"];
            }
        }
        [HarmonyPatch(typeof(BattlePassUIPopup), nameof(BattlePassUIPopup.SetupBaseData))]
        [HarmonyPostfix]
        private static void SeasonPass_Init(BattlePassUIPopup __instance)
        {
            __instance.seasonPeriod.font = LCB_French_Font.tmpfrenchfonts[1];
            __instance.seasonPeriod.fontMaterial = LCB_French_Font.tmpfrenchfonts[1].material;
            __instance.seasonPeriod.text = "28.03.2024 04:00 (CET) ~";

            //FLAGS
            __instance.seasonPeriod.m_isRebuildingLayout = false;
            __instance.seasonPeriod.ignoreVisibility = true;
            __instance.seasonPeriod.isOverlay = false;
            __instance.seasonPeriod.m_ignoreCulling = true;
            __instance.seasonPeriod.isOverlay = false;
            __instance.seasonPeriod.m_isOverlay = false;
            __instance.seasonPeriod.m_isParsingText = true;
            __instance.seasonPeriod.m_RaycastTarget = false;
            __instance.seasonPeriod.raycastTarget = false;
        }
    }
}
