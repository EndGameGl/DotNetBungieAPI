using NetBungieApi.Destiny.Profile.Components.Contracts;
using Newtonsoft.Json;
using System.Collections.Generic;

namespace NetBungieApi.Destiny.Profile
{
    public class DestinyComponentCharacterResponse
    {
        private DestinyProfileComponent<DestinyInventoryComponent> _inventory;
        private DestinyProfileComponent<DestinyCharacterComponent> _character;
        private DestinyProfileComponent<DestinyCharacterProgressionComponent> _progressions;
        private DestinyProfileComponent<DestinyCharacterRenderComponent> _renderData;
        private DestinyProfileComponent<DestinyCharacterActivitiesComponent> _activities;
        private DestinyProfileComponent<DestinyInventoryComponent> _equipment;
        private DestinyProfileComponent<DestinyKiosksComponent> _kiosks;
        private DestinyProfileComponent<DestinyPlugSetsComponent> _plugSets;
        private DestinyProfileComponent<DestinyPresentationNodesComponent> _presentationNodes;
        private DestinyProfileComponent<DestinyCharacterRecordsComponent> _records;
        private DestinyProfileComponent<DestinyCollectiblesComponent> _collectibles;
        private DestinyItemSetComponent _itemComponents;
        private СharacterUninstancedItemsComponent _uninstancedItemComponents;
        private DestinyProfileComponent<DestinyCurrenciesComponent> _currencyLookups;

        [JsonConstructor]
        internal DestinyComponentCharacterResponse(
            DestinyProfileComponent<DestinyInventoryComponent> inventory,
            DestinyProfileComponent<DestinyCharacterComponent> character,
            DestinyProfileComponent<DestinyCharacterProgressionComponent> progressions,
            DestinyProfileComponent<DestinyCharacterRenderComponent> renderData,
            DestinyProfileComponent<DestinyCharacterActivitiesComponent> activities,
            DestinyProfileComponent<DestinyInventoryComponent> equipment,
            DestinyProfileComponent<DestinyKiosksComponent> kiosks,
            DestinyProfileComponent<DestinyPlugSetsComponent> plugSets,
            DestinyProfileComponent<DestinyPresentationNodesComponent> presentationNodes,
            DestinyProfileComponent<DestinyCharacterRecordsComponent> records,
            DestinyProfileComponent<DestinyCollectiblesComponent> collectibles,
            DestinyItemSetComponent itemComponents,
            СharacterUninstancedItemsComponent uninstancedItemComponents,
            DestinyProfileComponent<DestinyCurrenciesComponent> currencyLookups)
        {
            _inventory = inventory;
            _character = character;
            _progressions = progressions;
            _renderData = renderData;
            _activities = activities;
            _equipment = equipment;
            _kiosks = kiosks;
            _plugSets = plugSets;
            _presentationNodes = presentationNodes;
            _records = records;
            _collectibles = collectibles;
            _itemComponents = itemComponents;
            _uninstancedItemComponents = uninstancedItemComponents;
            _currencyLookups = currencyLookups;
        }

        public bool TryGetInventory(out DestinyProfileComponent<DestinyInventoryComponent> data)
        {
            data = _inventory;
            return data != null;
        }
        public bool TryGetCharacter(out DestinyProfileComponent<DestinyCharacterComponent> data)
        {
            data = _character;
            return data != null;
        }
        public bool TryGetProgressions(out DestinyProfileComponent<DestinyCharacterProgressionComponent> data)
        {
            data = _progressions;
            return data != null;
        }
        public bool TryGetRenderData(out DestinyProfileComponent<DestinyCharacterRenderComponent> data)
        {
            data = _renderData;
            return data != null;
        }
        public bool TryGetActivities(out DestinyProfileComponent<DestinyCharacterActivitiesComponent> data)
        {
            data = _activities;
            return data != null;
        }
        public bool TryGetEquipment(out DestinyProfileComponent<DestinyInventoryComponent> data)
        {
            data = _equipment;
            return data != null;
        }
        public bool TryGetKiosks(out DestinyProfileComponent<DestinyKiosksComponent> data)
        {
            data = _kiosks;
            return data != null;
        }
        public bool TryGetPlugSets(out DestinyProfileComponent<DestinyPlugSetsComponent> data)
        {
            data = _plugSets;
            return data != null;
        }
        public bool TryGetPresentationNodes(out DestinyProfileComponent<DestinyPresentationNodesComponent> data)
        {
            data = _presentationNodes;
            return data != null;
        }
        public bool TryGetRecords(out DestinyProfileComponent<DestinyCharacterRecordsComponent> data)
        {
            data = _records;
            return data != null;
        }
        public bool TryGetCollectibles(out DestinyProfileComponent<DestinyCollectiblesComponent> data)
        {
            data = _collectibles;
            return data != null;
        }
        public bool TryGetUninstancedItemComponents(out СharacterUninstancedItemsComponent data)
        {
            data = _uninstancedItemComponents;
            return data != null;
        }
        public bool TryGetCurrencyLookups(out DestinyProfileComponent<DestinyCurrenciesComponent> data)
        {
            data = _currencyLookups;
            return data != null;
        }
        public bool TryGetItemInstances(out DestinyProfileComponent<Dictionary<long, DestinyItemInstanceComponent>> data)
        {
            data = default;
            return _itemComponents != null && _itemComponents.TryGetInstances(out data); 
        }
        public bool TryGetItemObjectives(out DestinyProfileComponent<Dictionary<long, DestinyItemObjectivesComponent>> data)
        {
            data = default;
            return _itemComponents != null && _itemComponents.TryGetObjectives(out data);
        }
        public bool TryGetItemPerks(out DestinyProfileComponent<Dictionary<long, DestinyItemPerksComponent>> data)
        {
            data = default;
            return _itemComponents != null && _itemComponents.TryGetPerks(out data);
        }
        public bool TryGetItemRenderData(out DestinyProfileComponent<Dictionary<long, DestinyItemRenderComponent>> data)
        {
            data = default;
            return _itemComponents != null && _itemComponents.TryGetRenderData(out data);
        }
        public bool TryGetItemStats(out DestinyProfileComponent<Dictionary<long, DestinyItemStatsComponent>> data)
        {
            data = default;
            return _itemComponents != null && _itemComponents.TryGetStats(out data);
        }
        public bool TryGetItemSockets(out DestinyProfileComponent<Dictionary<long, DestinyItemSocketsComponent>> data)
        {
            data = default;
            return _itemComponents != null && _itemComponents.TryGetSockets(out data);
        }
        public bool TryGetItemTalentGrids(out DestinyProfileComponent<Dictionary<long, DestinyItemTalentGridComponent>> data)
        {
            data = default;
            return _itemComponents != null && _itemComponents.TryGetTalentGrids(out data);
        }
        public bool TryGetItemPlugStates(out DestinyProfileComponent<Dictionary<uint, DestinyItemPlugComponent>> data)
        {
            data = default;
            return _itemComponents != null && _itemComponents.TryGetPlugStates(out data);
        }
        public bool TryGetItemPlugObjectives(out DestinyProfileComponent<Dictionary<long, DestinyItemPlugObjectivesComponent>> data)
        {
            data = default;
            return _itemComponents != null && _itemComponents.TryGetPlugObjectives(out data);
        }
        public bool TryGetItemReusablePlugs(out DestinyProfileComponent<Dictionary<long, DestinyItemReusablePlugsComponent>> data)
        {
            data = default;
            return _itemComponents != null && _itemComponents.TryGetReusablePlugs(out data);
        }
    }
}
