using System.Text.Json.Serialization;

namespace DotNetBungieAPI.Generated.Models.Destiny.Definitions;

/// <summary>
///     If you ever wondered how the Vault works, here it is.
/// <para />
///     The Vault is merely a set of inventory buckets that exist on your Profile/Account level. When you transfer items in the Vault, the game is using the Vault Vendor's DestinyVendorAcceptedItemDefinitions to see where the appropriate destination bucket is for the source bucket from whence your item is moving. If it finds such an entry, it transfers the item to the other bucket.
/// <para />
///     The mechanics for Postmaster works similarly, which is also a vendor. All driven by Accepted Items.
/// </summary>
public sealed class DestinyVendorAcceptedItemDefinition
{

    /// <summary>
    ///     The "source" bucket for a transfer. When a user wants to transfer an item, the appropriate DestinyVendorDefinition's acceptedItems property is evaluated, looking for an entry where acceptedInventoryBucketHash matches the bucket that the item being transferred is currently located. If it exists, the item will be transferred into whatever bucket is defined by destinationInventoryBucketHash.
    /// </summary>
    [JsonPropertyName("acceptedInventoryBucketHash")]
    public uint AcceptedInventoryBucketHash { get; init; }

    /// <summary>
    ///     This is the bucket where the item being transferred will be put, given that it was being transferred *from* the bucket defined in acceptedInventoryBucketHash.
    /// </summary>
    [JsonPropertyName("destinationInventoryBucketHash")]
    public uint DestinationInventoryBucketHash { get; init; }
}
