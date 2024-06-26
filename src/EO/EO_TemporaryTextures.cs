﻿using BattleUI;
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
using BattleUI.BattleUnit;
using System.Collections.Generic;
using UtilityUI;

namespace LimbusCompanyFR
{
    internal class EO_TemporaryTextures
    {
        #region MainMenu
        public static void getBurnTS(List<Transform> transforms)
        {
            foreach (Transform t in transforms)
            {
                getBurnT(t);
            }
        }
        public static void getBurnT(Transform t)
        {
            Color yellowish = new Color(1.0f, 0.306f, 0, 0.502f);
            t.GetComponentInChildren<TextMeshProUGUI>().m_sharedMaterial = LCB_French_Font.GetFrenchMats(11);
            t.GetComponentInChildren<TextMeshProUGUI>().fontMaterial.EnableKeyword("GLOW_ON");
            t.GetComponentInChildren<TextMeshProUGUI>().fontMaterial.SetColor("_GlowColor", yellowish);
            t.GetComponentInChildren<TextMeshProUGUI>().fontMaterial.SetFloat("_GlowInner", (float)0.6);
            t.GetComponentInChildren<TextMeshProUGUI>().fontMaterial.SetFloat("_GlowPower", 0.8f);
            t.GetComponentInChildren<TextMeshProUGUI>().characterSpacing = 3;
        }
        [HarmonyPatch(typeof(ChapterSelectionUIPanel), nameof(ChapterSelectionUIPanel.SetDataOpen))]
        [HarmonyPostfix]
        private static void ChapterSelectionUIPanel_Init(ChapterSelectionUIPanel __instance)
        {
            List<Transform> transforms = new List<Transform>
            {
                __instance._rewardDungeonBanner.transform.Find("[Rect]Items/[Text]Entrance"),
                __instance._rewardDungeonBanner.transform.Find("[Rect]Items/[Text]Entrance/[Text]Entrance (1)"),
                __instance._mirrorDungeonBanner.transform.Find("[Rect]Items/[Text]Entrance"),
                __instance._mirrorDungeonBanner.transform.Find("[Rect]Items/[Text]Entrance/[Text]Entrance (1)"),
                __instance._railwayDungeonBanner.transform.Find("[Rect]Items/[Text]Entrance"),
                __instance._railwayDungeonBanner.transform.Find("[Rect]Items/[Text]Entrance/[Text]Entrance (1)")
            };
            getBurnTS(transforms);

            Transform railway_line = __instance._railwayDungeonBanner.transform.Find("[Rect]Items/[Image]ImageBackground/[Image]Image/[Text]RailTextDeco");
            Color railway = railway_line.GetComponentInChildren<TextMeshProUGUI>(true).color;
            Color charcoal = new Color(0.016f, 0.016f, 0.016f, 0.91f);
            railway_line.GetComponentInChildren<TextMeshProUGUI>(true).m_sharedMaterial = LCB_French_Font.GetFrenchMats(11);
            railway_line.GetComponentInChildren<TextMeshProUGUI>(true).fontMaterial.SetColor("_GlowColor", railway);
            railway_line.GetComponentInChildren<TextMeshProUGUI>(true).fontMaterial.SetColor("_UnderlayColor", charcoal);
            railway_line.GetComponentInChildren<TextMeshProUGUI>().fontMaterial.SetFloat("_GlowPower", 0.8f);
            railway_line.GetComponentInChildren<TextMeshProUGUI>().fontMaterial.SetFloat("_GlowInner", 0.4f);
            railway_line.GetComponentInChildren<TextMeshProUGUI>().fontMaterial.SetFloat("_GlowOuter", 0.4f);
            railway_line.GetComponentInChildren<TextMeshProUGUI>(true).characterSpacing = 3;
        }
        private static Material glowingBurn = new Material(LCB_French_Font.GetFrenchMats(11));
        [HarmonyPatch(typeof(RailwayDungeonUIPanel), nameof(RailwayDungeonUIPanel.SetDataOpen))]
        [HarmonyPostfix]
        private static void RailwayDungeonUIPanel_Init(RailwayDungeonUIPanel __instance)
        {
            List<Transform> transforms = new List<Transform>
            {
                __instance._upperUI.transform.Find("[Text]Title_Highlight"),
                __instance._upperUI.transform.Find("[Text]Title_Highlight/[Text]Title_Highlight")
            };
            getBurnTS(transforms);
        }
        [HarmonyPatch(typeof(GetNewCardTimelineScriptBase), nameof(GetNewCardTimelineScriptBase.Init))]
        [HarmonyPostfix]
        private static void GetNewCardTimelineScriptBase_Init(GetNewCardTimelineScriptBase __instance)
        {
            Transform subtitle = __instance._subtitle.transform.Find("TextRect/TextLayout/[LocalizeText]Subtitle");
            subtitle.GetComponentInChildren<TextMeshProUGUI>().m_sharedMaterial = LCB_French_Font.GetFrenchMats(14);
        }
        [HarmonyPatch(typeof(GachaUIPanel), nameof(GachaUIPanel.SetGachaInfoPanel))]
        [HarmonyPostfix]
        private static void Gacha_Init(GachaUIPanel __instance)
        {
            Color charcoal = new Color(0.016f, 0.016f, 0.016f, 0.91f);
            Transform yisang = __instance.transform.Find("[Rect]CurrentGachaPage/ReasonPointAnchor/ReasonPointIndicator/tmp_number_of_extract");
            yisang.GetComponentInChildren<TextMeshProUGUI>(true).m_sharedMaterial = LCB_French_Font.GetFrenchMats(16);
            yisang.GetComponentInChildren<TextMeshProUGUI>(true).fontMaterial.EnableKeyword("UNDERLAY_ON");
            yisang.GetComponentInChildren<TextMeshProUGUI>(true).fontMaterial.SetColor("_UnderlayColor", charcoal);
            yisang.GetComponentInChildren<TextMeshProUGUI>(true).fontMaterial.SetFloat("_UnderlayOffsetX", 5);
            yisang.GetComponentInChildren<TextMeshProUGUI>(true).fontMaterial.SetFloat("_UnderlayOffsetY", -5);
            yisang.GetComponentInChildren<TextMeshProUGUI>(true).fontMaterial.SetFloat("_UnderlayDilate", 3);
            yisang.GetComponentInChildren<TextMeshProUGUI>(true).fontMaterial.SetFloat("_UnderlaySoftness", 0);
            Transform exchange = __instance.transform.Find("[Rect]CurrentGachaPage/ReasonPointAnchor/ReasonPointIndicator/tmp_exchange");
            exchange.GetComponentInChildren<TextMeshProUGUI>(true).m_sharedMaterial = LCB_French_Font.GetFrenchMats(16);
            exchange.GetComponentInChildren<TextMeshProUGUI>(true).fontMaterial.EnableKeyword("UNDERLAY_ON");
            exchange.GetComponentInChildren<TextMeshProUGUI>(true).fontMaterial.SetColor("_UnderlayColor", charcoal);
            exchange.GetComponentInChildren<TextMeshProUGUI>(true).fontMaterial.SetFloat("_UnderlayOffsetX", 5);
            exchange.GetComponentInChildren<TextMeshProUGUI>(true).fontMaterial.SetFloat("_UnderlayOffsetY", -5);
            exchange.GetComponentInChildren<TextMeshProUGUI>(true).fontMaterial.SetFloat("_UnderlayDilate", 3);
            exchange.GetComponentInChildren<TextMeshProUGUI>(true).fontMaterial.SetFloat("_UnderlaySoftness", 0);
        }
        [HarmonyPatch(typeof(StageEventBanner), nameof(StageEventBanner.Init))]
        [HarmonyPostfix]
        private static void EventOpen_Init(StageEventBanner __instance)
        {
            Color yellowish = new Color(1.0f, 0.306f, 0, 0.502f);
            __instance._eventStateUI.tmp_eventState.m_sharedMaterial = LCB_French_Font.GetFrenchMats(9);
            __instance._eventStateUI.tmp_eventState.color = Color.yellow;
            __instance._eventStateUI.tmp_eventState.GetComponentInChildren<TextMeshProUGUI>().fontMaterial.EnableKeyword("GLOW_ON");
            __instance._eventStateUI.tmp_eventState.GetComponentInChildren<TextMeshProUGUI>().fontMaterial.SetColor("_GlowColor", yellowish);
            __instance._eventStateUI.tmp_eventState.GetComponentInChildren<TextMeshProUGUI>().fontMaterial.SetFloat("_GlowInner", (float)0.6);
            __instance._eventStateUI.tmp_eventState.GetComponentInChildren<TextMeshProUGUI>().fontMaterial.SetFloat("_GlowPower", 3);
        }
        #endregion

