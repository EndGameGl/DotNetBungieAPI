using NetBungieAPI.Models.Destiny.Components;
using System.Text.Json.Serialization;

namespace NetBungieAPI.Models.Destiny.Responses
{
    public sealed record DestinyCharacterResponse
    {
        [JsonPropertyName("inventory")]
        public SingleComponentResponseOfDestinyInventoryComponent Inventory { get; init; }

        [JsonPropertyName("character")]
        public SingleComponentResponseOfDestinyCharacterComponent Character { get; init; }

        [JsonPropertyName("progressions")]
        public SingleComponentResponseOfDestinyCharacterProgressionComponent Progressions { get; init; }

        [JsonPropertyName("renderData")]
        public SingleComponentResponseOfDestinyCharacterRenderComponent RenderData { get; init; }

        [JsonPropertyName("activities")]
        public SingleComponentResponseOfDestinyCharacterActivitiesComponent Activities { get; init; }

        [JsonPropertyName("equipment")]
        public SingleComponentResponseOfDestinyInventoryComponent Equipment { get; init; }

        [JsonPropertyName("kiosks")] 
        public SingleComponentResponseOfDestinyKiosksComponent Kiosks { get; init; }
        
        [JsonPropertyName("plugSets")] 
        public SingleComponentResponseOfDestinyPlugSetsComponent PlugSets { get; init; }
        
        [JsonPropertyName("presentationNodes")] 
        public SingleComponentResponseOfDestinyPresentationNodesComponent PresentationNodes { get; init; }
        
        [JsonPropertyName("records")] 
        public SingleComponentResponseOfDestinyCharacterRecordsComponent Records { get; init; }
        
        [JsonPropertyName("collectibles")] 
        public SingleComponentResponseOfDestinyCollectiblesComponent Collectibles { get; init; }
        
        [JsonPropertyName("itemComponents")] 
        public DestinyItemComponentSetOfint64 ItemComponents { get; init; }
        
        [JsonPropertyName("uninstancedItemComponents")] 
        public DestinyBaseItemComponentSetOfuint32 UninstancedItemComponents { get; init; }
        
        [JsonPropertyName("currencyLookups")]
        public SingleComponentResponseOfDestinyCurrenciesComponent CurrencyLookups { get; init; }
    }
}