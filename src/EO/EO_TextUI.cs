using BattleUI;
using BattleUI.BattleUnit.SkillInfoUI;
using BattleUI.Information;
using UnitInformation.Tab;
using HarmonyLib;
using MainUI;
using MainUI.VendingMachine;
using TMPro;
using TMPro.SpriteAssetUtilities;
using UnityEngine;
using MainUI.Gacha;
using BattleUI.UIRoot;
using Login;
using static UI.Utility.InfoModels;
using static UI.Utility.TMProStringMatcher;
using BattleUI.EvilStock;
using UnityEngine.Playables;
using BattleUI.Typo;
using Dungeon.Map.UI;
using System.Collections.Generic;
using BattleUI.BattleUnit;
using Il2CppSystem;
using Dungeon;

namespace LimbusCompanyFR
{
    internal class EO_TextUI
    {
        #region Login
        [HarmonyPatch(typeof(LoginSceneManager), nameof(LoginSceneManager.SetLoginInfo))]
        [HarmonyPostfix]
        private static void Client_Init(LoginSceneManager __instance)
        {
            __instance.tmp_loginAccount.font = LCB_French_Font.tmpfrenchfonts[4];
            __instance.tmp_loginAccount.fontMaterial = LCB_French_Font.tmpfrenchfonts[4].material;
        }
        [HarmonyPatch(typeof(NetworkingUI), "Initialize")]
        [HarmonyPostfix]
        private static void NetworkingUI_Init(NetworkingUI __instance)
        {
            Transform connection = __instance.transform.Find("connecting_background/tmp_connecting");
            if (connection != null)
            {
                connection.GetComponentInChildren<TextMeshProUGUI>(true).text = "CONNEXION";
                connection.GetComponentInChildren<TextMeshProUGUI>(true).font = LCB_French_Font.tmpfrenchfonts[0];
                connection.GetComponentInChildren<TextMeshProUGUI>(true).fontMaterial = LCB_French_Font.tmpfrenchfonts[0].material;
                connection.GetComponentInChildren<TextMeshProUGUI>(true).fontSize = 77f;
            }
        }
        [HarmonyPatch(typeof(UpdateMovieScreen), nameof(UpdateMovieScreen.SetDownLoadProgress))]
        [HarmonyPostfix]
        private static void UpdateMovieScreen_Init(UpdateMovieScreen __instance)
        {
            if (__instance._loadingCategoryText != null)
            {
                GameObject now_l = GameObject.Find("[Canvas]DownloadScreen/UpdateMovieScreen/[Rect]LoadingUI/Text_NowLoading");
                now_l.GetComponentInChildren<TextMeshProUGUI>(true).text = "Chargement...";
                now_l.GetComponentInChildren<TextMeshProUGUI>(true).font = LCB_French_Font.tmpfrenchfonts[1];
                now_l.GetComponentInChildren<TextMeshProUGUI>(true).fontMaterial = LCB_French_Font.tmpfrenchfonts[1].material;
                __instance._loadingCategoryText.GetComponentInChildren<TextMeshProUGUI>(true).name = "Mises à jour";
                __instance._loadingCategoryText.GetComponentInChildren<TextMeshProUGUI>(true).text = __instance._loadingCategoryText.GetComponentInChildren<TextMeshProUGUI>(true).text.Replace("Downloading", "Téléchargement des");
                __instance._loadingCategoryText.GetComponentInChildren<TextMeshProUGUI>(true).text = __instance._loadingCategoryText.GetComponentInChildren<TextMeshProUGUI>(true).text.Replace("UPDATE", "MISES À JOUR");
                __instance._loadingCategoryText.GetComponentInChildren<TextMeshProUGUI>(true).text = __instance._loadingCategoryText.GetComponentInChildren<TextMeshProUGUI>(true).text.Replace("Sound", "Sons");
                __instance._loadingCategoryText.GetComponentInChildren<TextMeshProUGUI>(true).text = __instance._loadingCategoryText.GetComponentInChildren<TextMeshProUGUI>(true).text.Replace("Sprite", "Sprites");
                __instance._loadingCategoryText.GetComponentInChildren<TextMeshProUGUI>(true).font = LCB_French_Font.tmpfrenchfonts[1];
                __instance._loadingCategoryText.GetComponentInChildren<TextMeshProUGUI>(true).fontMaterial = LCB_French_Font.tmpfrenchfonts[1].material;
            }
        }
        #endregion