        #region Details
        [HarmonyPatch(typeof(VendingMachineUIPanel), nameof(VendingMachineUIPanel.ClickBannerEvent))]
        [HarmonyPostfix]
        private static void VendingMachineUI_Init(VendingMachineUIPanel __instance)
        {
            __instance.tmp_notice_sold_out.GetComponentInChildren<TextMeshProLanguageSetter>().enabled = false;
            Color yellowish = new Color(1.0f, 0.306f, 0, 0.502f);
            //ActiveRect/VendingMachineUIPanel/
            Transform sold_out = __instance.transform.Find("GoodsStoreAreaMaster/GoodsStorePanelGroup/BackPanel/Main/SoldOut/[LocalizeText]WaitRestock");
            if (sold_out != null)
            {
                sold_out.GetComponentInChildren<TextMeshProUGUI>(true).m_sharedMaterial = LCB_French_Font.GetFrenchMats(11);
                sold_out.GetComponentInChildren<TextMeshProUGUI>(true).fontSharedMaterial = LCB_French_Font.GetFrenchMats(11);
                sold_out.GetComponentInChildren<TextMeshProUGUI>(true).fontMaterial.SetColor("_GlowColor", yellowish);
                sold_out.GetComponentInChildren<TextMeshProUGUI>(true).fontMaterial.SetFloat("_GlowInner", (float)0.6);
                sold_out.GetComponentInChildren<TextMeshProUGUI>(true).fontMaterial.SetFloat("_GlowPower", 3);
                __instance.tmp_notice_sold_out.m_currentMaterial = LCB_French_Font.GetFrenchMats(11);
                __instance.tmp_notice_sold_out.m_sharedMaterial = LCB_French_Font.GetFrenchMats(11);
                __instance.tmp_notice_sold_out.fontSharedMaterial = LCB_French_Font.GetFrenchMats(11);
                __instance.tmp_notice_sold_out.fontMaterial.EnableKeyword("GLOW_ON");
                __instance.tmp_notice_sold_out.fontMaterial.SetColor("_GlowColor", yellowish);
                __instance.tmp_notice_sold_out.fontMaterial.SetFloat("_GlowInner", (float)0.1);
                __instance.tmp_notice_sold_out.fontMaterial.SetFloat("_GlowPower", 1);
                __instance.tmp_notice_sold_out.characterSpacing = 2;

            }
        }
        [HarmonyPatch(typeof(GacksungLevelUpCompletionPopup), nameof(GacksungLevelUpCompletionPopup.UpdateAcquiredContentsLayout))]
        [HarmonyPostfix]
        private static void GacksungLevelUpCompletionPopup_Init(GacksungLevelUpCompletionPopup __instance)
        {
            Color yellowish = new Color(1.0f, 0.306f, 0, 0.502f);
            __instance.tmp_contentTitle.fontSharedMaterial = LCB_French_Font.GetFrenchMats(11);
            __instance.tmp_contentTitle.m_sharedMaterial = LCB_French_Font.GetFrenchMats(11);
            __instance.tmp_contentTitle.GetComponentInChildren<TextMeshProUGUI>().fontMaterial.EnableKeyword("GLOW_ON");
            __instance.tmp_contentTitle.GetComponentInChildren<TextMeshProUGUI>().fontMaterial.SetColor("_GlowColor", yellowish);
            __instance.tmp_contentTitle.GetComponentInChildren<TextMeshProUGUI>().fontMaterial.SetFloat("_GlowInner", (float)0.1);
            __instance.tmp_contentTitle.GetComponentInChildren<TextMeshProUGUI>().fontMaterial.SetFloat("_GlowPower", 1);
        }
        #endregion

