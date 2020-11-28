using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Net.Http;
using System.Threading.Tasks;

namespace BungieNetCoreAPI.Destiny
{
    public class DestinyManifest
    {
        public string Version { get; }
        public string MobileAssetContentPath { get; }
        public List<MobileGearAssetDataBaseEntry> MobileGearAssetDataBases { get; }
        public Dictionary<string, string> MobileWorldContentPaths { get; }
        public Dictionary<string, string> JsonWorldContentPaths { get; }
        public Dictionary<string, Dictionary<string, string>> JsonWorldComponentContentPaths { get; }
        public string MobileClanBannerDatabasePath { get; }
        public Dictionary<string, string> MobileGearCDN { get; }

        [JsonConstructor]
        private DestinyManifest(string version, string mobileAssetContentPath, List<MobileGearAssetDataBaseEntry> mobileGearAssetDataBases, Dictionary<string, string> mobileWorldContentPaths,
            Dictionary<string, string> jsonWorldContentPaths, Dictionary<string, Dictionary<string, string>> jsonWorldComponentContentPaths, string mobileClanBannerDatabasePath,
            Dictionary<string, string> mobileGearCDN)
        {
            Version = version;
            MobileAssetContentPath = mobileAssetContentPath;
            MobileGearAssetDataBases = mobileGearAssetDataBases;
            MobileWorldContentPaths = mobileWorldContentPaths;
            JsonWorldContentPaths = jsonWorldContentPaths;
            JsonWorldComponentContentPaths = jsonWorldComponentContentPaths;
            MobileClanBannerDatabasePath = mobileClanBannerDatabasePath;
            MobileGearCDN = mobileGearCDN;
        }



