using BattleUI;
using BattleUI.Information;
using HarmonyLib;
using MainUI;
using MainUI.VendingMachine;
using TMPro;
using UnityEngine;
using Dungeon.Map.UI;
using BattleUI.BattleUnit;
using System.Collections.Generic;
using System.Text.RegularExpressions;
using MainUI.BattleResult;
using UtilityUI;
using BattleUI.Operation;
using System;
using EGOGift;
using BattleUI.BattleUnit.SkillInfoUI;

namespace LimbusCompanyFR
{
    internal class EO_TextUI
    {
        #region Login
        [HarmonyPatch(typeof(LoginSceneManager), nameof(LoginSceneManager.SetLoginInfo))]
        [HarmonyPostfix]
        private static void Client_Init(LoginSceneManager __instance)
        {
            __instance.btn_allCacheClear.GetComponentInChildren<TextMeshProUGUI>(true).lineSpacing = -60;
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
                now_l.GetComponentInChildren<TextMeshProUGUI>(true).font = LCB_French_Font.tmpfrenchfonts[0];
                now_l.GetComponentInChildren<TextMeshProUGUI>(true).fontMaterial = LCB_French_Font.tmpfrenchfonts[0].material;
                __instance._loadingCategoryText.GetComponentInChildren<TextMeshProUGUI>(true).name = "Mises à jour";
                __instance._loadingCategoryText.GetComponentInChildren<TextMeshProUGUI>(true).text = __instance._loadingCategoryText.GetComponentInChildren<TextMeshProUGUI>(true).text.Replace("Downloading", "Téléchargement des");
                __instance._loadingCategoryText.GetComponentInChildren<TextMeshProUGUI>(true).text = __instance._loadingCategoryText.GetComponentInChildren<TextMeshProUGUI>(true).text.Replace("UPDATE", "MISES À JOUR");
                __instance._loadingCategoryText.GetComponentInChildren<TextMeshProUGUI>(true).text = __instance._loadingCategoryText.GetComponentInChildren<TextMeshProUGUI>(true).text.Replace("Sound", "Sons");
                __instance._loadingCategoryText.GetComponentInChildren<TextMeshProUGUI>(true).text = __instance._loadingCategoryText.GetComponentInChildren<TextMeshProUGUI>(true).text.Replace("Sprite", "Sprites");
                __instance._loadingCategoryText.GetComponentInChildren<TextMeshProUGUI>(true).font = LCB_French_Font.tmpfrenchfonts[0];
                __instance._loadingCategoryText.GetComponentInChildren<TextMeshProUGUI>(true).fontMaterial = LCB_French_Font.tmpfrenchfonts[0].material;
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
                No.GetComponentInChildren<TextMeshProUGUI>(true).text = "№";
            }
        }

        [HarmonyPatch(typeof(UserInfoCard), nameof(UserInfoCard.SetDataMainLobby))]
        [HarmonyPostfix]
        private static void Lobby_LevelID(UserInfoCard __instance)
        {
            TextMeshProUGUI lv = __instance.transform.Find("[Rect]AspectRatio/[Canvas]Info/[Text]LevelLabel").GetComponentInChildren<TextMeshProUGUI>(true);
            lv.text = "NV";

            TextMeshProUGUI no = __instance.transform.Find("[Rect]AspectRatio/[Canvas]Info/[Text]IdNumberLabel").GetComponentInChildren<TextMeshProUGUI>(true);
            no.text = "№";
        }

        [HarmonyPatch(typeof(NoticeUIPopup), nameof(NoticeUIPopup.Initialize))]
        [HarmonyPostfix]
        private static void NoticeNews(NoticeUIPopup __instance)
        {
            __instance.btn_systemNotice.GetComponentInChildren<TextMeshProUGUI>(true).lineSpacing = -30;
            __instance.btn_eventNotice.GetComponentInChildren<TextMeshProUGUI>(true).lineSpacing = -30;
        }
        [HarmonyPatch(typeof(StageInfoUI), nameof(StageInfoUI.SetDataOpen))]
        [HarmonyPostfix]
        private static void StageInfoUI_Init(StageInfoUI __instance)
        {
            Transform level = __instance.transform.Find("[UIPanel]StageInfoUIRenewal/[Rect]Pivot/[Rect]StageInfoStatus/[Script]ExclearCondition/[Tmpro]Desc (1)/[Image]RecommentLevelTitleFrame/[Tmpro]Lv");
            if (level != null)
            {
                level.GetComponentInChildren<TextMeshProUGUI>(true).text = level.GetComponentInChildren<TextMeshProUGUI>(true).text.Replace("Lv", "Nv");
            }
        }
        private static string numberEnding(int number)
        {
            int lastDigit = number % 10;
            int lastTwoDigits = number % 100;

            if (lastDigit == 1 && lastTwoDigits < 10)
            {
                return "er";
            }
            else
            {
                return "ème";
            }
        }
        [HarmonyPatch(typeof(StageStoryNodeSelectUI), nameof(StageStoryNodeSelectUI.Init))]
        [HarmonyPostfix]
        private static void NodeSelectUI(StageStoryNodeSelectUI __instance)
        {
            Transform episode_right = __instance.transform.Find("[Rect]Banner/[Image]PageTitle/[Text]PageTitle");
            episode_right.GetComponentInChildren<TextMeshProLanguageSetter>(true).enabled = false;
            episode_right.GetComponentInChildren<TextMeshProUGUI>(true).fontSize = 48;

            Transform episode_main = __instance.transform.Find("[Rect]Desc/[Image]Background/[Image]Panel/[Text]Episode");
            episode_main.GetComponentInChildren<TextMeshProUGUI>(true).text = "ÉPISODE";

            Transform enter = __instance.transform.Find("[Rect]Desc/[Image]Background/[Image]Panel/[Button]EnterStory/[Text]Enter");
            enter.GetComponentInChildren<TextMeshProLanguageSetter>(true).enabled = false;
            enter.GetComponentInChildren<TextMeshProUGUI>(true).text = "Entrer";
        }