        #region Dialogues
        Color yisang = new Color(0.831f, 0.882f, 0.909f, 1.0f);
        Color faust = new Color(1.0f, 0.694f, 0.705f, 1.0f);
        Color donquixote = new Color(1.0f, 0.937f, 0.137f, 1.0f);
        Color ryoshu = new Color(0.811f, 0, 0, 1.0f);
        Color meursault = new Color(0.352f, 0411f, 0.701f, 1.0f);
        Color honglu = new Color(0.356f, 1.0f, 0.870f, 1.0f);
        Color heathcliff = new Color(0.549f, 0.388f, 0.760f, 1.0f);
        Color ishmael = new Color(1.0f, 0.584f, 0, 1.0f);
        Color rodya = new Color(0.572f, 0.219f, 0.219f, 1.0f);
        Color sinclair = new Color(0.545f, 0.611f, 0.082f, 1.0f);
        Color outis = new Color(0.415f, 0.6f, 0.454f, 1.0f);
        Color gregor = new Color(0.631f, 0.349f, 0.117f, 1.0f);

        Color wrath = new Color(1.0f, 0.294f, 0.2f, 1.0f);
        Color lust = new Color(1.0f, 0.396f, 0.101f, 1.0f);
        Color sloth = new Color(1.0f, 0.729f, 0.341f, 1.0f);
        Color gluttony = new Color(0.796f, 0.913f, 0, 1.0f);
        Color gloom = new Color(0.247f, 0.870f, 1.0f, 1.0f);
        Color pride = new Color(0, 0.388f, 0.737f, 1.0f);
        Color envy = new Color(0.760f, 0.266f, 1.0f, 1.0f);



