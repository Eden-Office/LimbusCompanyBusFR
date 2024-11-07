using HarmonyLib;
using BattleUI;
using BattleUI.Typo;
using MainUI;
using MainUI.VendingMachine;
using UnityEngine;
using UnityEngine.UI;
using StorySystem;
using BattleUI.BattleUnit;
using MainUI.Gacha;
using Dungeon.Shop;
using System;

namespace LimbusCompanyFR
{
    public static class EO_SpriteUI
    {
        #region Combo
        [HarmonyPatch(typeof(ParryingTypoUI), nameof(ParryingTypoUI.SetParryingTypoData))]
        [HarmonyPrefix]
        private static void ParryingTypoUI_Init(ParryingTypoUI __instance)
        {
            GameObject combo = GameObject.Find("[Prefab]ParryingTypo(Clone)/[Rect]Pivot/[Fixed,Image]ParryingText");
            if (combo != null)
            {
                combo.GetComponent<Image>().sprite = EO_ReadmeManager.ReadmeSprites["Combo"];
            }
            __instance.img_parryingTypo.sprite = EO_ReadmeManager.ReadmeSprites["Combo"];
        }
        #endregion

        #region Login
        [HarmonyPatch(typeof(LoginSceneManager), nameof(LoginSceneManager.OnInitLoginInfoManagerEnd))]
        [HarmonyPostfix]
        private static void LoginSceneManager_Init(LoginSceneManager __instance)
        {
            Transform catchphrase = __instance._canvas.transform.Find("[Image]Catchphrase");
            Transform logo = __instance._canvas.transform.Find("[Image]Logo");
            if (catchphrase.GetComponentInChildren<Image>(true).sprite.name == "season_catchphrase")
            {
                catchphrase.GetComponentInChildren<Image>(true).sprite = EO_ReadmeManager.ReadmeSprites["Catchphrase"];
            }
            __instance.img_touchToStart.sprite = EO_ReadmeManager.ReadmeSprites["Start"];
            Transform motto = __instance.transform.Find("[Canvas]/[Image]RedLine/[Image]Phrase");
            Motto_Changer(catchphrase, logo, motto);
        }

        public static void Motto_Changer(Transform catchphrase, Transform logo, Transform motto)
        {
            DateTime event_start = new DateTime(2024, 8, 8, 3, 0, 0).ToLocalTime();
            DateTime event_end = new DateTime(2024, 9, 12, 2, 59, 0).ToLocalTime();

            DateTime startup = DateTime.Now;
            if (motto != null)
            {
                if (catchphrase.gameObject.active == true)
                    motto.GetComponentInChildren<Image>(true).sprite = EO_ReadmeManager.ReadmeSprites["Motto_Season"];
                else if (logo.gameObject.active == true)
                {
                    if (DateTime.Compare(startup, event_end) < 0)
                        motto.GetComponentInChildren<Image>(true).sprite = EO_ReadmeManager.ReadmeSprites["Motto_Event"];
                    else
                        motto.GetComponentInChildren<Image>(true).sprite = EO_ReadmeManager.ReadmeSprites["Motto_Default"];
                }
            }
        }
        #endregion

        #region Main Menu
        [HarmonyPatch(typeof(LowerControlUIPanel), nameof(LowerControlUIPanel.Initialize))]
        [HarmonyPostfix]
        private static void LunacyTag_Init(LowerControlUIPanel __instance)
        {
            Transform lunacyTag = __instance.transform.Find("[Rect]Pivot/[Rect]UserInfoUI/[Rect]Info/[Button]CurrencyInfo/[Image]CashTag");
            if (lunacyTag != null)
            {
                lunacyTag.GetComponentInChildren<Image>(true).sprite = EO_ReadmeManager.ReadmeSprites["LunacyTag"];
            }
        }
        #endregion

        #region Friends
        [HarmonyPatch(typeof(UserInfoTicketItem), nameof(UserInfoTicketItem.SetData))]
        [HarmonyPostfix]
        private static void TicketInfoPopup_EffectSprite(UserInfoTicketItem __instance)
        {
            __instance._useEffectTagImage.overrideSprite = EO_ReadmeManager.ReadmeSprites["UserInfo_Effect"];
            __instance._subTicketUseEffectTagImage.overrideSprite = EO_ReadmeManager.ReadmeSprites["UserInfo_Effect"];
        }
        #endregion

        #region Vending Machine
        [HarmonyPatch(typeof(VendingMachineUIPanel), nameof(VendingMachineUIPanel.Initialize))]
        [HarmonyPostfix]
        private static void VendingMachineUIPanel_Init(VendingMachineUIPanel __instance)
        {
            Transform soldOut = __instance.transform.Find("GoodsStoreAreaMaster/GoodsStorePanelGroup/BackPanel/Main/SoldOut");
            if (soldOut != null)
            {
                soldOut.GetComponentInChildren<Image>(true).sprite = EO_ReadmeManager.ReadmeSprites["SoldOut"];
            }
        }
        #endregion

