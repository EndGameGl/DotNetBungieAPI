using NetBungieApi.Destiny.Profile.Components;
using NetBungieApi.Destiny.Profile.Components.Contracts;
using Newtonsoft.Json;
using System.Collections.Generic;
using System.Collections.ObjectModel;

namespace NetBungieApi.Destiny.Profile
{
    public class DestinyComponentProfileResponse
    {
        private DestinyProfileComponent<ProfileDataComponent> _profile;
        private DestinyProfileComponent<VendorReceiptsDataComponent> _vendorReceipts;
        private DestinyProfileComponent<DestinyInventoryComponent> _profileInventory;
        private DestinyProfileComponent<DestinyInventoryComponent> _profileCurrencies;
        private DestinyProfileComponent<DestinyProfileProgressionComponent> _profileProgression;
        private DestinyProfileComponent<DestinyPlatformSilverComponent> _platformSilver;
        private DestinyProfileComponent<Dictionary<long, DestinyCharacterComponent>> _characters;
        private DestinyProfileComponent<Dictionary<long, DestinyInventoryComponent>> _characterInventories;
        private DestinyProfileComponent<Dictionary<long, DestinyCharacterProgressionComponent>> _characterProgressions;
        private DestinyProfileComponent<Dictionary<long, DestinyCharacterRenderComponent>> _characterRenderData;
        private DestinyProfileComponent<Dictionary<long, DestinyCharacterActivitiesComponent>> _characterActivities;
        private DestinyProfileComponent<Dictionary<long, DestinyInventoryComponent>> _characterEquipment;
        private DestinyItemSetComponent _itemComponents;
        private Dictionary<long, СharacterUninstancedItemsComponent> _characterUninstancedItemComponents;
        private DestinyProfileComponent<Dictionary<long, DestinyKiosksComponent>> _characterKiosks;
        private DestinyProfileComponent<DestinyKiosksComponent> _profileKiosks;
        private DestinyProfileComponent<Dictionary<long, DestinyCurrenciesComponent>> _characterCurrencyLookups;
        private DestinyProfileComponent<Dictionary<long, DestinyPresentationNodesComponent>> _characterPresentationNodes;
        private DestinyProfileComponent<Dictionary<long, DestinyCollectiblesComponent>> _characterCollectibles;
        private DestinyProfileComponent<DestinyProfileCollectiblesComponent> _profileCollectibles;
        private DestinyProfileComponent<Dictionary<long, DestinyCharacterRecordsComponent>> _characterRecords;
        private DestinyProfileComponent<DestinyProfileRecordsComponent> _profileRecords;
        private DestinyProfileComponent<DestinyProfileTransitoryComponent> _profileTransitoryData;
        private DestinyProfileComponent<DestinyMetricsComponent> _metrics;
        private DestinyProfileComponent<Dictionary<long, DestinyPlugSetsComponent>> _characterPlugSets;
        private DestinyProfileComponent<DestinyPlugSetsComponent> _profilePlugSets;
        [JsonConstructor]
        internal DestinyComponentProfileResponse(
            DestinyProfileComponent<ProfileDataComponent> profile,
            DestinyProfileComponent<VendorReceiptsDataComponent> vendorReceipts,
            DestinyProfileComponent<DestinyInventoryComponent> profileInventory,
            DestinyProfileComponent<DestinyInventoryComponent> profileCurrencies,
            DestinyProfileComponent<DestinyProfileProgressionComponent> profileProgression,
            DestinyProfileComponent<DestinyPlatformSilverComponent> platformSilver,
            DestinyProfileComponent<Dictionary<long, DestinyCharacterComponent>> characters,
            DestinyProfileComponent<Dictionary<long, DestinyInventoryComponent>> characterInventories,
            DestinyProfileComponent<Dictionary<long, DestinyCharacterProgressionComponent>> characterProgressions,
            DestinyProfileComponent<Dictionary<long, DestinyCharacterRenderComponent>> characterRenderData,
            DestinyProfileComponent<Dictionary<long, DestinyCharacterActivitiesComponent>> characterActivities,
            DestinyProfileComponent<Dictionary<long, DestinyInventoryComponent>> characterEquipment,
            DestinyItemSetComponent itemComponents,
            Dictionary<long, СharacterUninstancedItemsComponent> characterUninstancedItemComponents,
            DestinyProfileComponent<Dictionary<long, DestinyKiosksComponent>> characterKiosks,
            DestinyProfileComponent<DestinyKiosksComponent> profileKiosks,
            DestinyProfileComponent<Dictionary<long, DestinyCurrenciesComponent>> characterCurrencyLookups,
            DestinyProfileComponent<Dictionary<long, DestinyPresentationNodesComponent>> characterPresentationNodes,
            DestinyProfileComponent<Dictionary<long, DestinyCollectiblesComponent>> characterCollectibles,
            DestinyProfileComponent<DestinyProfileCollectiblesComponent> profileCollectibles,
            DestinyProfileComponent<Dictionary<long, DestinyCharacterRecordsComponent>> characterRecords,
            DestinyProfileComponent<DestinyProfileRecordsComponent> profileRecords,
            DestinyProfileComponent<DestinyProfileTransitoryComponent> profileTransitoryData,
            DestinyProfileComponent<DestinyMetricsComponent> metrics,
            DestinyProfileComponent<Dictionary<long, DestinyPlugSetsComponent>> characterPlugSets,
            DestinyProfileComponent<DestinyPlugSetsComponent> profilePlugSets)
        {
            _profile = profile;
            _vendorReceipts = vendorReceipts;
            _profileInventory = profileInventory;
            _profileCurrencies = profileCurrencies;
            _profileProgression = profileProgression;
            _platformSilver = platformSilver;
            _characters = characters;
            _characterInventories = characterInventories;
            _characterProgressions = characterProgressions;
            _characterRenderData = characterRenderData;
            _characterActivities = characterActivities;
            _characterEquipment = characterEquipment;
            _itemComponents = itemComponents;
            _characterUninstancedItemComponents = characterUninstancedItemComponents;
            _characterKiosks = characterKiosks;
            _profileKiosks = profileKiosks;
            _characterCurrencyLookups = characterCurrencyLookups;
            _characterPresentationNodes = characterPresentationNodes;
            _characterCollectibles = characterCollectibles;
            _profileCollectibles = profileCollectibles;
            _characterRecords = characterRecords;
            _profileRecords = profileRecords;
            _profileTransitoryData = profileTransitoryData;
            _metrics = metrics;
            _characterPlugSets = characterPlugSets;
            _profilePlugSets = profilePlugSets;
        }