        #region Main Menu
        [HarmonyPatch(typeof(LowerControlUIPanel), nameof(LowerControlUIPanel.Initialize))]
        [HarmonyPostfix]
        private static void ControlPanel_Init(LowerControlUIPanel __instance)
        {
            Transform level = __instance.transform.Find("[Rect]Pivot/[Rect]UserInfoUI/[Rect]Info/[Rect]UserInfo/[Tmpro]Lv");
            Transform No = __instance.transform.Find("[Rect]Pivot/[Rect]UserInfoUI/[Rect]Info/[Rect]UserInfo/[Tmpro]No");
            if (level != null)
            {
                level.GetComponentInChildren<TextMeshProUGUI>(true).text = "NV";
                level.GetComponentInChildren<TextMeshProUGUI>(true).font = LCB_French_Font.tmpfrenchfonts[1];
                level.GetComponentInChildren<TextMeshProUGUI>(true).fontMaterial = LCB_French_Font.tmpfrenchfonts[1].material;
                No.GetComponentInChildren<TextMeshProUGUI>(true).text = "№";
                No.GetComponentInChildren<TextMeshProUGUI>(true).font = LCB_French_Font.tmpfrenchfonts[0];
                No.GetComponentInChildren<TextMeshProUGUI>(true).fontMaterial = LCB_French_Font.tmpfrenchfonts[0].material;
            }
        }
        [HarmonyPatch(typeof(StageUIPresenter), nameof(StageUIPresenter.Initialize))]
        [HarmonyPostfix]
        private static void StageUIPresenter_Init(StageUIPresenter __instance)
        {
            Color velvet_red = new Color(1.0f, 0.339f, 0.339f, 0.2f);
            Color reddish = new Color(0.686f, 0.003f, 0.003f, 1.0f);
            Transform district4 = __instance.transform.Find("[Rect]Active/[Script]PartAndChapterSelectionUIPanel/[Rect]Active/[Rect]Right/[Rect]Pivot/[Rect]StoryMap/[Mask]StoryMap/[Rect]ZoomPivot/[Image]MapBG/[Script]D_4/[Rect]TextData/[Tmpro]Area");
            Transform district10 = __instance.transform.Find("[Rect]Active/[Script]PartAndChapterSelectionUIPanel/[Rect]Active/[Rect]Right/[Rect]Pivot/[Rect]StoryMap/[Mask]StoryMap/[Rect]ZoomPivot/[Image]MapBG/[Script]J_10/[Rect]TextData/[Tmpro]Area");
            Transform district11 = __instance.transform.Find("[Rect]Active/[Script]PartAndChapterSelectionUIPanel/[Rect]Active/[Rect]Right/[Rect]Pivot/[Rect]StoryMap/[Mask]StoryMap/[Rect]ZoomPivot/[Image]MapBG/[Script]K_11/[Rect]TextData/[Tmpro]Area");
            Transform district21 = __instance.transform.Find("[Rect]Active/[Script]PartAndChapterSelectionUIPanel/[Rect]Active/[Rect]Right/[Rect]Pivot/[Rect]StoryMap/[Mask]StoryMap/[Rect]ZoomPivot/[Image]MapBG/[Script]U_21/[Rect]TextData/[Tmpro]Area");
            Transform district20 = __instance.transform.Find("[Rect]Active/[Script]PartAndChapterSelectionUIPanel/[Rect]Active/[Rect]Right/[Rect]Pivot/[Rect]StoryMap/[Mask]StoryMap/[Rect]ZoomPivot/[Image]MapBG/[Script]T_20/[Rect]TextData/[Tmpro]Area");
            if (district4 != null)
            {
                district4.GetComponentInChildren<TextMeshProUGUI>(true).text = "District 4";
                district4.GetComponentInChildren<TextMeshProUGUI>(true).color = reddish;
                district4.GetComponentInChildren<TextMeshProUGUI>(true).font = LCB_French_Font.tmpfrenchfonts[0];
                district4.GetComponentInChildren<TextMeshProUGUI>(true).m_sharedMaterial = LCB_French_Font.GetFrenchMats(1);
                district4.GetComponentInChildren<TextMeshProUGUI>(true).fontMaterial.SetColor("_GlowColor", velvet_red);
            }
            if (district10 != null)
            {
                district10.GetComponentInChildren<TextMeshProUGUI>(true).text = "District 10";
                district10.GetComponentInChildren<TextMeshProUGUI>(true).color = reddish;
                district10.GetComponentInChildren<TextMeshProUGUI>(true).font = LCB_French_Font.tmpfrenchfonts[0];
                district10.GetComponentInChildren<TextMeshProUGUI>(true).m_sharedMaterial = LCB_French_Font.GetFrenchMats(1);
                district10.GetComponentInChildren<TextMeshProUGUI>(true).fontMaterial.SetColor("_GlowColor", velvet_red);
            }
            if (district11 != null)
            {
                district11.GetComponentInChildren<TextMeshProUGUI>(true).text = "District 11";
                district11.GetComponentInChildren<TextMeshProUGUI>(true).color = reddish;
                district11.GetComponentInChildren<TextMeshProUGUI>(true).font = LCB_French_Font.tmpfrenchfonts[0];
                district11.GetComponentInChildren<TextMeshProUGUI>(true).m_sharedMaterial = LCB_French_Font.GetFrenchMats(1);
                district11.GetComponentInChildren<TextMeshProUGUI>(true).fontMaterial.SetColor("_GlowColor", velvet_red);
            }
            if (district21 != null)
            {
                district21.GetComponentInChildren<TextMeshProUGUI>(true).text = "District 21";
                district21.GetComponentInChildren<TextMeshProUGUI>(true).color = reddish;
                district21.GetComponentInChildren<TextMeshProUGUI>(true).font = LCB_French_Font.tmpfrenchfonts[0];
                district21.GetComponentInChildren<TextMeshProUGUI>(true).m_sharedMaterial = LCB_French_Font.GetFrenchMats(1);
                district21.GetComponentInChildren<TextMeshProUGUI>(true).fontMaterial.SetColor("_GlowColor", velvet_red);
            }
            if (district20 != null)
            {
                district20.GetComponentInChildren<TextMeshProUGUI>(true).text = "District 20";
                district20.GetComponentInChildren<TextMeshProUGUI>(true).color = reddish;
                district20.GetComponentInChildren<TextMeshProUGUI>(true).font = LCB_French_Font.tmpfrenchfonts[0];
                district20.GetComponentInChildren<TextMeshProUGUI>(true).m_sharedMaterial = LCB_French_Font.GetFrenchMats(1);
                district20.GetComponentInChildren<TextMeshProUGUI>(true).fontMaterial.SetColor("_GlowColor", velvet_red);
            }
        }
        [HarmonyPatch(typeof(StageInfoUI), nameof(StageInfoUI.SetDataOpen))]
        [HarmonyPostfix]
        private static void StageInfoUI_Init(StageInfoUI __instance)
        {
            Transform level = __instance.transform.Find("[UIPanel]StageInfoUIRenewal/[Rect]Pivot/[Rect]StageInfoStatus/[Script]ExclearCondition/[Tmpro]Desc (1)/[Image]RecommentLevelTitleFrame/[Tmpro]Lv");
            if (level != null)
            {
                level.GetComponentInChildren<TextMeshProUGUI>(true).text = level.GetComponentInChildren<TextMeshProUGUI>(true).text.Replace("Lv", "Nv");
                level.GetComponentInChildren<TextMeshProUGUI>(true).font = LCB_French_Font.tmpfrenchfonts[2];
                level.GetComponentInChildren<TextMeshProUGUI>(true).fontMaterial = LCB_French_Font.tmpfrenchfonts[2].material;
            }
        }
        #endregion

        #region Settings
        [HarmonyPatch(typeof(SettingsPopup), nameof(SettingsPopup.Initialize))]
        [HarmonyPostfix]
        private static void SettingsSound_Init(SettingsPopup __instance)
        {
            Transform bgm = __instance.transform.Find("PanelGroup/PopupBase/Container/[Rect]Contents/Viewport/Content/[Script]SettingsSound/SettingsSoundBGM/[Text]Label");
            if (bgm != null)
                bgm.GetComponentInChildren<TextMeshProUGUI>(true).text = "Musique de fond";
        }
        #endregion

        #region Luxcavation
        [HarmonyPatch(typeof(ExpDungeonItem), nameof(ExpDungeonItem.SetData))]
        [HarmonyPostfix]
        private static void ExpDungeonItem_Init(ExpDungeonItem __instance)
        {
            __instance.tmp_title.fontStyle = FontStyles.Normal | FontStyles.SmallCaps;
            __instance.tmp_level.text = __instance.tmp_level.text.Replace("Lv", "Nv.");
            __instance.tmp_level.font = LCB_French_Font.tmpfrenchfonts[2];
            __instance.tmp_level.fontMaterial = LCB_French_Font.tmpfrenchfonts[2].material;
            Transform label = __instance.tmp_level.transform.parent.parent.Find("[Text]StageLabel");
            label.GetComponentInChildren<TextMeshProUGUI>().text = "Niveau";
            label.GetComponentInChildren<TextMeshProUGUI>().font = LCB_French_Font.tmpfrenchfonts[2];
            label.GetComponentInChildren<TextMeshProUGUI>().fontMaterial = LCB_French_Font.tmpfrenchfonts[2].material;
        }

        [HarmonyPatch(typeof(ThreadDungeonSelectStageButton), nameof(ThreadDungeonSelectStageButton.SetData))]
        [HarmonyPostfix]
        private static void ThreadDungeonSelectStageButton_Init(ThreadDungeonSelectStageButton __instance)
        {
            __instance.tmp_level.text = __instance.tmp_level.text.Replace("Lv", "Nv.");
            __instance.tmp_level.font = LCB_French_Font.tmpfrenchfonts[2];
            __instance.tmp_level.fontMaterial = LCB_French_Font.tmpfrenchfonts[2].material;
            __instance.tmp_level.fontSize = 60;
        }
        #endregion

