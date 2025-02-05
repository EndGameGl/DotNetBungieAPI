using DotNetBungieAPI.Models.Destiny.Vendors;

namespace DotNetBungieAPI.Models.Destiny.Components;

/// <summary>
///     This component returns references to all of the Vendors in the response, grouped by categorizations that Bungie has
///     deemed to be interesting, in the order in which both the groups and the vendors within that group should be
///     rendered.
/// </summary>
public sealed record DestinyVendorGroupComponent
{
    /// <summary>
    ///     The ordered list of groups being returned.
    /// </summary>
    [JsonPropertyName("groups")]
    public ReadOnlyCollection<DestinyVendorGroup> Groups { get; init; } =
        ReadOnlyCollection<DestinyVendorGroup>.Empty;
}