        #region Formation UI
        [HarmonyPatch(typeof(FormationPersonalityUI), nameof(FormationPersonalityUI.Initialize))]
        [HarmonyPostfix]
        private static void FormationPersonalityUI_Init(FormationPersonalityUI __instance)
        {
            __instance.img_isParticipaged.sprite = EO_ReadmeManager.ReadmeSprites["InParty"];
            __instance.img_support.sprite = EO_ReadmeManager.ReadmeSprites["SupportTag"];
            __instance._redDot.GetComponentInChildren<Image>(true).sprite = EO_ReadmeManager.ReadmeSprites["New"];
        }
        [HarmonyPatch(typeof(FormationSwitchablePersonalityUIScrollViewItem), nameof(FormationSwitchablePersonalityUIScrollViewItem.Initialize))]
        [HarmonyPostfix]
        private static void FormationSwitchablePersonalityUIScrollViewItem_Init(FormationSwitchablePersonalityUIScrollViewItem __instance)
        {
            Transform img_isParticipaged = __instance._participatedObject.transform.parent.parent.parent.Find("[Image]ParticipateSlotUI");
            img_isParticipaged.GetComponentInChildren<Image>(true).sprite = EO_ReadmeManager.ReadmeSprites["InParty"];
            __instance._newAcquiredRedDot.GetComponentInChildren<Image>(true).sprite = EO_ReadmeManager.ReadmeSprites["New"];
        }
        [HarmonyPatch(typeof(FormationSwitchableSupporterPersonalityUIScrollViewItem), nameof(FormationSwitchableSupporterPersonalityUIScrollViewItem.SetData))]
        [HarmonyPostfix]
        private static void YobenBoben(FormationSwitchableSupporterPersonalityUIScrollViewItem __instance)
        {
            __instance._selectedFrame.sprite = EO_ReadmeManager.ReadmeSprites["InParty"];
        }
        [HarmonyPatch(typeof(FormationPersonalityUI_Label), nameof(FormationPersonalityUI_Label.Reload))]
        [HarmonyPostfix]
        private static void Participation_Label(FormationPersonalityUI_Label __instance)
        {
            if (__instance.img_label.sprite.name == "New_MainUI_Formation_1_2")
                __instance.img_label.overrideSprite = EO_ReadmeManager.ReadmeSprites["InParty"];
        }
        [HarmonyPatch(typeof(PersonalityUILabelScriptable), nameof(PersonalityUILabelScriptable.Convert))]
        [HarmonyPostfix]
        private static void ParticipationLabel_Scriptable(PersonalityUILabelScriptable __instance)
        {
            __instance._participatedLabelSprite = EO_ReadmeManager.ReadmeSprites["InParty"];
            __instance._batonSprite = EO_ReadmeManager.ReadmeSprites["Backup_Label"];
        }
        [HarmonyPatch(typeof(FormationEgoSlot), nameof(FormationEgoSlot.SetData))]
        [HarmonyPostfix]
        private static void FormationEgoSlot_Init(FormationEgoSlot __instance)
        {
            __instance._redDot.GetComponentInChildren<Image>(true).overrideSprite = EO_ReadmeManager.ReadmeSprites["New"];
        }
        [HarmonyPatch(typeof(FormationSwitchablePersonalityUIPanel), nameof(FormationSwitchablePersonalityUIPanel.SetDataOpen))]
        [HarmonyPostfix]
        private static void FormationSwitchablePersonalityUIPanel_Init(FormationSwitchablePersonalityUIPanel __instance)
        {
            Transform newPersonality = __instance.transform.Find("[Script]RightPanel/[Script]FormationEgoList/[Script]RedDot");
            __instance._egoRedDot.GetComponentInChildren<Image>(true).overrideSprite = EO_ReadmeManager.ReadmeSprites["New"];
            __instance._personalityRedDot.GetComponentInChildren<Image>(true).overrideSprite = EO_ReadmeManager.ReadmeSprites["New"];
            if (newPersonality != null)
                newPersonality.GetComponentInChildren<Image>(true).overrideSprite = EO_ReadmeManager.ReadmeSprites["New"];
        }
        [HarmonyPatch(typeof(FormationSwitchableEgoUIScrollViewItem), nameof(FormationSwitchableEgoUIScrollViewItem.SetData))]
        [HarmonyPostfix]
        private static void RedDotAgain_Init(FormationSwitchableEgoUIScrollViewItem __instance)
        {
            __instance._newAcquiredRedDot.GetComponentInChildren<Image>(true).sprite = EO_ReadmeManager.ReadmeSprites["New"];
        }
        #endregion