        [HarmonyPatch(typeof(StageStoryNodeSelectUI), nameof(StageStoryNodeSelectUI.OnStorySelect))]
        [HarmonyPostfix]
        private static void NodeSelectUI_RightCorner(StageStoryNodeSelectUI __instance)
        {
            if (__instance._leftStoryNumberText.text != null)
            {
                string[] parts = __instance._leftStoryNumberText.text.Split(' ');
                int number = int.Parse(parts[0]);
                string episode = parts[1];
                string numEpi = numberEnding(number);
                __instance._leftStoryNumberText.text = $"{number}{numEpi} {episode}";
            }
        }

        [HarmonyPatch(typeof(StorytheaterSelectNodeBase), nameof(StorytheaterSelectNodeBase.SetData))]
        [HarmonyPostfix]
        private static void NodeSelectUIBottom(StorytheaterSelectNodeBase __instance)
        {
            if (__instance._unSelectStoryText != null)
            {
                string[] unparts = __instance._unSelectStoryText.text.Split(' ');
                int unnumber = int.Parse(unparts[0]);
                string unepisode = unparts[1];
                string unnumEpi = numberEnding(unnumber);
                __instance._unSelectStoryText.text = $"{unnumber}{unnumEpi}\n{unepisode}";

                __instance._unSelectStoryText.fontSize = 46;
                __instance._unSelectStoryText.lineSpacing = -30;
            }

            if (__instance._selectStoryText != null)
            {
                string[] parts = __instance._selectStoryText.text.Split(' ');
                int number = int.Parse(parts[0]);
                string episode = parts[1];
                string numEpi = numberEnding(number);
                __instance._selectStoryText.text = $"{number}{numEpi}\n{episode}";

                __instance._selectStoryText.fontSize = 46;
                __instance._selectStoryText.lineSpacing = -30;
            }
        }
        private static string getTimerD(int days)
        {
            int lastDigit = days % 10;
            int lastTwoDigits = days % 100;

            if (lastTwoDigits >= 11 && lastTwoDigits <= 59)
            {
                return "jours";
            }
            else if (lastDigit == 1)
            {
                return "jour";
            }
            else
            {
                return "jours";
            }
        }

        private static string getTimerH(int hours)
        {
            int lastDigit = hours % 10;
            int lastTwoDigits = hours % 100;

            if (lastTwoDigits >= 11 && lastTwoDigits <= 59)
            {
                return "heures";
            }
            else if (lastDigit == 1)
            {
                return "heure";
            }
            else
            {
                return "heures";
            }
        }

        private static string getTimerM(int minutes)
        {
            int lastDigit = minutes % 10;
            int lastTwoDigits = minutes % 100;

            if (lastTwoDigits >= 11 && lastTwoDigits <= 59)
            {
                return "minutes";
            }
            else if (lastDigit == 1)
            {
                return "minute";
            }
            else
            {
                return "minutes";
            }
        }

        [HarmonyPatch(typeof(EventTimerUI), nameof(EventTimerUI.UpdateRemainEventTime))]
        [HarmonyPostfix]
        private static void EventTimerUI_Init(EventTimerUI __instance)
        {
            __instance.tmp_remainingTime.name = "EVENT!";
            string pattern = @"(\d+ jours)(\d+ heures)";
            Match match = Regex.Match(__instance.tmp_remainingTime.text, pattern);
            if (match.Success)
            {
                int days = int.Parse(match.Groups[1].Value.Split(' ')[0]);
                int hours = int.Parse(match.Groups[2].Value.Split(' ')[0]);
                string dayWord = getTimerD(days);
                string hourWord = getTimerH(hours);
                __instance.tmp_remainingTime.text = Regex.Replace(__instance.tmp_remainingTime.text, pattern, days + " " + dayWord + " " + hours + " " + hourWord);
            }
            string lastPattern = @"(\d+ heures)(\d+ minutes)";
            Match lastMatch = Regex.Match(__instance.tmp_remainingTime.text, lastPattern);
            if (lastMatch.Success)
            {
                int hours = int.Parse(lastMatch.Groups[1].Value.Split(' ')[0]);
                int minutes = int.Parse(lastMatch.Groups[2].Value.Split(' ')[0]);
                string hourWord = getTimerH(hours);
                string minuteWord = getTimerM(minutes);
                __instance.tmp_remainingTime.text = Regex.Replace(__instance.tmp_remainingTime.text, lastPattern, hours + " " + hourWord + " " + minutes + " " + minuteWord);
            }
            __instance.tmp_remainingTime.name = "EVENT!";
            string dayPattern = @"(\d+ jours)";
            Match dayMatch = Regex.Match(__instance.tmp_remainingTime.text, dayPattern);
            if (dayMatch.Success)
            {
                int days = int.Parse(dayMatch.Groups[1].Value.Split(' ')[0]);
                string dayWord = getTimerD(days);
                __instance.tmp_remainingTime.text = Regex.Replace(__instance.tmp_remainingTime.text, dayPattern, days + " " + dayWord);
            }
            __instance.tmp_remainingTime.name = "EVENT!";
            string hourPattern = @"(\d+ heures)";
            Match hourMatch = Regex.Match(__instance.tmp_remainingTime.text, hourPattern);
            if (hourMatch.Success)
            {
                int hours = int.Parse(hourMatch.Groups[1].Value.Split(' ')[0]);
                string hourWord = getTimerH(hours);
                __instance.tmp_remainingTime.text = Regex.Replace(__instance.tmp_remainingTime.text, hourPattern, hours + " " + hourWord);
            }
            __instance.tmp_remainingTime.name = "EVENT!";
            string minutePattern = @"(\d+ minutes)";
            Match minuteMatch = Regex.Match(__instance.tmp_remainingTime.text, minutePattern);
            if (minuteMatch.Success)
            {
                int minutes = int.Parse(minuteMatch.Groups[1].Value.Split(' ')[0]);
                string minuteWord = getTimerM(minutes);
                __instance.tmp_remainingTime.text = Regex.Replace(__instance.tmp_remainingTime.text, minutePattern, minutes + " " + minuteWord);
            }
        }
        [HarmonyPatch(typeof(RewatchingStageStoryButton), nameof(RewatchingStageStoryButton.SetData))]
        [HarmonyPostfix]
        private static void Rewatch_EpisodeLabel(RewatchingStageStoryButton __instance)
        {
            TextMeshProUGUI episode = __instance.transform.Find("[LayoutGroup]Episode/[Text]Episode").GetComponentInChildren<TextMeshProUGUI>(true);
            if (episode != null)
            {
                episode.text = "ÉPISODE";
            }
        }
        #endregion

