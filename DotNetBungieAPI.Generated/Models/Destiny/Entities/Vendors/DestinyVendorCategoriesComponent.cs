using System.Text.Json.Serialization;

namespace DotNetBungieAPI.Generated.Models.Destiny.Entities.Vendors;

public sealed class DestinyVendorCategoriesComponent
{

    [JsonPropertyName("categories")]
    public List<Destiny.Entities.Vendors.DestinyVendorCategory> Categories { get; init; }
}
