using System.Text.Json.Serialization;

namespace DotNetBungieAPI.Generated.Models.Destiny.Definitions;

public sealed class DestinyVendorSaleItemActionBlockDefinition
{

    [JsonPropertyName("executeSeconds")]
    public float ExecuteSeconds { get; init; }

    [JsonPropertyName("isPositive")]
    public bool IsPositive { get; init; }
}