        #region Mirror Dungeons
        [HarmonyPatch(typeof(MirrorDungeonEntranceScrollUIPanel), nameof(MirrorDungeonEntranceScrollUIPanel.Initialize))]
        [HarmonyPostfix]
        private static void MirrorDungeonDoors_Init(MirrorDungeonEntranceScrollUIPanel __instance)
        {
            Transform dungeon = __instance.transform.Find("[Script]EntranceItemsScrollView/[Rect]ViewPort/[Layout]Items/[Script]MirrorDungeonEntranceItemView_Single/[Rect]Selectable/[Tmpro]DungeonLabel");
            if (dungeon != null)
            {
                dungeon.GetComponentInChildren<TextMeshProUGUI>(true).text = "<cspace=-2px>Donjon</cspace>";
                dungeon.GetComponentInChildren<TextMeshProUGUI>(true).font = LCB_French_Font.tmpfrenchfonts[0];
                dungeon.GetComponentInChildren<TextMeshProUGUI>(true).fontMaterial = LCB_French_Font.tmpfrenchfonts[0].material;
            }
            Transform dungeon_hard = __instance.transform.Find("[Script]EntranceItemsScrollView/[Rect]ViewPort/[Layout]Items/[Script]MirrorDungeonEntranceItemView_Single (1)/[Rect]Selectable/[Tmpro]DungeonLabel");
            if (dungeon_hard != null)
            {
                dungeon_hard.GetComponentInChildren<TextMeshProUGUI>(true).text = "<cspace=-2px>Donjon</cspace>";
                dungeon_hard.GetComponentInChildren<TextMeshProUGUI>(true).font = LCB_French_Font.tmpfrenchfonts[0];
                dungeon_hard.GetComponentInChildren<TextMeshProUGUI>(true).fontMaterial = LCB_French_Font.tmpfrenchfonts[0].material;
            }
            Transform mirror = __instance.transform.Find("[Script]EntranceItemsScrollView/[Rect]ViewPort/[Layout]Items/[Script]MirrorDungeonEntranceItemView_Single/[Rect]Selectable/[Button]Stage Frame/Text (TMP)");
            if (mirror != null)
            {
                mirror.GetComponentInChildren<TextMeshProUGUI>(true).text = "Normal";
                mirror.GetComponentInChildren<TextMeshProUGUI>(true).font = LCB_French_Font.tmpfrenchfonts[0];
                mirror.GetComponentInChildren<TextMeshProUGUI>(true).fontMaterial = LCB_French_Font.tmpfrenchfonts[0].material;
            }
            Transform mirror_hard = __instance.transform.Find("[Script]EntranceItemsScrollView/[Rect]ViewPort/[Layout]Items/[Script]MirrorDungeonEntranceItemView_Single (1)/[Rect]Selectable/[Button]Stage Frame/Text (TMP)");
            if (mirror_hard != null)
            {
                mirror_hard.GetComponentInChildren<TextMeshProUGUI>(true).text = "Difficile";
                mirror_hard.GetComponentInChildren<TextMeshProUGUI>(true).font = LCB_French_Font.tmpfrenchfonts[0];
                mirror_hard.GetComponentInChildren<TextMeshProUGUI>(true).fontMaterial = LCB_French_Font.tmpfrenchfonts[0].material;
            }
        }
        #endregion

        #region Vending Machine
        [HarmonyPatch(typeof(VendingMachineUIPanel), "Initialize")]
        [HarmonyPostfix]
        private static void VendingMachineUIPanel_Init(VendingMachineUIPanel __instance)
        {
            Transform comment = __instance.transform.Find("GoodsStoreAreaMaster/PageButtonArea/BackPanel/Btn_TypeAnnouncer/Tmp_Announcer");
            Transform ego_dispence = __instance.transform.Find("GoodsStoreAreaMaster/PageButtonArea/BackPanel/Btn_TypeEGO/Tmp_EGO");
            if (ego_dispence != null)
            {
                ego_dispence.GetComponentInChildren<TextMeshProUGUI>(true).text = "E.G.O.";
            }
            if (comment != null)
            {
                comment.GetComponentInChildren<TextMeshProUGUI>(true).text = "<cspace=-2px>Commentateur</cspace>";
            }
        }
        #endregion

        #region Formation UI
        [HarmonyPatch(typeof(FormationSwitchablePersonalityUIPanel), nameof(FormationSwitchablePersonalityUIPanel.Initialize))]
        [HarmonyPostfix]
        private static void FormationSwitchablePersonalityUIPanel_Init(FormationSwitchablePersonalityUIPanel __instance)
        {
            Transform id_mainui = __instance.transform.Find("[Script]RightPanel/[Script]FormationEgoList/[Text]Personality_Label");
            Transform ego_mainui_1 = __instance.transform.Find("[Script]RightPanel/[Script]FormationEgoList/[Text]Ego_Label");
            Transform ego_mainui_2 = __instance.transform.Find("[Script]ListTabRoot/[Layout]Tabs/[Toggle]Ego/[Text]E.G.O");
            if (ego_mainui_1 != null)
            {
                ego_mainui_1.GetComponentInChildren<TextMeshProUGUI>(true).text = "E.G.O.";
                ego_mainui_2.GetComponentInChildren<TextMeshProUGUI>(true).text = "E.G.O.";
                ego_mainui_2.GetComponentInChildren<TextMeshProUGUI>(true).font = LCB_French_Font.tmpfrenchfonts[3];
                ego_mainui_2.GetComponentInChildren<TextMeshProUGUI>(true).fontMaterial = LCB_French_Font.tmpfrenchfonts[3].material;
            }
            if (id_mainui != null)
            {
                id_mainui.GetComponentInChildren<UITextDataLoader>().enabled = false;
                id_mainui.GetComponentInChildren<TextMeshProUGUI>(true).richText = false;
                id_mainui.GetComponentInChildren<TextMeshProUGUI>(true).autoSizeTextContainer = true;
                id_mainui.GetComponentInChildren<TextMeshProUGUI>(true).text = "Identités";
            }
        }
        [HarmonyPatch(typeof(FormationUIPanel), nameof(FormationUIPanel.Initialize))]
        [HarmonyPostfix]
        private static void FormationUIPanel_Init(FormationUIPanel __instance)
        {
            //MAIN UI HOVER EGO TEXT
            Transform ego = __instance.transform.Find("[Rect]MainPanel/[Rect]Contents/[Rect]Personalities/PersonalityDetail/[Button]Main/[Rect]Select/[Button]EGO/[Text]EGO");
            Transform ego_hover = __instance.transform.Find("[Rect]MainPanel/[Rect]Contents/[Rect]Personalities/PersonalityDetail/[Button]Main/[Rect]Select/[Button]EGO/[Text]EGO/[Text]EGO_Highlight");
            if (ego != null)
            {
                ego.GetComponentInChildren<TextMeshProUGUI>(true).text = "E.G.O.";
                ego.GetComponentInChildren<TextMeshProUGUI>(true).font = LCB_French_Font.tmpfrenchfonts[3];
                ego.GetComponentInChildren<TextMeshProUGUI>(true).fontMaterial = LCB_French_Font.tmpfrenchfonts[3].material;
                ego_hover.GetComponentInChildren<TextMeshProUGUI>(true).text = "E.G.O.";
                ego_hover.GetComponentInChildren<TextMeshProUGUI>(true).font = LCB_French_Font.tmpfrenchfonts[3];
                ego_hover.GetComponentInChildren<TextMeshProUGUI>(true).fontMaterial = LCB_French_Font.tmpfrenchfonts[3].material;
            }
            // TEAMS
            GameObject teams = GameObject.Find("[Canvas]RatioMainUI/[Rect]PanelRoot/[UIPanel]PersonalityFormationUIPanel(Clone)/[Rect]LeftObjects/[Rect]DeckSettings/[Rect]Contents/[Text]DeckTitle");
            if (teams != null)
            {
                teams.GetComponentInChildren<TextMeshProUGUI>(true).name = "Équipes";
                teams.GetComponentInChildren<UITextDataLoader>(true).enabled = false;
                teams.GetComponentInChildren<TextMeshProUGUI>(true).text = "Équipes";
            }
        }
        [HarmonyPatch(typeof(PersonalitySlotSkillInfoList), nameof(PersonalitySlotSkillInfoList.SetData))]
        [HarmonyPostfix]
        private static void PersonalitySlotSkillInfoList_Init(PersonalitySlotSkillInfoList __instance)
        {
            Transform guard = __instance._guardItem.transform.Find("Text (TMP)");
            if (guard != null)
            {
                guard.GetComponentInChildren<TextMeshProUGUI>(true).text = "Déf.";
                guard.GetComponentInChildren<TextMeshProUGUI>(true).font = LCB_French_Font.tmpfrenchfonts[3];
                guard.GetComponentInChildren<TextMeshProUGUI>(true).fontMaterial = LCB_French_Font.tmpfrenchfonts[3].material;
            }
        }
        [HarmonyPatch(typeof(FormationUIPanel), nameof(FormationUIPanel.Initialize))]
        [HarmonyPostfix]
        private static void FormationSecondChance_Init(FormationUIPanel __instance)
        {

            Transform skill = __instance.transform.Find("[Rect]MainPanel/[Rect]Contents/[Rect]Personalities/PersonalityDetail/[Button]Main/[Rect]Select/[Button]Skill/[Text]Skill");
            Transform skill_hover = __instance.transform.Find("[Rect]MainPanel/[Rect]Contents/[Rect]Personalities/PersonalityDetail/[Button]Main/[Rect]Select/[Button]Skill/[Text]Skill/[Text]Skill_Highlight");
            if (skill != null)
            {
                skill.GetComponentInChildren<TextMeshProUGUI>(true).text = "Capacité";
                skill_hover.GetComponentInChildren<TextMeshProUGUI>(true).text = "Capacité";
            }
        }
        [HarmonyPatch(typeof(FormationUIDeckToggle), nameof(FormationUIDeckToggle.SetText))]
        [HarmonyPostfix]
        private static void FormationUIDeckToggle_Init(FormationUIDeckToggle __instance)
        {
            __instance.tmp_title.text = __instance.tmp_title.text.Replace("#", "№");
        }
        #endregion

