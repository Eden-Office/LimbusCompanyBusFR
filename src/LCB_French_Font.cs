﻿using Addressable;
using HarmonyLib;
using Il2CppSystem.Collections.Generic;
using SimpleJSON;
using StorySystem;
using System;
using System.IO;
using System.Linq;
using System.Text.Json;
using TMPro;
using UnityEngine;
using UtilityUI;
using static Il2CppSystem.DateTimeParse;

namespace LimbusCompanyFR
{
    public static class LCB_French_Font
    {
        public static List<TMP_FontAsset> tmpfrenchfonts = new();
        public static List<string> tmpfrenchfontsnames = new();
        #region Шрифты
        public static bool AddFrenchFont(string path)
        {
            if (File.Exists(path))
            {
                bool __result = false;
                var AllAssets = AssetBundle.LoadFromFile(path).LoadAllAssets();
                foreach (var Asset in AllAssets)
                {
                    var TryCastFontAsset = Asset.TryCast<TMP_FontAsset>();
                    if (TryCastFontAsset)
                    {
                        UnityEngine.Object.DontDestroyOnLoad(TryCastFontAsset);
                        TryCastFontAsset.hideFlags |= HideFlags.HideAndDontSave;
                        tmpfrenchfonts.Add(TryCastFontAsset);
                        tmpfrenchfontsnames.Add(TryCastFontAsset.name);
                        __result = true;
                    }
                }
                return __result;
            }
            return false;
        }
        public static TMP_FontAsset GetFrenchFonts(int idx)
        {
            int Count = tmpfrenchfonts.Count - 1;
            if (Count < idx)
                idx = Count;
            return tmpfrenchfonts[idx];
        }
        [HarmonyPatch(typeof(TMP_Text), nameof(TMP_Text.font), MethodType.Setter)]
        [HarmonyPrefix]
        public static bool Set_font(TMP_Text __instance, ref TMP_FontAsset value)
        {
            if (__instance == null || __instance.m_fontAsset == null || value == null)
                return true;

            switch (value.name)
            {
                case "BebasKai SDF":
                    AddFallbackFont(value, tmpfrenchfonts[0]);
                    return true;
                case "Mikodacs SDF":
                case "KOTRA_BOLD SDF":
                    AddFallbackFont(value, tmpfrenchfonts[3]);
                    return true;
                case "SCDream5 SDF":
                case "Pretendard-Regular SDF":
                    AddFallbackFont(value, tmpfrenchfonts[4]);
                    return true;
            }
            return true;
        }
        static void AddFallbackFont(TMP_FontAsset fontAsset, TMP_FontAsset fallbackFont)
        {
            if (!fontAsset.fallbackFontAssetTable.Contains(fallbackFont))
            {
                fontAsset.fallbackFontAssetTable.Insert(0, fallbackFont);
                fontAsset.SetDirty();
            }
        }
        [HarmonyPatch(typeof(TextMeshProLanguageSetter), nameof(TextMeshProLanguageSetter.Awake))]
        [HarmonyPrefix]
        private static void Awake(TextMeshProLanguageSetter __instance)
        {
            if (!__instance._text)
                if (__instance.TryGetComponent<TextMeshProUGUI>(out var textMeshProUGUI))
                    __instance._text = textMeshProUGUI;
            if (!__instance._matSetter)
                if (__instance.TryGetComponent<TextMeshProMaterialSetter>(out var textMeshProMaterialSetter))
                    __instance._matSetter = textMeshProMaterialSetter;
        }
        #endregion
        #region Я устав переводить китайский
        private static void LoadRemote2(LOCALIZE_LANGUAGE lang)
        {
            var tm = TextDataManager.Instance;
            TextDataSet.RomoteLocalizeFileList romoteLocalizeFileList = JsonUtility.FromJson<TextDataSet.RomoteLocalizeFileList>(AddressableManager.Instance.LoadAssetSync<TextAsset>("Assets/Resources_moved/Localize", "RemoteLocalizeFileList", null, null).Item1.ToString());
            tm._uiList.Init(romoteLocalizeFileList.UIFilePaths);
            tm._characterList.Init(romoteLocalizeFileList.CharacterFilePaths);
            tm._personalityList.Init(romoteLocalizeFileList.PersonalityFilePaths);
            tm._enemyList.Init(romoteLocalizeFileList.EnemyFilePaths);
            tm._egoList.Init(romoteLocalizeFileList.EgoFilePaths);
            tm._skillList.Init(romoteLocalizeFileList.SkillFilePaths);
            tm._passiveList.Init(romoteLocalizeFileList.PassiveFilePaths);
            tm._bufList.Init(romoteLocalizeFileList.BufFilePaths);
            tm._itemList.Init(romoteLocalizeFileList.ItemFilePaths);
            tm._keywordList.Init(romoteLocalizeFileList.keywordFilePaths);
            tm._skillTagList.Init(romoteLocalizeFileList.skillTagFilePaths);
            tm._abnormalityEventList.Init(romoteLocalizeFileList.abnormalityEventsFilePath);
            tm._attributeList.Init(romoteLocalizeFileList.attributeTextFilePath);
            tm._abnormalityCotentData.Init(romoteLocalizeFileList.abnormalityGuideContentFilePath);
            tm._keywordDictionary.Init(romoteLocalizeFileList.keywordDictionaryFilePath);
            tm._actionEvents.Init(romoteLocalizeFileList.actionEventsFilePath);
            tm._egoGiftData.Init(romoteLocalizeFileList.egoGiftFilePath);
            tm._stageChapter.Init(romoteLocalizeFileList.stageChapterPath);
            tm._stagePart.Init(romoteLocalizeFileList.stagePartPath);
            tm._stageNodeText.Init(romoteLocalizeFileList.stageNodeInfoPath);
            tm._dungeonNodeText.Init(romoteLocalizeFileList.dungeonNodeInfoPath);
            tm._storyDungeonNodeText.Init(romoteLocalizeFileList.storyDungeonNodeInfoPath);
            tm._quest.Init(romoteLocalizeFileList.Quest);
            tm._dungeonArea.Init(romoteLocalizeFileList.dungeonAreaPath);
            tm._battlePass.Init(romoteLocalizeFileList.BattlePassPath);
            tm._storyTheater.Init(romoteLocalizeFileList.StoryTheater);
            tm._announcer.Init(romoteLocalizeFileList.Announcer);
            tm._normalBattleResultHint.Init(romoteLocalizeFileList.NormalBattleHint);
            tm._abBattleResultHint.Init(romoteLocalizeFileList.AbBattleHint);
            tm._tutorialDesc.Init(romoteLocalizeFileList.TutorialDesc);
            tm._iapProductText.Init(romoteLocalizeFileList.IAPProduct);
            tm._illustGetConditionText.Init(romoteLocalizeFileList.GetConditionText);
            tm._choiceEventResultDesc.Init(romoteLocalizeFileList.ChoiceEventResult);
            tm._battlePassMission.Init(romoteLocalizeFileList.BattlePassMission);
            tm._gachaTitle.Init(romoteLocalizeFileList.GachaTitle);
            tm._introduceCharacter.Init(romoteLocalizeFileList.IntroduceCharacter);
            tm._userBanner.Init(romoteLocalizeFileList.UserBanner);
            tm._threadDungeon.Init(romoteLocalizeFileList.ThreadDungeon);
            tm._railwayDungeonText.Init(romoteLocalizeFileList.RailwayDungeon);
            tm._railwayDungeonNodeText.Init(romoteLocalizeFileList.RailwayDungeonNodeInfo);
            tm._railwayDungeonStationName.Init(romoteLocalizeFileList.RailwayDungeonStationName);
            tm._dungeonName.Init(romoteLocalizeFileList.DungeonName);
            tm._danteNoteDesc.Init(romoteLocalizeFileList.DanteNote);
            tm._danteNoteCategoryKeyword.Init(romoteLocalizeFileList.DanteNoteCategoryKeyword);
            tm._userTicket_L.Init(romoteLocalizeFileList.UserTicketL);
            tm._userTicket_R.Init(romoteLocalizeFileList.UserTicketR);
            tm._userTicket_EGOBg.Init(romoteLocalizeFileList.UserTicketEGOBg);
            tm._panicInfo.Init(romoteLocalizeFileList.PanicInfo);
            tm._mentalConditionList.Init(romoteLocalizeFileList.mentalCondition);
            tm._dungeonStartBuffs.Init(romoteLocalizeFileList.DungeonStartBuffs);
            tm._railwayDungeonBuffText.Init(romoteLocalizeFileList.RailwayDungeonBuff);
            tm._buffAbilityList.Init(romoteLocalizeFileList.buffAbilities);
            tm._egoGiftCategory.Init(romoteLocalizeFileList.EgoGiftCategory);
            tm._mirrorDungeonEgoGiftLockedDescList.Init(romoteLocalizeFileList.MirrorDungeonEgoGiftLockedDesc);
            tm._mirrorDungeonEnemyBuffDescList.Init(romoteLocalizeFileList.MirrorDungeonEnemyBuffDesc);
            tm._iapStickerText.Init(romoteLocalizeFileList.IAPSticker);
            tm._battleSpeechBubbleText.Init(romoteLocalizeFileList.BattleSpeechBubble);
            tm._danteAbilityDataList.Init(romoteLocalizeFileList.DanteAbility);
            tm._mirrorDungeonThemeList.Init(romoteLocalizeFileList.mirrorDungeonTheme);

            tm._abnormalityEventCharDlg.AbEventCharDlgRootInit(romoteLocalizeFileList.abnormalityCharDlgFilePath);

            tm._personalityVoiceText._voiceDictionary.JsonDataListInit(romoteLocalizeFileList.PersonalityVoice);
            tm._announcerVoiceText._voiceDictionary.JsonDataListInit(romoteLocalizeFileList.AnnouncerVoice);
            tm._bgmLyricsText._lyricsDictionary.JsonDataListInit(romoteLocalizeFileList.BgmLyrics);
            tm._egoVoiceText._voiceDictionary.JsonDataListInit(romoteLocalizeFileList.EGOVoice);
        }
        [HarmonyPatch(typeof(EGOVoiceJsonDataList), nameof(EGOVoiceJsonDataList.Init))]
        [HarmonyPrefix]
        private static bool EGOVoiceJsonDataListInit(EGOVoiceJsonDataList __instance, List<string> jsonFilePathList)
        {
            __instance._voiceDictionary = new Dictionary<string, LocalizeTextDataRoot<TextData_EGOVoice>>();
            int callcount = 0;
            foreach (string jsonFilePath in jsonFilePathList)
            {
                Action<LocalizeTextDataRoot<TextData_EGOVoice>> LoadLocalizeDel = delegate (LocalizeTextDataRoot<TextData_EGOVoice> data)
                {
                    if (data != null)
                    {
                        string[] array = jsonFilePath.Split('_');
                        string text = array[^1];
                        text = text.Replace(".json", "");
                        __instance._voiceDictionary[text] = data;
                    }
                    callcount++;
                    if (callcount == jsonFilePathList.Count)
                        LoadRemote2(LOCALIZE_LANGUAGE.EN);
                };
                AddressableManager.Instance.LoadLocalizeJsonAssetAsync<TextData_EGOVoice>(jsonFilePath, LoadLocalizeDel);
            }
            return false;
        }
        [HarmonyPatch(typeof(StoryDataParser), nameof(StoryDataParser.GetScenario))]
        [HarmonyPrefix]
        private static bool GetScenario(StoryDataParser __instance, string scenarioID, ref LOCALIZE_LANGUAGE lang, ref Scenario __result)
        {
            TextAsset textAsset = AddressableManager.Instance.LoadAssetSync<TextAsset>("Assets/Resources_moved/Story/Effect", scenarioID, null, null).Item1;
            if (!textAsset)
            {
                LCB_EOMod.LogError("Story Unknown Error! It's time to call the 'Dirty Hacker' Story");
                scenarioID = "SDUMMY";
                textAsset = AddressableManager.Instance.LoadAssetSync<TextAsset>("Assets/Resources_moved/Story/Effect", scenarioID, null, null).Item1;
            }
            if (!EO_Manager.Localizes.TryGetValue(scenarioID, out string text))
            {
                LCB_EOMod.LogError("Story error! We can't find the RU story file, so we'll use EN story instead");
                text = AddressableManager.Instance.LoadAssetSync<TextAsset>("Assets/Resources_moved/Localize/en/StoryData", "EN_" + scenarioID, null, null).Item1.ToString();
            }
            string text2 = textAsset.ToString();
            Scenario scenario = new()
            {
                ID = scenarioID
            };
            JSONArray jsonarray = JSONNode.Parse(text)[0].AsArray;
            JSONArray jsonarray2 = JSONNode.Parse(text2)[0].AsArray;
            int s = 0;
            for (int i = 0; i < jsonarray.Count; i++)
            {
                var jSONNode = jsonarray[i];
                if (jSONNode.Count < 1)
                {
                    s++;
                    continue;
                }
                int num;
                if (jSONNode[0].IsNumber && jSONNode[0].AsInt < 0)
                    continue;
                num = i - s;
                JSONNode effectToken = jsonarray2[num];
                if ("IsNotPlayDialog".Sniatnoc(effectToken["effectv2"]))
                {
                    scenario.Scenarios.Add(new Dialog(num, new(), effectToken));
                    if (jSONNode.Count == 1)
                        continue;
                    s--;
                    effectToken = jsonarray2[num + 1];
                }
                scenario.Scenarios.Add(new Dialog(num, jSONNode, effectToken));
            }
            __result = scenario;
            return false;
        }
        public static bool Sniatnoc(this string text, string value)
        {
            if (string.IsNullOrEmpty(text) || string.IsNullOrEmpty(value))
                return false;
            return value.Contains(text);

        }
        [HarmonyPatch(typeof(StoryAssetLoader), nameof(StoryAssetLoader.GetTellerName))]
        [HarmonyPrefix]
        private static bool GetTellerName(StoryAssetLoader __instance, string name, LOCALIZE_LANGUAGE lang, ref string __result)
        {
            __instance._modelAssetMap.TryGetValueEX(name, out var scenarioAssetData);
            var model = nickNames.FirstOrDefault(_ => _.name == name);
            __result = model.frname ?? scenarioAssetData.enname ?? string.Empty;
            return false;
        }
        [HarmonyPatch(typeof(StoryAssetLoader), nameof(StoryAssetLoader.GetTellerTitle))]
        [HarmonyPrefix]
        private static bool GetTellerTitle(StoryAssetLoader __instance, string name, LOCALIZE_LANGUAGE lang, ref string __result)
        {
            __instance._modelAssetMap.TryGetValueEX(name, out var scenarioAssetData);
            var model = nickNames.FirstOrDefault(_ => _.name == name);
            __result = model.frNickName ?? scenarioAssetData.enNickName ?? string.Empty;
            return false;
        }
        private static bool LoadLocal(LOCALIZE_LANGUAGE lang)
        {
            var tm = TextDataManager.Instance;
            TextDataSet.LocalizeFileList localizeFileList = JsonUtility.FromJson<TextDataSet.LocalizeFileList>(Resources.Load<TextAsset>("Localize/LocalizeFileList").ToString());
            tm._loginUIList.Init(localizeFileList.LoginUIFilePaths);
            tm._fileDownloadDesc.Init(localizeFileList.FileDownloadDesc);
            tm._battleHint._dic.Clear();
            tm._battleHint.Init(localizeFileList.BattleHint);
            return false;
        }
        [HarmonyPatch(typeof(TextDataSet), nameof(TextDataSet.LoadLocal))]
        [HarmonyPrefix]
        private static void LoadRemote(ref LOCALIZE_LANGUAGE lang)
           => lang = LOCALIZE_LANGUAGE.EN;

