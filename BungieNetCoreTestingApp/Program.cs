using NetBungieAPI.Models.Applications;
using NetBungieAPI.Clients;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text.Json;
using System.Threading.Tasks;
using NetBungieAPI.HashReferences;
using NetBungieAPI.Models;
using NetBungieAPI.Models.Destiny;
using NetBungieAPI.Models.Destiny.Definitions.Achievements;
using NetBungieAPI.Models.Destiny.Definitions.Activities;
using NetBungieAPI.Models.Destiny.Definitions.ActivityGraphs;
using NetBungieAPI.Models.Destiny.Definitions.ActivityModes;
using NetBungieAPI.Models.Destiny.Definitions.ActivityModifiers;
using NetBungieAPI.Models.Destiny.Definitions.ActivityTypes;
using NetBungieAPI.Models.Destiny.Definitions.Artifacts;
using NetBungieAPI.Models.Destiny.Definitions.BreakerTypes;
using NetBungieAPI.Models.Destiny.Definitions.Checklists;
using NetBungieAPI.Models.Destiny.Definitions.Classes;
using NetBungieAPI.Models.Destiny.Definitions.Collectibles;
using NetBungieAPI.Models.Destiny.Definitions.DamageTypes;
using NetBungieAPI.Models.Destiny.Definitions.Destinations;
using NetBungieAPI.Models.Destiny.Definitions.EnergyTypes;
using NetBungieAPI.Models.Destiny.Definitions.EquipmentSlots;
using NetBungieAPI.Models.Destiny.Definitions.Factions;
using NetBungieAPI.Models.Destiny.Definitions.Genders;
using NetBungieAPI.Models.Destiny.Definitions.InventoryBuckets;
using NetBungieAPI.Models.Destiny.Definitions.InventoryItems;
using NetBungieAPI.Models.Destiny.Definitions.ItemCategories;
using NetBungieAPI.Models.Destiny.Definitions.ItemTierTypes;
using NetBungieAPI.Models.Destiny.Definitions.Locations;
using NetBungieAPI.Models.Destiny.Definitions.Lores;
using NetBungieAPI.Models.Destiny.Definitions.MaterialRequirementSets;
using NetBungieAPI.Models.Destiny.Definitions.MedalTiers;
using NetBungieAPI.Models.Destiny.Definitions.Metrics;
using NetBungieAPI.Models.Destiny.Definitions.Milestones;
using NetBungieAPI.Models.Destiny.Definitions.Objectives;
using NetBungieAPI.Models.Destiny.Definitions.Places;
using NetBungieAPI.Models.Destiny.Definitions.PlugSets;
using NetBungieAPI.Models.Destiny.Definitions.PowerCaps;
using NetBungieAPI.Models.Destiny.Definitions.PresentationNodes;
using NetBungieAPI.Models.Destiny.Definitions.ProgressionMappings;
using NetBungieAPI.Models.Destiny.Definitions.Progressions;
using NetBungieAPI.Models.Destiny.Definitions.Races;
using NetBungieAPI.Models.Destiny.Definitions.Records;
using NetBungieAPI.Models.Destiny.Definitions.ReportReasonCategories;
using NetBungieAPI.Models.Destiny.Definitions.SandboxPerks;
using NetBungieAPI.Models.Destiny.Definitions.SeasonPasses;
using NetBungieAPI.Models.Destiny.Definitions.Seasons;
using NetBungieAPI.Models.Destiny.Definitions.SocketCategories;
using NetBungieAPI.Models.Destiny.Definitions.SocketTypes;
using NetBungieAPI.Models.Destiny.Definitions.StatGroups;
using NetBungieAPI.Models.Destiny.Definitions.Stats;
using NetBungieAPI.Models.Destiny.Definitions.TalentGrids;
using NetBungieAPI.Models.Destiny.Definitions.TraitCategories;
using NetBungieAPI.Models.Destiny.Definitions.Traits;
using NetBungieAPI.Models.Destiny.Definitions.VendorGroups;
using NetBungieAPI.Models.Destiny.Definitions.Vendors;

namespace NetBungieAPI.TestProject
{
    class Program
    {
        private static DestinyComponentType[] ALL_COMPONENTS_ARRAY = new DestinyComponentType[]
        {
            DestinyComponentType.Profiles,
            DestinyComponentType.VendorReceipts,
            DestinyComponentType.ProfileInventories,
            DestinyComponentType.ProfileCurrencies,
            DestinyComponentType.ProfileProgression,
            DestinyComponentType.PlatformSilver,

            DestinyComponentType.Characters,
            DestinyComponentType.CharacterInventories,
            DestinyComponentType.CharacterProgressions,
            DestinyComponentType.CharacterRenderData,
            DestinyComponentType.CharacterActivities,
            DestinyComponentType.CharacterEquipment,

            DestinyComponentType.ItemInstances,
            DestinyComponentType.ItemObjectives,
            DestinyComponentType.ItemPerks,
            DestinyComponentType.ItemRenderData,
            DestinyComponentType.ItemStats,
            DestinyComponentType.ItemSockets,
            DestinyComponentType.ItemTalentGrids,
            DestinyComponentType.ItemCommonData,
            DestinyComponentType.ItemPlugStates,
            DestinyComponentType.ItemPlugObjectives,
            DestinyComponentType.ItemReusablePlugs,

            DestinyComponentType.Vendors,
            DestinyComponentType.VendorCategories,
            DestinyComponentType.VendorSales,

            DestinyComponentType.Kiosks,
            DestinyComponentType.CurrencyLookups,
            DestinyComponentType.PresentationNodes,
            DestinyComponentType.Collectibles,
            DestinyComponentType.Records,
            DestinyComponentType.Transitory,
            DestinyComponentType.Metrics,
            DestinyComponentType.StringVariables
        };

        private static IBungieClient _bungieClient;

        static async Task Main(string[] args)
        {
            Stopwatch sw = new Stopwatch();
            sw.Start();
            _bungieClient = BungieApiBuilder.GetApiClient((settings) =>
            {
                settings
                    .AddApiKey(key: args[0])
                    .AddClientIdAndSecret(id: int.Parse(args[1]), secret: args[2])
                    .SpecifyApplicationScopes(ApplicationScopes.ReadUserData | ApplicationScopes.AdminGroups |
                                              ApplicationScopes.ReadBasicUserProfile)
                    .UseDefaultProvider(@"H:\BungieNetCoreAPIRepository\Manifests")
                    .EnableLogging((mes) => Console.WriteLine(mes))
                    .PremapDefinitions()
                    .LoadAllDefinitionsOnStartup(waitEverythingToLoad: true)
                    .SetLocales(new BungieLocales[]
                    {
                        BungieLocales.EN,
                    })
                    // .ExcludeDefinitionsFromLoading(new DefinitionsEnum[]
                    // {
                    //     DefinitionsEnum.DestinyInventoryItemDefinition,
                    // })
                    .SetUpdateBehaviour(true, false);
            });
            sw.Stop();
            Console.WriteLine($"Startup in: {sw.ElapsedMilliseconds} ms");

            Console.WriteLine($"{Process.GetCurrentProcess().PrivateMemorySize64} bytes allocated for current app.");

            GenerateDefinitionHashes();
  
            //await WriteAllDataToJson();

            //Console.WriteLine($"Finished dumping json.");
            //await Task.Delay(Timeout.Infinite);
        }

        private static void RunDeepEqualityCheck<T>(List<T> collection) where T : IDeepEquatable<T>
        {
            var sw = new Stopwatch();
            sw.Start();
            var uniqueItems = 0;
            foreach (var item in collection)
            {
                var equalCount = 0;
                foreach (var itemNested in collection)
                {
                    if (item.DeepEquals(itemNested))
                    {
                        equalCount++;
                    }
                }

                if (equalCount == 1)
                    uniqueItems++;
            }

            sw.Stop();
            Console.WriteLine($"{sw.ElapsedMilliseconds} ms elapsed. Unique items: {uniqueItems}");
        }

        private static long MeasureOperation(Action action, bool writeResult = true)
        {
            Stopwatch sw = new Stopwatch();
            sw.Start();
            action.Invoke();
            sw.Stop();
            if (writeResult)
                Console.WriteLine($"{sw.ElapsedMilliseconds} ms elapsed.");
            return sw.ElapsedMilliseconds;
        }

        private static void MeasureOperationMultiple(Action action, int amount)
        {
            double totalTime = 0.0;
            for (int i = 0; i < amount; i++)
            {
                totalTime += MeasureOperation(action, false);
            }

            Console.WriteLine($"Ran op {amount} times in {totalTime} ms ({totalTime / amount} per op.)");
        }

        private static async Task PrintAllActivitiesCategorized()
        {
            Dictionary<string, Dictionary<uint, string>> data = new Dictionary<string, Dictionary<uint, string>>();
            var activityModes = _bungieClient.Repository.GetAll<DestinyActivityModeDefinition>();
            var activities = _bungieClient.Repository.GetAll<DestinyActivityDefinition>();
            foreach (var activityMode in activityModes)
            {
                if (data.TryAdd(activityMode.DisplayProperties.Name, new Dictionary<uint, string>()))
                {
                    foreach (var activity in activities)
                    {
                        foreach (var activity_activityMode in activity.ActivityModes)
                        {
                            if (activity_activityMode.TryGetDefinition(out var modeDefinition))
                            {
                                if (modeDefinition.Hash == activityMode.Hash)
                                    data[activityMode.DisplayProperties.Name]
                                        .TryAdd(activity.Hash, activity.DisplayProperties.Name);
                            }
                        }
                    }
                }
            }

            var json = JsonSerializer.Serialize(data, new JsonSerializerOptions() {WriteIndented = true});
            await File.WriteAllTextAsync("activities.json", json);
        }

