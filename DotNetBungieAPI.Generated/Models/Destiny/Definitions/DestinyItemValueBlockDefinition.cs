using System.Text.Json.Serialization;

namespace DotNetBungieAPI.Generated.Models.Destiny.Definitions;

public sealed class DestinyItemValueBlockDefinition
{

    [JsonPropertyName("itemValue")]
    public List<Destiny.DestinyItemQuantity> ItemValue { get; init; }

    [JsonPropertyName("valueDescription")]
    public string ValueDescription { get; init; }
}