        #region Sinner UI
        [HarmonyPatch(typeof(UnitInformationController), nameof(UnitInformationController.Initialize))]
        [HarmonyPostfix]
        private static void UnitInformationController_Init(UnitInformationController __instance)
        {
            Transform max_level = __instance.transform.Find("[Script]UnitInformationController_Renewal/[Rect]UnitStatusContent/[Button]PersonaliyLevelUpButton/[Text]MAXContent");
            Transform max_thread = __instance.transform.Find("[Script]UnitInformationController_Renewal/[Rect]UnitStatusContent/[Button]GacksungLevelUpButton/[Text]MAXContent");
            if (max_level != null)
            {
                max_level.GetComponentInChildren<TextMeshProUGUI>(true).text = "MAX";
                //max_level.GetComponentInChildren<TextMeshProUGUI>(true).font = LCB_French_Font.tmpfrenchfonts[1];
                //max_level.GetComponentInChildren<TextMeshProUGUI>(true).fontMaterial = LCB_French_Font.tmpfrenchfonts[1].material;
                max_thread.GetComponentInChildren<TextMeshProUGUI>(true).text = "MAX";
                //max_thread.GetComponentInChildren<TextMeshProUGUI>(true).font = LCB_French_Font.tmpfrenchfonts[1];
                //max_thread.GetComponentInChildren<TextMeshProUGUI>(true).fontMaterial = LCB_French_Font.tmpfrenchfonts[1].material;
            }
        }
        [HarmonyPatch(typeof(UnitInformationSkillSlot), nameof(UnitInformationSkillSlot.SetData))]
        [HarmonyPostfix]
        private static void UnitInformationSkillSlot_Init(UnitInformationSkillSlot __instance)
        {
            GameObject skill = GameObject.Find("[Canvas]RatioMainUI/[Rect]PanelRoot/[Script]UnitInformationController(Clone)/[Script]UnitInformationController_Renewal/[Script]TabContentManager/[Layout]UnitInfoTabList/[Button]UnitInfoTab (1)/[Text]UnitInfoTabName");
            if (skill != null)
            {
                skill.GetComponentInChildren<TextMeshProUGUI>(true).text = "Capacité";
                skill.GetComponentInChildren<TextMeshProUGUI>(true).font = LCB_French_Font.tmpfrenchfonts[3];
                skill.GetComponentInChildren<TextMeshProUGUI>(true).fontMaterial = LCB_French_Font.tmpfrenchfonts[3].material;
            }
            if (__instance.tmp_skillTier.text == "DEFENSE")
            {
                __instance.tmp_skillTier.text = "Défense";
                __instance.tmp_skillTier.GetComponent<TextMeshProUGUI>().enabled = true;
                __instance.tmp_skillTier.GetComponentInChildren<TextMeshProUGUI>(true).enabled = true;
            }
            __instance.tmp_skillTier.font = LCB_French_Font.tmpfrenchfonts[1];
            __instance.tmp_skillTier.fontMaterial = LCB_French_Font.tmpfrenchfonts[1].material;
        }
        [HarmonyPatch(typeof(UnitInformationTabButton), nameof(UnitInformationTabButton.SetData))]
        [HarmonyPostfix]
        private static void UnitInformationTabButton_Init(UnitInformationTabButton __instance)
        {
            if (__instance.tmp_tabName.text == "E.G.O")
            {
                __instance.tmp_tabName.text = "E.G.O.";
            }
        }
        [HarmonyPatch(typeof(UnitInformationSkillTabContent), nameof(UnitInformationSkillTabContent.SetData))]
        [HarmonyPostfix]
        private static void ShopPrelook_Init(UnitInformationSkillTabContent __instance)
        {
            GameObject skill_unobtained = GameObject.Find("[Canvas]RatioMainUI/[Rect]PanelRoot/[Script]UnitInformationController(Clone)/[Script]UnitInformationController_Renewal/[Script]TabContentManager/[Layout]UnitInfoTabList/[Button]UnitInfoTab/[Text]UnitInfoTabName");
            skill_unobtained.GetComponent<TextMeshProUGUI>().text = "Capacité";
            skill_unobtained.GetComponent<TextMeshProUGUI>().font = LCB_French_Font.tmpfrenchfonts[3];
            skill_unobtained.GetComponent<TextMeshProUGUI>().fontMaterial = LCB_French_Font.tmpfrenchfonts[3].material;
        }
        #endregion

