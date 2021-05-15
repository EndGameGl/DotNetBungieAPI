using NetBungieAPI.Models.Applications;
using NetBungieAPI.Clients;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Text.Json.Serialization;
using System.Threading;
using System.Threading.Tasks;
using NetBungieAPI.Models.Trending;
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
using NetBungieAPI.Models.GroupsV2;
using NetBungieAPI.Models.Queries;
using NetBungieAPI.Repositories;

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
            DestinyComponentType.Metrics
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
                    //.PremapDefinitions()
                    //.LoadAllDefinitionsOnStartup(waitEverythingToLoad: true)
                    .SetLocales(new BungieLocales[] {BungieLocales.EN})
                    .SetUpdateBehaviour(false, false);
            });
            sw.Stop();
            Console.WriteLine($"Startup in: {sw.ElapsedMilliseconds} ms");

            //var authAwaiter = _bungieClient.Authentification.CreateNewAuthentificationAwaiter();
            //var authLink = _bungieClient.Authentification.GetAuthorizationLink(authAwaiter);
            //authAwaiter.ReceiveCode(Console.ReadLine(), Console.ReadLine());
            //var token = await _bungieClient.Authentification.GetAuthTokenAsync(authAwaiter);

            var response = await _bungieClient.ApiAccess.GroupV2.GetPotentialGroupsForMember(
                BungieMembershipType.TigerSteam,
                20027802,
                GroupType.General, 
                GroupsForMemberFilter.All);

            await Task.Delay(Timeout.Infinite);
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
    }
}