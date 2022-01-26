namespace DotNetBungieAPI.Generated.Models.Destiny.Definitions;

/// <summary>
///     Not terribly useful, some basic cooldown interaction info.
/// </summary>
public class DestinyVendorSaleItemActionBlockDefinition : IDeepEquatable<DestinyVendorSaleItemActionBlockDefinition>
{
    [JsonPropertyName("executeSeconds")]
    public float ExecuteSeconds { get; set; }

    [JsonPropertyName("isPositive")]
    public bool IsPositive { get; set; }

    public bool DeepEquals(DestinyVendorSaleItemActionBlockDefinition? other)
    {
        return other is not null &&
               ExecuteSeconds == other.ExecuteSeconds &&
               IsPositive == other.IsPositive;
    }
}