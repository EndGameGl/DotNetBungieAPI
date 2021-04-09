using NetBungieAPI.Models.Destiny.Components;
using System.Text.Json.Serialization;

namespace NetBungieAPI.Models.Destiny.Responses
{
    public sealed record DestinyProfileResponse
    {
        [JsonPropertyName("vendorReceipts")]
        public SingleComponentResponseOfDestinyVendorReceiptsComponent VendorReceipts { get; init; }
        [JsonPropertyName("profileInventory")]
        public SingleComponentResponseOfDestinyInventoryComponent ProfileInventory { get; init; }
        [JsonPropertyName("profileCurrencies")]
        public SingleComponentResponseOfDestinyInventoryComponent ProfileCurrencies { get; init; }
        [JsonPropertyName("profile")]
        public SingleComponentResponseOfDestinyProfileComponent Profile { get; init; }
        [JsonPropertyName("platformSilver")]
        public SingleComponentResponseOfDestinyPlatformSilverComponent PlatformSilver { get; init; }
        [JsonPropertyName("profileKiosks")]
        public SingleComponentResponseOfDestinyKiosksComponent ProfileKiosks { get; init; }
        [JsonPropertyName("profilePlugSets")]
        public SingleComponentResponseOfDestinyPlugSetsComponent ProfilePlugSets { get; init; }
        [JsonPropertyName("profileProgression")]
        public SingleComponentResponseOfDestinyProfileProgressionComponent ProfileProgression { get; init; }
        [JsonPropertyName("profilePresentationNodes")]
        public SingleComponentResponseOfDestinyPresentationNodesComponent ProfilePresentationNodes { get; init; }
        [JsonPropertyName("profileRecords")]
        public SingleComponentResponseOfDestinyProfileRecordsComponent ProfileRecords { get; init; }
        [JsonPropertyName("profileCollectibles")]
        public SingleComponentResponseOfDestinyProfileCollectiblesComponent ProfileCollectibles { get; init; }
        [JsonPropertyName("profileTransitoryData")]
        public SingleComponentResponseOfDestinyProfileTransitoryComponent ProfileTransitoryData { get; init; }
        [JsonPropertyName("metrics")]
        public SingleComponentResponseOfDestinyMetricsComponent Metrics { get; init; }
        [JsonPropertyName("characters")]
        public DictionaryComponentResponseOfint64AndDestinyCharacterComponent Characters { get; init; }
        [JsonPropertyName("characterInventories")]
        public DictionaryComponentResponseOfint64AndDestinyInventoryComponent CharacterInventories { get; init; }
        [JsonPropertyName("characterProgressions")]
        public DictionaryComponentResponseOfint64AndDestinyCharacterProgressionComponent CharacterProgressions { get; init; }


        private DestinyProfileComponent<Dictionary<long, DestinyCharacterRecordsComponent>> _characterRecords;
        private DestinyProfileComponent<Dictionary<long, DestinyCharacterRenderComponent>> _characterRenderData;
        private DestinyProfileComponent<Dictionary<long, DestinyCharacterActivitiesComponent>> _characterActivities;
        private DestinyProfileComponent<Dictionary<long, DestinyInventoryComponent>> _characterEquipment;
        private DestinyItemSetComponent _itemComponents;
        private Dictionary<long, СharacterUninstancedItemsComponent> _characterUninstancedItemComponents;
        private DestinyProfileComponent<Dictionary<long, DestinyKiosksComponent>> _characterKiosks;
        private DestinyProfileComponent<Dictionary<long, DestinyCurrenciesComponent>> _characterCurrencyLookups;
        private DestinyProfileComponent<Dictionary<long, DestinyPresentationNodesComponent>> _characterPresentationNodes;
        private DestinyProfileComponent<Dictionary<long, DestinyCollectiblesComponent>> _characterCollectibles;
        private DestinyProfileComponent<Dictionary<long, DestinyPlugSetsComponent>> _characterPlugSets;
    }
}
