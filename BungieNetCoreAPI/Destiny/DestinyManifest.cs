using NetBungieAPI.Clients;
using NetBungieAPI.Logging;
using NetBungieAPI.Services;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.IO;
using System.IO.Compression;
using System.Linq;
using System.Net.Http;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace NetBungieAPI.Destiny
{
    /// <summary>
    /// DestinyManifest is the external-facing contract for just the properties needed by those calling the Destiny Platform.
    /// </summary>
    public class DestinyManifest
    {
        private DateTime _versionDate;
        public string Version { get; }
        public string MobileAssetContentPath { get; }
        public ReadOnlyCollection<MobileGearAssetDataBaseEntry> MobileGearAssetDataBases { get; }     
        public ReadOnlyDictionary<string, string> MobileWorldContentPaths { get; }
        /// <summary>
        /// This points to the generated JSON that contains all the Definitions. Each key is a locale. The value is a path to the aggregated world definitions (warning: large file!)
        /// </summary>
        public ReadOnlyDictionary<string, string> JsonWorldContentPaths { get; }
        /// <summary>
        /// This points to the generated JSON that contains all the Definitions. Each key is a locale. The value is a dictionary, where the key is a definition type by name, and the value is the path to the file for that definition. 
        /// <para />
        /// WARNING: This is unsafe and subject to change - do not depend on data in these files staying around long-term.
        /// </summary>
        public ReadOnlyDictionary<string, ReadOnlyDictionary<string, string>> JsonWorldComponentContentPaths { get; }
        public string MobileClanBannerDatabasePath { get; }
        public ReadOnlyDictionary<string, string> MobileGearCDN { get; }

        [JsonIgnore]
        public DateTime VersionDate
        {
            get
            {
                return _versionDate;
            }
            private set
            {
                _versionDate = value;
            }
        }

        [JsonConstructor]
        internal DestinyManifest(string version, string mobileAssetContentPath, MobileGearAssetDataBaseEntry[] mobileGearAssetDataBases, 
            Dictionary<string, string> mobileWorldContentPaths, Dictionary<string, string> jsonWorldContentPaths, 
            Dictionary<string, Dictionary<string, string>> jsonWorldComponentContentPaths, string mobileClanBannerDatabasePath,
            Dictionary<string, string> mobileGearCDN)
        {
            Version = version;
            MobileAssetContentPath = mobileAssetContentPath;
            MobileGearAssetDataBases = mobileGearAssetDataBases.AsReadOnlyOrEmpty();
            MobileWorldContentPaths = mobileWorldContentPaths.AsReadOnlyDictionaryOrEmpty();
            JsonWorldContentPaths = jsonWorldContentPaths.AsReadOnlyDictionaryOrEmpty();
            JsonWorldComponentContentPaths = jsonWorldComponentContentPaths
                .ToDictionary(x => x.Key, x => x.Value.AsReadOnlyDictionaryOrEmpty())
                .AsReadOnlyDictionaryOrEmpty();
            MobileClanBannerDatabasePath = mobileClanBannerDatabasePath;
            MobileGearCDN = mobileGearCDN.AsReadOnlyDictionaryOrEmpty();
            if (TryFetchDate(this, out var date))
            {
                VersionDate = date;
            }
        }

        public async Task DownloadAndSaveToLocalFiles(bool unpackSqlite)
        {
            var logger = StaticUnityContainer.GetLogger();
            string path = StaticUnityContainer.GetConfiguration().Settings.VersionsRepositoryPath;
            if (string.IsNullOrWhiteSpace(path))
                throw new Exception("Specify files path in configs.json or use DownloadAndSaveToLocalFiles(string) method");
            path = $"{path}\\{Version}";
            if (!Directory.Exists(path))
                Directory.CreateDirectory(path);

            var _httpClient = StaticUnityContainer.GetHTTPClient();
            Stopwatch stopwatch = new Stopwatch();
            stopwatch.Start();

            Uri _cdnUri = new Uri("https://www.bungie.net");
            logger.Log($"Loading data from: {_cdnUri.AbsoluteUri}", LogType.Info);

            HttpResponseMessage message;

            #region Downloading MobileAssetContent (zip SQLite)
            if (!Directory.Exists($"{path}/MobileAssetContent"))
                Directory.CreateDirectory($"{path}/MobileAssetContent");

            logger.Log($"Getting data from: {_cdnUri + MobileAssetContentPath}", LogType.Info);
            if (!File.Exists($"{path}/MobileAssetContent/{Path.GetFileName(MobileAssetContentPath)}"))
            {
                message = await _httpClient.Get(_cdnUri + MobileAssetContentPath);
                using (var stream = await message.Content.ReadAsStreamAsync())
                {
                    var fileInfo = new FileInfo($"{path}/MobileAssetContent/{Path.GetFileName(MobileAssetContentPath)}");
                    using (var fileStream = fileInfo.OpenWrite())
                    {
                        await stream.CopyToAsync(fileStream);
                    }
                }
            }
            else
                logger.Log("File already exists, skipping.", LogType.Info);
            if (unpackSqlite)
            {
                logger.Log("Unpacking zip...", LogType.Info);
                var packedFileName = $"{path}/MobileAssetContent/{Path.GetFileName(MobileAssetContentPath)}.zip";
                if (IsZIP($"{path}/MobileAssetContent/{Path.GetFileName(MobileAssetContentPath)}"))
                {
                    File.Move($"{path}/MobileAssetContent/{Path.GetFileName(MobileAssetContentPath)}", packedFileName);
                    ZipFile.ExtractToDirectory(packedFileName, $"{path}/MobileAssetContent/");
                    logger.Log("Clearing leftovers.", LogType.Info);
                    File.Delete(packedFileName);
                }
                else
                    logger.Log("File is already unpacked", LogType.Info);
            }
            #endregion

            #region Downloading MobileGearAssetDataBases (zip SQLite)
            if (!Directory.Exists($"{path}/MobileGearAssetDataBases"))
                Directory.CreateDirectory($"{path}/MobileGearAssetDataBases");
            foreach (var entry in MobileGearAssetDataBases)
            {
                if (!Directory.Exists($"{path}/MobileGearAssetDataBases/{entry.Version}"))
                    Directory.CreateDirectory($"{path}/MobileGearAssetDataBases/{entry.Version}");
                logger.Log($"Getting data from: {_cdnUri + entry.Path}", LogType.Info);
                if (!File.Exists($"{path}/MobileGearAssetDataBases/{entry.Version}/{Path.GetFileName(entry.Path)}"))
                {
                    message = await _httpClient.Get(_cdnUri + entry.Path);
                    using (var stream = await message.Content.ReadAsStreamAsync())
                    {
                        var fileInfo = new FileInfo($"{path}/MobileGearAssetDataBases/{entry.Version}/{Path.GetFileName(entry.Path)}");
                        using (var fileStream = fileInfo.OpenWrite())
                        {
                            await stream.CopyToAsync(fileStream);
                        }
                    }
                }
                else
                    logger.Log("File already exists, skipping.", LogType.Info);
                if (unpackSqlite)
                {
                    logger.Log("Unpacking zip...", LogType.Info);
                    var packedFileName = $"{path}/MobileGearAssetDataBases/{entry.Version}/{Path.GetFileName(entry.Path)}.zip";
                    if (IsZIP($"{path}/MobileGearAssetDataBases/{entry.Version}/{Path.GetFileName(entry.Path)}"))
                    {
                        File.Move($"{path}/MobileGearAssetDataBases/{entry.Version}/{Path.GetFileName(entry.Path)}", packedFileName);
                        ZipFile.ExtractToDirectory(packedFileName, $"{path}/MobileGearAssetDataBases/{entry.Version}");
                        logger.Log("Clearing leftovers.", LogType.Info);
                        File.Delete(packedFileName);
                    }
                    else
                        logger.Log("File is already unpacked", LogType.Info);
                }
            }
            #endregion

            #region Downloading MobileWorldContent (zip SQLite)
            if (!Directory.Exists($"{path}/MobileWorldContent"))
                Directory.CreateDirectory($"{path}/MobileWorldContent");
            foreach (var key in MobileWorldContentPaths.Keys)
            {
                if (!Directory.Exists($"{path}/MobileWorldContent/{key}"))
                    Directory.CreateDirectory($"{path}/MobileWorldContent/{key}");
                logger.Log($"Getting data from: {_cdnUri + MobileWorldContentPaths[key]}", LogType.Info);
                if (!File.Exists($"{path}/MobileWorldContent/{key}/{Path.GetFileName(MobileWorldContentPaths[key])}"))
                {
                    message = await _httpClient.Get(_cdnUri + MobileWorldContentPaths[key]);
                    using (var stream = await message.Content.ReadAsStreamAsync())
                    {
                        var fileInfo = new FileInfo($"{path}/MobileWorldContent/{key}/{Path.GetFileName(MobileWorldContentPaths[key])}");
                        using (var fileStream = fileInfo.OpenWrite())
                        {
                            await stream.CopyToAsync(fileStream);
                        }
                    }
                }
                else
                    logger.Log("File already exists, skipping.", LogType.Info);
                if (unpackSqlite)
                {
                    logger.Log("Unpacking zip...", LogType.Info);
                    var packedFileName = $"{path}/MobileWorldContent/{key}/{Path.GetFileName(MobileWorldContentPaths[key])}.zip";
                    if (IsZIP($"{path}/MobileWorldContent/{key}/{Path.GetFileName(MobileWorldContentPaths[key])}"))
                    {
                        File.Move($"{path}/MobileWorldContent/{key}/{Path.GetFileName(MobileWorldContentPaths[key])}", packedFileName);
                        ZipFile.ExtractToDirectory(packedFileName, $"{path}/MobileWorldContent/{key}/");
                        logger.Log("Clearing leftovers.", LogType.Info);
                        File.Delete(packedFileName);
                    }
                    else
                        logger.Log("File is already unpacked", LogType.Info);
                }
            }
            #endregion

            #region Downloading JsonWorldContent (json text file)
            if (!Directory.Exists($"{path}/JsonWorldContent"))
                Directory.CreateDirectory($"{path}/JsonWorldContent");
            foreach (var key in JsonWorldContentPaths.Keys)
            {
                if (!Directory.Exists($"{path}/JsonWorldContent/{key}"))
                    Directory.CreateDirectory($"{path}/JsonWorldContent/{key}");
                logger.Log($"Getting data from: {_cdnUri + JsonWorldContentPaths[key]}", LogType.Info);
                if (!File.Exists($"{path}/JsonWorldContent/{key}/{Path.GetFileName(JsonWorldContentPaths[key])}"))
                {
                    message = await _httpClient.Get(_cdnUri + JsonWorldContentPaths[key]);
                    using (var stream = await message.Content.ReadAsStreamAsync())
                    {
                        var fileInfo = new FileInfo($"{path}/JsonWorldContent/{key}/{Path.GetFileName(JsonWorldContentPaths[key])}");
                        using (var fileStream = fileInfo.OpenWrite())
                        {
                            await stream.CopyToAsync(fileStream);
                        }
                    }
                }
            }
            #endregion

            #region Downloading JsonWorldComponentContent (json text files)
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
                    logger.Log($"Getting data from: {_cdnUri + JsonWorldComponentContentPaths[key][innerKey]}", LogType.Info);
                    if (!File.Exists($"{path}/JsonWorldComponentContent/{key}/{innerKey}/{Path.GetFileName(JsonWorldComponentContentPaths[key][innerKey])}"))
                    {
                        message = await _httpClient.Get(_cdnUri + JsonWorldComponentContentPaths[key][innerKey]);
                        using (var stream = await message.Content.ReadAsStreamAsync())
                        {
                            var fileInfo = new FileInfo($"{path}/JsonWorldComponentContent/{key}/{innerKey}/{Path.GetFileName(JsonWorldComponentContentPaths[key][innerKey])}");
                            using (var fileStream = fileInfo.OpenWrite())
                            {
                                await stream.CopyToAsync(fileStream);
                            }
                        }
                    }
                }
            }
            #endregion

            #region Downloading MobileClanBannerDatabase (zip SQLite)
            if (!Directory.Exists($"{path}/MobileClanBannerDatabase"))
                Directory.CreateDirectory($"{path}/MobileClanBannerDatabase");
            logger.Log($"Getting data from: {_cdnUri + MobileClanBannerDatabasePath}", LogType.Info);
            if (!File.Exists($"{path}/MobileClanBannerDatabase/{Path.GetFileName(MobileClanBannerDatabasePath)}"))
            {
                message = await _httpClient.Get(_cdnUri + MobileClanBannerDatabasePath);
                using (var stream = await message.Content.ReadAsStreamAsync())
                {
                    var fileInfo = new FileInfo($"{path}/MobileClanBannerDatabase/{Path.GetFileName(MobileClanBannerDatabasePath)}");
                    using (var fileStream = fileInfo.OpenWrite())
                    {
                        await stream.CopyToAsync(fileStream);
                    }
                }
            }
            else
                logger.Log("File already exists, skipping.", LogType.Info);
            if (unpackSqlite)
            {
                logger.Log("Unpacking zip...", LogType.Info);
                var packedFileName = $"{path}/MobileClanBannerDatabase/{Path.GetFileName(MobileClanBannerDatabasePath)}.zip";
                if (IsZIP($"{path}/MobileClanBannerDatabase/{Path.GetFileName(MobileClanBannerDatabasePath)}"))
                {
                    File.Move($"{path}/MobileClanBannerDatabase/{Path.GetFileName(MobileClanBannerDatabasePath)}", packedFileName);
                    ZipFile.ExtractToDirectory(packedFileName, $"{path}/MobileClanBannerDatabase/");
                    logger.Log("Clearing leftovers.", LogType.Info);
                    File.Delete(packedFileName);
                }
                else
                    logger.Log("File is already unpacked", LogType.Info);
            }
            #endregion

            if (!File.Exists($"{path}/Manifest.json"))
            {
                var manifestJson = JsonConvert.SerializeObject(this, Formatting.Indented);
                File.WriteAllText($"{path}/Manifest.json", manifestJson);
            }

            stopwatch.Stop();
            logger.Log($"Finished getting data! {stopwatch.ElapsedMilliseconds} ms.", LogType.Info);
        }
        private bool IsZIP(string filepath)
        {
            if (File.Exists(filepath))
            {
                try
                {
                    using (var zipFile = ZipFile.OpenRead(filepath))
                    {
                        var entries = zipFile.Entries;
                        return true;
                    }
                }
                catch (InvalidDataException)
                {
                    return false;
                }
            }
            else
                return false;
        }
        public static bool TryFetchDate(DestinyManifest manifest, out DateTime date) 
        {
            date = DateTime.MinValue;
            if (string.IsNullOrWhiteSpace(manifest.Version))
                return false;
            Regex rgx = new Regex(@"\.\d{2}\.\d{2}\.\d{2}\.");
            Match match = rgx.Match(manifest.Version);
            if (match.Success)
            {
                var valuesArray = match.ToString().Split('.', StringSplitOptions.RemoveEmptyEntries);
                if (valuesArray.Length == 3)
                {
                    int year = 2000 + int.Parse(valuesArray[0]);
                    int month = int.Parse(valuesArray[1]);
                    int day = int.Parse(valuesArray[2]);
                    date = new DateTime(year, month, day);
                    return true;
                }
                else
                    return false;
            }
            else
                return false;
        }      
    }
}
