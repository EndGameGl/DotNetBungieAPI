using System.Text.Json.Serialization;

namespace DotNetBungieAPI.Generated.Models.Destiny.Entities.Profiles;

public sealed class DestinyVendorReceiptsComponent
{

    [JsonPropertyName("receipts")]
    public List<Destiny.Vendors.DestinyVendorReceipt> Receipts { get; init; }
}
