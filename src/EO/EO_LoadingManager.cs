using BepInEx.Configuration;
using HarmonyLib;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using UnityEngine;

namespace LimbusCompanyFR
{
    public static class EO_LoadingManager
    {
        static List<string> LoadingTexts = new();
        static string Angela;
        static readonly string Raw = "<bounce f=0.5>Chargement...</bounce>";
        public static ConfigEntry<bool> RandomLoadText = LCB_EOMod.EO_Settings.Bind("EO Settings", "RandomLoadText", true, "Utilise des messages de chargement aléatoire au lieu de ceux par défaut ( true | false )");
        static EO_LoadingManager() => InitLoadingTexts();
        public static void InitLoadingTexts()
        {
            LoadingTexts = File.ReadAllLines(LCB_EOMod.ModPath + "/Localize/Readme/LoadingTexts.md").ToList();
            for (int i = 0; i < LoadingTexts.Count; i++)
            {
                string LoadingText = LoadingTexts[i];
                LoadingTexts[i] = "<bounce f=0.5>" + LoadingText.Remove(0, 2) + "</bounce>";
            }
            Angela = LoadingTexts[0];
            LoadingTexts.RemoveAt(0);
        }
        public static T SelectOne<T>(List<T> list)
            => list.Count == 0 ? default : list[Random.Range(0, list.Count - 1)];
        [HarmonyPatch(typeof(LoadingSceneManager), nameof(LoadingSceneManager.Start))]
        [HarmonyPostfix]
        private static void LSM_Start(LoadingSceneManager __instance)
        {
            if (!RandomLoadText.Value)
                return;
            var loadingText = __instance._loadingText;
            loadingText.font = LCB_French_Font.GetFrenchFonts(0);
            loadingText.fontMaterial = LCB_French_Font.GetFrenchFonts(0).material;
            loadingText.fontSize = 56;
            int random = Random.Range(0, 100);
            if (random < 25)
                loadingText.text = Raw;
            else if (random < 50)
                loadingText.text = Angela;
            else
                loadingText.text = SelectOne(LoadingTexts);
        }
    }
}