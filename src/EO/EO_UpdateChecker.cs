using SimpleJSON;
using BepInEx.Configuration;
using Il2CppSystem.Threading;
using System;
using System.IO;
using System.Net.Http;
using System.Threading.Tasks;
using UnityEngine;
using UnityEngine.Networking;

namespace LimbusCompanyFR
{
    public static class EO_UpdateChecker
    {
        public static ConfigEntry<bool> AutoUpdate = LCB_EOMod.EO_Settings.Bind("EO Settings", "AutoUpdate", false, "");
        public static void StartAutoUpdate()
        {
            if (AutoUpdate.Value)
            {
                LCB_EOMod.LogWarning("Check Mod Update");
                Action ModUpdate = CheckModUpdate;
                new Thread(ModUpdate).Start();
            }
        }
        static void CheckModUpdate()
        {
            UnityWebRequest www = UnityWebRequest.Get("");
            www.timeout = 4;
            www.SendWebRequest();
            while (!www.isDone)
                Thread.Sleep(100);
            if (www.result != UnityWebRequest.Result.Success)
                LCB_EOMod.LogWarning("Can't access GitHub!!!" + www.error);
            else
            {
                JSONArray releases = JSONNode.Parse(www.downloadHandler.text).AsArray;
                string latestReleaseTag = releases[0]["tag_name"].Value;
                string latest2ReleaseTag = releases.m_List.Count > 1 ? releases[1]["tag_name"].Value : string.Empty;
                if (Version.Parse(LCB_EOMod.VERSION) < Version.Parse(latestReleaseTag.Remove(0, 1)))
                {
                    string updatelog = (latest2ReleaseTag == "v" + LCB_EOMod.VERSION ? "" : "") + latestReleaseTag;
                    Updatelog += updatelog + ".7z ";
                    string download = "" + latestReleaseTag + "/" + updatelog + ".7z";
                    var dirs = download.Split('/');
                    string filename = LCB_EOMod.GamePath + "/" + dirs[^1];
                    if (!File.Exists(filename))
                        DownloadFileAsync(download, filename).GetAwaiter().GetResult();
                    UpdateCall = UpdateDel;
                }
                LCB_EOMod.LogWarning("Check French Font Asset Update");
                Action FontAssetUpdate = CheckFrenchFontAssetUpdate;
                new Thread(FontAssetUpdate).Start();
            }
        }
        static void CheckFrenchFontAssetUpdate()
        {
            UnityWebRequest www = UnityWebRequest.Get("");
            string FilePath = LCB_EOMod.ModPath + "/tmpfrenchfonts";
            var LastWriteTime = File.Exists(FilePath) ? int.Parse(TimeZoneInfo.ConvertTime(new FileInfo(FilePath).LastWriteTime, TimeZoneInfo.FindSystemTimeZoneById("Moscow Standard Time")).ToString("ddMMyy")) : 0;
            www.SendWebRequest();
            while (!www.isDone)
                Thread.Sleep(100);
            var latest = JSONNode.Parse(www.downloadHandler.text).AsObject;
            int latestReleaseTag = int.Parse(latest["tag_name"].Value);
            if (LastWriteTime < latestReleaseTag)
            {
                string updatelog = "tmpfrenchfonts_" + latestReleaseTag;

                Updatelog += updatelog + ".7z ";
                string download = "" + latestReleaseTag + "/" + updatelog + ".7z";
                var dirs = download.Split('/');
                string filename = LCB_EOMod.GamePath + "/" + dirs[^1];
                if (!File.Exists(filename))
                    DownloadFileAsync(download, filename).GetAwaiter().GetResult();
                UpdateCall = UpdateDel;
            }
        }
        static void UpdateDel()
        {
            LCB_EOMod.OpenGamePath();
            Application.Quit();
        }
        static async Task DownloadFileAsync(string url, string filePath)
        {
            LCB_EOMod.LogWarning("Download " + url + " To " + filePath);
            using HttpClient client = new();
            using HttpResponseMessage response = await client.GetAsync(url);
            using HttpContent content = response.Content;
            using FileStream fileStream = new(filePath, FileMode.Create);
            await content.CopyToAsync(fileStream);
        }
        public static void CheckReadmeUpdate()
        {
            UnityWebRequest www = UnityWebRequest.Get("");
            www.timeout = 1;
            www.SendWebRequest();
            string FilePath = LCB_EOMod.ModPath + "/Localize/Readme/Readme.json";
            var LastWriteTime = new FileInfo(FilePath).LastWriteTime;
            while (!www.isDone)
            {
                Thread.Sleep(100);
            }
            if (www.result == UnityWebRequest.Result.Success && LastWriteTime < DateTime.Parse(www.downloadHandler.text))
            {
                UnityWebRequest www2 = UnityWebRequest.Get("");
                www2.SendWebRequest();
                while (!www2.isDone)
                {
                    Thread.Sleep(100);
                }
                File.WriteAllText(FilePath, www2.downloadHandler.text);
                EO_ReadmeManager.InitReadmeList();
            }
        }
        public static string Updatelog;
        public static Action UpdateCall;
    }
}