        [HarmonyPatch(typeof(MainLobbyUIPanel), nameof(MainLobbyUIPanel.ActiveDialog))]
        [HarmonyPostfix]
        private static void Lobby_Init(MainLobbyUIPanel __instance)
        {
            __instance.tmpro_dialog.m_sharedMaterial = LCB_French_Font.GetFrenchMats(15);
            __instance.tmpro_dialog.m_currentMaterial = LCB_French_Font.GetFrenchMats(15);
            __instance.tmpro_dialog.m_sharedMaterial.SetColor("_GlowColor", __instance.tmpro_dialog.m_underlineColor);
            __instance.tmpro_dialog.m_sharedMaterial.SetFloat("_GlowPower", 0.025f);
        }
        [HarmonyPatch(typeof(TierUpEffectUIPanel), nameof(TierUpEffectUIPanel.SetupAndOpen))]
        [HarmonyPostfix]
        private static void TierUp_Init(TierUpEffectUIPanel __instance)
        {
            __instance._subtitle.tmp_punchLine.m_sharedMaterial = LCB_French_Font.GetFrenchMats(15);
            __instance._subtitle.tmp_punchLine.fontMaterial.SetColor("_GlowColor", __instance._subtitle.tmp_punchLine.m_underlineColor);
            __instance._subtitle.tmp_punchLine.m_sharedMaterial.SetFloat("_GlowPower", 0.025f);
        }
        [HarmonyPatch(typeof(PersonalityStoryPersonalityUI), nameof(PersonalityStoryPersonalityUI.OpenPersonalityVoiceTab))]
        [HarmonyPostfix]
        private static void PersonalityStoryPersonalityUI_Init(PersonalityStoryPersonalityUI __instance)
        {
            __instance._voiceText.m_sharedMaterial = LCB_French_Font.GetFrenchMats(15);
            __instance._voiceText.m_sharedMaterial.EnableKeyword("UNDELAY_ON");
            __instance._voiceText.m_sharedMaterial.SetColor("_GlowColor", __instance._voiceText.m_underlineColor);
            __instance._voiceText.m_sharedMaterial.SetFloat("_GlowPower", 0.025f);
            __instance._voiceText.GetComponentInChildren<TextMeshProLanguageSetter>().enabled = false;
        }
        [HarmonyPatch(typeof(BattleDialogUI), nameof(BattleDialogUI.Init))]
        [HarmonyPostfix]
        private static void EGO_Init(BattleDialogUI __instance)
        {
            __instance.tmp_dialog.m_sharedMaterial = LCB_French_Font.GetFrenchMats(15);
        }
        [HarmonyPatch(typeof(BattleResultUIPanel), nameof(BattleResultUIPanel.SetStatusUI))]
        [HarmonyPostfix]
        private static void BattleResult_Init(BattleResultUIPanel __instance)
        {
            __instance.tmp_dialog.m_sharedMaterial = LCB_French_Font.GetFrenchMats(15);
            __instance.tmp_dialog.m_sharedMaterial.SetColor("_GlowColor", __instance.tmp_dialog.m_underlineColor);
            __instance.tmp_dialog.m_sharedMaterial.SetFloat("_GlowPower", 0.025f);

            Color yellowish = new Color(1.0f, 0.306f, 0, 0.502f);
            Color reddish = new Color(0.686f, 0.003f, 0.003f, 1.0f);
            __instance.tmp_result.m_sharedMaterial = LCB_French_Font.GetFrenchMats(11);
            __instance.tmp_result.fontMaterial.EnableKeyword("GLOW_ON");
            __instance.tmp_result.fontMaterial.SetFloat("_GlowInner", 0.4f);
            __instance.tmp_result.fontMaterial.SetFloat("_GlowOuter", 0.3f);
            __instance.tmp_result.fontMaterial.SetFloat("_GlowPower", 3);
            __instance.tmp_result.characterSpacing = 2;
            if (__instance.tmp_result.text.Contains("Победа"))
                __instance.tmp_result.fontMaterial.SetColor("_GlowColor", yellowish);
            else
                __instance.tmp_result.fontMaterial.SetColor("_GlowColor", reddish);
        }
        [HarmonyPatch(typeof(GachaResultUI), nameof(GachaResultUI.SetData))]
        [HarmonyPostfix]
        private static void GachaDialogue_Init(GachaResultUI __instance)
        {
            __instance._getNewCardTimelineManager._currentTimeline._subtitle.tmp_punchLine.m_sharedMaterial = LCB_French_Font.GetFrenchMats(14);
            __instance._getNewCardTimelineManager._currentTimeline._punchline.tmp_punchLine.m_sharedMaterial = LCB_French_Font.GetFrenchMats(15);
            __instance._getNewCardTimelineManager._currentTimeline._punchline.tmp_punchLine.fontMaterial.SetFloat("_GlowPower", 0.6f);
            __instance._getNewCardTimelineManager._currentTimeline._punchline.tmp_punchLine.fontMaterial.SetFloat("_UnderlayDilate", 0.95f);
        }
        [HarmonyPatch(typeof(GachaResultUI), nameof(GachaResultUI.Initialize))]
        [HarmonyPostfix]
        private static void GachaPunchline_Init(GachaResultUI __instance)
        {
            __instance._getNewCardTimelineManager._currentTimeline._punchline.tmp_punchLine.m_sharedMaterial = LCB_French_Font.GetFrenchMats(15);
            __instance._getNewCardTimelineManager._currentTimeline._punchline.tmp_punchLine.fontMaterial.SetFloat("_GlowPower", 0.6f);
            __instance._getNewCardTimelineManager._currentTimeline._punchline.tmp_punchLine.fontMaterial.SetFloat("_UnderlayDilate", 0.95f);
        }
        #endregion