        /// <summary>
        /// Downloads and saves all data from manifest paths to specified path. Warning: this operation is really long. I mean like REALLY LONG.
        /// </summary>
        /// <param name="path">Path to save data</param>
        /// <returns></returns>
        public async Task DownloadAndSaveToLocalFiles(string path)
        {
            Stopwatch stopwatch = new Stopwatch();
            stopwatch.Start();
            Uri _cdnUri = new Uri("https://www.bungie.net/");
            Console.WriteLine($"Loading data from: {_cdnUri.AbsoluteUri}");
            HttpResponseMessage message;

            // Downloading MobileAssetContent (zip SQLite)
            if (!Directory.Exists($"{path}/MobileAssetContent"))
                Directory.CreateDirectory($"{path}/MobileAssetContent");
            Console.Write($"Getting data from: {_cdnUri + MobileAssetContentPath}");
            message = await HttpClientInstance.Get(_cdnUri + MobileAssetContentPath);
            using (var stream = await message.Content.ReadAsStreamAsync())
            {
                var fileInfo = new FileInfo($"{path}/MobileAssetContent/{Path.GetFileName(MobileAssetContentPath)}");
                using (var fileStream = fileInfo.OpenWrite())
                {
                    await stream.CopyToAsync(fileStream);
                }
            }
            Console.WriteLine("...Done!");

            // Downloading MobileGearAssetDataBases (zip SQLite)
            if (!Directory.Exists($"{path}/MobileGearAssetDataBases"))
                Directory.CreateDirectory($"{path}/MobileGearAssetDataBases");
            foreach (var entry in MobileGearAssetDataBases)
            {
                if (!Directory.Exists($"{path}/MobileGearAssetDataBases/{entry.Version}"))
                    Directory.CreateDirectory($"{path}/MobileGearAssetDataBases/{entry.Version}");
                Console.Write($"Getting data from: {_cdnUri + entry.Path}");
                message = await HttpClientInstance.Get(_cdnUri + entry.Path);
                using (var stream = await message.Content.ReadAsStreamAsync())
                {
                    var fileInfo = new FileInfo($"{path}/MobileGearAssetDataBases/{entry.Version}/{Path.GetFileName(entry.Path)}");
                    using (var fileStream = fileInfo.OpenWrite())
                    {
                        await stream.CopyToAsync(fileStream);
                    }
                }
                Console.WriteLine("...Done!");
            }           

            // Downloading MobileWorldContent (zip SQLite)
            if (!Directory.Exists($"{path}/MobileWorldContent"))
                Directory.CreateDirectory($"{path}/MobileWorldContent");
            foreach (var key in MobileWorldContentPaths.Keys)
            {
                if (!Directory.Exists($"{path}/MobileWorldContent/{key}"))
                    Directory.CreateDirectory($"{path}/MobileWorldContent/{key}");
                Console.Write($"Getting data from: {_cdnUri + MobileWorldContentPaths[key]}");
                message = await HttpClientInstance.Get(_cdnUri + MobileWorldContentPaths[key]);
                using (var stream = await message.Content.ReadAsStreamAsync())
                {
                    var fileInfo = new FileInfo($"{path}/MobileWorldContent/{key}/{Path.GetFileName(MobileWorldContentPaths[key])}");
                    using (var fileStream = fileInfo.OpenWrite())
                    {
                        await stream.CopyToAsync(fileStream);
                    }
                }
                Console.WriteLine("...Done!");
            }

            // Downloading JsonWorldContent (json text file)
            if (!Directory.Exists($"{path}/JsonWorldContent"))
                Directory.CreateDirectory($"{path}/JsonWorldContent");
            foreach (var key in JsonWorldContentPaths.Keys)
            {
                if (!Directory.Exists($"{path}/JsonWorldContent/{key}"))
                    Directory.CreateDirectory($"{path}/JsonWorldContent/{key}");
                Console.Write($"Getting data from: {_cdnUri + JsonWorldContentPaths[key]}");
                message = await HttpClientInstance.Get(_cdnUri + JsonWorldContentPaths[key]);
                using (var stream = await message.Content.ReadAsStreamAsync())
                {
                    var fileInfo = new FileInfo($"{path}/JsonWorldContent/{key}/{Path.GetFileName(JsonWorldContentPaths[key])}");
                    using (var fileStream = fileInfo.OpenWrite())
                    {
                        await stream.CopyToAsync(fileStream);
                    }
                }
                Console.WriteLine("...Done!");
            }

            // Downloading JsonWorldComponentContent (json text files)
            if (!Directory.Exists($"{path}/JsonWorldComponentContent"))
                Directory.CreateDirectory($"{path}/JsonWorldComponentContent");
            foreach (var key in JsonWorldComponentContentPaths.Keys)
            {
                if (!Directory.Exists($"{path}/JsonWorldComponentContent/{key}"))
                    Directory.CreateDirectory($"{path}/JsonWorldComponentContent/{key}");
                foreach (var innerKey in JsonWorldComponentContentPaths[key].Keys)
                {
                    if (!Directory.Exists($"{path}/JsonWorldComponentContent/{key}/{innerKey}"))
                        Directory.CreateDirectory($"{path}/JsonWorldComponentContent/{key}/{innerKey}");
                    Console.Write($"Getting data from: {_cdnUri + JsonWorldComponentContentPaths[key][innerKey]}");
                    message = await HttpClientInstance.Get(_cdnUri + JsonWorldComponentContentPaths[key][innerKey]);
                    using (var stream = await message.Content.ReadAsStreamAsync())
                    {
                        var fileInfo = new FileInfo($"{path}/JsonWorldComponentContent/{key}/{innerKey}/{Path.GetFileName(JsonWorldComponentContentPaths[key][innerKey])}");
                        using (var fileStream = fileInfo.OpenWrite())
                        {
                            await stream.CopyToAsync(fileStream);
                        }
                    }
                    Console.WriteLine("...Done!");
                }
            }

            // Downloading MobileClanBannerDatabase (zip SQLite)
            if (!Directory.Exists($"{path}/MobileClanBannerDatabase"))
                Directory.CreateDirectory($"{path}/MobileClanBannerDatabase");
            Console.Write($"Getting data from: {_cdnUri + MobileClanBannerDatabasePath}");
            message = await HttpClientInstance.Get(_cdnUri + MobileClanBannerDatabasePath);
            using (var stream = await message.Content.ReadAsStreamAsync())
            {
                var fileInfo = new FileInfo($"{path}/MobileClanBannerDatabase/{Path.GetFileName(MobileClanBannerDatabasePath)}");
                using (var fileStream = fileInfo.OpenWrite())
                {
                    await stream.CopyToAsync(fileStream);
                }
            }
            Console.WriteLine("...Done!");
            stopwatch.Stop();
            Console.WriteLine($"Finished getting data! {stopwatch.ElapsedMilliseconds} ms.");
        }
    }
}