        private static async Task WriteAllDataToJson()
        {
            try
            {
                if (!Directory.Exists("data"))
                    Directory.CreateDirectory("data");

                var json = JsonSerializer.Serialize(
                    _bungieClient
                        .Repository
                        .GetAll<DestinyAchievementDefinition>()
                        .ToDictionary(x => x.Hash, x => x.DisplayProperties.Name),
                    new JsonSerializerOptions() {WriteIndented = true});
                await File.WriteAllTextAsync("data/achievements.json", json);

                json = JsonSerializer.Serialize(
                    _bungieClient
                        .Repository
                        .GetAll<DestinyActivityDefinition>()
                        .ToDictionary(x => x.Hash, x => x.DisplayProperties.Name),
                    new JsonSerializerOptions() {WriteIndented = true});
                await File.WriteAllTextAsync("data/activities.json", json);

                json = JsonSerializer.Serialize(
                    _bungieClient
                        .Repository
                        .GetAll<DestinyActivityModeDefinition>()
                        .ToDictionary(x => x.Hash, x => x.DisplayProperties.Name),
                    new JsonSerializerOptions() {WriteIndented = true});
                await File.WriteAllTextAsync("data/activityModes.json", json);

                json = JsonSerializer.Serialize(
                    _bungieClient
                        .Repository
                        .GetAll<DestinyActivityModifierDefinition>()
                        .ToDictionary(x => x.Hash, x => x.DisplayProperties.Name),
                    new JsonSerializerOptions() {WriteIndented = true});
                await File.WriteAllTextAsync("data/activityModifiers.json", json);

                json = JsonSerializer.Serialize(
                    _bungieClient
                        .Repository
                        .GetAll<DestinyActivityTypeDefinition>()
                        .ToDictionary(x => x.Hash, x => x.DisplayProperties.Name),
                    new JsonSerializerOptions() {WriteIndented = true});
                await File.WriteAllTextAsync("data/activityTypes.json", json);

                json = JsonSerializer.Serialize(
                    _bungieClient
                        .Repository
                        .GetAll<DestinyArtifactDefinition>()
                        .ToDictionary(x => x.Hash, x => x.DisplayProperties.Name),
                    new JsonSerializerOptions() {WriteIndented = true});
                await File.WriteAllTextAsync("data/artifacts.json", json);

                json = JsonSerializer.Serialize(
                    _bungieClient
                        .Repository
                        .GetAll<DestinyBreakerTypeDefinition>()
                        .ToDictionary(x => x.Hash, x => x.DisplayProperties.Name),
                    new JsonSerializerOptions() {WriteIndented = true});
                await File.WriteAllTextAsync("data/breakerTypes.json", json);

                json = JsonSerializer.Serialize(
                    _bungieClient
                        .Repository
                        .GetAll<DestinyChecklistDefinition>()
                        .ToDictionary(x => x.Hash, x => x.DisplayProperties.Name),
                    new JsonSerializerOptions() {WriteIndented = true});
                await File.WriteAllTextAsync("data/checklists.json", json);

                json = JsonSerializer.Serialize(
                    _bungieClient
                        .Repository
                        .GetAll<DestinyClassDefinition>()
                        .ToDictionary(x => x.Hash, x => x.DisplayProperties.Name),
                    new JsonSerializerOptions() {WriteIndented = true});
                await File.WriteAllTextAsync("data/classes.json", json);

                json = JsonSerializer.Serialize(
                    _bungieClient
                        .Repository
                        .GetAll<DestinyCollectibleDefinition>()
                        .ToDictionary(x => x.Hash, x => x.DisplayProperties.Name),
                    new JsonSerializerOptions() {WriteIndented = true});
                await File.WriteAllTextAsync("data/collectibles.json", json);

                json = JsonSerializer.Serialize(
                    _bungieClient
                        .Repository
                        .GetAll<DestinyDamageTypeDefinition>()
                        .ToDictionary(x => x.Hash, x => x.DisplayProperties.Name),
                    new JsonSerializerOptions() {WriteIndented = true});
                await File.WriteAllTextAsync("data/damageTypes.json", json);

                json = JsonSerializer.Serialize(
                    _bungieClient
                        .Repository
                        .GetAll<DestinyDestinationDefinition>()
                        .ToDictionary(x => x.Hash, x => x.DisplayProperties.Name),
                    new JsonSerializerOptions() {WriteIndented = true});
                await File.WriteAllTextAsync("data/destinations.json", json);

                json = JsonSerializer.Serialize(
                    _bungieClient
                        .Repository
                        .GetAll<DestinyEnergyTypeDefinition>()
                        .ToDictionary(x => x.Hash, x => x.DisplayProperties.Name),
                    new JsonSerializerOptions() {WriteIndented = true});
                await File.WriteAllTextAsync("data/energyTypes.json", json);

                json = JsonSerializer.Serialize(
                    _bungieClient
                        .Repository
                        .GetAll<DestinyEquipmentSlotDefinition>()
                        .ToDictionary(x => x.Hash, x => x.DisplayProperties.Name),
                    new JsonSerializerOptions() {WriteIndented = true});
                await File.WriteAllTextAsync("data/equipmentSlots.json", json);

                json = JsonSerializer.Serialize(
                    _bungieClient
                        .Repository
                        .GetAll<DestinyFactionDefinition>()
                        .ToDictionary(x => x.Hash, x => x.DisplayProperties.Name),
                    new JsonSerializerOptions() {WriteIndented = true});
                await File.WriteAllTextAsync("data/factions.json", json);

                json = JsonSerializer.Serialize(
                    _bungieClient
                        .Repository
                        .GetAll<DestinyGenderDefinition>()
                        .ToDictionary(x => x.Hash, x => x.DisplayProperties.Name),
                    new JsonSerializerOptions() {WriteIndented = true});
                await File.WriteAllTextAsync("data/genders.json", json);

                json = JsonSerializer.Serialize(
                    _bungieClient
                        .Repository
                        .GetAll<DestinyInventoryBucketDefinition>()
                        .ToDictionary(x => x.Hash, x => x.DisplayProperties.Name),
                    new JsonSerializerOptions() {WriteIndented = true});
                await File.WriteAllTextAsync("data/inventoryBuckets.json", json);

                json = JsonSerializer.Serialize(
                    _bungieClient
                        .Repository
                        .GetAll<DestinyInventoryItemDefinition>()
                        .ToDictionary(x => x.Hash, x => x.DisplayProperties.Name),
                    new JsonSerializerOptions() {WriteIndented = true});
                await File.WriteAllTextAsync("data/inventoryItems.json", json);

                json = JsonSerializer.Serialize(
                    _bungieClient
                        .Repository
                        .GetAll<DestinyItemCategoryDefinition>()
                        .ToDictionary(x => x.Hash, x => x.DisplayProperties.Name),
                    new JsonSerializerOptions() {WriteIndented = true});
                await File.WriteAllTextAsync("data/itemCategories.json", json);

                json = JsonSerializer.Serialize(
                    _bungieClient
                        .Repository
                        .GetAll<DestinyItemTierTypeDefinition>()
                        .ToDictionary(x => x.Hash, x => x.DisplayProperties.Name),
                    new JsonSerializerOptions() {WriteIndented = true});
                await File.WriteAllTextAsync("data/itemTierTypes.json", json);

                json = JsonSerializer.Serialize(
                    _bungieClient
                        .Repository
                        .GetAll<DestinyLocationDefinition>()
                        .ToDictionary(x => x.Hash, x => x.LocationReleases.FirstOrDefault()?.DisplayProperties.Name),
                    new JsonSerializerOptions() {WriteIndented = true});
                await File.WriteAllTextAsync("data/locations.json", json);

                json = JsonSerializer.Serialize(
                    _bungieClient
                        .Repository
                        .GetAll<DestinyLoreDefinition>()
                        .ToDictionary(x => x.Hash, x => x.DisplayProperties.Name),
                    new JsonSerializerOptions() {WriteIndented = true});
                await File.WriteAllTextAsync("data/lores.json", json);

                json = JsonSerializer.Serialize(
                    _bungieClient
                        .Repository
                        .GetAll<DestinyMedalTierDefinition>()
                        .ToDictionary(x => x.Hash, x => x.TierName),
                    new JsonSerializerOptions() {WriteIndented = true});
                await File.WriteAllTextAsync("data/medalTiers.json", json);

                json = JsonSerializer.Serialize(
                    _bungieClient
                        .Repository
                        .GetAll<DestinyMetricDefinition>()
                        .ToDictionary(x => x.Hash, x => x.DisplayProperties.Name),
                    new JsonSerializerOptions() {WriteIndented = true});
                await File.WriteAllTextAsync("data/metrics.json", json);

                json = JsonSerializer.Serialize(
                    _bungieClient
                        .Repository
                        .GetAll<DestinyMilestoneDefinition>()
                        .ToDictionary(x => x.Hash, x => x.DisplayProperties.Name),
                    new JsonSerializerOptions() {WriteIndented = true});
                await File.WriteAllTextAsync("data/milestones.json", json);

                json = JsonSerializer.Serialize(
                    _bungieClient
                        .Repository
                        .GetAll<DestinyObjectiveDefinition>()
                        .ToDictionary(x => x.Hash, x => x.DisplayProperties.Name),
                    new JsonSerializerOptions() {WriteIndented = true});
                await File.WriteAllTextAsync("data/objectives.json", json);

                json = JsonSerializer.Serialize(
                    _bungieClient
                        .Repository
                        .GetAll<DestinyPlaceDefinition>()
                        .ToDictionary(x => x.Hash, x => x.DisplayProperties.Name),
                    new JsonSerializerOptions() {WriteIndented = true});
                await File.WriteAllTextAsync("data/places.json", json);

                json = JsonSerializer.Serialize(
                    _bungieClient
                        .Repository
                        .GetAll<DestinyPlugSetDefinition>()
                        .ToDictionary(x => x.Hash, x => x.DisplayProperties?.Name),
                    new JsonSerializerOptions() {WriteIndented = true});
                await File.WriteAllTextAsync("data/plugSets.json", json);

                json = JsonSerializer.Serialize(
                    _bungieClient
                        .Repository
                        .GetAll<DestinyPowerCapDefinition>()
                        .ToDictionary(x => x.Hash, x => x.PowerCap),
                    new JsonSerializerOptions() {WriteIndented = true});
                await File.WriteAllTextAsync("data/powerCaps.json", json);

                json = JsonSerializer.Serialize(
                    _bungieClient
                        .Repository
                        .GetAll<DestinyPresentationNodeDefinition>()
                        .ToDictionary(x => x.Hash, x => x.DisplayProperties.Name),
                    new JsonSerializerOptions() {WriteIndented = true});
                await File.WriteAllTextAsync("data/presentationNodes.json", json);

                json = JsonSerializer.Serialize(
                    _bungieClient
                        .Repository
                        .GetAll<DestinyProgressionMappingDefinition>()
                        .ToDictionary(x => x.Hash, x => x.DisplayProperties.Name),
                    new JsonSerializerOptions() {WriteIndented = true});
                await File.WriteAllTextAsync("data/progressionMappings.json", json);

                json = JsonSerializer.Serialize(
                    _bungieClient
                        .Repository
                        .GetAll<DestinyProgressionDefinition>()
                        .ToDictionary(x => x.Hash, x => x.DisplayProperties.Name),
                    new JsonSerializerOptions() {WriteIndented = true});
                await File.WriteAllTextAsync("data/progressions.json", json);

                json = JsonSerializer.Serialize(
                    _bungieClient
                        .Repository
                        .GetAll<DestinyRaceDefinition>()
                        .ToDictionary(x => x.Hash, x => x.DisplayProperties.Name),
                    new JsonSerializerOptions() {WriteIndented = true});
                await File.WriteAllTextAsync("data/races.json", json);

                json = JsonSerializer.Serialize(
                    _bungieClient
                        .Repository
                        .GetAll<DestinyRecordDefinition>()
                        .ToDictionary(x => x.Hash, x => x.DisplayProperties.Name),
                    new JsonSerializerOptions() {WriteIndented = true});
                await File.WriteAllTextAsync("data/records.json", json);

                json = JsonSerializer.Serialize(
                    _bungieClient
                        .Repository
                        .GetAll<DestinyReportReasonCategoryDefinition>()
                        .ToDictionary(x => x.Hash, x => x.DisplayProperties.Name),
                    new JsonSerializerOptions() {WriteIndented = true});
                await File.WriteAllTextAsync("data/reportReasons.json", json);

                json = JsonSerializer.Serialize(
                    _bungieClient
                        .Repository
                        .GetAll<DestinyReportReasonCategoryDefinition>()
                        .ToDictionary(x => x.Hash, x => x.DisplayProperties.Name),
                    new JsonSerializerOptions() {WriteIndented = true});
                await File.WriteAllTextAsync("data/reportReasons.json", json);

                json = JsonSerializer.Serialize(
                    _bungieClient
                        .Repository
                        .GetAll<DestinySandboxPerkDefinition>()
                        .ToDictionary(x => x.Hash, x => x.DisplayProperties.Name),
                    new JsonSerializerOptions() {WriteIndented = true});
                await File.WriteAllTextAsync("data/sandboxPerks.json", json);

                json = JsonSerializer.Serialize(
                    _bungieClient
                        .Repository
                        .GetAll<DestinySeasonPassDefinition>()
                        .ToDictionary(x => x.Hash, x => x.DisplayProperties.Name),
                    new JsonSerializerOptions() {WriteIndented = true});
                await File.WriteAllTextAsync("data/seasonPasses.json", json);

                json = JsonSerializer.Serialize(
                    _bungieClient
                        .Repository
                        .GetAll<DestinySeasonDefinition>()
                        .ToDictionary(x => x.Hash, x => x.DisplayProperties.Name),
                    new JsonSerializerOptions() {WriteIndented = true});
                await File.WriteAllTextAsync("data/seasons.json", json);

                json = JsonSerializer.Serialize(
                    _bungieClient
                        .Repository
                        .GetAll<DestinySocketCategoryDefinition>()
                        .ToDictionary(x => x.Hash, x => x.DisplayProperties.Name),
                    new JsonSerializerOptions() {WriteIndented = true});
                await File.WriteAllTextAsync("data/socketCategories.json", json);

                json = JsonSerializer.Serialize(
                    _bungieClient
                        .Repository
                        .GetAll<DestinySocketTypeDefinition>()
                        .ToDictionary(x => x.Hash, x => x.DisplayProperties.Name),
                    new JsonSerializerOptions() {WriteIndented = true});
                await File.WriteAllTextAsync("data/socketTypes.json", json);

                json = JsonSerializer.Serialize(
                    _bungieClient
                        .Repository
                        .GetAll<DestinyStatDefinition>()
                        .ToDictionary(x => x.Hash, x => x.DisplayProperties.Name),
                    new JsonSerializerOptions() {WriteIndented = true});
                await File.WriteAllTextAsync("data/stats.json", json);

                json = JsonSerializer.Serialize(
                    _bungieClient
                        .Repository
                        .GetAll<DestinyTraitCategoryDefinition>()
                        .ToDictionary(x => x.Hash, x => x.TraitCategoryId),
                    new JsonSerializerOptions() {WriteIndented = true});
                await File.WriteAllTextAsync("data/traitCategories.json", json);

                json = JsonSerializer.Serialize(
                    _bungieClient
                        .Repository
                        .GetAll<DestinyTraitDefinition>()
                        .ToDictionary(x => x.Hash, x => x.DisplayProperties.Name),
                    new JsonSerializerOptions() {WriteIndented = true});
                await File.WriteAllTextAsync("data/traits.json", json);

                json = JsonSerializer.Serialize(
                    _bungieClient
                        .Repository
                        .GetAll<DestinyVendorGroupDefinition>()
                        .ToDictionary(x => x.Hash, x => x.CategoryName),
                    new JsonSerializerOptions() {WriteIndented = true});
                await File.WriteAllTextAsync("data/vendorGroups.json", json);

                json = JsonSerializer.Serialize(
                    _bungieClient
                        .Repository
                        .GetAll<DestinyVendorDefinition>()
                        .ToDictionary(x => x.Hash, x => x.DisplayProperties.Name),
                    new JsonSerializerOptions() {WriteIndented = true});
                await File.WriteAllTextAsync("data/vendors.json", json);
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
        }

        private static void GenerateDefinitionHashes()
        {
            string[] forbiddenSymbols = new string[]
            {
                " ", ":", "-", "\\", "/", "(", ")", "'", ".", "[", "]", "\"", "?", ",", "", "…", "!", "%", "+", "#",
                "{", "}", " ", "—", "~", "|", ";", "–", "="
            };

            if (File.Exists("DefinitionHashes.cs"))
            {
                File.Delete("DefinitionHashes.cs");
            }

            if (!File.Exists("DefinitionHashes.cs"))
            {
                File.Create("DefinitionHashes.cs").Close();
            }

            using (TextWriter textWriter = new StreamWriter("DefinitionHashes.cs", true))
            {
                textWriter.Write("namespace NetBungieAPI.HashReferences { public static class DefinitionHashes { ");

                var definitionCacheLookup = new Dictionary<string, uint>();

                #region Activities

                textWriter.Write("public static class Activities {");
                foreach (var definition in _bungieClient.Repository.GetAll<DestinyActivityDefinition>())
                {
                    if (definition.DisplayProperties is not null)
                    {
                        ValidateAndAddValue(
                            definitionCacheLookup,
                            definition.DisplayProperties.Name,
                            definition.Hash,
                            forbiddenSymbols);
                    }
                    else
                    {
                        definitionCacheLookup.Add($"F{definition.Hash.ToString()}", definition.Hash);
                    }
                }

                foreach (var (key, value) in definitionCacheLookup)
                {
                    if (_bungieClient.Repository.TryGetDestinyDefinition<DestinyActivityDefinition>(
                        DefinitionsEnum.DestinyActivityDefinition, value, BungieLocales.EN, out var activityDefinition))
                    {
                        if (!string.IsNullOrEmpty(activityDefinition.DisplayProperties?.Description))
                        {
                            textWriter.WriteLine(
                                activityDefinition.DisplayProperties.Description.Contains("\n")
                                    ? $"/// <summary> {(string.Join("\n/// <para/>", activityDefinition.DisplayProperties.Description.Split("\n", StringSplitOptions.RemoveEmptyEntries)))} \n/// </summary>"
                                    : $"/// <summary>\n /// {activityDefinition.DisplayProperties.Description}\n/// </summary>");
                        }
                    }

                    if (definitionCacheLookup.Count(x => x.Key.Split("_")[0] == key) > 1 &&
                        !key.Contains(value.ToString()))
                    {
                        textWriter.WriteLine($"public const uint {key}_{value} = {value};");
                    }
                    else
                    {
                        textWriter.WriteLine($"public const uint {key} = {value};");
                    }
                }

                textWriter.Write(" } ");
                textWriter.Flush();
                definitionCacheLookup.Clear();

                #endregion

                #region ActivityModes

                textWriter.Write("public static class ActivityModes {");
                foreach (var definition in _bungieClient.Repository.GetAll<DestinyActivityModeDefinition>())
                {
                    if (definition.DisplayProperties is not null)
                    {
                        ValidateAndAddValue(
                            definitionCacheLookup,
                            definition.DisplayProperties.Name,
                            definition.Hash,
                            forbiddenSymbols);
                    }
                    else
                    {
                        definitionCacheLookup.Add($"F{definition.Hash.ToString()}", definition.Hash);
                    }
                }

                foreach (var (key, value) in definitionCacheLookup)
                {
                    if (_bungieClient.Repository.TryGetDestinyDefinition<DestinyActivityModeDefinition>(
                        DefinitionsEnum.DestinyActivityModeDefinition, value, BungieLocales.EN, out var definition))
                    {
                        if (!string.IsNullOrEmpty(definition.DisplayProperties?.Description))
                        {
                            textWriter.WriteLine(
                                definition.DisplayProperties.Description.Contains("\n")
                                    ? $"/// <summary> {(string.Join("\n/// <para/>", definition.DisplayProperties.Description.Split("\n", StringSplitOptions.RemoveEmptyEntries)))} \n/// </summary>"
                                    : $"/// <summary>\n /// {definition.DisplayProperties.Description}\n/// </summary>");
                        }
                    }

                    if (definitionCacheLookup.Count(x => x.Key.Split("_")[0] == key) > 1 &&
                        !key.Contains(value.ToString()))
                    {
                        textWriter.WriteLine($"public const uint {key}_{value} = {value};");
                    }
                    else
                    {
                        textWriter.WriteLine($"public const uint {key} = {value};");
                    }
                }

                textWriter.Write(" } ");
                textWriter.Flush();
                definitionCacheLookup.Clear();

                #endregion

                #region ActivityModifiers

                textWriter.Write("public static class ActivityModifiers {");
                foreach (var definition in _bungieClient.Repository.GetAll<DestinyActivityModifierDefinition>())
                {
                    if (definition.DisplayProperties is not null)
                    {
                        ValidateAndAddValue(
                            definitionCacheLookup,
                            definition.DisplayProperties.Name,
                            definition.Hash,
                            forbiddenSymbols);
                    }
                    else
                    {
                        definitionCacheLookup.Add($"F{definition.Hash.ToString()}", definition.Hash);
                    }
                }

                foreach (var (key, value) in definitionCacheLookup)
                {
                    if (_bungieClient.Repository.TryGetDestinyDefinition<DestinyActivityModifierDefinition>(
                        DefinitionsEnum.DestinyActivityModifierDefinition, value, BungieLocales.EN, out var definition))
                    {
                        if (!string.IsNullOrEmpty(definition.DisplayProperties?.Description))
                        {
                            textWriter.WriteLine(
                                definition.DisplayProperties.Description.Contains("\n")
                                    ? $"/// <summary> {(string.Join("\n/// <para/>", definition.DisplayProperties.Description.Split("\n", StringSplitOptions.RemoveEmptyEntries)))} \n/// </summary>"
                                    : $"/// <summary>\n /// {definition.DisplayProperties.Description}\n/// </summary>");
                        }
                    }

                    if (definitionCacheLookup.Count(x => x.Key.Split("_")[0] == key) > 1 &&
                        !key.Contains(value.ToString()))
                    {
                        textWriter.WriteLine($"public const uint {key}_{value} = {value};");
                    }
                    else
                    {
                        textWriter.WriteLine($"public const uint {key} = {value};");
                    }
                }

                textWriter.Write(" } ");
                textWriter.Flush();
                definitionCacheLookup.Clear();

                #endregion

                #region ActivityTypes

                textWriter.Write("public static class ActivityTypes {");
                foreach (var definition in _bungieClient.Repository.GetAll<DestinyActivityTypeDefinition>())
                {
                    if (definition.DisplayProperties is not null)
                    {
                        ValidateAndAddValue(
                            definitionCacheLookup,
                            definition.DisplayProperties.Name,
                            definition.Hash,
                            forbiddenSymbols);
                    }
                    else
                    {
                        definitionCacheLookup.Add($"F{definition.Hash.ToString()}", definition.Hash);
                    }
                }

                foreach (var (key, value) in definitionCacheLookup)
                {
                    if (_bungieClient.Repository.TryGetDestinyDefinition<DestinyActivityTypeDefinition>(
                        DefinitionsEnum.DestinyActivityTypeDefinition, value, BungieLocales.EN, out var definition))
                    {
                        if (!string.IsNullOrEmpty(definition.DisplayProperties?.Description))
                        {
                            textWriter.WriteLine(
                                definition.DisplayProperties.Description.Contains("\n")
                                    ? $"/// <summary> {(string.Join("\n/// <para/>", definition.DisplayProperties.Description.Split("\n", StringSplitOptions.RemoveEmptyEntries)))} \n/// </summary>"
                                    : $"/// <summary>\n /// {definition.DisplayProperties.Description}\n/// </summary>");
                        }
                    }

                    if (definitionCacheLookup.Count(x => x.Key.Split("_")[0] == key) > 1 &&
                        !key.Contains(value.ToString()))
                    {
                        textWriter.WriteLine($"public const uint {key}_{value} = {value};");
                    }
                    else
                    {
                        textWriter.WriteLine($"public const uint {key} = {value};");
                    }
                }

                textWriter.Write(" } ");
                textWriter.Flush();
                definitionCacheLookup.Clear();

                #endregion

                #region Artifacts

                textWriter.Write("public static class Artifacts {");
                foreach (var definition in _bungieClient.Repository.GetAll<DestinyArtifactDefinition>())
                {
                    if (definition.DisplayProperties is not null)
                    {
                        ValidateAndAddValue(
                            definitionCacheLookup,
                            definition.DisplayProperties.Name,
                            definition.Hash,
                            forbiddenSymbols);
                    }
                    else
                    {
                        definitionCacheLookup.Add($"F{definition.Hash.ToString()}", definition.Hash);
                    }
                }

                foreach (var (key, value) in definitionCacheLookup)
                {
                    if (_bungieClient.Repository.TryGetDestinyDefinition<DestinyArtifactDefinition>(
                        DefinitionsEnum.DestinyArtifactDefinition, value, BungieLocales.EN, out var definition))
                    {
                        if (!string.IsNullOrEmpty(definition.DisplayProperties?.Description))
                        {
                            textWriter.WriteLine(
                                definition.DisplayProperties.Description.Contains("\n")
                                    ? $"/// <summary> {(string.Join("\n/// <para/>", definition.DisplayProperties.Description.Split("\n", StringSplitOptions.RemoveEmptyEntries)))} \n/// </summary>"
                                    : $"/// <summary>\n /// {definition.DisplayProperties.Description}\n/// </summary>");
                        }
                    }

                    if (definitionCacheLookup.Count(x => x.Key.Split("_")[0] == key) > 1 &&
                        !key.Contains(value.ToString()))
                    {
                        textWriter.WriteLine($"public const uint {key}_{value} = {value};");
                    }
                    else
                    {
                        textWriter.WriteLine($"public const uint {key} = {value};");
                    }
                }

                textWriter.Write(" } ");
                textWriter.Flush();
                definitionCacheLookup.Clear();

                #endregion

                #region BreakerTypes

                textWriter.Write("public static class BreakerTypes {");
                foreach (var definition in _bungieClient.Repository.GetAll<DestinyBreakerTypeDefinition>())
                {
                    if (definition.DisplayProperties is not null)
                    {
                        ValidateAndAddValue(
                            definitionCacheLookup,
                            definition.DisplayProperties.Name,
                            definition.Hash,
                            forbiddenSymbols);
                    }
                    else
                    {
                        definitionCacheLookup.Add($"F{definition.Hash.ToString()}", definition.Hash);
                    }
                }

                foreach (var (key, value) in definitionCacheLookup)
                {
                    if (_bungieClient.Repository.TryGetDestinyDefinition<DestinyBreakerTypeDefinition>(
                        DefinitionsEnum.DestinyBreakerTypeDefinition, value, BungieLocales.EN, out var definition))
                    {
                        if (!string.IsNullOrEmpty(definition.DisplayProperties?.Description))
                        {
                            textWriter.WriteLine(
                                definition.DisplayProperties.Description.Contains("\n")
                                    ? $"/// <summary> {(string.Join("\n/// <para/>", definition.DisplayProperties.Description.Split("\n", StringSplitOptions.RemoveEmptyEntries)))} \n/// </summary>"
                                    : $"/// <summary>\n /// {definition.DisplayProperties.Description}\n/// </summary>");
                        }
                    }

                    if (definitionCacheLookup.Count(x => x.Key.Split("_")[0] == key) > 1 &&
                        !key.Contains(value.ToString()))
                    {
                        textWriter.WriteLine($"public const uint {key}_{value} = {value};");
                    }
                    else
                    {
                        textWriter.WriteLine($"public const uint {key} = {value};");
                    }
                }

                textWriter.Write(" } ");
                textWriter.Flush();
                definitionCacheLookup.Clear();

                #endregion

                #region Checklists

                textWriter.Write("public static class Checklists {");
                foreach (var definition in _bungieClient.Repository.GetAll<DestinyChecklistDefinition>())
                {
                    if (definition.DisplayProperties is not null)
                    {
                        ValidateAndAddValue(
                            definitionCacheLookup,
                            definition.DisplayProperties.Name,
                            definition.Hash,
                            forbiddenSymbols);
                    }
                    else
                    {
                        definitionCacheLookup.Add($"F{definition.Hash.ToString()}", definition.Hash);
                    }
                }

                foreach (var (key, value) in definitionCacheLookup)
                {
                    if (_bungieClient.Repository.TryGetDestinyDefinition<DestinyChecklistDefinition>(
                        DefinitionsEnum.DestinyChecklistDefinition, value, BungieLocales.EN, out var definition))
                    {
                        if (!string.IsNullOrEmpty(definition.DisplayProperties?.Description))
                        {
                            textWriter.WriteLine(
                                definition.DisplayProperties.Description.Contains("\n")
                                    ? $"/// <summary> {(string.Join("\n/// <para/>", definition.DisplayProperties.Description.Split("\n", StringSplitOptions.RemoveEmptyEntries)))} \n/// </summary>"
                                    : $"/// <summary>\n /// {definition.DisplayProperties.Description}\n/// </summary>");
                        }
                    }

                    if (definitionCacheLookup.Count(x => x.Key.Split("_")[0] == key) > 1 &&
                        !key.Contains(value.ToString()))
                    {
                        textWriter.WriteLine($"public const uint {key}_{value} = {value};");
                    }
                    else
                    {
                        textWriter.WriteLine($"public const uint {key} = {value};");
                    }
                }

                textWriter.Write(" } ");
                textWriter.Flush();
                definitionCacheLookup.Clear();

                #endregion

                #region Classes

                textWriter.Write("public static class Classes {");
                foreach (var definition in _bungieClient.Repository.GetAll<DestinyClassDefinition>())
                {
                    if (definition.DisplayProperties is not null)
                    {
                        ValidateAndAddValue(
                            definitionCacheLookup,
                            definition.DisplayProperties.Name,
                            definition.Hash,
                            forbiddenSymbols);
                    }
                    else
                    {
                        definitionCacheLookup.Add($"F{definition.Hash.ToString()}", definition.Hash);
                    }
                }

                foreach (var (key, value) in definitionCacheLookup)
                {
                    if (_bungieClient.Repository.TryGetDestinyDefinition<DestinyClassDefinition>(
                        DefinitionsEnum.DestinyClassDefinition, value, BungieLocales.EN, out var definition))
                    {
                        if (!string.IsNullOrEmpty(definition.DisplayProperties?.Description))
                        {
                            textWriter.WriteLine(
                                definition.DisplayProperties.Description.Contains("\n")
                                    ? $"/// <summary> {(string.Join("\n/// <para/>", definition.DisplayProperties.Description.Split("\n", StringSplitOptions.RemoveEmptyEntries)))} \n/// </summary>"
                                    : $"/// <summary>\n /// {definition.DisplayProperties.Description}\n/// </summary>");
                        }
                    }

                    if (definitionCacheLookup.Count(x => x.Key.Split("_")[0] == key) > 1 &&
                        !key.Contains(value.ToString()))
                    {
                        textWriter.WriteLine($"public const uint {key}_{value} = {value};");
                    }
                    else
                    {
                        textWriter.WriteLine($"public const uint {key} = {value};");
                    }
                }

                textWriter.Write(" } ");
                textWriter.Flush();
                definitionCacheLookup.Clear();

                #endregion

                #region Collectibles
                
                textWriter.Write("public static class Collectibles {");
                foreach (var definition in _bungieClient.Repository.GetAll<DestinyCollectibleDefinition>())
                {
                    if (definition.DisplayProperties is not null)
                    {
                        ValidateAndAddValue(
                            definitionCacheLookup,
                            definition.DisplayProperties.Name,
                            definition.Hash,
                            forbiddenSymbols);
                    }
                    else
                    {
                        definitionCacheLookup.Add($"F{definition.Hash.ToString()}", definition.Hash);
                    }
                }
                
                foreach (var (key, value) in definitionCacheLookup)
                {
                    if (_bungieClient.Repository.TryGetDestinyDefinition<DestinyCollectibleDefinition>(
                        DefinitionsEnum.DestinyCollectibleDefinition, value, BungieLocales.EN, out var definition))
                    {
                        if (!string.IsNullOrEmpty(definition.DisplayProperties?.Description))
                        {
                            textWriter.WriteLine(
                                definition.DisplayProperties.Description.Contains("\n")
                                    ? $"/// <summary> {(string.Join("\n/// <para/>", definition.DisplayProperties.Description.Split("\n", StringSplitOptions.RemoveEmptyEntries)))} \n/// </summary>"
                                    : $"/// <summary>\n /// {definition.DisplayProperties.Description}\n/// </summary>");
                        }
                    }
                
                    if (definitionCacheLookup.Count(x => x.Key.Split("_")[0] == key) > 1 && !key.Contains(value.ToString()))
                    {
                        textWriter.WriteLine($"public const uint {key}_{value} = {value};");
                    }
                    else
                    {
                        textWriter.WriteLine($"public const uint {key} = {value};");
                    }
                }
                
                textWriter.Write(" } ");
                textWriter.Flush();
                definitionCacheLookup.Clear();
                
                #endregion

                #region DamageTypes

                textWriter.Write("public static class DamageTypes {");
                foreach (var definition in _bungieClient.Repository.GetAll<DestinyDamageTypeDefinition>())
                {
                    if (definition.DisplayProperties is not null)
                    {
                        ValidateAndAddValue(
                            definitionCacheLookup,
                            definition.DisplayProperties.Name,
                            definition.Hash,
                            forbiddenSymbols);
                    }
                    else
                    {
                        definitionCacheLookup.Add($"F{definition.Hash.ToString()}", definition.Hash);
                    }
                }

                foreach (var (key, value) in definitionCacheLookup)
                {
                    if (_bungieClient.Repository.TryGetDestinyDefinition<DestinyDamageTypeDefinition>(
                        DefinitionsEnum.DestinyDamageTypeDefinition, value, BungieLocales.EN, out var definition))
                    {
                        if (!string.IsNullOrEmpty(definition.DisplayProperties?.Description))
                        {
                            textWriter.WriteLine(
                                definition.DisplayProperties.Description.Contains("\n")
                                    ? $"/// <summary> {(string.Join("\n/// <para/>", definition.DisplayProperties.Description.Split("\n", StringSplitOptions.RemoveEmptyEntries)))} \n/// </summary>"
                                    : $"/// <summary>\n /// {definition.DisplayProperties.Description}\n/// </summary>");
                        }
                    }

                    if (definitionCacheLookup.Count(x => x.Key.Split("_")[0] == key) > 1 &&
                        !key.Contains(value.ToString()))
                    {
                        textWriter.WriteLine($"public const uint {key}_{value} = {value};");
                    }
                    else
                    {
                        textWriter.WriteLine($"public const uint {key} = {value};");
                    }
                }

                textWriter.Write(" } ");
                textWriter.Flush();
                definitionCacheLookup.Clear();

                #endregion

                #region Destinations

                textWriter.Write("public static class Destinations {");
                foreach (var definition in _bungieClient.Repository.GetAll<DestinyDestinationDefinition>())
                {
                    if (definition.DisplayProperties is not null)
                    {
                        ValidateAndAddValue(
                            definitionCacheLookup,
                            definition.DisplayProperties.Name,
                            definition.Hash,
                            forbiddenSymbols);
                    }
                    else
                    {
                        definitionCacheLookup.Add($"F{definition.Hash.ToString()}", definition.Hash);
                    }
                }

                foreach (var (key, value) in definitionCacheLookup)
                {
                    if (_bungieClient.Repository.TryGetDestinyDefinition<DestinyDestinationDefinition>(
                        DefinitionsEnum.DestinyDestinationDefinition, value, BungieLocales.EN, out var definition))
                    {
                        if (!string.IsNullOrEmpty(definition.DisplayProperties?.Description))
                        {
                            textWriter.WriteLine(
                                definition.DisplayProperties.Description.Contains("\n")
                                    ? $"/// <summary> {(string.Join("\n/// <para/>", definition.DisplayProperties.Description.Split("\n", StringSplitOptions.RemoveEmptyEntries)))} \n/// </summary>"
                                    : $"/// <summary>\n /// {definition.DisplayProperties.Description}\n/// </summary>");
                        }
                    }

                    if (definitionCacheLookup.Count(x => x.Key.Split("_")[0] == key) > 1 &&
                        !key.Contains(value.ToString()))
                    {
                        textWriter.WriteLine($"public const uint {key}_{value} = {value};");
                    }
                    else
                    {
                        textWriter.WriteLine($"public const uint {key} = {value};");
                    }
                }

                textWriter.Write(" } ");
                textWriter.Flush();
                definitionCacheLookup.Clear();

                #endregion

                #region EnergyTypes

                textWriter.Write("public static class EnergyTypes {");
                foreach (var definition in _bungieClient.Repository.GetAll<DestinyEnergyTypeDefinition>())
                {
                    if (definition.DisplayProperties is not null)
                    {
                        ValidateAndAddValue(
                            definitionCacheLookup,
                            definition.DisplayProperties.Name,
                            definition.Hash,
                            forbiddenSymbols);
                    }
                    else
                    {
                        definitionCacheLookup.Add($"F{definition.Hash.ToString()}", definition.Hash);
                    }
                }

                foreach (var (key, value) in definitionCacheLookup)
                {
                    if (_bungieClient.Repository.TryGetDestinyDefinition<DestinyEnergyTypeDefinition>(
                        DefinitionsEnum.DestinyEnergyTypeDefinition, value, BungieLocales.EN, out var definition))
                    {
                        if (!string.IsNullOrEmpty(definition.DisplayProperties?.Description))
                        {
                            textWriter.WriteLine(
                                definition.DisplayProperties.Description.Contains("\n")
                                    ? $"/// <summary> {(string.Join("\n/// <para/>", definition.DisplayProperties.Description.Split("\n", StringSplitOptions.RemoveEmptyEntries)))} \n/// </summary>"
                                    : $"/// <summary>\n /// {definition.DisplayProperties.Description}\n/// </summary>");
                        }
                    }

                    if (definitionCacheLookup.Count(x => x.Key.Split("_")[0] == key) > 1 &&
                        !key.Contains(value.ToString()))
                    {
                        textWriter.WriteLine($"public const uint {key}_{value} = {value};");
                    }
                    else
                    {
                        textWriter.WriteLine($"public const uint {key} = {value};");
                    }
                }

                textWriter.Write(" } ");
                textWriter.Flush();
                definitionCacheLookup.Clear();

                #endregion

                #region EquipmentSlots

                textWriter.Write("public static class EquipmentSlots {");
                foreach (var definition in _bungieClient.Repository.GetAll<DestinyEquipmentSlotDefinition>())
                {
                    if (definition.DisplayProperties is not null)
                    {
                        ValidateAndAddValue(
                            definitionCacheLookup,
                            definition.DisplayProperties.Name,
                            definition.Hash,
                            forbiddenSymbols);
                    }
                    else
                    {
                        definitionCacheLookup.Add($"F{definition.Hash.ToString()}", definition.Hash);
                    }
                }

                foreach (var (key, value) in definitionCacheLookup)
                {
                    if (_bungieClient.Repository.TryGetDestinyDefinition<DestinyEquipmentSlotDefinition>(
                        DefinitionsEnum.DestinyEquipmentSlotDefinition, value, BungieLocales.EN, out var definition))
                    {
                        if (!string.IsNullOrEmpty(definition.DisplayProperties?.Description))
                        {
                            textWriter.WriteLine(
                                definition.DisplayProperties.Description.Contains("\n")
                                    ? $"/// <summary> {(string.Join("\n/// <para/>", definition.DisplayProperties.Description.Split("\n", StringSplitOptions.RemoveEmptyEntries)))} \n/// </summary>"
                                    : $"/// <summary>\n /// {definition.DisplayProperties.Description}\n/// </summary>");
                        }
                    }

                    if (definitionCacheLookup.Count(x => x.Key.Split("_")[0] == key) > 1 &&
                        !key.Contains(value.ToString()))
                    {
                        textWriter.WriteLine($"public const uint {key}_{value} = {value};");
                    }
                    else
                    {
                        textWriter.WriteLine($"public const uint {key} = {value};");
                    }
                }

                textWriter.Write(" } ");
                textWriter.Flush();
                definitionCacheLookup.Clear();

                #endregion

                #region Factions

                textWriter.Write("public static class Factions {");
                foreach (var definition in _bungieClient.Repository.GetAll<DestinyFactionDefinition>())
                {
                    if (definition.DisplayProperties is not null)
                    {
                        ValidateAndAddValue(
                            definitionCacheLookup,
                            definition.DisplayProperties.Name,
                            definition.Hash,
                            forbiddenSymbols);
                    }
                    else
                    {
                        definitionCacheLookup.Add($"F{definition.Hash.ToString()}", definition.Hash);
                    }
                }

                foreach (var (key, value) in definitionCacheLookup)
                {
                    if (_bungieClient.Repository.TryGetDestinyDefinition<DestinyFactionDefinition>(
                        DefinitionsEnum.DestinyFactionDefinition, value, BungieLocales.EN, out var definition))
                    {
                        if (!string.IsNullOrEmpty(definition.DisplayProperties?.Description))
                        {
                            textWriter.WriteLine(
                                definition.DisplayProperties.Description.Contains("\n")
                                    ? $"/// <summary> {(string.Join("\n/// <para/>", definition.DisplayProperties.Description.Split("\n", StringSplitOptions.RemoveEmptyEntries)))} \n/// </summary>"
                                    : $"/// <summary>\n /// {definition.DisplayProperties.Description}\n/// </summary>");
                        }
                    }

                    if (definitionCacheLookup.Count(x => x.Key.Split("_")[0] == key) > 1 &&
                        !key.Contains(value.ToString()))
                    {
                        textWriter.WriteLine($"public const uint {key}_{value} = {value};");
                    }
                    else
                    {
                        textWriter.WriteLine($"public const uint {key} = {value};");
                    }
                }

                textWriter.Write(" } ");
                textWriter.Flush();
                definitionCacheLookup.Clear();

                #endregion

                #region Genders

                textWriter.Write("public static class Genders {");
                foreach (var definition in _bungieClient.Repository.GetAll<DestinyGenderDefinition>())
                {
                    if (definition.DisplayProperties is not null)
                    {
                        ValidateAndAddValue(
                            definitionCacheLookup,
                            definition.DisplayProperties.Name,
                            definition.Hash,
                            forbiddenSymbols);
                    }
                    else
                    {
                        definitionCacheLookup.Add($"F{definition.Hash.ToString()}", definition.Hash);
                    }
                }

                foreach (var (key, value) in definitionCacheLookup)
                {
                    if (_bungieClient.Repository.TryGetDestinyDefinition<DestinyGenderDefinition>(
                        DefinitionsEnum.DestinyGenderDefinition, value, BungieLocales.EN, out var definition))
                    {
                        if (!string.IsNullOrEmpty(definition.DisplayProperties?.Description))
                        {
                            textWriter.WriteLine(
                                definition.DisplayProperties.Description.Contains("\n")
                                    ? $"/// <summary> {(string.Join("\n/// <para/>", definition.DisplayProperties.Description.Split("\n", StringSplitOptions.RemoveEmptyEntries)))} \n/// </summary>"
                                    : $"/// <summary>\n /// {definition.DisplayProperties.Description}\n/// </summary>");
                        }
                    }

                    if (definitionCacheLookup.Count(x => x.Key.Split("_")[0] == key) > 1 &&
                        !key.Contains(value.ToString()))
                    {
                        textWriter.WriteLine($"public const uint {key}_{value} = {value};");
                    }
                    else
                    {
                        textWriter.WriteLine($"public const uint {key} = {value};");
                    }
                }

                textWriter.Write(" } ");
                textWriter.Flush();
                definitionCacheLookup.Clear();

                #endregion

                #region HistoricalStats

                textWriter.Write("public static class HistoricalStats {");

                foreach (var statsDefinition in _bungieClient.Repository.GetAllHistoricalStatsDefinitions(BungieLocales
                    .EN))
                {
                    var key = char.ToUpper(statsDefinition.StatId.First()) + statsDefinition.StatId[1..];
                    if (key.Contains('_'))
                    {
                        var split = key.Split('_');
                        key = string.Empty;
                        for (var index = 0; index < split.Length; index++)
                        {
                            var entry = split[index];
                            key += char.ToUpper(entry.First()) + entry[1..];
                        }
                    }

                    if (!string.IsNullOrEmpty(statsDefinition.StatDescription))
                    {
                        textWriter.WriteLine(
                            statsDefinition.StatDescription.Contains("\n")
                                ? $"/// <summary> {(string.Join("\n/// <para/>", statsDefinition.StatDescription.Split("\n", StringSplitOptions.RemoveEmptyEntries)))} \n/// </summary>"
                                : $"/// <summary>\n /// {statsDefinition.StatDescription}\n/// </summary>");
                    }

                    textWriter.WriteLine(
                        $"public const string {key} = \"{statsDefinition.StatId}\";");
                }

                textWriter.Write(" } ");
                textWriter.Flush();
                definitionCacheLookup.Clear();

                #endregion

                #region InventoryBuckets

                textWriter.Write("public static class InventoryBuckets {");
                foreach (var definition in _bungieClient.Repository.GetAll<DestinyInventoryBucketDefinition>())
                {
                    if (definition.DisplayProperties is not null)
                    {
                        ValidateAndAddValue(
                            definitionCacheLookup,
                            definition.DisplayProperties.Name,
                            definition.Hash,
                            forbiddenSymbols);
                    }
                    else
                    {
                        definitionCacheLookup.Add($"F{definition.Hash.ToString()}", definition.Hash);
                    }
                }

                foreach (var (key, value) in definitionCacheLookup)
                {
                    if (_bungieClient.Repository.TryGetDestinyDefinition<DestinyInventoryBucketDefinition>(
                        DefinitionsEnum.DestinyInventoryBucketDefinition, value, BungieLocales.EN, out var definition))
                    {
                        if (!string.IsNullOrEmpty(definition.DisplayProperties?.Description))
                        {
                            textWriter.WriteLine(
                                definition.DisplayProperties.Description.Contains("\n")
                                    ? $"/// <summary> {(string.Join("\n/// <para/>", definition.DisplayProperties.Description.Split("\n", StringSplitOptions.RemoveEmptyEntries)))} \n/// </summary>"
                                    : $"/// <summary>\n /// {definition.DisplayProperties.Description}\n/// </summary>");
                        }
                    }

                    if (definitionCacheLookup.Count(x => x.Key.Split("_")[0] == key) > 1 &&
                        !key.Contains(value.ToString()))
                    {
                        textWriter.WriteLine($"public const uint {key}_{value} = {value};");
                    }
                    else
                    {
                        textWriter.WriteLine($"public const uint {key} = {value};");
                    }
                }

                textWriter.Write(" } ");
                textWriter.Flush();
                definitionCacheLookup.Clear();

                #endregion

                #region InventoryItems
                
                textWriter.Write("public static class InventoryItems {");
                foreach (var definition in _bungieClient.Repository.GetAll<DestinyInventoryItemDefinition>())
                {
                    if (definition.DisplayProperties is not null)
                    {
                        ValidateAndAddValue(
                            definitionCacheLookup,
                            definition.DisplayProperties.Name,
                            definition.Hash,
                            forbiddenSymbols);
                    }
                    else
                    {
                        definitionCacheLookup.Add($"F{definition.Hash.ToString()}", definition.Hash);
                    }
                }
                
                foreach (var (key, value) in definitionCacheLookup)
                {
                    if (_bungieClient.Repository.TryGetDestinyDefinition<DestinyInventoryItemDefinition>(
                        DefinitionsEnum.DestinyInventoryItemDefinition, value, BungieLocales.EN, out var definition))
                    {
                        if (!string.IsNullOrEmpty(definition.DisplayProperties?.Description))
                        {
                            textWriter.WriteLine(
                                definition.DisplayProperties.Description.Contains("\n")
                                    ? $"/// <summary> {(string.Join("\n/// <para/>", definition.DisplayProperties.Description.Split("\n", StringSplitOptions.RemoveEmptyEntries)))} \n/// </summary>"
                                    : $"/// <summary>\n /// {definition.DisplayProperties.Description}\n/// </summary>");
                        }
                    }
                
                    if (definitionCacheLookup.Count(x => x.Key.Split("_")[0] == key) > 1 &&
                        !key.Contains(value.ToString()))
                    {
                        textWriter.WriteLine($"public const uint {key}_{value} = {value};");
                    }
                    else
                    {
                        textWriter.WriteLine($"public const uint {key} = {value};");
                    }
                }
                
                textWriter.Write(" } ");
                textWriter.Flush();
                definitionCacheLookup.Clear();
                
                #endregion

                #region ItemCategories

                textWriter.Write("public static class ItemCategories {");
                foreach (var definition in _bungieClient.Repository.GetAll<DestinyItemCategoryDefinition>())
                {
                    if (definition.DisplayProperties is not null)
                    {
                        ValidateAndAddValue(
                            definitionCacheLookup,
                            definition.DisplayProperties.Name,
                            definition.Hash,
                            forbiddenSymbols);
                    }
                    else
                    {
                        definitionCacheLookup.Add($"F{definition.Hash.ToString()}", definition.Hash);
                    }
                }

                foreach (var (key, value) in definitionCacheLookup)
                {
                    if (_bungieClient.Repository.TryGetDestinyDefinition<DestinyItemCategoryDefinition>(
                        DefinitionsEnum.DestinyItemCategoryDefinition, value, BungieLocales.EN, out var definition))
                    {
                        if (!string.IsNullOrEmpty(definition.DisplayProperties?.Description))
                        {
                            textWriter.WriteLine(
                                definition.DisplayProperties.Description.Contains("\n")
                                    ? $"/// <summary> {(string.Join("\n/// <para/>", definition.DisplayProperties.Description.Split("\n", StringSplitOptions.RemoveEmptyEntries)))} \n/// </summary>"
                                    : $"/// <summary>\n /// {definition.DisplayProperties.Description}\n/// </summary>");
                        }
                    }

                    if (definitionCacheLookup.Count(x => x.Key.Split("_")[0] == key) > 1 &&
                        !key.Contains(value.ToString()))
                    {
                        textWriter.WriteLine($"public const uint {key}_{value} = {value};");
                    }
                    else
                    {
                        textWriter.WriteLine($"public const uint {key} = {value};");
                    }
                }

                textWriter.Write(" } ");
                textWriter.Flush();
                definitionCacheLookup.Clear();

                #endregion

                #region ItemTierTypes

                textWriter.Write("public static class ItemTierTypes {");
                foreach (var definition in _bungieClient.Repository.GetAll<DestinyItemTierTypeDefinition>())
                {
                    if (definition.DisplayProperties is not null)
                    {
                        ValidateAndAddValue(
                            definitionCacheLookup,
                            definition.DisplayProperties.Name,
                            definition.Hash,
                            forbiddenSymbols);
                    }
                    else
                    {
                        definitionCacheLookup.Add($"F{definition.Hash.ToString()}", definition.Hash);
                    }
                }

                foreach (var (key, value) in definitionCacheLookup)
                {
                    if (_bungieClient.Repository.TryGetDestinyDefinition<DestinyItemTierTypeDefinition>(
                        DefinitionsEnum.DestinyItemTierTypeDefinition, value, BungieLocales.EN, out var definition))
                    {
                        if (!string.IsNullOrEmpty(definition.DisplayProperties?.Description))
                        {
                            textWriter.WriteLine(
                                definition.DisplayProperties.Description.Contains("\n")
                                    ? $"/// <summary> {(string.Join("\n/// <para/>", definition.DisplayProperties.Description.Split("\n", StringSplitOptions.RemoveEmptyEntries)))} \n/// </summary>"
                                    : $"/// <summary>\n /// {definition.DisplayProperties.Description}\n/// </summary>");
                        }
                    }

                    if (definitionCacheLookup.Count(x => x.Key.Split("_")[0] == key) > 1 &&
                        !key.Contains(value.ToString()))
                    {
                        textWriter.WriteLine($"public const uint {key}_{value} = {value};");
                    }
                    else
                    {
                        textWriter.WriteLine($"public const uint {key} = {value};");
                    }
                }

                textWriter.Write(" } ");
                textWriter.Flush();
                definitionCacheLookup.Clear();

                #endregion

                #region Lore
                
                textWriter.Write("public static class Lore {");
                foreach (var definition in _bungieClient.Repository.GetAll<DestinyLoreDefinition>())
                {
                    if (definition.DisplayProperties is not null)
                    {
                        ValidateAndAddValue(
                            definitionCacheLookup,
                            definition.DisplayProperties.Name,
                            definition.Hash,
                            forbiddenSymbols);
                    }
                    else
                    {
                        definitionCacheLookup.Add($"F{definition.Hash.ToString()}", definition.Hash);
                    }
                }
                
                foreach (var (key, value) in definitionCacheLookup)
                {
                    if (_bungieClient.Repository.TryGetDestinyDefinition<DestinyLoreDefinition>(
                        DefinitionsEnum.DestinyLoreDefinition, value, BungieLocales.EN, out var definition))
                    {
                        if (!string.IsNullOrEmpty(definition.DisplayProperties?.Description))
                        {
                            textWriter.WriteLine(
                                definition.DisplayProperties.Description.Contains("\n")
                                    ? $"/// <summary> {(string.Join("\n/// <para/>", definition.DisplayProperties.Description.Split("\n", StringSplitOptions.RemoveEmptyEntries)))} \n/// </summary>"
                                    : $"/// <summary>\n /// {definition.DisplayProperties.Description}\n/// </summary>");
                        }
                    }
                
                    if (definitionCacheLookup.Count(x => x.Key.Split("_")[0] == key) > 1 &&
                        !key.Contains(value.ToString()))
                    {
                        textWriter.WriteLine($"public const uint {key}_{value} = {value};");
                    }
                    else
                    {
                        textWriter.WriteLine($"public const uint {key} = {value};");
                    }
                }
                
                textWriter.Write(" } ");
                textWriter.Flush();
                definitionCacheLookup.Clear();
                
                #endregion

                #region MedalTiers

                textWriter.Write("public static class MedalTiers {");
                foreach (var definition in _bungieClient.Repository.GetAll<DestinyMedalTierDefinition>())
                {
                    textWriter.WriteLine(
                        $"public const uint {definition.TierName.Replace(" ", "")} = {definition.Hash};");
                }

                textWriter.Write(" } ");
                textWriter.Flush();
                definitionCacheLookup.Clear();

                #endregion

                #region Metrics

                textWriter.Write("public static class Metrics {");
                foreach (var definition in _bungieClient.Repository.GetAll<DestinyMetricDefinition>())
                {
                    if (definition.DisplayProperties is not null)
                    {
                        ValidateAndAddValue(
                            definitionCacheLookup,
                            definition.DisplayProperties.Name,
                            definition.Hash,
                            forbiddenSymbols);
                    }
                    else
                    {
                        definitionCacheLookup.Add($"F{definition.Hash.ToString()}", definition.Hash);
                    }
                }

                foreach (var (key, value) in definitionCacheLookup)
                {
                    if (_bungieClient.Repository.TryGetDestinyDefinition<DestinyMetricDefinition>(
                        DefinitionsEnum.DestinyMetricDefinition, value, BungieLocales.EN, out var definition))
                    {
                        if (!string.IsNullOrEmpty(definition.DisplayProperties?.Description))
                        {
                            textWriter.WriteLine(
                                definition.DisplayProperties.Description.Contains("\n")
                                    ? $"/// <summary> {(string.Join("\n/// <para/>", definition.DisplayProperties.Description.Split("\n", StringSplitOptions.RemoveEmptyEntries)))} \n/// </summary>"
                                    : $"/// <summary>\n /// {definition.DisplayProperties.Description}\n/// </summary>");
                        }
                    }

                    if (definitionCacheLookup.Count(x => x.Key.Split("_")[0] == key) > 1 &&
                        !key.Contains(value.ToString()))
                    {
                        textWriter.WriteLine($"public const uint {key}_{value} = {value};");
                    }
                    else
                    {
                        textWriter.WriteLine($"public const uint {key} = {value};");
                    }
                }

                textWriter.Write(" } ");
                textWriter.Flush();
                definitionCacheLookup.Clear();

                #endregion

                #region Milestones

                textWriter.Write("public static class Milestones {");
                foreach (var definition in _bungieClient.Repository.GetAll<DestinyMilestoneDefinition>())
                {
                    if (definition.DisplayProperties is not null)
                    {
                        ValidateAndAddValue(
                            definitionCacheLookup,
                            definition.DisplayProperties.Name,
                            definition.Hash,
                            forbiddenSymbols);
                    }
                    else
                    {
                        definitionCacheLookup.Add($"F{definition.Hash.ToString()}", definition.Hash);
                    }
                }

                foreach (var (key, value) in definitionCacheLookup)
                {
                    if (_bungieClient.Repository.TryGetDestinyDefinition<DestinyMilestoneDefinition>(
                        DefinitionsEnum.DestinyMilestoneDefinition, value, BungieLocales.EN, out var definition))
                    {
                        if (!string.IsNullOrEmpty(definition.DisplayProperties?.Description))
                        {
                            textWriter.WriteLine(
                                definition.DisplayProperties.Description.Contains("\n")
                                    ? $"/// <summary> {(string.Join("\n/// <para/>", definition.DisplayProperties.Description.Split("\n", StringSplitOptions.RemoveEmptyEntries)))} \n/// </summary>"
                                    : $"/// <summary>\n /// {definition.DisplayProperties.Description}\n/// </summary>");
                        }
                    }

                    if (definitionCacheLookup.Count(x => x.Key.Split("_")[0] == key) > 1 &&
                        !key.Contains(value.ToString()))
                    {
                        textWriter.WriteLine($"public const uint {key}_{value} = {value};");
                    }
                    else
                    {
                        textWriter.WriteLine($"public const uint {key} = {value};");
                    }
                }

                textWriter.Write(" } ");
                textWriter.Flush();
                definitionCacheLookup.Clear();

                #endregion

                #region Places

                textWriter.Write("public static class Places {");
                foreach (var definition in _bungieClient.Repository.GetAll<DestinyPlaceDefinition>())
                {
                    if (definition.DisplayProperties is not null)
                    {
                        ValidateAndAddValue(
                            definitionCacheLookup,
                            definition.DisplayProperties.Name,
                            definition.Hash,
                            forbiddenSymbols);
                    }
                    else
                    {
                        definitionCacheLookup.Add($"F{definition.Hash.ToString()}", definition.Hash);
                    }
                }

                foreach (var (key, value) in definitionCacheLookup)
                {
                    if (_bungieClient.Repository.TryGetDestinyDefinition<DestinyPlaceDefinition>(
                        DefinitionsEnum.DestinyPlaceDefinition, value, BungieLocales.EN, out var definition))
                    {
                        if (!string.IsNullOrEmpty(definition.DisplayProperties?.Description))
                        {
                            textWriter.WriteLine(
                                definition.DisplayProperties.Description.Contains("\n")
                                    ? $"/// <summary> {(string.Join("\n/// <para/>", definition.DisplayProperties.Description.Split("\n", StringSplitOptions.RemoveEmptyEntries)))} \n/// </summary>"
                                    : $"/// <summary>\n /// {definition.DisplayProperties.Description}\n/// </summary>");
                        }
                    }

                    if (definitionCacheLookup.Count(x => x.Key.Split("_")[0] == key) > 1 &&
                        !key.Contains(value.ToString()))
                    {
                        textWriter.WriteLine($"public const uint {key}_{value} = {value};");
                    }
                    else
                    {
                        textWriter.WriteLine($"public const uint {key} = {value};");
                    }
                }

                textWriter.Write(" } ");
                textWriter.Flush();
                definitionCacheLookup.Clear();

                #endregion

                #region PowerCaps

                textWriter.Write("public static class PowerCaps {");
                foreach (var definition in _bungieClient.Repository.GetAll<DestinyPowerCapDefinition>())
                {
                    ValidateAndAddValue(
                        definitionCacheLookup,
                        definition.PowerCap.ToString(),
                        definition.Hash,
                        forbiddenSymbols);
                }

                foreach (var (key, value) in definitionCacheLookup)
                {
                    if (definitionCacheLookup.Count(x => x.Key.Split("_")[0] == key) > 1 &&
                        !key.Contains(value.ToString()))
                    {
                        textWriter.WriteLine($"public const uint {key}_{value} = {value};");
                    }
                    else
                    {
                        textWriter.WriteLine($"public const uint {key} = {value};");
                    }
                }

                textWriter.Write(" } ");
                textWriter.Flush();
                definitionCacheLookup.Clear();

                #endregion

                #region PresentationNodes

                textWriter.Write("public static class PresentationNodes {");
                foreach (var definition in _bungieClient.Repository.GetAll<DestinyPresentationNodeDefinition>())
                {
                    if (definition.DisplayProperties is not null)
                    {
                        ValidateAndAddValue(
                            definitionCacheLookup,
                            definition.DisplayProperties.Name,
                            definition.Hash,
                            forbiddenSymbols);
                    }
                    else
                    {
                        definitionCacheLookup.Add($"F{definition.Hash.ToString()}", definition.Hash);
                    }
                }

                foreach (var (key, value) in definitionCacheLookup)
                {
                    if (_bungieClient.Repository.TryGetDestinyDefinition<DestinyPresentationNodeDefinition>(
                        DefinitionsEnum.DestinyPresentationNodeDefinition, value, BungieLocales.EN, out var definition))
                    {
                        if (!string.IsNullOrEmpty(definition.DisplayProperties?.Description))
                        {
                            textWriter.WriteLine(
                                definition.DisplayProperties.Description.Contains("\n")
                                    ? $"/// <summary> {(string.Join("\n/// <para/>", definition.DisplayProperties.Description.Split("\n", StringSplitOptions.RemoveEmptyEntries)))} \n/// </summary>"
                                    : $"/// <summary>\n /// {definition.DisplayProperties.Description}\n/// </summary>");
                        }
                    }

                    if (definitionCacheLookup.Count(x => x.Key.Split("_")[0] == key) > 1 &&
                        !key.Contains(value.ToString()))
                    {
                        textWriter.WriteLine($"public const uint {key}_{value} = {value};");
                    }
                    else
                    {
                        textWriter.WriteLine($"public const uint {key} = {value};");
                    }
                }

                textWriter.Write(" } ");
                textWriter.Flush();
                definitionCacheLookup.Clear();

                #endregion

                #region Progressions

                textWriter.Write("public static class Progressions {");
                foreach (var definition in _bungieClient.Repository.GetAll<DestinyProgressionDefinition>())
                {
                    if (definition.DisplayProperties is not null)
                    {
                        ValidateAndAddValue(
                            definitionCacheLookup,
                            definition.DisplayProperties.Name,
                            definition.Hash,
                            forbiddenSymbols);
                    }
                    else
                    {
                        definitionCacheLookup.Add($"F{definition.Hash.ToString()}", definition.Hash);
                    }
                }

                foreach (var (key, value) in definitionCacheLookup)
                {
                    if (_bungieClient.Repository.TryGetDestinyDefinition<DestinyProgressionDefinition>(
                        DefinitionsEnum.DestinyProgressionDefinition, value, BungieLocales.EN, out var definition))
                    {
                        if (!string.IsNullOrEmpty(definition.DisplayProperties?.Description))
                        {
                            textWriter.WriteLine(
                                definition.DisplayProperties.Description.Contains("\n")
                                    ? $"/// <summary> {(string.Join("\n/// <para/>", definition.DisplayProperties.Description.Split("\n", StringSplitOptions.RemoveEmptyEntries)))} \n/// </summary>"
                                    : $"/// <summary>\n /// {definition.DisplayProperties.Description}\n/// </summary>");
                        }
                    }

                    if (definitionCacheLookup.Count(x => x.Key.Split("_")[0] == key) > 1 &&
                        !key.Contains(value.ToString()))
                    {
                        textWriter.WriteLine($"public const uint {key}_{value} = {value};");
                    }
                    else
                    {
                        textWriter.WriteLine($"public const uint {key} = {value};");
                    }
                }

                textWriter.Write(" } ");
                textWriter.Flush();
                definitionCacheLookup.Clear();

                #endregion

                #region Races

                textWriter.Write("public static class Races {");
                foreach (var definition in _bungieClient.Repository.GetAll<DestinyRaceDefinition>())
                {
                    if (definition.DisplayProperties is not null)
                    {
                        ValidateAndAddValue(
                            definitionCacheLookup,
                            definition.DisplayProperties.Name,
                            definition.Hash,
                            forbiddenSymbols);
                    }
                    else
                    {
                        definitionCacheLookup.Add($"F{definition.Hash.ToString()}", definition.Hash);
                    }
                }

                foreach (var (key, value) in definitionCacheLookup)
                {
                    if (_bungieClient.Repository.TryGetDestinyDefinition<DestinyRaceDefinition>(
                        DefinitionsEnum.DestinyRaceDefinition, value, BungieLocales.EN, out var definition))
                    {
                        if (!string.IsNullOrEmpty(definition.DisplayProperties?.Description))
                        {
                            textWriter.WriteLine(
                                definition.DisplayProperties.Description.Contains("\n")
                                    ? $"/// <summary> {(string.Join("\n/// <para/>", definition.DisplayProperties.Description.Split("\n", StringSplitOptions.RemoveEmptyEntries)))} \n/// </summary>"
                                    : $"/// <summary>\n /// {definition.DisplayProperties.Description}\n/// </summary>");
                        }
                    }

                    if (definitionCacheLookup.Count(x => x.Key.Split("_")[0] == key) > 1 &&
                        !key.Contains(value.ToString()))
                    {
                        textWriter.WriteLine($"public const uint {key}_{value} = {value};");
                    }
                    else
                    {
                        textWriter.WriteLine($"public const uint {key} = {value};");
                    }
                }

                textWriter.Write(" } ");
                textWriter.Flush();
                definitionCacheLookup.Clear();

                #endregion

                #region Records

                textWriter.Write("public static class Records {");
                foreach (var definition in _bungieClient.Repository.GetAll<DestinyRecordDefinition>())
                {
                    if (definition.DisplayProperties is not null)
                    {
                        ValidateAndAddValue(
                            definitionCacheLookup,
                            definition.DisplayProperties.Name,
                            definition.Hash,
                            forbiddenSymbols);
                    }
                    else
                    {
                        definitionCacheLookup.Add($"F{definition.Hash.ToString()}", definition.Hash);
                    }
                }

                foreach (var (key, value) in definitionCacheLookup)
                {
                    if (_bungieClient.Repository.TryGetDestinyDefinition<DestinyRecordDefinition>(
                        DefinitionsEnum.DestinyRecordDefinition, value, BungieLocales.EN, out var definition))
                    {
                        if (!string.IsNullOrEmpty(definition.DisplayProperties?.Description))
                        {
                            textWriter.WriteLine(
                                definition.DisplayProperties.Description.Contains("\n")
                                    ? $"/// <summary> {(string.Join("\n/// <para/>", definition.DisplayProperties.Description.Split("\n", StringSplitOptions.RemoveEmptyEntries)))} \n/// </summary>"
                                    : $"/// <summary>\n /// {definition.DisplayProperties.Description}\n/// </summary>");
                        }
                    }

                    if (definitionCacheLookup.Count(x => x.Key.Split("_")[0] == key) > 1 &&
                        !key.Contains(value.ToString()))
                    {
                        textWriter.WriteLine($"public const uint {key}_{value} = {value};");
                    }
                    else
                    {
                        textWriter.WriteLine($"public const uint {key} = {value};");
                    }
                }

                textWriter.Write(" } ");
                textWriter.Flush();
                definitionCacheLookup.Clear();

                #endregion

                #region ReportReasonCategories

                textWriter.Write("public static class ReportReasonCategories {");
                foreach (var definition in _bungieClient.Repository.GetAll<DestinyReportReasonCategoryDefinition>())
                {
                    if (definition.DisplayProperties is not null)
                    {
                        ValidateAndAddValue(
                            definitionCacheLookup,
                            definition.DisplayProperties.Name,
                            definition.Hash,
                            forbiddenSymbols);
                    }
                    else
                    {
                        definitionCacheLookup.Add($"F{definition.Hash.ToString()}", definition.Hash);
                    }
                }

                foreach (var (key, value) in definitionCacheLookup)
                {
                    if (_bungieClient.Repository.TryGetDestinyDefinition<DestinyReportReasonCategoryDefinition>(
                        DefinitionsEnum.DestinyReportReasonCategoryDefinition, value, BungieLocales.EN,
                        out var definition))
                    {
                        if (!string.IsNullOrEmpty(definition.DisplayProperties?.Description))
                        {
                            textWriter.WriteLine(
                                definition.DisplayProperties.Description.Contains("\n")
                                    ? $"/// <summary> {(string.Join("\n/// <para/>", definition.DisplayProperties.Description.Split("\n", StringSplitOptions.RemoveEmptyEntries)))} \n/// </summary>"
                                    : $"/// <summary>\n /// {definition.DisplayProperties.Description}\n/// </summary>");
                        }
                    }

                    if (definitionCacheLookup.Count(x => x.Key.Split("_")[0] == key) > 1 &&
                        !key.Contains(value.ToString()))
                    {
                        textWriter.WriteLine($"public const uint {key}_{value} = {value};");
                    }
                    else
                    {
                        textWriter.WriteLine($"public const uint {key} = {value};");
                    }
                }

                textWriter.Write(" } ");
                textWriter.Flush();
                definitionCacheLookup.Clear();

                #endregion

                #region SandboxPerks

                textWriter.Write("public static class SandboxPerks {");
                foreach (var definition in _bungieClient.Repository.GetAll<DestinySandboxPerkDefinition>())
                {
                    if (definition.DisplayProperties is not null)
                    {
                        ValidateAndAddValue(
                            definitionCacheLookup,
                            definition.DisplayProperties.Name,
                            definition.Hash,
                            forbiddenSymbols);
                    }
                    else
                    {
                        definitionCacheLookup.Add($"F{definition.Hash.ToString()}", definition.Hash);
                    }
                }

                foreach (var (key, value) in definitionCacheLookup)
                {
                    if (_bungieClient.Repository.TryGetDestinyDefinition<DestinySandboxPerkDefinition>(
                        DefinitionsEnum.DestinySandboxPerkDefinition, value, BungieLocales.EN, out var definition))
                    {
                        if (!string.IsNullOrEmpty(definition.DisplayProperties?.Description))
                        {
                            textWriter.WriteLine(
                                definition.DisplayProperties.Description.Contains("\n")
                                    ? $"/// <summary> {(string.Join("\n/// <para/>", definition.DisplayProperties.Description.Split("\n", StringSplitOptions.RemoveEmptyEntries)))} \n/// </summary>"
                                    : $"/// <summary>\n /// {definition.DisplayProperties.Description}\n/// </summary>");
                        }
                    }

                    if (definitionCacheLookup.Count(x => x.Key.Split("_")[0] == key) > 1 &&
                        !key.Contains(value.ToString()))
                    {
                        textWriter.WriteLine($"public const uint {key}_{value} = {value};");
                    }
                    else
                    {
                        textWriter.WriteLine($"public const uint {key} = {value};");
                    }
                }

                textWriter.Write(" } ");
                textWriter.Flush();
                definitionCacheLookup.Clear();

                #endregion

                #region Seasons

                textWriter.Write("public static class Seasons {");
                foreach (var definition in _bungieClient.Repository.GetAll<DestinySeasonDefinition>())
                {
                    if (definition.DisplayProperties is not null)
                    {
                        ValidateAndAddValue(
                            definitionCacheLookup,
                            definition.DisplayProperties.Name,
                            definition.Hash,
                            forbiddenSymbols);
                    }
                    else
                    {
                        definitionCacheLookup.Add($"F{definition.Hash.ToString()}", definition.Hash);
                    }
                }

                foreach (var (key, value) in definitionCacheLookup)
                {
                    if (_bungieClient.Repository.TryGetDestinyDefinition<DestinySeasonDefinition>(
                        DefinitionsEnum.DestinySeasonDefinition, value, BungieLocales.EN, out var definition))
                    {
                        if (!string.IsNullOrEmpty(definition.DisplayProperties?.Description))
                        {
                            textWriter.WriteLine(
                                definition.DisplayProperties.Description.Contains("\n")
                                    ? $"/// <summary> {(string.Join("\n/// <para/>", definition.DisplayProperties.Description.Split("\n", StringSplitOptions.RemoveEmptyEntries)))} \n/// </summary>"
                                    : $"/// <summary>\n /// {definition.DisplayProperties.Description}\n/// </summary>");
                        }
                    }

                    if (definitionCacheLookup.Count(x => x.Key.Split("_")[0] == key) > 1 &&
                        !key.Contains(value.ToString()))
                    {
                        textWriter.WriteLine($"public const uint {key}_{value} = {value};");
                    }
                    else
                    {
                        textWriter.WriteLine($"public const uint {key} = {value};");
                    }
                }

                textWriter.Write(" } ");
                textWriter.Flush();
                definitionCacheLookup.Clear();

                #endregion

                #region SeasonPasses

                textWriter.Write("public static class SeasonPasses {");
                foreach (var definition in _bungieClient.Repository.GetAll<DestinySeasonPassDefinition>())
                {
                    if (definition.DisplayProperties is not null)
                    {
                        ValidateAndAddValue(
                            definitionCacheLookup,
                            definition.DisplayProperties.Name,
                            definition.Hash,
                            forbiddenSymbols);
                    }
                    else
                    {
                        definitionCacheLookup.Add($"F{definition.Hash.ToString()}", definition.Hash);
                    }
                }

                foreach (var (key, value) in definitionCacheLookup)
                {
                    if (_bungieClient.Repository.TryGetDestinyDefinition<DestinySeasonPassDefinition>(
                        DefinitionsEnum.DestinySeasonPassDefinition, value, BungieLocales.EN, out var definition))
                    {
                        if (!string.IsNullOrEmpty(definition.DisplayProperties?.Description))
                        {
                            textWriter.WriteLine(
                                definition.DisplayProperties.Description.Contains("\n")
                                    ? $"/// <summary> {(string.Join("\n/// <para/>", definition.DisplayProperties.Description.Split("\n", StringSplitOptions.RemoveEmptyEntries)))} \n/// </summary>"
                                    : $"/// <summary>\n /// {definition.DisplayProperties.Description}\n/// </summary>");
                        }
                    }

                    if (definitionCacheLookup.Count(x => x.Key.Split("_")[0] == key) > 1 &&
                        !key.Contains(value.ToString()))
                    {
                        textWriter.WriteLine($"public const uint {key}_{value} = {value};");
                    }
                    else
                    {
                        textWriter.WriteLine($"public const uint {key} = {value};");
                    }
                }

                textWriter.Write(" } ");
                textWriter.Flush();
                definitionCacheLookup.Clear();

                #endregion

                #region SocketCategories

                textWriter.Write("public static class SocketCategories {");
                foreach (var definition in _bungieClient.Repository.GetAll<DestinySocketCategoryDefinition>())
                {
                    if (definition.DisplayProperties is not null)
                    {
                        ValidateAndAddValue(
                            definitionCacheLookup,
                            definition.DisplayProperties.Name,
                            definition.Hash,
                            forbiddenSymbols);
                    }
                    else
                    {
                        definitionCacheLookup.Add($"F{definition.Hash.ToString()}", definition.Hash);
                    }
                }

                foreach (var (key, value) in definitionCacheLookup)
                {
                    if (_bungieClient.Repository.TryGetDestinyDefinition<DestinySocketCategoryDefinition>(
                        DefinitionsEnum.DestinySocketCategoryDefinition, value, BungieLocales.EN, out var definition))
                    {
                        if (!string.IsNullOrEmpty(definition.DisplayProperties?.Description))
                        {
                            textWriter.WriteLine(
                                definition.DisplayProperties.Description.Contains("\n")
                                    ? $"/// <summary> {(string.Join("\n/// <para/>", definition.DisplayProperties.Description.Split("\n", StringSplitOptions.RemoveEmptyEntries)))} \n/// </summary>"
                                    : $"/// <summary>\n /// {definition.DisplayProperties.Description}\n/// </summary>");
                        }
                    }

                    if (definitionCacheLookup.Count(x => x.Key.Split("_")[0] == key) > 1 &&
                        !key.Contains(value.ToString()))
                    {
                        textWriter.WriteLine($"public const uint {key}_{value} = {value};");
                    }
                    else
                    {
                        textWriter.WriteLine($"public const uint {key} = {value};");
                    }
                }

                textWriter.Write(" } ");
                textWriter.Flush();
                definitionCacheLookup.Clear();

                #endregion

                #region SocketTypes

                textWriter.Write("public static class SocketTypes {");
                foreach (var definition in _bungieClient.Repository.GetAll<DestinySocketTypeDefinition>())
                {
                    if (definition.DisplayProperties is not null)
                    {
                        ValidateAndAddValue(
                            definitionCacheLookup,
                            definition.DisplayProperties.Name,
                            definition.Hash,
                            forbiddenSymbols);
                    }
                    else
                    {
                        definitionCacheLookup.Add($"F{definition.Hash.ToString()}", definition.Hash);
                    }
                }

                foreach (var (key, value) in definitionCacheLookup)
                {
                    if (_bungieClient.Repository.TryGetDestinyDefinition<DestinySocketTypeDefinition>(
                        DefinitionsEnum.DestinySocketTypeDefinition, value, BungieLocales.EN, out var definition))
                    {
                        if (!string.IsNullOrEmpty(definition.DisplayProperties?.Description))
                        {
                            textWriter.WriteLine(
                                definition.DisplayProperties.Description.Contains("\n")
                                    ? $"/// <summary> {(string.Join("\n/// <para/>", definition.DisplayProperties.Description.Split("\n", StringSplitOptions.RemoveEmptyEntries)))} \n/// </summary>"
                                    : $"/// <summary>\n /// {definition.DisplayProperties.Description}\n/// </summary>");
                        }
                    }

                    if (definitionCacheLookup.Count(x => x.Key.Split("_")[0] == key) > 1 &&
                        !key.Contains(value.ToString()))
                    {
                        textWriter.WriteLine($"public const uint {key}_{value} = {value};");
                    }
                    else
                    {
                        textWriter.WriteLine($"public const uint {key} = {value};");
                    }
                }

                textWriter.Write(" } ");
                textWriter.Flush();
                definitionCacheLookup.Clear();

                #endregion

                #region Stats

                textWriter.Write("public static class Stats {");
                foreach (var definition in _bungieClient.Repository.GetAll<DestinyStatDefinition>())
                {
                    if (definition.DisplayProperties is not null)
                    {
                        ValidateAndAddValue(
                            definitionCacheLookup,
                            definition.DisplayProperties.Name,
                            definition.Hash,
                            forbiddenSymbols);
                    }
                    else
                    {
                        definitionCacheLookup.Add($"F{definition.Hash.ToString()}", definition.Hash);
                    }
                }

                foreach (var (key, value) in definitionCacheLookup)
                {
                    if (_bungieClient.Repository.TryGetDestinyDefinition<DestinyStatDefinition>(
                        DefinitionsEnum.DestinyStatDefinition, value, BungieLocales.EN, out var definition))
                    {
                        if (!string.IsNullOrEmpty(definition.DisplayProperties?.Description))
                        {
                            textWriter.WriteLine(
                                definition.DisplayProperties.Description.Contains("\n")
                                    ? $"/// <summary> {(string.Join("\n/// <para/>", definition.DisplayProperties.Description.Split("\n", StringSplitOptions.RemoveEmptyEntries)))} \n/// </summary>"
                                    : $"/// <summary>\n /// {definition.DisplayProperties.Description}\n/// </summary>");
                        }
                    }

                    if (definitionCacheLookup.Count(x => x.Key.Split("_")[0] == key) > 1 &&
                        !key.Contains(value.ToString()))
                    {
                        textWriter.WriteLine($"public const uint {key}_{value} = {value};");
                    }
                    else
                    {
                        textWriter.WriteLine($"public const uint {key} = {value};");
                    }
                }

                textWriter.Write(" } ");
                textWriter.Flush();
                definitionCacheLookup.Clear();

                #endregion

                #region TraitCategories

                textWriter.Write("public static class TraitCategories {");
                foreach (var definition in _bungieClient.Repository.GetAll<DestinyTraitCategoryDefinition>())
                {
                    textWriter.WriteLine($"public const uint {definition.TraitCategoryId} = {definition.Hash};");
                }

                textWriter.Write(" } ");
                textWriter.Flush();
                definitionCacheLookup.Clear();

                #endregion

                #region Traits

                textWriter.Write("public static class Traits {");
                foreach (var definition in _bungieClient.Repository.GetAll<DestinyTraitDefinition>())
                {
                    if (definition.DisplayProperties is not null)
                    {
                        ValidateAndAddValue(
                            definitionCacheLookup,
                            definition.DisplayProperties.Name,
                            definition.Hash,
                            forbiddenSymbols);
                    }
                    else
                    {
                        definitionCacheLookup.Add($"F{definition.Hash.ToString()}", definition.Hash);
                    }
                }

                foreach (var (key, value) in definitionCacheLookup)
                {
                    if (_bungieClient.Repository.TryGetDestinyDefinition<DestinyTraitDefinition>(
                        DefinitionsEnum.DestinyTraitDefinition, value, BungieLocales.EN, out var definition))
                    {
                        if (!string.IsNullOrEmpty(definition.DisplayProperties?.Description))
                        {
                            textWriter.WriteLine(
                                definition.DisplayProperties.Description.Contains("\n")
                                    ? $"/// <summary> {(string.Join("\n/// <para/>", definition.DisplayProperties.Description.Split("\n", StringSplitOptions.RemoveEmptyEntries)))} \n/// </summary>"
                                    : $"/// <summary>\n /// {definition.DisplayProperties.Description}\n/// </summary>");
                        }
                    }

                    if (definitionCacheLookup.Count(x => x.Key.Split("_")[0] == key) > 1 &&
                        !key.Contains(value.ToString()))
                    {
                        textWriter.WriteLine($"public const uint {key}_{value} = {value};");
                    }
                    else
                    {
                        textWriter.WriteLine($"public const uint {key} = {value};");
                    }
                }

                textWriter.Write(" } ");
                textWriter.Flush();
                definitionCacheLookup.Clear();

                #endregion

                #region Vendors

                textWriter.Write("public static class Vendors {");
                foreach (var definition in _bungieClient.Repository.GetAll<DestinyVendorDefinition>())
                {
                    if (definition.DisplayProperties is not null)
                    {
                        ValidateAndAddValue(
                            definitionCacheLookup,
                            definition.DisplayProperties.Name,
                            definition.Hash,
                            forbiddenSymbols);
                    }
                    else
                    {
                        definitionCacheLookup.Add($"F{definition.Hash.ToString()}", definition.Hash);
                    }
                }

                foreach (var (key, value) in definitionCacheLookup)
                {
                    if (_bungieClient.Repository.TryGetDestinyDefinition<DestinyVendorDefinition>(
                        DefinitionsEnum.DestinyVendorDefinition, value, BungieLocales.EN, out var definition))
                    {
                        if (!string.IsNullOrEmpty(definition.DisplayProperties?.Description))
                        {
                            textWriter.WriteLine(
                                definition.DisplayProperties.Description.Contains("\n")
                                    ? $"/// <summary> {(string.Join("\n/// <para/>", definition.DisplayProperties.Description.Split("\n", StringSplitOptions.RemoveEmptyEntries)))} \n/// </summary>"
                                    : $"/// <summary>\n /// {definition.DisplayProperties.Description}\n/// </summary>");
                        }
                    }

                    if (definitionCacheLookup.Count(x => x.Key.Split("_")[0] == key) > 1 &&
                        !key.Contains(value.ToString()))
                    {
                        textWriter.WriteLine($"public const uint {key}_{value} = {value};");
                    }
                    else
                    {
                        textWriter.WriteLine($"public const uint {key} = {value};");
                    }
                }

                textWriter.Write(" } ");
                textWriter.Flush();
                definitionCacheLookup.Clear();

                #endregion

                #region VendorGroups

                textWriter.Write("public static class VendorGroups {");
                foreach (var definition in _bungieClient.Repository.GetAll<DestinyVendorGroupDefinition>())
                {
                    var key = string.Join("", definition.CategoryName.Split(forbiddenSymbols, StringSplitOptions.TrimEntries));
                    textWriter.WriteLine($"public const uint {key} = {definition.Hash};");
                }

                textWriter.Write(" } ");
                textWriter.Flush();
                definitionCacheLookup.Clear();

                #endregion

                textWriter.Write(" } }");
            }

            Console.WriteLine("Finished generating definitions.");
        }

        private static void ValidateAndAddValue(
            Dictionary<string, uint> definitionCacheLookup,
            string key,
            uint value,
            string[] forbiddenSymbols)
        {
            key ??= value.ToString();

            key = string.Join("", key.Split(forbiddenSymbols, StringSplitOptions.TrimEntries));

            if (string.IsNullOrWhiteSpace(key))
            {
                key = value.ToString();
            }

            if (char.IsDigit(key[0]))
            {
                key = $"F{key}";
            }

            var sameEntriesAmount = definitionCacheLookup.Keys.Count(x => x.Split("_")[0] == key);

            definitionCacheLookup.Add(
                sameEntriesAmount > 0 ? $"{key}_{value}" : key, value);
        }
    }
}