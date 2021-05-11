using NetBungieAPI.Models.Destiny.Components;
using System.Collections.ObjectModel;
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

        [JsonPropertyName("profile")] public SingleComponentResponseOfDestinyProfileComponent Profile { get; init; }

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

        [JsonPropertyName("metrics")] public SingleComponentResponseOfDestinyMetricsComponent Metrics { get; init; }

        [JsonPropertyName("profileStringVariables")]
        public SingleComponentResponseOfDestinyStringVariablesComponent ProfileStringVariables { get; init; }

        [JsonPropertyName("characters")]
        public DictionaryComponentResponseOfint64AndDestinyCharacterComponent Characters { get; init; }

        [JsonPropertyName("characterInventories")]
        public DictionaryComponentResponseOfint64AndDestinyInventoryComponent CharacterInventories { get; init; }

        [JsonPropertyName("characterProgressions")]
        public DictionaryComponentResponseOfint64AndDestinyCharacterProgressionComponent CharacterProgressions
        {
            get;
            init;
        }

        [JsonPropertyName("characterRenderData")]
        public DictionaryComponentResponseOfint64AndDestinyCharacterRenderComponent CharacterRenderData { get; init; }

        [JsonPropertyName("characterActivities")]
        public DictionaryComponentResponseOfint64AndDestinyCharacterActivitiesComponent CharacterActivities
        {
            get;
            init;
        }

        [JsonPropertyName("characterEquipment")]
        public DictionaryComponentResponseOfint64AndDestinyInventoryComponent CharacterEquipment { get; init; }

        [JsonPropertyName("characterKiosks")]
        public DictionaryComponentResponseOfint64AndDestinyKiosksComponent CharacterKiosks { get; init; }

        [JsonPropertyName("characterPlugSets")]
        public DictionaryComponentResponseOfint64AndDestinyPlugSetsComponent CharacterPlugSets { get; init; }

        [JsonPropertyName("characterUninstancedItemComponents")]
        public ReadOnlyDictionary<long, DestinyBaseItemComponentSetOfuint32> CharacterUninstancedItemComponents
        {
            get;
            init;
        }

        [JsonPropertyName("characterPresentationNodes")]
        public DictionaryComponentResponseOfint64AndDestinyPresentationNodesComponent CharacterPresentationNodes
        {
            get;
            init;
        }

        [JsonPropertyName("characterRecords")]
        public DictionaryComponentResponseOfint64AndDestinyCharacterRecordsComponent CharacterRecords { get; init; }

        [JsonPropertyName("characterCollectibles")]
        public DictionaryComponentResponseOfint64AndDestinyCollectiblesComponent CharacterCollectibles { get; init; }

        [JsonPropertyName("characterStringVariables")]
        public DictionaryComponentResponseOfint64AndDestinyStringVariablesComponent CharacterStringVariables
        {
            get;
            init;
        }

        [JsonPropertyName("itemComponents")] public DestinyItemComponentSetOfint64 ItemComponents { get; init; }

        [JsonPropertyName("characterCurrencyLookups")]
        public DictionaryComponentResponseOfint64AndDestinyCurrenciesComponent CharacterCurrencyLookups { get; init; }
    }
}