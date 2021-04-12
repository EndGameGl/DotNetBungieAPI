using NetBungieAPI.Models.Destiny.Definitions.InventoryItems;
using NetBungieAPI.Models.Destiny.Quests;
using System.Collections.ObjectModel;
using System.Text.Json.Serialization;

namespace NetBungieAPI.Models.Destiny.Components
{
    public sealed record DestinyItemPlugComponent
    {
        [JsonPropertyName("plugObjectives")]
        public ReadOnlyCollection<DestinyObjectiveProgress> PlugObjectives { get; init; } = Defaults.EmptyReadOnlyCollection<DestinyObjectiveProgress>();
        [JsonPropertyName("plugItemHash")]
        public DefinitionHashPointer<DestinyInventoryItemDefinition> PlugItem { get; init; } = DefinitionHashPointer<DestinyInventoryItemDefinition>.Empty;
        [JsonPropertyName("canInsert")]
        public bool CanInsert { get; init; }
        [JsonPropertyName("enabled")]
        public bool IsEnabled { get; init; }
        [JsonPropertyName("insertFailIndexes")]
        public ReadOnlyCollection<int> InsertFailIndexes { get; init; } = Defaults.EmptyReadOnlyCollection<int>();
        [JsonPropertyName("enableFailIndexes")]
        public ReadOnlyCollection<int> EnableFailIndexes { get; init; } = Defaults.EmptyReadOnlyCollection<int>();
    }
}