        public bool TryGetProfile(out DestinyProfileComponent<ProfileDataComponent> data)
        {
            data = _profile;
            return data != null;
        }
        public bool TryGetVendorReceipts(out DestinyProfileComponent<VendorReceiptsDataComponent> data)
        {
            data = _vendorReceipts;
            return data != null;
        }
        public bool TryGetProfileInventory(out DestinyProfileComponent<DestinyInventoryComponent> data)
        {
            data = _profileInventory;
            return data != null;
        }
        public bool TryGetProfileCurrencies(out DestinyProfileComponent<DestinyInventoryComponent> data)
        {
            data = _profileCurrencies;
            return data != null;
        }
        public bool TryGetProfileProgression(out DestinyProfileComponent<DestinyProfileProgressionComponent> data)
        {
            data = _profileProgression;
            return data != null;
        }
        public bool TryGetPlatformSilver(out DestinyProfileComponent<DestinyPlatformSilverComponent> data)
        {
            data = _platformSilver;
            return data != null;
        }
        public bool TryGetCharacters(out DestinyProfileComponent<Dictionary<long, DestinyCharacterComponent>> data)
        {
            data = _characters;
            return data != null;
        }
        public bool TryGetCharacterInventories(out DestinyProfileComponent<Dictionary<long, DestinyInventoryComponent>> data)
        {
            data = _characterInventories;
            return data != null;
        }
        public bool TryGetCharacterProgressions(out DestinyProfileComponent<Dictionary<long, DestinyCharacterProgressionComponent>> data)
        {
            data = _characterProgressions;
            return data != null;
        }
        public bool TryGetCharacterRenderData(out DestinyProfileComponent<Dictionary<long, DestinyCharacterRenderComponent>> data)
        {
            data = _characterRenderData;
            return data != null;
        }
        public bool TryGetCharacterActivities(out DestinyProfileComponent<Dictionary<long, DestinyCharacterActivitiesComponent>> data)
        {
            data = _characterActivities;
            return data != null;
        }
        public bool TryGetCharacterEquipment(out DestinyProfileComponent<Dictionary<long, DestinyInventoryComponent>> data)
        {
            data = _characterEquipment;
            return data != null;
        }
        public bool TryGetItemComponents(out DestinyItemSetComponent data)
        {
            data = _itemComponents;
            return data != null;
        }
        public bool TryGetCharacterUninstancedItemComponents(out Dictionary<long, СharacterUninstancedItemsComponent> data)
        {
            data = _characterUninstancedItemComponents;
            return data != null;
        }
        public bool TryGetCharacterKiosks(out DestinyProfileComponent<Dictionary<long, DestinyKiosksComponent>> data)
        {
            data = _characterKiosks;
            return data != null;
        }
        public bool TryGetProfileKiosks(out DestinyProfileComponent<DestinyKiosksComponent> data)
        {
            data = _profileKiosks;
            return data != null;
        }
        public bool TryGetCharacterCurrencyLookups(out DestinyProfileComponent<Dictionary<long, DestinyCurrenciesComponent>> data)
        {
            data = _characterCurrencyLookups;
            return data != null;
        }
        public bool TryGetCharacterPresentationNodes(out DestinyProfileComponent<Dictionary<long, DestinyPresentationNodesComponent>> data)
        {
            data = _characterPresentationNodes;
            return data != null;
        }
        public bool TryGetCharacterCollectibles(out DestinyProfileComponent<Dictionary<long, DestinyCollectiblesComponent>> data)
        {
            data = _characterCollectibles;
            return data != null;
        }
        public bool TryGetProfileCollectibles(out DestinyProfileComponent<DestinyProfileCollectiblesComponent> data)
        {
            data = _profileCollectibles;
            return data != null;
        }
        public bool TryGetCharacterRecords(out DestinyProfileComponent<Dictionary<long, DestinyCharacterRecordsComponent>> data)
        {
            data = _characterRecords;
            return data != null;
        }
        public bool TryGetProfileRecords(out DestinyProfileComponent<DestinyProfileRecordsComponent> data)
        {
            data = _profileRecords;
            return data != null;
        }
        public bool TryGetProfileTransitoryData(out DestinyProfileComponent<DestinyProfileTransitoryComponent> data)
        {
            data = _profileTransitoryData;
            return data != null;
        }
        public bool TryGetMetrics(out DestinyProfileComponent<DestinyMetricsComponent> data)
        {
            data = _metrics;
            return data != null;
        }
        public bool TryGetCharacterPlugSets(out DestinyProfileComponent<Dictionary<long, DestinyPlugSetsComponent>> data)
        {
            data = _characterPlugSets;
            return data != null;
        }
        public bool TryGetProfilePlugSets(out DestinyProfileComponent<DestinyPlugSetsComponent> data)
        {
            data = _profilePlugSets;
            return data != null;
        }
    }
}
