using BungieNetCoreAPI.Destiny.Profile.Components;
using BungieNetCoreAPI.Destiny.Profile.Components.Contracts;
using Newtonsoft.Json;
using System.Collections.Generic;
using System.Collections.ObjectModel;

namespace BungieNetCoreAPI.Destiny.Profile
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

    }
}
