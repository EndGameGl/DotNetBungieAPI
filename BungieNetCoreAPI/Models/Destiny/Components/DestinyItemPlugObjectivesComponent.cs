using NetBungieAPI.Models.Destiny.Definitions.InventoryItems;
using NetBungieAPI.Models.Destiny.Quests;
using System.Collections.ObjectModel;
using System.Text.Json.Serialization;

namespace NetBungieAPI.Models.Destiny.Components
{
    public sealed record DestinyItemPlugObjectivesComponent
    {
        [JsonPropertyName("objectivesPerPlug")]
        public ReadOnlyDictionary<DefinitionHashPointer<DestinyInventoryItemDefinition>, ReadOnlyCollection<DestinyObjectiveProgress>> ObjectivesPerPlug { get; init; } = Defaults.EmptyReadOnlyDictionary<DefinitionHashPointer<DestinyInventoryItemDefinition>, ReadOnlyCollection<DestinyObjectiveProgress>>();
    }
}
