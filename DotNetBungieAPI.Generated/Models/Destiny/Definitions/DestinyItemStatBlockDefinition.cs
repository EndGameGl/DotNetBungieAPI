using System.Text.Json.Serialization;

namespace DotNetBungieAPI.Generated.Models.Destiny.Definitions;

public sealed class DestinyItemStatBlockDefinition
{

    [JsonPropertyName("disablePrimaryStatDisplay")]
    public bool DisablePrimaryStatDisplay { get; init; }

    [JsonPropertyName("statGroupHash")]
    public uint? StatGroupHash { get; init; }

    [JsonPropertyName("stats")]
    public Dictionary<uint, Destiny.Definitions.DestinyInventoryItemStatDefinition> Stats { get; init; }

    [JsonPropertyName("hasDisplayableStats")]
    public bool HasDisplayableStats { get; init; }

    [JsonPropertyName("primaryBaseStatHash")]
    public uint PrimaryBaseStatHash { get; init; }
}
