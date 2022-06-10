namespace DotNetBungieAPI.Generated.Models.Destiny.Definitions;

/// <summary>
///     Not terribly useful, some basic cooldown interaction info.
/// </summary>
public class DestinyVendorSaleItemActionBlockDefinition
{
    [JsonPropertyName("executeSeconds")]
    public float? ExecuteSeconds { get; set; }

    [JsonPropertyName("isPositive")]
    public bool? IsPositive { get; set; }
}
