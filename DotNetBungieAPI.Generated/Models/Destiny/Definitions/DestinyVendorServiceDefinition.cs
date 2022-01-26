namespace DotNetBungieAPI.Generated.Models.Destiny.Definitions;

/// <summary>
///     When a vendor provides services, this is the localized name of those services.
/// </summary>
public class DestinyVendorServiceDefinition : IDeepEquatable<DestinyVendorServiceDefinition>
{
    /// <summary>
    ///     The localized name of a service provided.
    /// </summary>
    [JsonPropertyName("name")]
    public string Name { get; set; }

    public bool DeepEquals(DestinyVendorServiceDefinition? other)
    {
        return other is not null &&
               Name == other.Name;
    }
}