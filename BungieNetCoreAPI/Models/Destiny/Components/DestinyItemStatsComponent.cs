using NetBungieAPI.Models.Destiny.Definitions.Stats;
using NetBungieAPI.Models.Destiny.Items;
using System.Collections.ObjectModel;
using System.Text.Json.Serialization;

namespace NetBungieAPI.Models.Destiny.Components
{
    public sealed record DestinyItemStatsComponent
    {
        [JsonPropertyName("stats")]
        public ReadOnlyDictionary<DefinitionHashPointer<DestinyStatDefinition>, DestinyStat> Stats { get; init; } = Defaults.EmptyReadOnlyDictionary<DefinitionHashPointer<DestinyStatDefinition>, DestinyStat>();
    }
}