        #region Battle UI
        [HarmonyPatch(typeof(EvilStockController), nameof(EvilStockController.Init))]
        [HarmonyPostfix]
        private static void BattleUI_Init(EvilStockController __instance)
        {
            Transform min = __instance.transform.Find("[Rect]ActiveControl/[Rect]Pivot/[Rect]UpperSkillInfoUIStateField/[Rect]ChangeState/[Image]Min/[Text]MIN");
            Transform mid = __instance.transform.Find("[Rect]ActiveControl/[Rect]Pivot/[Rect]UpperSkillInfoUIStateField/[Rect]ChangeState/[Image]Mid/[Text]MID");
            Transform max = __instance.transform.Find("[Rect]ActiveControl/[Rect]Pivot/[Rect]UpperSkillInfoUIStateField/[Rect]ChangeState/[Image]Max/[Text]MAX");
            if (min != null)
            {
                min.GetComponentInChildren<TextMeshProUGUI>(true).font = LCB_French_Font.tmpfrenchfonts[1];
                min.GetComponentInChildren<TextMeshProUGUI>(true).fontMaterial = LCB_French_Font.tmpfrenchfonts[1].material;
                min.GetComponentInChildren<TextMeshProUGUI>(true).text = "<size=50>MIN</size>";
            }
            if (mid != null)
            {
                mid.GetComponentInChildren<TextMeshProUGUI>(true).font = LCB_French_Font.tmpfrenchfonts[1];
                mid.GetComponentInChildren<TextMeshProUGUI>(true).fontMaterial = LCB_French_Font.tmpfrenchfonts[1].material;
                mid.GetComponentInChildren<TextMeshProUGUI>(true).text = "<size=50>MOY</size>";
            }
            if (max != null)
            {
                max.GetComponentInChildren<TextMeshProUGUI>(true).font = LCB_French_Font.tmpfrenchfonts[1];
                max.GetComponentInChildren<TextMeshProUGUI>(true).fontMaterial = LCB_French_Font.tmpfrenchfonts[1].material;
                max.GetComponentInChildren<TextMeshProUGUI>(true).text = "<size=50><cspace=-3px>MAX</cspace></size>";
            }
            Transform ordealName = __instance.transform.Find("[Rect]ActiveControl/[Rect]Pivot/[Rect]KillCountUI/[Text]TestTitle");
            Transform killCount = __instance.transform.Find("[Rect]ActiveControl/[Rect]Pivot/[Rect]KillCountUI/[Text]StaticTitle");
            if (ordealName != null)
            {
                ordealName.GetComponentInChildren<TextMeshProUGUI>(true).font = LCB_French_Font.tmpfrenchfonts[3];
                ordealName.GetComponentInChildren<TextMeshProUGUI>(true).fontMaterial = LCB_French_Font.tmpfrenchfonts[3].material;
            }
            if (killCount != null)
            {
                killCount.GetComponentInChildren<TextMeshProUGUI>(true).font = LCB_French_Font.tmpfrenchfonts[4];
                killCount.GetComponentInChildren<TextMeshProUGUI>(true).fontMaterial = LCB_French_Font.tmpfrenchfonts[4].material;
            }
        }
        [HarmonyPatch(typeof(UpperSkillInfoUIStateSettingButton), nameof(UpperSkillInfoUIStateSettingButton.SetCurrentState))]
        [HarmonyPostfix]
        private static void UpperSkillInfoUIStateSettingButton_Init(UpperSkillInfoUIStateSettingButton __instance)
        {
            __instance._currentStateText.GetComponentInChildren<TextMeshProUGUI>(true).font = LCB_French_Font.tmpfrenchfonts[1];
            __instance._currentStateText.GetComponentInChildren<TextMeshProUGUI>(true).fontMaterial = LCB_French_Font.tmpfrenchfonts[1].material;
            __instance._currentStateText.text = __instance._currentStateText.text.Replace("MAX", "<size=50><cspace=-3px>MAX</cspace></size>");
            __instance._currentStateText.text = __instance._currentStateText.text.Replace("MID", "<size=50>MOY</size>");
            __instance._currentStateText.text = __instance._currentStateText.text.Replace("MIN", "<size=50>MIN</size>");
        }
        [HarmonyPatch(typeof(BattleEncounterDamageTypoController), nameof(BattleEncounterDamageTypoController.SetDirection))]
        [HarmonyPostfix]
        private static void BattleEncounterDamageTypoController_Init(BattleEncounterDamageTypoController __instance)
        {
            __instance.playerDamagedSlot.tmp_total.text = "<size=40>Total</size>";
            __instance.playerDamagedSlot.tmp_total.font = LCB_French_Font.tmpfrenchfonts[1];
            __instance.playerDamagedSlot.tmp_total.fontMaterial = LCB_French_Font.tmpfrenchfonts[1].material;
            __instance.enemyDamagedSlot.tmp_total.text = "<size=40>Total</size>";
            __instance.enemyDamagedSlot.tmp_total.font = LCB_French_Font.tmpfrenchfonts[1];
            __instance.enemyDamagedSlot.tmp_total.fontMaterial = LCB_French_Font.tmpfrenchfonts[1].material;
            GameObject ego_t = GameObject.Find("[Script]BattleUIRoot/[Script]BattleSkillViewUIController/[Canvas]Canvas/[Script]SkillViewCanvas/[Rect]NameBox_EGO/[Image]EgoNameBg/[Rect]TotalDamageSlot/[Tmpro]Total");
            if (ego_t != null)
            {
                ego_t.GetComponentInChildren<TextMeshProUGUI>(true).text = "<size=40>Total</size>";
                ego_t.GetComponentInChildren<TextMeshProUGUI>(true).name = "Total";
                ego_t.GetComponentInChildren<TextMeshProUGUI>(true).font = LCB_French_Font.tmpfrenchfonts[1];
                ego_t.GetComponentInChildren<TextMeshProUGUI>(true).fontMaterial = LCB_French_Font.tmpfrenchfonts[1].material;
            }
        }
        [HarmonyPatch(typeof(ActTypoWaveStartUI), nameof(ActTypoWaveStartUI.Open))]
        [HarmonyPostfix]
        private static void ActTypoWaveStartUI_Init(ActTypoWaveStartUI __instance)
        {
            if (__instance.tmp_content.text.Contains("WAVE"))
            {
                __instance.tmp_content.text = __instance.tmp_content.text.Replace("WAVE", "Vague");
                __instance.tmp_content.font = LCB_French_Font.tmpfrenchfonts[3];
                __instance.tmp_content.fontMaterial = LCB_French_Font.tmpfrenchfonts[3].material;
            }
        }
        [HarmonyPatch(typeof(UnitInformationController), nameof(UnitInformationController.OpenInit))]
        [HarmonyPostfix]
        private static void UnitInfo_Init(UnitInformationController __instance)
        {
            Transform skill = __instance.transform.Find("[Script]UnitInformationController_Renewal/[Script]TabContentManager/[Layout]UnitInfoTabList/[Button]UnitInfoTab (1)/[Text]UnitInfoTabName");
            if (skill != null)
                skill.GetComponentInChildren<TextMeshProUGUI>(true).text = "Capacité";
        }
        #endregion

