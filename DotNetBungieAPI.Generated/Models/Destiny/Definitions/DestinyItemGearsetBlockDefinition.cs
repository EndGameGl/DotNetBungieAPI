using System.Text.Json.Serialization;

namespace DotNetBungieAPI.Generated.Models.Destiny.Definitions;

public sealed class DestinyItemGearsetBlockDefinition
{

    [JsonPropertyName("trackingValueMax")]
    public int TrackingValueMax { get; init; }

    [JsonPropertyName("itemList")]
    public List<uint> ItemList { get; init; }
}
