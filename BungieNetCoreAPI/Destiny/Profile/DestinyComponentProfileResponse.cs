using BungieNetCoreAPI.Destiny.Profile.Components;
using BungieNetCoreAPI.Destiny.Profile.Components.Contracts;
using Newtonsoft.Json;
using System.Collections.Generic;
using System.Collections.ObjectModel;

namespace BungieNetCoreAPI.Destiny.Profile
{
    public class DestinyComponentProfileResponse
    {
        private ReadOnlyDictionary<DestinyComponentType, IProfileComponent> Components { get; }
        private ReadOnlyDictionary<long, ComponentСharacterUninstancedItems> CharacterUninstancedItemComponents { get; }
        private DestinyProfileComponent<Dictionary<long, ComponentDestinyKiosks>> CharacterKiosks { get; }
        private DestinyProfileComponent<ComponentDestinyKiosks> ProfileKiosks { get; }
        private DestinyProfileComponent<Dictionary<long, ComponentDestinyCollectibles>> CharacterCollectibles { get; }
        private DestinyProfileComponent<ComponentDestinyProfileCollectibles> ProfileCollectibles { get; }
        private DestinyProfileComponent<Dictionary<long, ComponentDestinyCharacterRecords>> CharacterRecords { get; }
        private DestinyProfileComponent<ComponentDestinyProfileRecords> ProfileRecords { get; }
        private DestinyProfileComponent<Dictionary<long, ComponentDestinyPlugSets>> CharacterPlugSets { get; }
        private DestinyProfileComponent<ComponentDestinyPlugSets> ProfilePlugSets { get; }
        [JsonConstructor]
        internal DestinyComponentProfileResponse(
            DestinyProfileComponent<ComponentProfileData> profile,
            DestinyProfileComponent<ComponentVendorReceiptsData> vendorReceipts,
            DestinyProfileComponent<ComponentDestinyInventory> profileInventory,
            DestinyProfileComponent<ComponentDestinyInventory> profileCurrencies,
            DestinyProfileComponent<ComponentDestinyProfileProgression> profileProgression,
            DestinyProfileComponent<ComponentDestinyPlatformSilver> platformSilver,
            DestinyProfileComponent<Dictionary<long, ComponentDestinyCharacter>> characters,
            DestinyProfileComponent<Dictionary<long, ComponentDestinyInventory>> characterInventories,
            DestinyProfileComponent<Dictionary<long, ComponentDestinyCharacterProgression>> characterProgressions,
            DestinyProfileComponent<Dictionary<long, ComponentDestinyCharacterRender>> characterRenderData,
            DestinyProfileComponent<Dictionary<long, ComponentDestinyCharacterActivities>> characterActivities,
            DestinyProfileComponent<Dictionary<long, ComponentDestinyInventory>> characterEquipment,
            ComponentDestinyItemSet itemComponents,
            Dictionary<long, ComponentСharacterUninstancedItems> characterUninstancedItemComponents,
            DestinyProfileComponent<Dictionary<long, ComponentDestinyKiosks>> characterKiosks,
            DestinyProfileComponent<ComponentDestinyKiosks> profileKiosks,
            DestinyProfileComponent<Dictionary<long, ComponentDestinyCurrencies>> characterCurrencyLookups,
            DestinyProfileComponent<Dictionary<long, ComponentDestinyPresentationNodes>> characterPresentationNodes,
            DestinyProfileComponent<Dictionary<long, ComponentDestinyCollectibles>> characterCollectibles,
            DestinyProfileComponent<ComponentDestinyProfileCollectibles> profileCollectibles,
            DestinyProfileComponent<Dictionary<long, ComponentDestinyCharacterRecords>> characterRecords,
            DestinyProfileComponent<ComponentDestinyProfileRecords> profileRecords,
            DestinyProfileComponent<ComponentDestinyProfileTransitory> profileTransitoryData,
            DestinyProfileComponent<ComponentDestinyMetrics> metrics,
            DestinyProfileComponent<Dictionary<long, ComponentDestinyPlugSets>> characterPlugSets,
            DestinyProfileComponent<ComponentDestinyPlugSets> profilePlugSets)
        {
            var components = new Dictionary<DestinyComponentType, IProfileComponent>();

            if (profile != null)
                components.Add(DestinyComponentType.Profiles, profile);
            if (vendorReceipts != null)
                components.Add(DestinyComponentType.VendorReceipts, vendorReceipts);
            if (profileInventory != null)
                components.Add(DestinyComponentType.ProfileInventories, profileInventory);
            if (profileCurrencies != null)
                components.Add(DestinyComponentType.ProfileCurrencies, profileCurrencies);
            if (profileProgression != null)
                components.Add(DestinyComponentType.ProfileProgression, profileProgression);
            if (platformSilver != null)
                components.Add(DestinyComponentType.PlatformSilver, platformSilver);
            if (characters != null)
                components.Add(DestinyComponentType.Characters, characters);
            if (characterInventories != null)
                components.Add(DestinyComponentType.CharacterInventories, characterInventories);
            if (characterProgressions != null)
                components.Add(DestinyComponentType.CharacterProgressions, characterProgressions);
            if (characterRenderData != null)
                components.Add(DestinyComponentType.CharacterRenderData, characterRenderData);
            if (characterActivities != null)
                components.Add(DestinyComponentType.CharacterActivities, characterActivities);
            if (characterEquipment != null)
                components.Add(DestinyComponentType.CharacterEquipment, characterEquipment);
            if (itemComponents != null)
                foreach (var itemComponent in itemComponents.Components)
                    components.Add(itemComponent.Key, itemComponent.Value);
            if (characterUninstancedItemComponents != null)
                CharacterUninstancedItemComponents = characterUninstancedItemComponents.AsReadOnlyDictionaryOrEmpty();
            CharacterKiosks = characterKiosks;
            ProfileKiosks = profileKiosks;
            if (characterCurrencyLookups != null)
                components.Add(DestinyComponentType.CurrencyLookups, characterCurrencyLookups);
            if (characterPresentationNodes != null)
                components.Add(DestinyComponentType.PresentationNodes, characterPresentationNodes);
            CharacterCollectibles = characterCollectibles;
            ProfileCollectibles = profileCollectibles;
            CharacterRecords = characterRecords;
            ProfileRecords = profileRecords;
            if (profileTransitoryData != null)
                components.Add(DestinyComponentType.Transitory, profileTransitoryData);
            if (metrics != null)
                components.Add(DestinyComponentType.Metrics, metrics);
            CharacterPlugSets = characterPlugSets;
            ProfilePlugSets = profilePlugSets;

            Components = new ReadOnlyDictionary<DestinyComponentType, IProfileComponent>(components);
        }

