namespace DotNetBungieAPI.Models.Destiny.Definitions;

/// <summary>
///     Not terribly useful, some basic cooldown interaction info.
/// </summary>
public sealed class DestinyVendorSaleItemActionBlockDefinition
{
    [JsonPropertyName("executeSeconds")]
    public float? ExecuteSeconds { get; init; }

    [JsonPropertyName("isPositive")]
    public bool IsPositive { get; init; }
}