        #region Dungeon
        [HarmonyPatch(typeof(NodeUI), nameof(NodeUI.Init))]
        [HarmonyPostfix]
        private static void Nodes_Init(NodeUI __instance)
        {
            GameObject canto1_1 = GameObject.Find("[Script]MapCanvas/DungeonMapFloor_10401_0(Clone)/Nodes/NodeUI_10101/IconFrame/StartTypo");
            if (canto1_1 != null)
            {
                canto1_1.GetComponentInChildren<TextMeshProUGUI>(true).text = "Début";
                canto1_1.GetComponentInChildren<TextMeshProUGUI>(true).font = LCB_French_Font.tmpfrenchfonts[2];
                canto1_1.GetComponentInChildren<TextMeshProUGUI>(true).fontMaterial = LCB_French_Font.tmpfrenchfonts[2].material;
            }

            GameObject canto2_1 = GameObject.Find("[Script]MapCanvas/DungeonMapFloor_10401_0(Clone)/Nodes/NodeUI_10201/IconFrame/StartTypo");
            if (canto2_1 != null)
            {
                canto2_1.GetComponentInChildren<TextMeshProUGUI>(true).text = "Début";
                canto2_1.GetComponentInChildren<TextMeshProUGUI>(true).font = LCB_French_Font.tmpfrenchfonts[2];
                canto2_1.GetComponentInChildren<TextMeshProUGUI>(true).fontMaterial = LCB_French_Font.tmpfrenchfonts[2].material;
            }

            GameObject canto3_1 = GameObject.Find("[Script]MapCanvas/DungeonMapFloor_10401_0(Clone)/Nodes/NodeUI_10301/IconFrame/StartTypo");
            if (canto3_1 != null)
            {
                canto3_1.GetComponentInChildren<TextMeshProUGUI>(true).text = "Début";
                canto3_1.GetComponentInChildren<TextMeshProUGUI>(true).font = LCB_French_Font.tmpfrenchfonts[2];
                canto3_1.GetComponentInChildren<TextMeshProUGUI>(true).fontMaterial = LCB_French_Font.tmpfrenchfonts[2].material;
            }

            GameObject canto4_1 = GameObject.Find("[Script]MapCanvas/DungeonMapFloor_10401_0(Clone)/Nodes/NodeUI_10401/IconFrame/StartTypo");
            if (canto4_1 != null)
            {
                canto4_1.GetComponentInChildren<TextMeshProUGUI>(true).text = "Début";
                canto4_1.GetComponentInChildren<TextMeshProUGUI>(true).font = LCB_French_Font.tmpfrenchfonts[2];
                canto4_1.GetComponentInChildren<TextMeshProUGUI>(true).fontMaterial = LCB_French_Font.tmpfrenchfonts[2].material;
            }

            GameObject canto5_1 = GameObject.Find("[Script]MapCanvas/DungeonMapFloor_10401_0(Clone)/Nodes/NodeUI_10501/IconFrame/StartTypo");
            if (canto5_1 != null)
            {
                canto5_1.GetComponentInChildren<TextMeshProUGUI>(true).text = "Début";
                canto5_1.GetComponentInChildren<TextMeshProUGUI>(true).font = LCB_French_Font.tmpfrenchfonts[2];
                canto5_1.GetComponentInChildren<TextMeshProUGUI>(true).fontMaterial = LCB_French_Font.tmpfrenchfonts[2].material;
            }
        }
        #endregion

        #region Announcers
        [HarmonyPatch(typeof(AnnouncerSelectionUI), nameof(AnnouncerSelectionUI.UpdateBattleAnnouncer))]
        [HarmonyPostfix]
        private static void AnnouncerSelectionUI_Init(AnnouncerSelectionUI __instance)
        {
            Transform dante = __instance.transform.Find("[Scroll]AnnouncerScrollView/Scroll View/Viewport/Content/Layout/[Script]BattleAnnouncerSlot/[Image]SelectedTag/[Text]Selected");
            if (dante != null)
            {
                dante.GetComponentInChildren<TextMeshProUGUI>(true).text = "Choisi";
            }
            Transform gregor = __instance.transform.Find("[Scroll]AnnouncerScrollView/Scroll View/Viewport/Content/Layout/[Script]BattleAnnouncerSlot (1)/[Image]SelectedTag/[Text]Selected");
            if (gregor != null)
            {
                gregor.GetComponentInChildren<TextMeshProUGUI>(true).text = "Choisi";
            }
            Transform charon = __instance.transform.Find("[Scroll]AnnouncerScrollView/Scroll View/Viewport/Content/Layout/[Script]BattleAnnouncerSlot (2)/[Image]SelectedTag/[Text]Selected");
            if (charon != null)
            {
                charon.GetComponentInChildren<TextMeshProUGUI>(true).text = "Choisie";
            }
            Transform sinclair = __instance.transform.Find("[Scroll]AnnouncerScrollView/Scroll View/Viewport/Content/Layout/[Script]BattleAnnouncerSlot(Clone)/[Image]SelectedTag/[Text]Selected");
            if (sinclair != null)
            {
                sinclair.GetComponentInChildren<TextMeshProUGUI>(true).text = "Choisi";
                sinclair.GetComponentInChildren<TextMeshProUGUI>(true).name = "Choisi";
            }
            Transform rodya = __instance.transform.Find("[Scroll]AnnouncerScrollView/Scroll View/Viewport/Content/Layout/[Script]BattleAnnouncerSlot(Clone)/[Image]SelectedTag/[Text]Selected");
            if (rodya != null)
            {
                rodya.GetComponentInChildren<TextMeshProUGUI>(true).text = "Choisie";
                rodya.GetComponentInChildren<TextMeshProUGUI>(true).name = "Choisie";
            }
            Transform yisang = __instance.transform.Find("[Scroll]AnnouncerScrollView/Scroll View/Viewport/Content/Layout/[Script]BattleAnnouncerSlot(Clone)/[Image]SelectedTag/[Text]Selected");
            if (yisang != null)
            {
                yisang.GetComponentInChildren<TextMeshProUGUI>(true).text = "Choisi";
                yisang.GetComponentInChildren<TextMeshProUGUI>(true).name = "Choisi";
            }
            Transform yuri = __instance.transform.Find("[Scroll]AnnouncerScrollView/Scroll View/Viewport/Content/Layout/[Script]BattleAnnouncerSlot(Clone)/[Image]SelectedTag/[Text]Selected");
            if (yuri != null)
            {

                yuri.GetComponentInChildren<TextMeshProUGUI>(true).text = "Choisie";
                yuri.GetComponentInChildren<TextMeshProUGUI>(true).name = "Choisie";
            }
            Transform effiesod = __instance.transform.Find("[Scroll]AnnouncerScrollView/Scroll View/Viewport/Content/Layout/[Script]BattleAnnouncerSlot(Clone)/[Image]SelectedTag/[Text]Selected");
            if (effiesod != null)
            {
                effiesod.GetComponentInChildren<TextMeshProUGUI>(true).text = "Choisis";
                effiesod.GetComponentInChildren<TextMeshProUGUI>(true).name = "Choisis";
            }
            Transform ishmael = __instance.transform.Find("[Scroll]AnnouncerScrollView/Scroll View/Viewport/Content/Layout/[Script]BattleAnnouncerSlot(Clone)/[Image]SelectedTag/[Text]Selected");
            if (ishmael != null)
            {
                ishmael.GetComponentInChildren<TextMeshProUGUI>(true).text = "Choisie";
                ishmael.GetComponentInChildren<TextMeshProUGUI>(true).name = "Choisie";
            }
            Transform malkuth = __instance.transform.Find("[Scroll]AnnouncerScrollView/Scroll View/Viewport/Content/Layout/[Script]BattleAnnouncerSlot(Clone)/[Image]SelectedTag/[Text]Selected");
            if (malkuth != null)
            {
                malkuth.GetComponentInChildren<TextMeshProUGUI>(true).text = "Choisie";
                malkuth.GetComponentInChildren<TextMeshProUGUI>(true).name = "Choisie";
            }
            Transform pierrejack = __instance.transform.Find("[Scroll]AnnouncerScrollView/Scroll View/Viewport/Content/Layout/[Script]BattleAnnouncerSlot(Clone)/[Image]SelectedTag/[Text]Selected");
            if (pierrejack != null)
            {
                pierrejack.GetComponentInChildren<TextMeshProUGUI>(true).text = "Choisis";
                pierrejack.GetComponentInChildren<TextMeshProUGUI>(true).name = "Choisis";
            }
        }
        [HarmonyPatch(typeof(FormationBattleAnnouncerSelectionScrollViewItem), nameof(FormationBattleAnnouncerSelectionScrollViewItem.SetData))]
        [HarmonyPostfix]
        private static void FormationBattleAnnouncerSelectionScrollViewItem_Init(FormationBattleAnnouncerSelectionScrollViewItem __instance)
        {
            __instance.cg_selectedTag.GetComponentInChildren<TextMeshProUGUI>().font = LCB_French_Font.tmpfrenchfonts[0];
            __instance.cg_selectedTag.GetComponentInChildren<TextMeshProUGUI>().fontMaterial = LCB_French_Font.tmpfrenchfonts[0].material;
        }
        [HarmonyPatch(typeof(FormationUIPanel), nameof(FormationUIPanel.Initialize))]
        [HarmonyPostfix]
        private static void FixedAnnouncer_Init(FormationUIPanel __instance)
        {
            GameObject fixedAnnouncer = GameObject.Find("[Canvas]RatioMainUI/[Rect]PanelRoot/[UIPanel]PersonalityFormationUIPanel(Clone)/[Rect]LeftObjects/[Script]FormationBattleAnnouncer/[Rect]Contents/[Rect]LeftSide/[Rect]FixedLabel/[Image]FixedLabel/[Text]Fixed");
            if (fixedAnnouncer != null)
            {
                fixedAnnouncer.GetComponentInChildren<TextMeshProUGUI>(true).font = LCB_French_Font.tmpfrenchfonts[4];
                fixedAnnouncer.GetComponentInChildren<TextMeshProUGUI>(true).fontMaterial = LCB_French_Font.tmpfrenchfonts[4].material;
            }
        }
        #endregion