        #region Support Formation UI
        [HarmonyPatch(typeof(FormationSwitchablePersonalityUIPanel), nameof(FormationSwitchablePersonalityUIPanel.SetDataOpen))]
        [HarmonyPostfix]
        private static void Support_Init(FormationSwitchablePersonalityUIPanel __instance)
        {
            // SUPPORT TAG
            Transform support_tag = __instance.transform.Find("[Script]RightPanel/[Script]FormationEgoList/[Image]SupportTag");
            if (support_tag != null)
                support_tag.GetComponentInChildren<Image>(true).sprite = EO_ReadmeManager.ReadmeSprites["SupportTag"];
        }
        #endregion

        #region Mirror Dungeon
        [HarmonyPatch(typeof(AbnormalityStatUI), nameof(AbnormalityStatUI.SetAbnormalityGuideUIActive))]
        [HarmonyPostfix]
        private static void BottomStat_Init(AbnormalityStatUI __instance)
        {
            Transform new_info = __instance.transform.Find("[Rect]FixedScalePivot/[Text]UnitName/[Image]Icon");
            if (new_info != null)
                new_info.GetComponentInChildren<Image>(true).sprite = EO_ReadmeManager.ReadmeSprites["NewInfo"];
        }
        [HarmonyPatch(typeof(MirrorDungeonShopItemSlot), nameof(MirrorDungeonShopItemSlot.SetData))]
        [HarmonyPostfix]
        private static void MirrorDungeonShopItemSlot_Init(MirrorDungeonShopItemSlot __instance)
        {
            __instance._soldOutTitleObject.GetComponentInChildren<UnityEngine.UI.Image>().sprite = EO_ReadmeManager.ReadmeSprites["Mirror_SoldOut"];
        }
        #endregion

        #region Battle UI
        [HarmonyPatch(typeof(BattleUIRoot), nameof(BattleUIRoot.Init))]
        [HarmonyPostfix]
        private static void BattleUI_Init(BattleUIRoot __instance)
        {
            Transform waveUI = __instance.transform.Find("[Canvas]PerspectiveUI/SafeArea/[Script]WaveUI/[Rect]Pivot/[Image]WavePanel");
            Transform turnUI = __instance.transform.Find("[Canvas]PerspectiveUI/SafeArea/[Script]WaveUI/[Rect]Pivot/[Image]TurnPanel");
            Transform start = __instance.transform.Find("[Canvas,Script]BattleUIController/SafeArea/[Script]NewOperationController/[Rect]ActiveControl/[Rect]Pivot/[Rect]ActionableSlotList/[Layout]SinActionSlotsGrid/[EventTrigger]EndButton/[Image]RightLeg/[Rect]StartUI/[Rect]Pivot/[Image]Start");
            if (waveUI != null)
            {
                waveUI.GetComponentInChildren<Image>(true).sprite = EO_ReadmeManager.ReadmeSprites["WaveUI"];
                waveUI.GetComponentInChildren<Image>(true).m_Sprite = EO_ReadmeManager.ReadmeSprites["WaveUI"];
                waveUI.GetComponentInChildren<Image>(true).overrideSprite = EO_ReadmeManager.ReadmeSprites["WaveUI"];
            }
            if (turnUI != null)
            {
                turnUI.GetComponentInChildren<Image>(true).sprite = EO_ReadmeManager.ReadmeSprites["TurnUI"];
                turnUI.GetComponentInChildren<Image>(true).m_Sprite = EO_ReadmeManager.ReadmeSprites["TurnUI"];
                turnUI.GetComponentInChildren<Image>(true).overrideSprite = EO_ReadmeManager.ReadmeSprites["TurnUI"];
            }
            if (start != null)
            {
                start.GetComponentInChildren<Image>(true).sprite = EO_ReadmeManager.ReadmeSprites["StartBattle"];
                start.GetComponentInChildren<Image>(true).m_Sprite = EO_ReadmeManager.ReadmeSprites["StartBattle"];
                start.GetComponentInChildren<Image>(true).overrideSprite = EO_ReadmeManager.ReadmeSprites["StartBattle"];
            }
        }
        [HarmonyPatch(typeof(ActTypoController), nameof(ActTypoController.Init))]
        [HarmonyPostfix]
        private static void PreBattleUI_Init(ActTypoController __instance)
        {
            Transform turn = __instance.transform.Find("[Rect]Active/[Script]ActTypoTurnUI/[Image]Turn");
            if (turn != null)
            {
                turn.GetComponentInChildren<Image>(true).sprite = EO_ReadmeManager.ReadmeSprites["Turn"];
                turn.GetComponentInChildren<Image>(true).m_Sprite = EO_ReadmeManager.ReadmeSprites["Turn"];
                turn.GetComponentInChildren<Image>(true).overrideSprite = EO_ReadmeManager.ReadmeSprites["Turn"];
            }
        }
        //[HarmonyPatch(typeof(BattleSkillViewUIOverClock), nameof(BattleSkillViewUIOverClock.SetActiveOverClock))]
        //[HarmonyPostfix]
        //private static void OverClock_Init(BattleSkillViewUIOverClock __instance)
        //{
        //    Transform overclock_stable = __instance.transform.Find("[Canvas]Canvas/[Script]SkillViewCanvas/OverClock/OverClockImg");
        //    if (overclock_stable != null)
        //    {
        //        overclock_stable.GetComponentInChildren<Image>(true).sprite = EO_ReadmeManager.ReadmeSprites["Overclock"];
        //        overclock_stable.GetComponentInChildren<Image>(true).m_Sprite = EO_ReadmeManager.ReadmeSprites["Overclock"];
        //        overclock_stable.GetComponentInChildren<Image>(true).overrideSprite = EO_ReadmeManager.ReadmeSprites["Overclock"];
        //        __instance._image_OverClock.sprite = EO_ReadmeManager.ReadmeSprites["Overclock"];
        //        __instance._image_OverClock.m_Sprite = EO_ReadmeManager.ReadmeSprites["Overclock"];
        //        __instance._image_OverClock.overrideSprite = EO_ReadmeManager.ReadmeSprites["Overclock"];
        //    }
        //}
        #endregion

