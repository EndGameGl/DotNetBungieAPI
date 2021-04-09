using NetBungieAPI.Models.Destiny.Definitions.InventoryItems;
using System.Collections.ObjectModel;
using System.Text.Json.Serialization;

namespace NetBungieAPI.Models.Destiny.Milestones
{
    public sealed record DestinyMilestoneContentItemCategory
    {
        [JsonPropertyName("title")]
        public string Title { get; init; }
        [JsonPropertyName("itemHashes")]
        public ReadOnlyCollection<DefinitionHashPointer<DestinyInventoryItemDefinition>> Items { get; init; } = Defaults.EmptyReadOnlyCollection<DefinitionHashPointer<DestinyInventoryItemDefinition>>();
    }
}