        private bool TryGetComponent<T>(DestinyComponentType type, out T component)
        {
            component = default;
            if (Components.TryGetValue(type, out var foundComponent))
            {
                component = ((DestinyProfileComponent<T>)foundComponent).Data;
                return true;
            }
            else
                return false;
        }
        public bool TryGetProfileData(out DestinyProfileComponent<ComponentProfileData> data)
            => TryGetComponent(DestinyComponentType.Profiles, out data);
        public bool TryGetVendorReceipts(out DestinyProfileComponent<ComponentVendorReceiptsData> data)
            => TryGetComponent(DestinyComponentType.VendorReceipts, out data);
        public bool TryGetProfileInventory(out DestinyProfileComponent<ComponentDestinyInventory> data)
            => TryGetComponent(DestinyComponentType.ProfileInventories, out data);
        public bool TryGetProfileCurrencies(out DestinyProfileComponent<ComponentDestinyInventory> data)
            => TryGetComponent(DestinyComponentType.ProfileCurrencies, out data);
        public bool TryGetProfileProgressions(out DestinyProfileComponent<ComponentDestinyProfileProgression> data)
            => TryGetComponent(DestinyComponentType.ProfileProgression, out data);
        public bool TryGetPlatformSilver(out DestinyProfileComponent<ComponentDestinyPlatformSilver> data)
            => TryGetComponent(DestinyComponentType.PlatformSilver, out data);
        public bool TryGetCharacters(out DestinyProfileComponent<Dictionary<long, ComponentDestinyCharacter>> data)
            => TryGetComponent(DestinyComponentType.Characters, out data);
        public bool TryGetCharacterInventories(out DestinyProfileComponent<Dictionary<long, ComponentDestinyInventory>> data)
            => TryGetComponent(DestinyComponentType.CharacterInventories, out data);
        public bool TryGetCharacterProgressions(out DestinyProfileComponent<Dictionary<long, ComponentDestinyCharacterProgression>> data)
            => TryGetComponent(DestinyComponentType.CharacterProgressions, out data);
        public bool TryGetCharacterRenderData(out DestinyProfileComponent<Dictionary<long, ComponentDestinyCharacterRender>> data)
            => TryGetComponent(DestinyComponentType.CharacterRenderData, out data);
        public bool TryGetCharacterActivities(out DestinyProfileComponent<Dictionary<long, ComponentDestinyCharacterActivities>> data)
            => TryGetComponent(DestinyComponentType.CharacterActivities, out data);
        public bool TryGetCharacterEquipment(out DestinyProfileComponent<Dictionary<long, ComponentDestinyInventory>> data)
            => TryGetComponent(DestinyComponentType.CharacterEquipment, out data);
        public bool TryGetItemInstances(out DestinyProfileComponent<Dictionary<long, ComponentDestinyItemInstance>> data)
            => TryGetComponent(DestinyComponentType.ItemInstances, out data);
        public bool TryGetItemObjectives(out DestinyProfileComponent<Dictionary<long, ComponentDestinyItemObjectives>> data)
            => TryGetComponent(DestinyComponentType.ItemObjectives, out data);
        public bool TryGetItemPerks(out DestinyProfileComponent<Dictionary<long, ComponentDestinyItemPerks>> data)
            => TryGetComponent(DestinyComponentType.ItemPerks, out data);
        public bool TryGetItemRenderData(out DestinyProfileComponent<Dictionary<long, ComponentDestinyItemRender>> data)
            => TryGetComponent(DestinyComponentType.ItemRenderData, out data);
        public bool TryGetItemStats(out DestinyProfileComponent<Dictionary<long, ComponentDestinyItemStats>> data)
            => TryGetComponent(DestinyComponentType.ItemStats, out data);
        public bool TryGetItemSockets(out DestinyProfileComponent<Dictionary<long, ComponentDestinyItemSockets>> data)
            => TryGetComponent(DestinyComponentType.ItemSockets, out data);
        public bool TryGetItemTalentGrids(out DestinyProfileComponent<Dictionary<long, ComponentDestinyItemTalentGrid>> data)
         => TryGetComponent(DestinyComponentType.ItemTalentGrids, out data);
        public bool TryGetItemCommonData(out ReadOnlyDictionary<long, ComponentСharacterUninstancedItems> data)
        {
            data = CharacterUninstancedItemComponents;
            return data != null;
        }
        public bool TryGetItemPlugStates(out DestinyProfileComponent<Dictionary<uint, ComponentDestinyItemPlug>> data)
         => TryGetComponent(DestinyComponentType.ItemTalentGrids, out data);
        public bool TryGetItemPlugObjectives(out DestinyProfileComponent<Dictionary<long, ComponentDestinyItemPlugObjectives>> data)
         => TryGetComponent(DestinyComponentType.ItemPlugObjectives, out data);
        public bool TryGetItemReusablePlugs(out DestinyProfileComponent<Dictionary<long, ComponentDestinyItemReusablePlugs>> data)
         => TryGetComponent(DestinyComponentType.ItemReusablePlugs, out data);
        public bool TryGetCharacterKiosks(out DestinyProfileComponent<Dictionary<long, ComponentDestinyKiosks>> data)
        {
            data = CharacterKiosks;
            return data != null;
        }
        public bool TryGetProfileiosks(out DestinyProfileComponent<ComponentDestinyKiosks> data)
        {
            data = ProfileKiosks;
            return data != null;
        }
        public bool TryGetCharacterCurrencyLookups(out DestinyProfileComponent<Dictionary<long, ComponentDestinyCurrencies>> data)
         => TryGetComponent(DestinyComponentType.CurrencyLookups, out data);
        public bool TryGetCharacterPresentationNodes(out DestinyProfileComponent<Dictionary<long, ComponentDestinyPresentationNodes>> data)
         => TryGetComponent(DestinyComponentType.PresentationNodes, out data);
        public bool TryGetCharacterCollectibles(out DestinyProfileComponent<Dictionary<long, ComponentDestinyCollectibles>> data)
        {
            data = CharacterCollectibles;
            return data != null;
        }
        public bool TryGetProfileCollectibles(out DestinyProfileComponent<ComponentDestinyProfileCollectibles> data)
        {
            data = ProfileCollectibles;
            return data != null;
        }
        public bool TryGetCharacterRecords(out DestinyProfileComponent<Dictionary<long, ComponentDestinyCharacterRecords>> data)
        {
            data = CharacterRecords;
            return data != null;
        }
        public bool TryGetProfileRecords(out DestinyProfileComponent<ComponentDestinyProfileRecords> data)
        {
            data = ProfileRecords;
            return data != null;
        }
        public bool TryGetProfileTransitoryData(out DestinyProfileComponent<ComponentDestinyProfileTransitory> data)
         => TryGetComponent(DestinyComponentType.Transitory, out data);
        public bool TryGetMetrics(out DestinyProfileComponent<ComponentDestinyMetrics> data)
         => TryGetComponent(DestinyComponentType.Metrics, out data);
        public bool TryGetCharactherPlugSets(out DestinyProfileComponent<Dictionary<long, ComponentDestinyPlugSets>> data)
        {
            data = CharacterPlugSets;
            return data != null;
        }
        public bool TryGetProfilePlugSets(out DestinyProfileComponent<ComponentDestinyPlugSets> data)
        {
            data = ProfilePlugSets;
            return data != null;
        }
    }
}
