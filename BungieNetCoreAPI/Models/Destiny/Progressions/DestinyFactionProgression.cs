using NetBungieAPI.Models.Destiny.Definitions.Factions;
using System.Text.Json.Serialization;

namespace NetBungieAPI.Models.Destiny.Progressions
{
    public sealed record DestinyFactionProgression : DestinyProgression
    {
        [JsonPropertyName("factionHash")]
        public DefinitionHashPointer<DestinyFactionDefinition> Faction { get; init; } = DefinitionHashPointer<DestinyFactionDefinition>.Empty;
        [JsonPropertyName("factionVendorIndex")]
        public int FactionVendorIndex { get; init; }
    }
}
