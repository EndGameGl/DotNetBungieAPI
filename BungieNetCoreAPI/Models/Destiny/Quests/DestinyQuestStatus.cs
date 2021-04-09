using NetBungieAPI.Models.Destiny.Definitions.InventoryItems;
using NetBungieAPI.Models.Destiny.Definitions.Vendors;
using System.Collections.ObjectModel;
using System.Text.Json.Serialization;

namespace NetBungieAPI.Models.Destiny.Quests
{
    public sealed record DestinyQuestStatus
    {
        [JsonPropertyName("questHash")]
        public DefinitionHashPointer<DestinyInventoryItemDefinition> Quest { get; init; } = DefinitionHashPointer<DestinyInventoryItemDefinition>.Empty;
        [JsonPropertyName("stepHash")]
        public DefinitionHashPointer<DestinyInventoryItemDefinition> Step { get; init; } = DefinitionHashPointer<DestinyInventoryItemDefinition>.Empty;
        [JsonPropertyName("stepObjectives")]
        public ReadOnlyCollection<DestinyObjectiveProgress> StepObjectives { get; init; } = Defaults.EmptyReadOnlyCollection<DestinyObjectiveProgress>();
        [JsonPropertyName("tracked")]
        public bool IsTracked { get; init; }
        [JsonPropertyName("itemInstanceId")]
        public long ItemInstanceId { get; init; }
        [JsonPropertyName("completed")]
        public bool IsCompleted { get; init; }
        [JsonPropertyName("redeemed")]
        public bool IsRedeemed { get; init; }
        [JsonPropertyName("started")]
        public bool Started { get; init; }
        [JsonPropertyName("vendorHash")]
        public DefinitionHashPointer<DestinyVendorDefinition> Vendor { get; init; } = DefinitionHashPointer<DestinyVendorDefinition>.Empty;
    }
}
