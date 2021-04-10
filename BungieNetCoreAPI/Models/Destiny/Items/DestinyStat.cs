using NetBungieAPI.Models.Destiny.Definitions.Stats;
using System.Text.Json.Serialization;

namespace NetBungieAPI.Models.Destiny.Items
{
    public sealed record DestinyStat
    {
        [JsonPropertyName("statHash")]
        public DefinitionHashPointer<DestinyStatDefinition> Stat { get; init; } = DefinitionHashPointer<DestinyStatDefinition>.Empty;
        [JsonPropertyName("value")]
        public int Value { get; init; }
    }
}
