using System.Text.Json.Serialization;

namespace DotNetBungieAPI.Generated.Models.Destiny;

public enum DestinyVendorItemRefundPolicy : int
{
    NotRefundable = 0,
    DeletesItem = 1,
    RevokesLicense = 2
}
