namespace DotNetBungieAPI.Generated.Models.Destiny.Components.Vendors;

/// <summary>
///     This component returns references to all of the Vendors in the response, grouped by categorizations that Bungie has deemed to be interesting, in the order in which both the groups and the vendors within that group should be rendered.
/// </summary>
public class DestinyVendorGroupComponent
{
    /// <summary>
    ///     The ordered list of groups being returned.
    /// </summary>
    [JsonPropertyName("groups")]
    public List<Destiny.Components.Vendors.DestinyVendorGroup> Groups { get; set; }
}