        #region SeasonTag
        [HarmonyPatch(typeof(UnitInfoPersonalityNameTag), nameof(UnitInfoPersonalityNameTag.SetSeasonTagUI))]
        [HarmonyPostfix]
        private static void UnitInfoPersonalityNameTag_Init(UnitInfoPersonalityNameTag __instance)
        {
            string text = __instance._seasonTagUI.tmp_season.text.Replace("SEASON", "Saison");
            __instance._seasonTagUI.tmp_season.text = text.Replace("WALPURGISNACHT", "<cspace=-1px>WALPURGISNACHT</cspace>");
            __instance._seasonTagUI.tmp_season.font = LCB_French_Font.tmpfrenchfonts[1];
            __instance._seasonTagUI.tmp_season.m_sharedMaterial = LCB_French_Font.GetFrenchMats(2);
        }
        [HarmonyPatch(typeof(UnitInformationSeasonTagUI), nameof(UnitInformationSeasonTagUI.SetSeasonData))]
        [HarmonyPostfix]
        private static void UnitInformationSeasonTagUI_Init(UnitInformationSeasonTagUI __instance)
        {
            string text = __instance.tmp_season.text.Replace("SEASON", "Saison");
            __instance.tmp_season.text = text.Replace("WALPURGISNACHT -", "<cspace=-4px>WALPURGISNACHT -</cspace>");
            __instance.tmp_season.text = __instance.tmp_season.text.Replace("I", "<cspace=-4px>I</cspace>");
            __instance.tmp_season.font = LCB_French_Font.tmpfrenchfonts[1];
            __instance.tmp_season.m_sharedMaterial = LCB_French_Font.GetFrenchMats(2);
        }
        #endregion

        #region BattlePass
        public static void BebasForPass(List<Transform> transforms)
        {
            foreach (Transform t in transforms)
            {
                t.GetComponentInChildren<TextMeshProUGUI>(true).m_fontAsset = LCB_French_Font.GetFrenchFonts(0);
                t.GetComponentInChildren<TextMeshProUGUI>(true).m_sharedMaterial = LCB_French_Font.GetFrenchMats(2);
            }
        }
        [HarmonyPatch(typeof(BattlePassUIPopup), nameof(BattlePassUIPopup.localizeHelper.Initialize))]
        [HarmonyPostfix]
        private static void BattlePass_Init(BattlePassUIPopup __instance)
        {
            Transform limbus_pass = __instance.transform.Find("[Rect]Right/[Rect]Ticket/[Button]TicketImage_BuyNotYet/[Rect]Texts/[Text]LIMBUSPASS");
            Transform limbus_pass_bought = __instance.transform.Find("[Rect]Right/[Rect]Ticket/[Image]LimTicketImage_YesIHave/[LocalizeText]Useing/[Text]LimbusPass");
            Transform battle_pass = __instance.transform.Find("[Rect]Right/[Rect]Ticket/[Button]TicketImage_BuyNotYet/[Rect]Texts/[LocalizeText]Buying");
            Transform battle_pass_bought = __instance.transform.Find("[Rect]Right/[Rect]Ticket/[Image]LimTicketImage_YesIHave/[LocalizeText]Useing");
            Transform package = __instance.transform.Find("[Rect]Right/[Rect]Package/[Text]Title");
            Transform package_popUp = __instance.transform.Find("BattlePassPurchaseLimbusOrPackagePopup/PanelGroup/PopupBase/Container/[Rect]Contents/[Button]PurchasePackage/[Text]Title");
            Transform until_pass = __instance.transform.Find("[Rect]Right/[Text]UntilSeason");
            limbus_pass.GetComponentInChildren<TextMeshProUGUI>(true).text = "<cspace=-2px>PASS LIMBUS</cspace>";
            limbus_pass_bought.GetComponentInChildren<TextMeshProUGUI>(true).text = "<cspace=-2px>PASS LIMBUS</cspace>";
            battle_pass_bought.GetComponentInChildren<TextMeshProUGUI>(true).fontSize = 44;
            limbus_pass_bought.GetComponentInChildren<TextMeshProUGUI>(true).fontSize = 44;
            battle_pass_bought.GetComponentInChildren<TextMeshProUGUI>(true).characterSpacing = -22;
            List<Transform> transforms = new List<Transform> { limbus_pass, limbus_pass_bought, battle_pass, battle_pass_bought, package, package_popUp, until_pass, __instance.tmp_be_in_use.transform, __instance.limbusPassPopup.tmp_description.transform };
            BebasForPass(transforms);
        }
        [HarmonyPatch(typeof(BattlePassUIPopup), nameof(BattlePassUIPopup.SetRemainText))]
        [HarmonyPostfix]
        private static void BattleSeason_Init(BattlePassUIPopup __instance)
        {
            Transform until_pass = __instance.transform.Find("[Rect]Right/[Text]UntilSeason");
            until_pass.GetComponentInChildren<TextMeshProUGUI>(true).m_fontAsset = LCB_French_Font.GetFrenchFonts(0);
            until_pass.GetComponentInChildren<TextMeshProUGUI>(true).m_sharedMaterial = LCB_French_Font.GetFrenchMats(2);
        }
        [HarmonyPatch(typeof(BattlePassPurchasedModal), nameof(BattlePassPurchasedModal.SetCurrentSeasonOpen))]
        [HarmonyPostfix]
        private static void Activation_Init(BattlePassPurchasedModal __instance)
        {
            Transform limbuspass_active = __instance.transform.Find("MainPanel/[Text]Activation");
            if (limbuspass_active != null)
            {
                limbuspass_active.GetComponentInChildren<TextMeshProUGUI>(true).m_fontAsset = LCB_French_Font.GetFrenchFonts(0);
                limbuspass_active.GetComponentInChildren<TextMeshProUGUI>(true).m_sharedMaterial = LCB_French_Font.GetFrenchMats(2);
            }
        }
        #endregion

