using System.Text.Json.Serialization;

namespace DotNetBungieAPI.Generated.Models.Destiny.Definitions;

public sealed class DestinyItemSetBlockEntryDefinition
{

    [JsonPropertyName("trackingValue")]
    public int TrackingValue { get; init; }

    [JsonPropertyName("itemHash")]
    public uint ItemHash { get; init; }
}
