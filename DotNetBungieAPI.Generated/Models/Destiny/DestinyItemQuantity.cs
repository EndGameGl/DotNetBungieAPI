using System.Text.Json.Serialization;

namespace DotNetBungieAPI.Generated.Models.Destiny;

public sealed class DestinyItemQuantity
{

    [JsonPropertyName("itemHash")]
    public uint ItemHash { get; init; }

    [JsonPropertyName("itemInstanceId")]
    public long? ItemInstanceId { get; init; }

    [JsonPropertyName("quantity")]
    public int Quantity { get; init; }

    [JsonPropertyName("hasConditionalVisibility")]
    public bool HasConditionalVisibility { get; init; }
}
