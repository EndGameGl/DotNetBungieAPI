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
using BungieNetCoreAPI.Destiny.Definitions.InventoryItems;
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
