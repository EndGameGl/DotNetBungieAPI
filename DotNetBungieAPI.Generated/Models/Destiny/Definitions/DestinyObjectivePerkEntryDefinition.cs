using System.Text.Json.Serialization;

namespace DotNetBungieAPI.Generated.Models.Destiny.Definitions;

public sealed class DestinyObjectivePerkEntryDefinition
{

    [JsonPropertyName("perkHash")]
    public uint PerkHash { get; init; }

    [JsonPropertyName("style")]
    public Destiny.DestinyObjectiveGrantStyle Style { get; init; }
}