        #region Experimental properties
        [HarmonyPatch(typeof(TextMeshProMaterialSetter), nameof(TextMeshProMaterialSetter.WriteMaterialProperty))]
        [HarmonyPrefix]
        public static bool WriteMaterialProperty(TextMeshProMaterialSetter __instance)
        {
            if (!__instance._text.font.name.StartsWith("Pretendard-Regular") && !__instance._text.font.name.StartsWith("Mikodacs") || !LCB_French_Font.GetFrenchFonts(__instance._text.font.name, out _) && !LCB_French_Font.IsFrenchFont(__instance._text.font))
                return true;
            Color underlay = __instance._text.fontMaterial.GetColor("_UnderlayColor");

            if (__instance._text.font.name.StartsWith("Pretendard-Regular"))
                __instance._text.m_sharedMaterial = LCB_French_Font.GetFrenchMats(15);

            Color underlayColor = __instance.underlayColor;

            if (__instance._text.font.name.StartsWith("Pretendard-Regular"))
            {
                if (__instance.underlayOn && __instance._fontMaterialInstance.HasProperty(ShaderUtilities.ID_UnderlayColor))
                {
                    underlayColor = __instance.underlayHdrColorOn ? __instance.underlayHdrColor : underlayColor;
                    if (underlayColor.r > 0f || underlayColor.g > 0f || underlayColor.b > 0f)
                        __instance._text.color = underlayColor;
                }

                Color charcoal = new Color(0.016f, 0.016f, 0.016f, 0.91f);
                Color textcolor = __instance._text.color;

                if (__instance.underlayHdrColorOn == false)
                {
                    __instance._text.fontMaterial.SetColor("_UnderlayColor", underlayColor);
                    __instance._text.fontMaterial.SetColor("_GlowColor", underlayColor);
                    __instance._text.fontMaterial.SetFloat("_GlowPower", 0.3f);
                    __instance._text.color = Color.white;
                    return false;
                }
                else if (__instance._text.text.EndsWith("</color>"))
                {
                    __instance._text.fontMaterial.SetColor("_UnderlayColor", underlayColor);
                    __instance._text.fontMaterial.SetColor("_GlowColor", charcoal);
                    __instance._text.color = textcolor;
                }
                else
                {
                    __instance._text.fontMaterial.SetColor("_UnderlayColor", underlayColor);
                    __instance._text.fontMaterial.SetColor("_GlowColor", charcoal);
                    __instance._text.color = charcoal;
                    return false;
                }
            }

            //if (__instance._text.fontMaterial.name.Contains("Lyrics"))
            //{
            //    __instance._fontMaterialInstance = LCB_French_Font.GetFrenchMats(10);
            //    __instance.defaultMat = LCB_French_Font.GetFrenchMats(10);
            //    __instance._text.m_sharedMaterial = LCB_French_Font.GetFrenchMats(10);
            //    __instance._text.fontMaterial.SetColor("_GlowColor", underlayColor);
            //    if (__instance._text.text.StartsWith("<color=#7A181C>"))
            //    {
            //        __instance._fontMaterialInstance = LCB_French_Font.GetFrenchMats(9);
            //        __instance.defaultMat = LCB_French_Font.GetFrenchMats(9);
            //        __instance._text.m_sharedMaterial = LCB_French_Font.GetFrenchMats(9);
            //    }
            //}
            return false;
        }

