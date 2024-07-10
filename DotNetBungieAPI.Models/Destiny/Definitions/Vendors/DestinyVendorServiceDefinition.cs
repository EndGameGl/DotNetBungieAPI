namespace DotNetBungieAPI.Models.Destiny.Definitions.Vendors;

/// <summary>
///     When a vendor provides services, this is the localized name of those services.
/// </summary>
public sealed record DestinyVendorServiceDefinition : IDeepEquatable<DestinyVendorServiceDefinition>
{
    /// <summary>
    ///     The localized name of a service provided.
    /// </summary>
    [JsonPropertyName("name")]
    public string Name { get; init; }

    public bool DeepEquals(DestinyVendorServiceDefinition other)
    {
        return other != null && Name == other.Name;
    }
}