        #region Friends
        [HarmonyPatch(typeof(UserInfoUIPopup), nameof(UserInfoUIPopup.Open))]
        [HarmonyPostfix]
        private static void TicketInfoPopup(UserInfoUIPopup __instance)
        {
            Transform ego = __instance._userinfoTicketCustomPopup._egoBackgroundBtn.transform.Find("[Text]EGO");
            Transform bg = __instance._userinfoTicketCustomPopup._egoBackgroundBtn.transform.Find("[Text]BG");
            ego.GetComponentInChildren<TextMeshProUGUI>(true).text = "<size=50>Fond</size>";
            ego.GetComponentInChildren<TextMeshProUGUI>(true).lineSpacing = -20;
            bg.GetComponentInChildren<UITextDataLoader>(true).enabled = false;
            bg.GetComponentInChildren<TextMeshProUGUI>(true).text = "<size=70>E.G.O.</size>";
        }
        [HarmonyPatch(typeof(UserInfoTicketItem), nameof(UserInfoTicketItem.SetTag))]
        [HarmonyPostfix]
        private static void TicketChangePopup(UserInfoTicketItem __instance)
        {
            __instance._using_choosingText.text = "Choisi";
            __instance._using_choosingText.lineSpacing = -20;
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
        [HarmonyPatch(typeof(ExpDungeonUIPanel), nameof(ExpDungeonUIPanel.SetDataOpen))]
        [HarmonyPostfix]
        private static void ExpDungeonItem_Init(ExpDungeonUIPanel __instance)
        {
            foreach (ExpDungeonItem item in __instance._dungeonItemList)
            {
                item.tmp_title.fontStyle = FontStyles.Normal | FontStyles.SmallCaps;
                item.tmp_level.text = item.tmp_level.text.Replace("Lv", "Nv.");
                Transform label = item.tmp_level.transform.parent.parent.Find("[Text]StageLabel");
                label.GetComponentInChildren<TextMeshProUGUI>().text = "Niveau";
            }
        }

        [HarmonyPatch(typeof(ThreadDungeonSelectStageButton), nameof(ThreadDungeonSelectStageButton.SetData))]
        [HarmonyPostfix]
        private static void ThreadDungeonSelectStageButton_Init(ThreadDungeonSelectStageButton __instance)
        {
            __instance.tmp_level.text = __instance.tmp_level.text.Replace("Lv", "Nv.");
            __instance.tmp_level.fontSize = 60;
        }

        [HarmonyPatch(typeof(RemainTimeText), nameof(RemainTimeText.SetRemainNextDay))]
        [HarmonyPostfix]
        private static void ThreadDungeonRemainingTime(RemainTimeText __instance)
        {
            if (__instance.tmp_timer.text.Contains("Heures:"))
            {
                __instance.tmp_timer.text = __instance.tmp_timer.text.Replace("Heures:", "");
                string[] parts = __instance.tmp_timer.text.Split(' ');
                int number = int.Parse(parts[0]);
                __instance.tmp_timer.text = $"Il vous reste {number} {getTimerH(number)}";
            }
            if (__instance.tmp_timer.text.Contains("Minutes:"))
            {
                __instance.tmp_timer.text = __instance.tmp_timer.text.Replace("Minutes:", "");
                string[] parts = __instance.tmp_timer.text.Split(' ');
                int number = int.Parse(parts[0]);
                __instance.tmp_timer.text = $"Il vous reste {number} {getTimerM(number)}";
            }
        }
        #endregion

        #region Mirror Dungeons
        [HarmonyPatch(typeof(EgoGiftTooltip), nameof(EgoGiftTooltip.SetUpDataAndOpen))]
        [HarmonyPostfix]
        private static void EgoGift_ToolTipLabel(EgoGiftTooltip __instance)
        {
            TextMeshProUGUI tooltip = __instance.transform.Find("TitleLabelRect/tmp_title").GetComponentInChildren<TextMeshProUGUI>(true);
            if (tooltip != null)
            {
                tooltip.text = "Don E.G.O.";
            }
        }
        #endregion

        #region Choice UI
        [HarmonyPatch(typeof(PersonalityChoiceEventJudgementTitleUI), nameof(PersonalityChoiceEventJudgementTitleUI.SetEventJudgementTitle))]
        [HarmonyPostfix]
        private static void SinAffinity_UI(PersonalityChoiceEventJudgementTitleUI __instance)
        {
            __instance.tmp_requiredAttributes.lineSpacing = -30;
            Transform sins = __instance.transform.Find("[Text]AttributeTypeJudgment");
            sins.GetComponentInChildren<RectTransform>().anchoredPosition = new Vector2(700, 87);
            __instance.tmp_judgementComparisonType.lineSpacing = -30;
            Transform chance = __instance.transform.Find("[Text]JudgmentComparison");
            chance.GetComponentInChildren<RectTransform>().anchoredPosition = new Vector2(410, 755);

            __instance.tmp_requiredAttributes.text = __instance.tmp_requiredAttributes.text.Replace("/", " / ").Replace("< / ", "</");
        }
        #endregion

        #region Vending Machine
        [HarmonyPatch(typeof(VendingMachineUIPanel), "Initialize")]
        [HarmonyPostfix]
        private static void VendingMachineUIPanel_Init(VendingMachineUIPanel __instance)
        {
            Transform comment = __instance.transform.Find("GoodsStoreAreaMaster/PageButtonArea/BackPanel/Btn_TypeAnnouncer/Tmp_Announcer");
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
            if (id_mainui != null)
            {
                id_mainui.GetComponentInChildren<UITextDataLoader>().enabled = false;
                id_mainui.GetComponentInChildren<TextMeshProUGUI>(true).richText = false;
                id_mainui.GetComponentInChildren<TextMeshProUGUI>(true).autoSizeTextContainer = true;
                id_mainui.GetComponentInChildren<TextMeshProUGUI>(true).text = "Identité";
            }
        }
        [HarmonyPatch(typeof(UnitInformationTabButton), nameof(UnitInformationTabButton.SetData))]
        [HarmonyPostfix]
        private static void Skills(UnitInformationTabButton __instance)
        {
            __instance.tmp_tabName.text = __instance.tmp_tabName.text.Replace("Capacité", "Capacités");
        }
        [HarmonyPatch(typeof(FormationUIPanel), nameof(FormationUIPanel.Initialize))]
        [HarmonyPostfix]
        private static void FormationUIPanel_Init(FormationUIPanel __instance)
        {
            GameObject teams = GameObject.Find("[Canvas]RatioMainUI/[Rect]PanelRoot/[UIPanel]PersonalityFormationUIPanel(Clone)/[Rect]LeftObjects/[Rect]DeckSettings/[Rect]Contents/[Text]DeckTitle");
            if (teams != null)
            {
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
            }
        }
        [HarmonyPatch(typeof(PersonalityDetailButton), nameof(PersonalityDetailButton.SetUIMode))]
        [HarmonyPostfix]
        private static void FormationSecondChance_Init(PersonalityDetailButton __instance)
        {
            __instance._skillText._text.fontStyle = FontStyles.Normal | FontStyles.SmallCaps;
            __instance.tmp_skillHighlight.fontStyle = FontStyles.Normal | FontStyles.SmallCaps;
            __instance._skillText._text.text = "Capacités";
            __instance.tmp_skillHighlight.text = "Capacités";
        }
        [HarmonyPatch(typeof(PersonalityDetailButton), nameof(PersonalityDetailButton.Initialize))]
        [HarmonyPostfix]
        private static void FormationUwa_Init(PersonalityDetailButton __instance)
        {
            __instance._skillText._text.text = "Capacités";
            __instance.tmp_skillHighlight.text = "Capacités";
        }
        [HarmonyPatch(typeof(FormationUIDeckToggle), nameof(FormationUIDeckToggle.SetText))]
        [HarmonyPostfix]
        private static void FormationUIDeckToggle_Init(FormationUIDeckToggle __instance)
        {
            __instance.tmp_title.text = __instance.tmp_title.text.Replace("#", "№");
        }
        [HarmonyPatch(typeof(FormationPersonalityUI), nameof(FormationPersonalityUI.SetNonClickable))]
        [HarmonyPostfix]
        private static void FormationLabel_Init(FormationPersonalityUI __instance)
        {
            __instance._textInfo.txt_level.text = __instance._textInfo.txt_level.text.Replace("Lv.", "Nv.");
        }

        [HarmonyPatch(typeof(FormationPersonalityUI_Label), nameof(FormationPersonalityUI_Label.Reload))]
        [HarmonyPostfix]
        private static void FormationLabel(FormationPersonalityUI_Label __instance)
        {
            String sinner = __instance.tmp_text.transform.parent.parent.parent.parent.name.Substring(25);
            if (__instance.tmp_text.text.Contains("Appointé"))
            {
                switch (sinner)
                {
                    case "Faust" or "Donqui" or "Ryoshu" or "Ishmael" or "Rodion" or "Outis":
                        __instance.tmp_text.text = "<voffset=-0.25em><size=56><cspace=-1px>Appointée</cspace></size></voffset>";
                        break;
                }
            }
            if (__instance.tmp_text.text.Contains("Échangé"))
            {
                switch (sinner)
                {
                    case "Faust" or "Donqui" or "Ryoshu" or "Ishmael" or "Rodion" or "Outis":
                        __instance.tmp_text.text = "<voffset=-0.25em><size=56><cspace=-1px>Échangée</cspace></size></voffset>";
                        break;
                }
            }
        }

        [HarmonyPatch(typeof(FormationUIDeckToggle), nameof(FormationUIDeckToggle.UpdateScrollAnimation))]
        [HarmonyPostfix]
        private static void TeamName(FormationUIDeckToggle __instance)
        {
            __instance.tmp_title.text = __instance.tmp_title.text.Replace("#", "№");
        }
        #endregion

        #region LV
        [HarmonyPatch(typeof(UnitinfoUnitStatusContent), nameof(UnitinfoUnitStatusContent.Init))]
        [HarmonyPostfix]
        private static void UnitinfoUnitStatusContent_Init(UnitinfoUnitStatusContent __instance)
        {
            TextMeshProUGUI lvlb = __instance._levelUI.transform.Find("Tmp_LV_sign").GetComponentInChildren<TextMeshProUGUI>();
            TextMeshProUGUI lvlp = __instance._levelExpGuageUI.transform.Find("Tmp_LV_sign").GetComponentInChildren<TextMeshProUGUI>();
            List<TextMeshProUGUI> lvl_l = new List<TextMeshProUGUI> { lvlb, lvlp };
            foreach (TextMeshProUGUI lvl in lvl_l)
            {
                lvl.text = lvl.text.Replace("LV", "NV");
            }
        }
        [HarmonyPatch(typeof(FormationSwitchablePersonalityUIScrollViewItem), nameof(FormationSwitchablePersonalityUIScrollViewItem.SetData))]
        [HarmonyPostfix]
        private static void FormationSwitchablePersonalityUIScrollViewItemLevel_Init(FormationSwitchablePersonalityUIScrollViewItem __instance)
        {
            __instance.txt_level.text = __instance.txt_level.text.Replace("Lv", "Nv");
            if (__instance._participatedObject != null)
            {
                TextMeshProUGUI participated = __instance._participatedObject.transform.Find("[Text]Label").GetComponentInChildren<TextMeshProUGUI>();
                participated.fontSize = 56;
            }
        }
        [HarmonyPatch(typeof(UserInfoCard), nameof(UserInfoCard.SetData))]
        [HarmonyPostfix]
        private static void UserInfoCard_Init(UserInfoCard __instance)
        {
            TextMeshProUGUI lvl = __instance.tmp_level.transform.parent.Find("[Text]LevelLabel").GetComponentInChildren<TextMeshProUGUI>();
            LevelLabel(lvl);
            TextMeshProUGUI num = __instance.tmp_level.transform.parent.Find("[Text]IdNumberLabel").GetComponentInChildren<TextMeshProUGUI>();
            NumberLabel(num);
        }
        [HarmonyPatch(typeof(UserInfoFriednsSlot), nameof(UserInfoFriednsSlot.SetData))]
        [HarmonyPostfix]
        private static void UserInfoFriednsSlot_Init(UserInfoFriednsSlot __instance)
        {
            TextMeshProUGUI lvl = __instance._friendCard.tmp_level.transform.parent.Find("[Text]LevelLabel").GetComponentInChildren<TextMeshProUGUI>();
            LevelLabel(lvl);
            TextMeshProUGUI num = __instance._friendCard.tmp_level.transform.parent.Find("[Text]IdNumberLabel").GetComponentInChildren<TextMeshProUGUI>();
            NumberLabel(num);
            num.fontSize = 35;
        }
        [HarmonyPatch(typeof(UserInfoFriendsInfoPopup), nameof(UserInfoFriendsInfoPopup.SetData))]
        [HarmonyPostfix]
        private static void UserInfoFriendsInfoPopup_Init(UserInfoFriendsInfoPopup __instance)
        {
            TextMeshProUGUI lvl = __instance._friendsManager._friendCard.tmp_level.transform.parent.Find("[Text]LevelLabel").GetComponentInChildren<TextMeshProUGUI>();
            LevelLabel(lvl);
            TextMeshProUGUI num = __instance._friendsManager._friendCard.tmp_level.transform.parent.Find("[Text]IdNumberLabel").GetComponentInChildren<TextMeshProUGUI>();
            NumberLabel(num);
        }
        private static void LevelLabel(TextMeshProUGUI lvl_l)
        {
            lvl_l.text = lvl_l.text.Replace("LV", "NV");
        }
        private static void NumberLabel(TextMeshProUGUI num_l)
        {
            num_l.text = "№";
        }
        #endregion

        #region Sinner UI
        [HarmonyPatch(typeof(UnitInformationSkillSlot), nameof(UnitInformationSkillSlot.SetData))]
        [HarmonyPostfix]
        private static void UnitInformationSkillSlot_Init(UnitInformationSkillSlot __instance)
        {
            GameObject skill = GameObject.Find("[Canvas]RatioMainUI/[Rect]PanelRoot/[Script]UnitInformationController(Clone)/[Script]UnitInformationController_Renewal/[Script]TabContentManager/[Layout]UnitInfoTabList/[Button]UnitInfoTab (1)/[Text]UnitInfoTabName");
            if (skill != null)
            {
                skill.GetComponentInChildren<TextMeshProUGUI>(true).text = "Capacités";
            }
            if (__instance.tmp_skillTier.text == "DEFENSE")
            {
                __instance.tmp_skillTier.text = "Défense";
                __instance.tmp_skillTier.GetComponent<TextMeshProUGUI>().enabled = true;
                __instance.tmp_skillTier.GetComponentInChildren<TextMeshProUGUI>(true).enabled = true;
            }
        }
        [HarmonyPatch(typeof(UnitInfoBreakSectionTooltipUI), nameof(UnitInfoBreakSectionTooltipUI.SetDataAndOpen))]
        [HarmonyPostfix]
        private static void UnitInfoBreakSections(UnitInfoBreakSectionTooltipUI __instance)
        {
            __instance.tmp_tooltipContent.fontSize = 35f;
        }
        #endregion

        #region Battle UI
        [HarmonyPatch(typeof(UpperSkillInfoUIStateSettingButton), nameof(UpperSkillInfoUIStateSettingButton.SetCurrentState))]
        [HarmonyPostfix]
        private static void BattleUI_Init(UpperSkillInfoUIStateSettingButton __instance)
        {
            __instance._currentStateText.text = __instance._currentStateText.text.Replace("MAX", "<size=50>MAX</size>").Replace("MID", "<size=50>MOY</size>").Replace("MIN", "<size=50>MIN</size>");

            __instance._minBtn.tmp_text.text = "<size=50>MIN</size>";
            __instance._midBtn.tmp_text.text = "<size=50>MOY</size>";
            __instance._maxBtn.tmp_text.text = "<size=50>MAX</size>";
        }

        [HarmonyPatch(typeof(ActTypoWaveStartUI), nameof(ActTypoWaveStartUI.Open))]
        [HarmonyPostfix]
        private static void ActTypoWaveStartUI_Init(ActTypoWaveStartUI __instance)
        {
            if (__instance.tmp_content.text.Contains("WAVE"))
            {
                __instance.tmp_content.text = __instance.tmp_content.text.Replace("WAVE", "Vague");
            }
        }
        [HarmonyPatch(typeof(TargetDetailSkillInfoController), nameof(TargetDetailSkillInfoController.SetSkillUpperData))]
        [HarmonyPostfix]
        private static void ParryingData_WinRate(TargetDetailSkillInfoController __instance)
        {
            __instance._winRateTypo._textMeshPro.lineSpacing = -30;
        }
        [HarmonyPatch(typeof(UnitInformationTabButton), nameof(UnitInformationTabButton.Init))]
        [HarmonyPostfix]
        private static void EnemyUnitInfo_Init(UnitInformationTabButton __instance)
        {
            __instance.tmp_tabName.text = __instance.tmp_tabName.text.Replace("Capacité", "Capacités");
        }
        [HarmonyPatch(typeof(TmproCharacterTypoTextEffect), nameof(TmproCharacterTypoTextEffect.SetTiltAndPosText))]
        [HarmonyPostfix]
        private static void PanicStateUI_Open(TmproCharacterTypoTextEffect __instance)
        {
            __instance.tmp.text = __instance.tmp.text.Replace("PANIC", "PANIQUE");
        }

        [HarmonyPatch(typeof(NewOperationController), nameof(NewOperationController.SetState))]
        [HarmonyPostfix]
        private static void AutoButtons(NewOperationController __instance)
        {
            Transform WinRate = __instance.transform.Find("[Rect]ActiveControl/[Rect]Pivot/[Rect]ActionableSlotList/[Layout]SinActionSlotsGrid/[Rect]AutoSelectButton/[Rect]Pivot/[Toggle]WinRate/Background/Text (TMP)");
            WinRate.GetComponentInChildren<TextMeshProUGUI>(true).fontSize = 34;
            WinRate.GetComponentInChildren<TextMeshProUGUI>(true).lineSpacing = -20;
        }
        [HarmonyPatch(typeof(UnitInfoNameTagAbResearchLevelUI), nameof(UnitInfoNameTagAbResearchLevelUI.Init))]
        [HarmonyPostfix]
        private static void AbnormalityResearch(UnitInfoNameTagAbResearchLevelUI __instance)
        {
            __instance.tmp_storyButton.lineSpacing = -20;
        }
        [HarmonyPatch(typeof(UnitInformationSkillSlot), nameof(UnitInformationSkillSlot.UpdateLayout))]
        [HarmonyPostfix]
        private static void SkillDefence(UnitInformationSkillSlot __instance)
        {
            __instance.tmp_skillTier.text = __instance.tmp_skillTier.text.Replace("DEFENSE", "ЗАЩИТА");
        }

        [HarmonyPatch(typeof(AbnormalityUnitConditionText), nameof(AbnormalityUnitConditionText.SetConditionText))]
        [HarmonyPostfix]
        private static void AbnormalityPartTexts(AbnormalityUnitConditionText __instance)
        {
            __instance.tmp_condition.lineSpacing = -30;
        }
        #endregion

        #region Battle Result UI
        [HarmonyPatch(typeof(BattleResultUIPanel), nameof(BattleResultUIPanel.SetStatusUI))]
        [HarmonyPostfix]
        private static void BattleResult_Init(BattleResultUIPanel __instance)
        {
            Transform managerLV = __instance.transform.Find("[Rect]Right/[Rect]Frames/rect_titleGroup/[Script]UserLevel/[Tmpro]LvValue/[Tmpro]Lv");
            if (managerLV != null)
            {
                managerLV.GetComponentInChildren<TextMeshProUGUI>(true).text = managerLV.GetComponentInChildren<TextMeshProUGUI>(true).text.Replace("LV.", "NV.");
            }
        }
        [HarmonyPatch(typeof(BattleResultPersonalityExpGaugeUI), nameof(BattleResultPersonalityExpGaugeUI.SetLevelText))]
        [HarmonyPostfix]
        private static void BattleResultPersonalityExpGaugeUI_Init(BattleResultPersonalityExpGaugeUI __instance)
        {
            Transform Lv = __instance.tmp_levelText.transform.Find("tmp_level_text");
            Lv.GetComponentInChildren<TextMeshProUGUI>().text = "NV.";
        }
        #endregion

        #region Dungeon
        [HarmonyPatch(typeof(NodeUI), nameof(NodeUI.UpdateData))]
        [HarmonyPostfix]
        private static void Nodes(NodeUI __instance)
        {
            if (__instance._startTypo != null)
            {
                __instance._startTypo.GetComponentInChildren<TextMeshProUGUI>(true).text = "DÉPART";
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
            Transform angela_my_beloved = __instance.transform.Find("[Scroll]AnnouncerScrollView/Scroll View/Viewport/Content/Layout/[Script]BattleAnnouncerSlot(Clone)/[Image]SelectedTag/[Text]Selected");
            if (angela_my_beloved != null)
            {
                angela_my_beloved.GetComponentInChildren<TextMeshProUGUI>(true).text = "Choisie";
                angela_my_beloved.GetComponentInChildren<TextMeshProUGUI>(true).name = "Choisie";
            }
            Transform nelly = __instance.transform.Find("[Scroll]AnnouncerScrollView/Scroll View/Viewport/Content/Layout/[Script]BattleAnnouncerSlot(Clone)/[Image]SelectedTag/[Text]Selected");
            if (nelly != null)
            {
                nelly.GetComponentInChildren<TextMeshProUGUI>(true).text = "Choisie";
                nelly.GetComponentInChildren<TextMeshProUGUI>(true).name = "Choisie";
            }
            Transform heathcliff = __instance.transform.Find("[Scroll]AnnouncerScrollView/Scroll View/Viewport/Content/Layout/[Script]BattleAnnouncerSlot(Clone)/[Image]SelectedTag/[Text]Selected");
            if (heathcliff != null)
            {
                heathcliff.GetComponentInChildren<TextMeshProUGUI>(true).text = "Choisi";
                heathcliff.GetComponentInChildren<TextMeshProUGUI>(true).name = "Choisi";
            }
            Transform samjo = __instance.transform.Find("[Scroll]AnnouncerScrollView/Scroll View/Viewport/Content/Layout/[Script]BattleAnnouncerSlot(Clone)/[Image]SelectedTag/[Text]Selected");
            if (samjo != null)
            {
                samjo.GetComponentInChildren<TextMeshProUGUI>(true).text = "Choisi";
                samjo.GetComponentInChildren<TextMeshProUGUI>(true).name = "Choisi";
            }
            Transform yesod = __instance.transform.Find("[Scroll]AnnouncerScrollView/Scroll View/Viewport/Content/Layout/[Script]BattleAnnouncerSlot(Clone)/[Image]SelectedTag/[Text]Selected");
            if (yesod != null)
            {
                yesod.GetComponentInChildren<TextMeshProUGUI>(true).text = "Choisi";
                yesod.GetComponentInChildren<TextMeshProUGUI>(true).name = "Choisi";
            }
            Transform molars = __instance.transform.Find("[Scroll]AnnouncerScrollView/Scroll View/Viewport/Content/Layout/[Script]BattleAnnouncerSlot(Clone)/[Image]SelectedTag/[Text]Selected");
            if (molars != null)
            {
                molars.GetComponentInChildren<TextMeshProUGUI>(true).text = "Choisis";
                molars.GetComponentInChildren<TextMeshProUGUI>(true).name = "Choisis";
            }
            Transform hod = __instance.transform.Find("[Scroll]AnnouncerScrollView/Scroll View/Viewport/Content/Layout/[Script]BattleAnnouncerSlot(Clone)/[Image]SelectedTag/[Text]Selected");
            if (hod != null)
            {
                hod.GetComponentInChildren<TextMeshProUGUI>(true).text = "Choisie";
                hod.GetComponentInChildren<TextMeshProUGUI>(true).name = "Choisie";
            }
            Transform dawn_offise = __instance.transform.Find("[Scroll]AnnouncerScrollView/Scroll View/Viewport/Content/Layout/[Script]BattleAnnouncerSlot(Clone)/[Image]SelectedTag/[Text]Selected");
            if (dawn_offise != null)
            {
                dawn_offise.GetComponentInChildren<TextMeshProUGUI>(true).text = "Choisis";
                dawn_offise.GetComponentInChildren<TextMeshProUGUI>(true).name = "Choisis";
            }
            Transform sancho = __instance.transform.Find("[Scroll]AnnouncerScrollView/Scroll View/Viewport/Content/Layout/[Script]BattleAnnouncerSlot(Clone)/[Image]SelectedTag/[Text]Selected");
            if (sancho != null)
            {
                sancho.GetComponentInChildren<TextMeshProUGUI>(true).text = "Choisie";
                sancho.GetComponentInChildren<TextMeshProUGUI>(true).name = "Choisie";
            }
            Transform don_quixote = __instance.transform.Find("[Scroll]AnnouncerScrollView/Scroll View/Viewport/Content/Layout/[Script]BattleAnnouncerSlot(Clone)/[Image]SelectedTag/[Text]Selected");
            if (don_quixote != null)
            {
                don_quixote.GetComponentInChildren<TextMeshProUGUI>(true).text = "Choisie";
                don_quixote.GetComponentInChildren<TextMeshProUGUI>(true).name = "Choisie";
            }
            Transform laMancha_bloodfiends = __instance.transform.Find("[Scroll]AnnouncerScrollView/Scroll View/Viewport/Content/Layout/[Script]BattleAnnouncerSlot(Clone)/[Image]SelectedTag/[Text]Selected");
            if (laMancha_bloodfiends != null)
            {
                laMancha_bloodfiends.GetComponentInChildren<TextMeshProUGUI>(true).text = "Choisis";
                laMancha_bloodfiends.GetComponentInChildren<TextMeshProUGUI>(true).name = "Choisis";
            }
        }
        #endregion

        #region SeasonTag
        [HarmonyPatch(typeof(UnitInformationSeasonTagUI), nameof(UnitInformationSeasonTagUI.SetSeasonDataWithTitle))]
        [HarmonyPostfix]
        private static void UnitInformationSeasonTagUI_Init(UnitInformationSeasonTagUI __instance)
        {
            string text = __instance.tmp_season.text.Replace("SEASON", "Saison");
            __instance.tmp_season.text = text.Replace("WALPURGISNACHT", "<cspace=-1px>WALPURGISNACHT</cspace>");
        }
        [HarmonyPatch(typeof(UnitInformationSeasonTagUI), nameof(UnitInformationSeasonTagUI.SetSeasonData))]
        [HarmonyPostfix]
        private static void UnitInformationSeasonTagUI_SetSeasonData(UnitInformationSeasonTagUI __instance)
        {
            string text = __instance.tmp_season.text.Replace("SEASON", "Saison");
            __instance.tmp_season.text = text.Replace("WALPURGISNACHT -", "<cspace=-4px>WALPURGISNACHT -</cspace>");
            __instance.tmp_season.text = __instance.tmp_season.text.Replace("I", "<cspace=-4px>I</cspace>");
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
            limbus_pass.GetComponentInChildren<TextMeshProUGUI>(true).text = "<cspace=-2px>PASS LIMBUS</cspace>";
            limbus_pass.GetComponentInChildren<RectTransform>().anchoredPosition = new Vector2(0, -37);
            limbus_pass_bought.GetComponentInChildren<TextMeshProUGUI>(true).text = "PASS LIMBUS En Cours d’Utilisation";
            limbus_pass_bought.GetComponentInChildren<TextMeshProUGUI>(true).m_enableWordWrapping = false;
            limbus_pass_bought.GetComponentInChildren<RectTransform>().anchoredPosition = new Vector2(-100, -37);
            limbus_pass_bought.GetComponentInChildren<TextMeshProUGUI>(true).m_fontSize = 40;
            battle_pass_bought.GetComponentInChildren<TextMeshProUGUI>(true).text = "";
            battle_pass.GetComponentInChildren<RectTransform>().anchoredPosition = new Vector2(100, 1);
            package.GetComponentInChildren<TextMeshProLanguageSetter>(true).enabled = false;
        }
        #endregion

        #region BattlePass Timer
        [HarmonyPatch(typeof(BattlePassUIPopup), nameof(BattlePassUIPopup.SetRemainText))]
        [HarmonyPostfix]
        private static void BattlePassT_Init(BattlePassUIPopup __instance)
        {
            if (__instance.tmp_remainDate.text.Contains("Jours:"))
            {
                __instance.tmp_remainDate.text = __instance.tmp_remainDate.text.Replace("Jours:", "");
                string[] parts = __instance.tmp_remainDate.text.Split(' ');
                int number = int.Parse(parts[0]);
                __instance.tmp_remainDate.text = $"Il vous reste {number} {getTimerD(number)}";
            }
            else if (__instance.tmp_remainDate.text.Contains("Heures:"))
            {
                __instance.tmp_remainDate.text = __instance.tmp_remainDate.text.Replace("Heures:", "");
                string[] parts = __instance.tmp_remainDate.text.Split(' ');
                int number = int.Parse(parts[0]);
                __instance.tmp_remainDate.text = $"Il vous reste {number} {getTimerH(number)}";
            }
            else if (__instance.tmp_remainDate.text.Contains("Minutes:"))
            {
                __instance.tmp_remainDate.text = __instance.tmp_remainDate.text.Replace("Minutes:", "");
                string[] parts = __instance.tmp_remainDate.text.Split(' ');
                int number = int.Parse(parts[0]);
                __instance.tmp_remainDate.text = $"Il vous reste {number} {getTimerM(number)}";
            }
            else if (__instance.tmp_remainDate.text.Contains("Joursheures:"))
            {
                __instance.tmp_remainDate.text = __instance.tmp_remainDate.text.Replace("Joursheures:", "");
                string[] parts = __instance.tmp_remainDate.text.Split(' ');
                int number1 = int.Parse(parts[0]);
                int number2 = int.Parse(parts[1]);
                __instance.tmp_remainDate.text = $"Il vous reste {number1} {getTimerD(number1)} et {number2} {getTimerH(number2)}";
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
                episode.GetComponentInChildren<TextMeshProUGUI>(true).text = "Épisode";
            }
            __instance._conditionComingSoonText.GetComponent<TextMeshProUGUI>().text = "Prochainement...";
        }
        [HarmonyPatch(typeof(OtherStorySlot), nameof(OtherStorySlot.SetData))]
        [HarmonyPostfix]
        private static void OtherStorySlot_Init(OtherStorySlot __instance)
        {
            Transform coming_soon = __instance.transform.Find("[Button]OtherStorySlot/[Rect]LockObject/[Text]LockComingSoon");
            if (coming_soon != null)
            {
                coming_soon.GetComponent<TextMeshProUGUI>().text = "Prochainement";
            }
            Transform episode = __instance.transform.Find("[Button]OtherStorySlot/[Rect]UnLockObject/[Text]EPISODE");
            if (episode != null)
            {
                episode.GetComponentInChildren<TextMeshProUGUI>(true).text = "Épisode";
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
            }
        }
        #endregion

        #region Gacha
        [HarmonyPatch(typeof(GachaUIPanel), nameof(GachaUIPanel.SetGachaInfoPanel))]
        [HarmonyPostfix]
        private static void GachaDateChanger(GachaUIPanel __instance)
        {
            if (__instance.GachaInfo.BannerInfo.EndDate == null)
            {
                __instance._scheduleRoot.SetActive(false);
            }
            else
            {
                var newCetTIME = __instance.GachaInfo.bannerInfo.EndDate.ToString("HH:mm", false);
                __instance.tmp_dateOfLimit.text = __instance.GachaInfo.BannerInfo.EndDate.ToString("dd.MM.yyyy", false);
                __instance.tmp_timeOfLimit.text = $"{newCetTIME} (CET)";
            }
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
            __instance._text.text = __instance._text.text.Replace("Lack of ", "Manque de ");
        }
        #endregion

        #region EGO
        [HarmonyPatch(typeof(BattleSkillViewUIInfo), nameof(BattleSkillViewUIInfo.Init))]
        [HarmonyPostfix]
        private static void EGO_Name_Lines(BattleSkillViewUIInfo __instance)
        {
            __instance._abnormalNameText.lineSpacing = -20;
            __instance._egoSkillNameText.lineSpacing = -20;
        }
        #endregion

        #region Dante Notes
        [HarmonyPatch(typeof(StoryTheaterDanteNoteDescSlot), nameof(StoryTheaterDanteNoteDescSlot.SetData))]
        [HarmonyPostfix]
        private static void StoryTheaterDanteNoteDescSlot3_Clear(StoryTheaterDanteNoteDescSlot __instance)
        {
            __instance._descText.text = Regex.Replace(__instance._descText.text, @"<line-height=.*?>", "");
        }
        #endregion

        #region Mental BreakDown
        [HarmonyPatch(typeof(UnitInfoMentalTabContent), nameof(UnitInfoMentalTabContent.SetData))]
        [HarmonyPostfix]
        private static void UnitInfoMentalTabContent_Clear(UnitInfoMentalTabContent __instance)
        {
            __instance.tmp_addConditionDesc.text = Regex.Replace(__instance.tmp_addConditionDesc.text, @"<line-height=.*?>", "");
            __instance.tmp_addConditionDesc.fontSize = 35;
        }
        #endregion

        #region History de
        [HarmonyPatch(typeof(PersonalityStoryPersonalityStorySlot), nameof(PersonalityStoryPersonalityStorySlot.SetData))]
        [HarmonyPostfix]
        private static void DescriptionChange(PersonalityStoryPersonalityStorySlot __instance)
        {
            __instance._storyTitleText.GetComponentInChildren<TextMeshProLanguageSetter>(true).enabled = false;
            __instance._storyTitleText.text = __instance._storyTitleText.text.Replace(",H", ", H");
            string[] parts = __instance._storyTitleText.text.Split(',');
            string faction = parts[0];
            string sinner = parts[1];
            string history = parts[2];
            __instance._storyTitleText.text = $"{faction} : {history}{sinner}";
        }
        #endregion
    }
}