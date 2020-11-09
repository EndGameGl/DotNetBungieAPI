using BungieNetCoreAPI.Destiny;
using BungieNetCoreAPI.Destiny.Definitions;
using BungieNetCoreAPI.Destiny.Definitions.Achievements;
using BungieNetCoreAPI.Destiny.Definitions.Activities;
using BungieNetCoreAPI.Destiny.Definitions.ActivityGraphs;
using BungieNetCoreAPI.Destiny.Definitions.ActivityInteractables;
using BungieNetCoreAPI.Destiny.Definitions.ActivityModes;
using BungieNetCoreAPI.Destiny.Definitions.ActivityModifiers;
using BungieNetCoreAPI.Destiny.Definitions.ActivityTypes;
using BungieNetCoreAPI.Destiny.Definitions.ArtDyeChannels;
using BungieNetCoreAPI.Destiny.Definitions.ArtDyeReferences;
using BungieNetCoreAPI.Destiny.Definitions.Artifacts;
using BungieNetCoreAPI.Destiny.Definitions.Bonds;
using BungieNetCoreAPI.Destiny.Definitions.BreakerTypes;
using BungieNetCoreAPI.Destiny.Definitions.CharacterCustomizationCategories;
using BungieNetCoreAPI.Destiny.Definitions.CharacterCustomizationOptions;
using BungieNetCoreAPI.Destiny.Definitions.Checklists;
using BungieNetCoreAPI.Destiny.Definitions.Classes;
using BungieNetCoreAPI.Destiny.Definitions.Collectibles;
using BungieNetCoreAPI.Destiny.Definitions.DamageTypes;
using BungieNetCoreAPI.Destiny.Definitions.Destinations;
using BungieNetCoreAPI.Destiny.Definitions.EnemyRaces;
using BungieNetCoreAPI.Destiny.Definitions.EnergyTypes;
using BungieNetCoreAPI.Destiny.Definitions.EntitlementOffers;
using BungieNetCoreAPI.Destiny.Definitions.EquipmentSlots;
using BungieNetCoreAPI.Destiny.Definitions.Factions;
using BungieNetCoreAPI.Destiny.Definitions.Genders;
using BungieNetCoreAPI.Destiny.Definitions.InventoryBuckets;
using BungieNetCoreAPI.Destiny.Definitions.InventoryItemLites;
using BungieNetCoreAPI.Destiny.Definitions.InventoryItems;
using BungieNetCoreAPI.Destiny.Definitions.ItemCategories;
using BungieNetCoreAPI.Destiny.Definitions.ItemTierTypes;
using BungieNetCoreAPI.Destiny.Definitions.Locations;
using BungieNetCoreAPI.Destiny.Definitions.Lores;
using BungieNetCoreAPI.Destiny.Definitions.MaterialRequirementSets;
using BungieNetCoreAPI.Destiny.Definitions.MedalTiers;
using BungieNetCoreAPI.Destiny.Definitions.Metrics;
using BungieNetCoreAPI.Destiny.Definitions.Milestones;
using BungieNetCoreAPI.Destiny.Definitions.NodeStepSummaries;
using BungieNetCoreAPI.Destiny.Definitions.Objectives;
using BungieNetCoreAPI.Destiny.Definitions.Places;
using BungieNetCoreAPI.Destiny.Definitions.PlatformBucketMappings;
using BungieNetCoreAPI.Destiny.Definitions.PlugSets;
using BungieNetCoreAPI.Destiny.Definitions.PowerCaps;
using BungieNetCoreAPI.Destiny.Definitions.PresentationNodeBases;
using BungieNetCoreAPI.Destiny.Definitions.PresentationNodes;
using BungieNetCoreAPI.Destiny.Definitions.ProgressionLevelRequirements;
using BungieNetCoreAPI.Destiny.Definitions.ProgressionMappings;
using BungieNetCoreAPI.Destiny.Definitions.Progressions;
using BungieNetCoreAPI.Destiny.Definitions.Races;
using BungieNetCoreAPI.Destiny.Definitions.Records;
using BungieNetCoreAPI.Destiny.Definitions.ReportReasonCategories;
using BungieNetCoreAPI.Destiny.Definitions.RewardAdjusterPointers;
using BungieNetCoreAPI.Destiny.Definitions.RewardAdjusterProgressionMaps;
using BungieNetCoreAPI.Destiny.Definitions.RewardItemLists;
using BungieNetCoreAPI.Destiny.Definitions.RewardMappings;
using BungieNetCoreAPI.Destiny.Definitions.RewardSheets;
using BungieNetCoreAPI.Destiny.Definitions.RewardSources;
using BungieNetCoreAPI.Destiny.Definitions.SackRewardItemLists;
using BungieNetCoreAPI.Destiny.Definitions.SandboxPatterns;
using BungieNetCoreAPI.Destiny.Definitions.SandboxPerks;
using BungieNetCoreAPI.Destiny.Definitions.SeasonPasses;
using BungieNetCoreAPI.Destiny.Definitions.Seasons;
using BungieNetCoreAPI.Destiny.Definitions.SocketCategories;
using BungieNetCoreAPI.Destiny.Definitions.SocketTypes;
using BungieNetCoreAPI.Destiny.Definitions.StatGroups;
using BungieNetCoreAPI.Destiny.Definitions.Stats;
using BungieNetCoreAPI.Destiny.Definitions.TalentGrids;
using BungieNetCoreAPI.Destiny.Definitions.TraitCategories;
using BungieNetCoreAPI.Destiny.Definitions.Traits;
using BungieNetCoreAPI.Destiny.Definitions.UnlockCountMappings;
using BungieNetCoreAPI.Destiny.Definitions.UnlockEvents;
using BungieNetCoreAPI.Destiny.Definitions.UnlockExpressionMappings;
using BungieNetCoreAPI.Destiny.Definitions.Unlocks;
using BungieNetCoreAPI.Destiny.Definitions.UnlockValues;
using BungieNetCoreAPI.Destiny.Definitions.VendorGroups;
using BungieNetCoreAPI.Destiny.Definitions.Vendors;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace BungieNetCoreAPI
{
    public static class DefinitionsCacheRepository
    {
        private static Dictionary<string, FieldInfo> Definitions = new Dictionary<string, FieldInfo>();

        private static DestinyDefinitionRepository DestinyAchievementDefinitions = new DestinyDefinitionRepository(typeof(DestinyAchievementDefinition));
        private static DestinyDefinitionRepository DestinyActivityDefinitions = new DestinyDefinitionRepository(typeof(DestinyActivityDefinition));
        private static DestinyDefinitionRepository DestinyActivityGraphDefinitions = new DestinyDefinitionRepository(typeof(DestinyActivityGraphDefinition));
        private static DestinyDefinitionRepository DestinyActivityInteractableDefinitions = new DestinyDefinitionRepository(typeof(DestinyActivityInteractableDefinition));
        private static DestinyDefinitionRepository DestinyActivityModeDefinitions = new DestinyDefinitionRepository(typeof(DestinyActivityModeDefinition));
        private static DestinyDefinitionRepository DestinyActivityModifierDefinitions = new DestinyDefinitionRepository(typeof(DestinyActivityModifierDefinition));
        private static DestinyDefinitionRepository DestinyActivityTypeDefinitions = new DestinyDefinitionRepository(typeof(DestinyActivityTypeDefinition));
        private static DestinyDefinitionRepository DestinyArtDyeChannelDefinitions = new DestinyDefinitionRepository(typeof(DestinyArtDyeChannelDefinition));
        private static DestinyDefinitionRepository DestinyArtDyeReferenceDefinitions = new DestinyDefinitionRepository(typeof(DestinyArtDyeReferenceDefinition));
        private static DestinyDefinitionRepository DestinyArtifactDefinitions = new DestinyDefinitionRepository(typeof(DestinyArtifactDefinition));
        private static DestinyDefinitionRepository DestinyBondDefinitions = new DestinyDefinitionRepository(typeof(DestinyBondDefinition));
        private static DestinyDefinitionRepository DestinyBreakerTypeDefinitions = new DestinyDefinitionRepository(typeof(DestinyBreakerTypeDefinition));
        private static DestinyDefinitionRepository DestinyCharacterCustomizationCategoryDefinitions = new DestinyDefinitionRepository(typeof(DestinyCharacterCustomizationCategoryDefinition));
        private static DestinyDefinitionRepository DestinyCharacterCustomizationOptionDefinitions = new DestinyDefinitionRepository(typeof(DestinyCharacterCustomizationOptionDefinition));
        private static DestinyDefinitionRepository DestinyChecklistDefinitions = new DestinyDefinitionRepository(typeof(DestinyChecklistDefinition));
        private static DestinyDefinitionRepository DestinyClassDefinitions = new DestinyDefinitionRepository(typeof(DestinyClassDefinition));
        private static DestinyDefinitionRepository DestinyCollectibleDefinitions = new DestinyDefinitionRepository(typeof(DestinyCollectibleDefinition));
        private static DestinyDefinitionRepository DestinyDamageTypeDefinitions = new DestinyDefinitionRepository(typeof(DestinyDamageTypeDefinition));
        private static DestinyDefinitionRepository DestinyDestinationDefinitions = new DestinyDefinitionRepository(typeof(DestinyDestinationDefinition));
        private static DestinyDefinitionRepository DestinyEnemyRaceDefinitions = new DestinyDefinitionRepository(typeof(DestinyEnemyRaceDefinition));
        private static DestinyDefinitionRepository DestinyEnergyTypeDefinitions = new DestinyDefinitionRepository(typeof(DestinyEnergyTypeDefinition));
        private static DestinyDefinitionRepository DestinyEntitlementOfferDefinitions = new DestinyDefinitionRepository(typeof(DestinyEntitlementOfferDefinition));
        private static DestinyDefinitionRepository DestinyEquipmentSlotDefinitions = new DestinyDefinitionRepository(typeof(DestinyEquipmentSlotDefinition));
        private static DestinyDefinitionRepository DestinyFactionDefinitions = new DestinyDefinitionRepository(typeof(DestinyFactionDefinition));
        private static DestinyDefinitionRepository DestinyGenderDefinitions = new DestinyDefinitionRepository(typeof(DestinyGenderDefinition));
        private static DestinyDefinitionRepository DestinyInventoryBucketDefinitions = new DestinyDefinitionRepository(typeof(DestinyInventoryBucketDefinition));
        private static DestinyDefinitionRepository DestinyInventoryItemDefinitions = new DestinyDefinitionRepository(typeof(DestinyInventoryItemDefinition));
        private static DestinyDefinitionRepository DestinyInventoryItemLiteDefinitions = new DestinyDefinitionRepository(typeof(DestinyInventoryItemLiteDefinition));
        private static DestinyDefinitionRepository DestinyItemCategoryDefinitions = new DestinyDefinitionRepository(typeof(DestinyItemCategoryDefinition));
        private static DestinyDefinitionRepository DestinyItemTierTypeDefinitions = new DestinyDefinitionRepository(typeof(DestinyItemTierTypeDefinition));
        private static DestinyDefinitionRepository DestinyLocationDefinitions = new DestinyDefinitionRepository(typeof(DestinyLocationDefinition));
        private static DestinyDefinitionRepository DestinyLoreDefinitions = new DestinyDefinitionRepository(typeof(DestinyLoreDefinition));
        private static DestinyDefinitionRepository DestinyMaterialRequirementSetDefinitions = new DestinyDefinitionRepository(typeof(DestinyMaterialRequirementSetDefinition));
        private static DestinyDefinitionRepository DestinyMedalTierDefinitions = new DestinyDefinitionRepository(typeof(DestinyMedalTierDefinition));
        private static DestinyDefinitionRepository DestinyMetricDefinitions = new DestinyDefinitionRepository(typeof(DestinyMetricDefinition));
        private static DestinyDefinitionRepository DestinyMilestoneDefinitions = new DestinyDefinitionRepository(typeof(DestinyMilestoneDefinition));
        private static DestinyDefinitionRepository DestinyNodeStepSummaryDefinitions = new DestinyDefinitionRepository(typeof(DestinyNodeStepSummaryDefinition));
        private static DestinyDefinitionRepository DestinyObjectiveDefinitions = new DestinyDefinitionRepository(typeof(DestinyObjectiveDefinition));
        private static DestinyDefinitionRepository DestinyPlaceDefinitions = new DestinyDefinitionRepository(typeof(DestinyPlaceDefinition));
        private static DestinyDefinitionRepository DestinyPlatformBucketMappingDefinitions = new DestinyDefinitionRepository(typeof(DestinyPlatformBucketMappingDefinition));
        private static DestinyDefinitionRepository DestinyPlugSetDefinitions = new DestinyDefinitionRepository(typeof(DestinyPlugSetDefinition));
        private static DestinyDefinitionRepository DestinyPowerCapDefinitions = new DestinyDefinitionRepository(typeof(DestinyPowerCapDefinition));
        private static DestinyDefinitionRepository DestinyPresentationNodeBaseDefinitions = new DestinyDefinitionRepository(typeof(DestinyPresentationNodeBaseDefinition));
        private static DestinyDefinitionRepository DestinyPresentationNodeDefinitions = new DestinyDefinitionRepository(typeof(DestinyPresentationNodeDefinition));
        private static DestinyDefinitionRepository DestinyProgressionDefinitions = new DestinyDefinitionRepository(typeof(DestinyProgressionDefinition));
        private static DestinyDefinitionRepository DestinyProgressionLevelRequirementDefinitions = new DestinyDefinitionRepository(typeof(DestinyProgressionLevelRequirementDefinition));
        private static DestinyDefinitionRepository DestinyProgressionMappingDefinitions = new DestinyDefinitionRepository(typeof(DestinyProgressionMappingDefinition));
        private static DestinyDefinitionRepository DestinyRaceDefinitions = new DestinyDefinitionRepository(typeof(DestinyRaceDefinition));
        private static DestinyDefinitionRepository DestinyRecordDefinitions = new DestinyDefinitionRepository(typeof(DestinyRecordDefinition));
        private static DestinyDefinitionRepository DestinyReportReasonCategoryDefinitions = new DestinyDefinitionRepository(typeof(DestinyReportReasonCategoryDefinition));
        private static DestinyDefinitionRepository DestinyRewardAdjusterPointerDefinitions = new DestinyDefinitionRepository(typeof(DestinyRewardAdjusterPointerDefinition));
        private static DestinyDefinitionRepository DestinyRewardAdjusterProgressionMapDefinitions = new DestinyDefinitionRepository(typeof(DestinyRewardAdjusterProgressionMapDefinition));
        private static DestinyDefinitionRepository DestinyRewardItemListDefinitions = new DestinyDefinitionRepository(typeof(DestinyRewardItemListDefinition));
        private static DestinyDefinitionRepository DestinyRewardMappingDefinitions = new DestinyDefinitionRepository(typeof(DestinyRewardMappingDefinition));
        private static DestinyDefinitionRepository DestinyRewardSheetDefinitions = new DestinyDefinitionRepository(typeof(DestinyRewardSheetDefinition));
        private static DestinyDefinitionRepository DestinyRewardSourceDefinitions = new DestinyDefinitionRepository(typeof(DestinyRewardSourceDefinition));
        private static DestinyDefinitionRepository DestinySackRewardItemListDefinitions = new DestinyDefinitionRepository(typeof(DestinySackRewardItemListDefinition));
        private static DestinyDefinitionRepository DestinySandboxPatternDefinitions = new DestinyDefinitionRepository(typeof(DestinySandboxPatternDefinition));
        private static DestinyDefinitionRepository DestinySandboxPerkDefinitions = new DestinyDefinitionRepository(typeof(DestinySandboxPerkDefinition));
        private static DestinyDefinitionRepository DestinySeasonDefinitions = new DestinyDefinitionRepository(typeof(DestinySeasonDefinition));
        private static DestinyDefinitionRepository DestinySeasonPassDefinitions = new DestinyDefinitionRepository(typeof(DestinySeasonPassDefinition));
        private static DestinyDefinitionRepository DestinySocketCategoryDefinitions = new DestinyDefinitionRepository(typeof(DestinySocketCategoryDefinition));
        private static DestinyDefinitionRepository DestinySocketTypeDefinitions = new DestinyDefinitionRepository(typeof(DestinySocketTypeDefinition));
        private static DestinyDefinitionRepository DestinyStatDefinitions = new DestinyDefinitionRepository(typeof(DestinyStatDefinition));
        private static DestinyDefinitionRepository DestinyStatGroupDefinitions = new DestinyDefinitionRepository(typeof(DestinyStatGroupDefinition));
        private static DestinyDefinitionRepository DestinyTalentGridDefinitions = new DestinyDefinitionRepository(typeof(DestinyTalentGridDefinition));
        private static DestinyDefinitionRepository DestinyTraitCategoryDefinitions = new DestinyDefinitionRepository(typeof(DestinyTraitCategoryDefinition));
        private static DestinyDefinitionRepository DestinyTraitDefinitions = new DestinyDefinitionRepository(typeof(DestinyTraitDefinition));
        private static DestinyDefinitionRepository DestinyUnlockCountMappingDefinitions = new DestinyDefinitionRepository(typeof(DestinyUnlockCountMappingDefinition));
        private static DestinyDefinitionRepository DestinyUnlockDefinitions = new DestinyDefinitionRepository(typeof(DestinyUnlockDefinition));
        private static DestinyDefinitionRepository DestinyUnlockEventDefinitions = new DestinyDefinitionRepository(typeof(DestinyUnlockEventDefinition));
        private static DestinyDefinitionRepository DestinyUnlockExpressionMappingDefinitions = new DestinyDefinitionRepository(typeof(DestinyUnlockExpressionMappingDefinition));
        private static DestinyDefinitionRepository DestinyUnlockValueDefinitions = new DestinyDefinitionRepository(typeof(DestinyUnlockValueDefinition));
        private static DestinyDefinitionRepository DestinyVendorDefinitions = new DestinyDefinitionRepository(typeof(DestinyVendorDefinition));
        private static DestinyDefinitionRepository DestinyVendorGroupDefinitions = new DestinyDefinitionRepository(typeof(DestinyVendorGroupDefinition));

        public static void RegisterDefinitionsTables()
        {
            var type = typeof(DefinitionsCacheRepository);
            var fields = type.GetFields(BindingFlags.NonPublic | BindingFlags.Public | BindingFlags.Static);
            foreach (var info in fields)
            {
                if (info.Name != "Definitions")
                    Definitions.Add(info.Name, info);
            }
        }
        public static async Task LoadAllDataFromDisk(string localManifestPath, string locale, DestinyManifest manifest)
        {
            var Manifest = manifest.JsonWorldComponentContentPaths[locale];
            foreach (var key in Definitions.Keys)
            {
                var definitionName = key[0..^1]; 
                var definitionJson = File.ReadAllText($"{localManifestPath}/JsonWorldComponentContent/{locale}/{definitionName}/{Path.GetFileName(Manifest[definitionName])}");
                var definitionJObjectDictionary = JObject.Parse(definitionJson);
                foreach (var entry in definitionJObjectDictionary)
                {
                    var definitionType = ((DestinyDefinitionRepository)Definitions[key].GetValue(null)).Type;
                    var deserializedDestinyDefinition = (DestinyDefinition)entry.Value.ToObject(definitionType);
                    AddDefinitionToCache(definitionName, deserializedDestinyDefinition);
                }
            }
        }
        public static void AddDefinitionToCache(string definitionName, DestinyDefinition defValue)
        {
            if (Definitions.TryGetValue($"{definitionName}s", out var fieldData))
            {
                var repository = (DestinyDefinitionRepository)fieldData.GetValue(null);
                repository.Add(defValue);
            }
        }
        public static bool TryGetDestinyDefinition(string definitionName, uint key, out DestinyDefinition definition)
        {
            definition = null;
            if (Definitions.TryGetValue($"{definitionName}s", out var fieldData))
            {
                var repository = (DestinyDefinitionRepository)fieldData.GetValue(null);
                if (repository.TryGetDefinition(key, out definition))
                {
                    return true;
                }
                else
                    return false;
            }
            else
                return false;
        }
        public static List<DestinyDefinition> GetAllDefinitions(string definitionName)
        {
            if (Definitions.TryGetValue($"{definitionName}s", out var fieldData))
            {
                var repository = (DestinyDefinitionRepository)fieldData.GetValue(null);
                    return repository.GetAllAsList();
            }
            else
                throw new Exception();
        }
    }
}
