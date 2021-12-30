using System.Text.Json.Serialization;

namespace DotNetBungieAPI.Generated.Models.Destiny.Components.Vendors;

public sealed class DestinyVendorGroupComponent
{

    [JsonPropertyName("groups")]
    public List<Destiny.Components.Vendors.DestinyVendorGroup> Groups { get; init; }
}