        [HarmonyPatch(typeof(BattleLyricsContoller), nameof(BattleLyricsContoller.Init))]
        [HarmonyPostfix]
        private static void BattleLyricsMat1(BattleLyricsContoller __instance)
        {
            Color textColor = new Color(1.0f, 0.636f, 0, 0.5f);
            Color charcoal = new Color(0.016f, 0.016f, 0.016f, 0.91f);
            Color crimson = new Color(0.666f, 0.001f, 0, 0.99f);
            __instance.tmp.m_fontAsset = LCB_French_Font.GetFrenchFonts(3);
            __instance.tmp.m_sharedMaterial = LCB_French_Font.GetFrenchMats(10);
            __instance.tmp.fontMaterial.EnableKeyword("GLOW_ON");
            __instance.tmp.fontMaterial.SetColor("_GlowColor", textColor);
            __instance.tmp.fontMaterial.SetFloat("_GlowInner", 1f);
            __instance.tmp.fontMaterial.SetFloat("_GlowOffset", 0.08f);
            __instance.tmp.fontMaterial.SetFloat("_GlowOuter", 0.4f);
            __instance.tmp.fontMaterial.SetFloat("_GlowPower", 0.6f);
            __instance.tmp.fontMaterial.SetColor("_UnderlayColor", textColor);
            if (__instance._curText.Contains("</color>"))
            {
                __instance.tmp.m_fontAsset = LCB_French_Font.GetFrenchFonts(3);
                __instance.tmp.m_sharedMaterial = LCB_French_Font.GetFrenchMats(9);
                __instance.tmp.color = charcoal;
                __instance.tmp.fontMaterial.EnableKeyword("GLOW_ON");
                __instance.tmp.fontMaterial.SetColor("_GlowColor", crimson);
                __instance.tmp.fontMaterial.SetFloat("_GlowInner", 0.15f);
                __instance.tmp.fontMaterial.SetFloat("_GlowOuter", 0.5f);
                __instance.tmp.fontMaterial.EnableKeyword("UNDERLAY_ON");
                __instance.tmp.fontMaterial.SetColor("_UnderlayColor", crimson);
                __instance.tmp.fontMaterial.SetFloat("_UnderlaySoftness", 0);
                __instance.tmp.fontMaterial.SetFloat("_UnderlayOffsetX", 0);
                __instance.tmp.fontMaterial.SetFloat("_UnderlayOffsetY", 0);
            }
        }
        [HarmonyPatch(typeof(BattleLyricsContoller), nameof(BattleLyricsContoller.CompleteText))]
        [HarmonyPostfix]
        private static void BattleLyricsMatC(BattleLyricsContoller __instance)
        {
            Color textColor = new Color(1.0f, 0.636f, 0, 0.5f);
            __instance.tmp.fontMaterial.EnableKeyword("GLOW_ON");
            __instance.tmp.fontMaterial.SetColor("_GlowColor", Color.white);
            __instance.tmp.fontMaterial.SetFloat("_GlowPower", 1f);
            __instance.tmp.m_fontAsset = LCB_French_Font.GetFrenchFonts(3);
            __instance.tmp.m_sharedMaterial = LCB_French_Font.GetFrenchMats(10);
            __instance._curFontInfo.fontMaterial.SetColor("_UnderlayColor", textColor);
            __instance._curFontInfo.fontMaterial.SetFloat("_UnderlayDilate", 0.06f);
            __instance._curFontInfo.fontMaterial.SetFloat("_UnderlaySoftness", 0);
            __instance._curFontInfo.fontMaterial.SetFloat("_UnderlayOffsetX", 0);
            __instance._curFontInfo.fontMaterial.SetFloat("_UnderlayOffsetY", 0);

            if (__instance._curText.Contains("</color>"))
            {
                Color charcoal = new Color(0.016f, 0.016f, 0.016f, 0.91f);
                Color crimson = new Color(0.666f, 0.001f, 0, 0.99f);
                __instance.tmp.m_fontAsset = LCB_French_Font.GetFrenchFonts(3);
                __instance.tmp.m_sharedMaterial = LCB_French_Font.GetFrenchMats(9);
                __instance.tmp.color = charcoal;
                __instance.tmp.fontMaterial.EnableKeyword("GLOW_ON");
                __instance.tmp.fontMaterial.SetColor("_GlowColor", crimson);
                __instance.tmp.fontMaterial.SetFloat("_GlowInner", 0.15f);
                __instance.tmp.fontMaterial.SetFloat("_GlowOuter", 0.5f);
                __instance.tmp.fontMaterial.SetFloat("_GlowPower", 1f);
                __instance.tmp.fontMaterial.EnableKeyword("UNDERLAY_ON");
            }
        }
        #endregion
    }
}