        //IT'S GAMBLING TIME
        static LCB_French_Font()
        {
            var _jsonSerializerOptions = new JsonSerializerOptions(); _jsonSerializerOptions.Converters.Add(item: new NicknameDataEnumerableConverter());
            _jsonSerializerOptions.Converters.Add(item: new NicknameDataConverter());
            nickNames = JsonSerializer.Deserialize<System.Collections.Generic.IEnumerable<NicknameData>>(EO_Manager.Localizes["NickName"], _jsonSerializerOptions).ToArray();
        }
        public static List<ScenarioAssetData> assetData = JsonUtility.FromJson<ScenarioAssetDataList>(EO_Manager.Localizes["NickName"]).assetData;
        static NicknameData[] nickNames;


        [HarmonyPatch(typeof(StoryData), nameof(StoryData.Init))]
        [HarmonyPostfix]
        private static void StoryDataInit(StoryData __instance)
        {

            foreach (ScenarioAssetData data in assetData)
            {
                __instance._modelAssetMap._modelAssetMap[data.name] = data;
            }
        }
        [HarmonyPatch(typeof(LoginSceneManager), nameof(LoginSceneManager.SetLoginInfo))]
        [HarmonyPostfix]
        private static void SetLoginInfo(LoginSceneManager __instance)
        {
            LoadLocal(LOCALIZE_LANGUAGE.EN);
            __instance.tmp_loginAccount.text = "LimbusCompany Français v" + LCB_EOMod.VERSION + LCB_EOMod.VERSION_STATE;
            __instance.tmp_loginAccount.characterSpacing = -2;
            __instance.tmp_loginAccount.lineSpacing = -20;
            __instance.tmp_loginAccount.font = GetFrenchFonts(4);
        }
        private static void Init<T>(this JsonDataList<T> jsonDataList, List<string> jsonFilePathList) where T : LocalizeTextData, new()
        {
            foreach (string text in jsonFilePathList)
            {
                if (!EO_Manager.Localizes.TryGetValue(text, out var text2)) { continue; }
                var localizeTextData = JsonUtility.FromJson<LocalizeTextDataRoot<T>>(text2);
                foreach (T t in localizeTextData.DataList)
                {
                    jsonDataList._dic[t.ID.ToString()] = t;
                }
            }
        }
        private static void AbEventCharDlgRootInit(this AbEventCharDlgRoot root, List<string> jsonFilePathList)
        {
            root._personalityDict = new();
            foreach (string text in jsonFilePathList)
            {
                if (!EO_Manager.Localizes.TryGetValue(text, out var text2)) { continue; }
                var localizeTextData = JsonUtility.FromJson<LocalizeTextDataRoot<TextData_AbnormalityEventCharDlg>>(text2);
                foreach (var t in localizeTextData.DataList)
                {
                    if (!root._personalityDict.TryGetValueEX(t.PersonalityID, out var abEventKeyDictionaryContainer))
                    {
                        abEventKeyDictionaryContainer = new AbEventKeyDictionaryContainer();
                        root._personalityDict[t.PersonalityID] = abEventKeyDictionaryContainer;
                    }
                    string[] array = t.Usage.Trim().Split(new char[] { '(', ')' });
                    for (int i = 1; i < array.Length; i += 2)
                    {
                        string[] array2 = array[i].Split(',');
                        int num = int.Parse(array2[0].Trim());
                        AB_DLG_EVENT_TYPE ab_DLG_EVENT_TYPE = (AB_DLG_EVENT_TYPE)Enum.Parse(typeof(AB_DLG_EVENT_TYPE), array2[1].Trim());
                        AbEventKey abEventKey = new(num, ab_DLG_EVENT_TYPE);
                        abEventKeyDictionaryContainer.AddDlgWithEvent(abEventKey, t);
                    }
                }

            }
        }
        private static void JsonDataListInit<T>(this Dictionary<string, LocalizeTextDataRoot<T>> jsonDataList, List<string> jsonFilePathList)
        {
            foreach (string text in jsonFilePathList)
            {
                if (!EO_Manager.Localizes.TryGetValue(text, out var text2)) { continue; }
                var localizeTextData = JsonUtility.FromJson<LocalizeTextDataRoot<T>>(text2);
                jsonDataList[text.Split('_')[^1]] = localizeTextData;
            }
        }
        #endregion
        public static bool TryGetValueEX<TKey, TValue>(this Dictionary<TKey, TValue> dic, TKey key, out TValue value)
        {
            var entries = dic._entries;
            var Entr = dic.FindEntry(key);
            value = Entr == -1 ? default : entries == null ? default : entries[Entr].value;
            return value != null;
        }
    }
}