        #region Skip Button
        [HarmonyPatch(typeof(GachaResultUI), nameof(GachaResultUI.Initialize))]
        [HarmonyPostfix]
        private static void SkipGacha_Init(GachaResultUI __instance)
        {
            Transform skip_gacha = __instance.transform.Find("[Rect]GetNewCardRoot/[Button]Skip");
            if (skip_gacha != null)
            {
                skip_gacha.GetComponentInChildren<Image>(true).sprite = EO_ReadmeManager.ReadmeSprites["Skip"];
            }
        }
        #endregion

        #region Auto Button
        [HarmonyPatch(typeof(StoryManager), nameof(StoryManager.Init))]
        [HarmonyPostfix]
        private static void AutoButton_Init(StoryManager __instance)
        {
            Transform autoButton = __instance._nonPostProcessRectTransform.transform.Find("[Rect]Buttons/[Rect]MenuObject/[Button]Auto");
            autoButton.GetComponentInChildren<Image>(true).sprite = EO_ReadmeManager.ReadmeSprites["AutoButton"];
            autoButton.GetComponentInChildren<StoryUIButton>(true)._buttonImageList[0] = EO_ReadmeManager.ReadmeSprites["AutoButton"];
            autoButton.GetComponentInChildren<StoryUIButton>(true)._buttonImageList[1] = EO_ReadmeManager.ReadmeSprites["AutoButton_Enabled"];
            autoButton.GetComponentInChildren<StoryUIButton>(true)._buttonImageList[2] = EO_ReadmeManager.ReadmeSprites["TextButton"];
        }
        #endregion

        #region BattleEnding
        [HarmonyPatch(typeof(ActBattleEndTypoUI), nameof(ActBattleEndTypoUI.Open))]
        [HarmonyPostfix]
        private static void ActBattleEndTypoUI_Init(ActBattleEndTypoUI __instance)
        {
            Transform Def = __instance._defeatGroup.transform.Find("[Image]Typo_Defeat");
            Transform Win = __instance._victoryGroup.transform.Find("[Image]Typo_Victory");
            Def.GetComponentInChildren<Image>().overrideSprite = EO_ReadmeManager.ReadmeSprites["Defeat_Text"];
            Win.GetComponentInChildren<Image>().overrideSprite = EO_ReadmeManager.ReadmeSprites["Victory_Text"];
        }
        [HarmonyPatch(typeof(BattleResultUIPanel), nameof(BattleResultUIPanel.SetStatusUI))]
        [HarmonyPostfix]
        private static void BattleResultUIPanel_Init(BattleResultUIPanel __instance)
        {
            if (__instance.img_ResultMark.sprite.name == "MainUI_BattleResult_1_20")
            {
                __instance.img_ResultMark.overrideSprite = EO_ReadmeManager.ReadmeSprites["Defeat"];
            }
            else
            {
                __instance.img_ResultMark.overrideSprite = EO_ReadmeManager.ReadmeSprites["Victory"];
            }
            __instance.img_exclear.overrideSprite = EO_ReadmeManager.ReadmeSprites["EX"];
        }
        #endregion

        #region GachaResult
        [HarmonyPatch(typeof(GachaCardUI), nameof(GachaCardUI.OnDisable))]
        [HarmonyPostfix]
        private static void GachaCardUI_SetData(GachaCardUI __instance)
        {
            __instance.img_newMark.overrideSprite = EO_ReadmeManager.ReadmeSprites["NewGacha"];
        }
        #endregion
    }
}