        #region Story UI
        [HarmonyPatch(typeof(MainStorySlot), nameof(MainStorySlot.SetData))]
        [HarmonyPostfix]
        private static void MainStorySlot_Init(MainStorySlot __instance)
        {
            GameObject episode = GameObject.Find("[Canvas]RatioMainUI/[Rect]PanelRoot/[UIPanel]StoryUIPanel(Clone)/[Rect]MainStoryUI/[Rect]MainStory/Scroll View/Viewport/Content/[Rect]MainStorySlot(Clone)/[Rect]Panel/[Rect]Title/[Text]Chapter");
            if (episode != null)
            {
                episode.GetComponentInChildren<TextMeshProUGUI>(true).name = "Episodes";
                episode.GetComponentInChildren<TextMeshProUGUI>(true).text = "Épisode";
                episode.GetComponentInChildren<TextMeshProUGUI>(true).font = LCB_French_Font.tmpfrenchfonts[1];
                episode.GetComponentInChildren<TextMeshProUGUI>(true).fontMaterial = LCB_French_Font.tmpfrenchfonts[1].material;
            }
            __instance._conditionComingSoonText.GetComponent<TextMeshProUGUI>().text = "Prochainement...";
            __instance._conditionComingSoonText.GetComponent<TextMeshProUGUI>().font = LCB_French_Font.tmpfrenchfonts[1];
            __instance._conditionComingSoonText.GetComponent<TextMeshProUGUI>().fontMaterial = LCB_French_Font.tmpfrenchfonts[1].material;
        }
        [HarmonyPatch(typeof(OtherStorySlot), nameof(OtherStorySlot.SetData))]
        [HarmonyPostfix]
        private static void OtherStorySlot_Init(OtherStorySlot __instance)
        {
            Transform coming_soon = __instance.transform.Find("[Button]OtherStorySlot/[Rect]LockObject/[Text]LockComingSoon");
            if (coming_soon != null)
            {
                coming_soon.GetComponent<TextMeshProUGUI>().text = "Prochainement";
                coming_soon.GetComponent<TextMeshProUGUI>().font = LCB_French_Font.tmpfrenchfonts[1];
                coming_soon.GetComponent<TextMeshProUGUI>().fontMaterial = LCB_French_Font.tmpfrenchfonts[1].material;
            }
            Transform episode = __instance.transform.Find("[Button]OtherStorySlot/[Rect]UnLockObject/[Text]EPISODE");
            if (episode != null)
            {
                episode.GetComponentInChildren<TextMeshProUGUI>(true).text = "Épisode";
                episode.GetComponentInChildren<TextMeshProUGUI>(true).font = LCB_French_Font.tmpfrenchfonts[1];
                episode.GetComponentInChildren<TextMeshProUGUI>(true).fontMaterial = LCB_French_Font.tmpfrenchfonts[1].material;
            }
        }
        [HarmonyPatch(typeof(OtherStorySlot), nameof(OtherStorySlot.SetData_Event))]
        [HarmonyPostfix]
        private static void OSS_Init(OtherStorySlot __instance)
        {
            Transform episode = __instance.transform.Find("[Button]OtherStorySlot/[Rect]UnLockObject/[Text]EPISODE");
            if (episode != null)
            {
                episode.GetComponentInChildren<TextMeshProUGUI>(true).text = "Épisode";
                episode.GetComponentInChildren<TextMeshProUGUI>(true).font = LCB_French_Font.tmpfrenchfonts[1];
                episode.GetComponentInChildren<TextMeshProUGUI>(true).fontMaterial = LCB_French_Font.tmpfrenchfonts[1].material;
            }
        }
        #endregion

        #region Kromer
        [HarmonyPatch(typeof(BattleUnitView), nameof(BattleUnitView.Update))]
        [HarmonyPostfix]
        private static void BattleUnitView_Init(BattleUnitView __instance)
        {
            __instance._uiManager._dialogUI.GetComponentInChildren<BattleDialogUI>(true).tmp_dialog.name = "AHUET";
            __instance._uiManager._dialogUI.GetComponentInChildren<BattleDialogUI>(true).tmp_dialog.m_fontAsset = LCB_French_Font.GetFrenchFonts(4);
            __instance._uiManager._dialogUI.GetComponentInChildren<BattleDialogUI>(true).tmp_dialog.m_sharedMaterial = LCB_French_Font.GetFrenchMats(16);
        }
        #endregion

        #region Buffs
        [HarmonyPatch(typeof(TypoText), nameof(TypoText.SetEnable))]
        [HarmonyPostfix]
        private static void TypoText_Init(TypoText __instance)
        {
            __instance._text.text = __instance._text.text.Replace("Calme Compte", "Compte de Calme");
            __instance._text.text = __instance._text.text.Replace("Charge Compte", "Compte de Charge");
            __instance._text.text = __instance._text.text.Replace("Saignement Compte", "Compte de Saignement");
            __instance._text.text = __instance._text.text.Replace("Brûlure Compte", "Compte de Brûlure");
            __instance._text.text = __instance._text.text.Replace("Déchirure Compte", "Compte de Déchirure");
            __instance._text.text = __instance._text.text.Replace("Tremblement Compte", "Compte de Tremblement");
            __instance._text.text = __instance._text.text.Replace("Lourdeur Compte", "Compte de Lourdeur");
            __instance._text.text = __instance._text.text.Replace("Lack of Munition", "Manque de Munition");
        }
        #endregion
    }
}
