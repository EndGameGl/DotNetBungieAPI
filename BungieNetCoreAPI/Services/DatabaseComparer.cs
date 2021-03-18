using NetBungieAPI.DBComparer;
using NetBungieAPI.Destiny;
using NetBungieAPI.Destiny.Definitions;
using NetBungieAPI.Pipes;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace NetBungieAPI.Services
{
    public class DatabaseComparer
    {
        private DestinyManifest _older;
        private DestinyManifest _newer;

        public Dictionary<DestinyLocales, Dictionary<DefinitionsEnum, Dictionary<uint, CompareResult>>> Results = new Dictionary<DestinyLocales, Dictionary<DefinitionsEnum, Dictionary<uint, CompareResult>>>();
        public void Init(DestinyManifest older, DestinyManifest newer)
        {
            _older = older;
            _newer = newer;
        }

        public void Compare(string repoPath, DestinyLocales[] locales, List<DefinitionsEnum> definitions)
        {
            definitions.Remove(DefinitionsEnum.DestinyHistoricalStatsDefinition);

            foreach (var locale in locales)
            {
                Results.Add(locale, new Dictionary<DefinitionsEnum, Dictionary<uint, CompareResult>>());
                foreach (var definition in definitions)
                {
                    Results[locale].Add(definition, new Dictionary<uint, CompareResult>());
                }
            }

            foreach (var locale in locales)
            {

                var olderMobileWorldContentPathsLocalePath = Path.GetFileName(_older.MobileWorldContentPaths[locale.LocaleToString()]);
                using var olderManifestPipe = SQLiteDataPipe.CreatePipe($"{repoPath}\\{_older.Version}\\MobileWorldContent\\{locale}\\{olderMobileWorldContentPathsLocalePath}");

                var newerMobileWorldContentPathsLocalePath = Path.GetFileName(_newer.MobileWorldContentPaths[locale.LocaleToString()]);
                using var newerManifestPipe = SQLiteDataPipe.CreatePipe($"{repoPath}\\{_newer.Version}\\MobileWorldContent\\{locale}\\{newerMobileWorldContentPathsLocalePath}");

                foreach (var definition in definitions)
                {
                    try
                    {
                        var olderReader = olderManifestPipe.GetReader($"SELECT * FROM {definition}");

                        while (olderReader.Read())
                        {
                            var byteArray = (byte[])olderReader["json"];
                            var jsonString = Encoding.UTF8.GetString(byteArray, 0, byteArray.Length);
                            CompareResult result = new CompareResult()
                            {
                                Definition = definition,
                                Hash = (uint)olderReader.GetInt64(0),
                                Locale = locale,
                                Older = jsonString
                            };
                            Results[locale][definition].Add(result.Hash, result);
                        }
                    }
                    catch { }
                    try
                    {
                        var newerReader = newerManifestPipe.GetReader($"SELECT * FROM {definition}");

                        while (newerReader.Read())
                        {
                            var byteArray = (byte[])newerReader["json"];
                            var jsonString = Encoding.UTF8.GetString(byteArray, 0, byteArray.Length);
                            var key = (uint)newerReader.GetInt64(0);
                            if (Results[locale][definition].TryGetValue(key, out var result))
                            {
                                result.Newer = jsonString;
                                result.WasUpdated = result.Older != result.Newer;
                            }
                            else
                            {
                                CompareResult newResult = new CompareResult()
                                {
                                    Definition = definition,
                                    Hash = key,
                                    Locale = locale,
                                    Newer = jsonString,
                                    IsNew = true
                                };
                                Results[locale][definition].Add(newResult.Hash, newResult);
                            }
                        }
                    }
                    catch { }
                }
            }
        }
        public List<CompareResult> GetNew(DestinyLocales locale, DefinitionsEnum definition)
        {
            return Results[locale][definition].Where(x => x.Value.IsNew).Select(x => x.Value).ToList();
        }
        public List<DefinitionHashPointer<T>> GetNewAs<T>(DestinyLocales locale, DefinitionsEnum definition) where T : IDestinyDefinition
        {
            var newItems = GetNew(locale, definition);
            List<DefinitionHashPointer<T>> items = new List<DefinitionHashPointer<T>>();
            foreach (var item in newItems)
            {
                items.Add(new DefinitionHashPointer<T>(item.Hash, definition));
            }

            return items;
        }
        public List<CompareResult> GetUpdated(DestinyLocales locale, DefinitionsEnum definition)
        {
            return Results[locale][definition].Where(x => x.Value.WasUpdated).Select(x => x.Value).ToList();
        }
        public List<DefinitionHashPointer<T>> GetUpdatedAs<T>(DestinyLocales locale, DefinitionsEnum definition) where T : IDestinyDefinition
        {
            var newItems = GetUpdated(locale, definition);
            List<DefinitionHashPointer<T>> items = new List<DefinitionHashPointer<T>>();
            foreach (var item in newItems)
            {
                items.Add(new DefinitionHashPointer<T>(item.Hash, definition));
            }

            return items;
        }
    }
}
