using System.Text.Json.Serialization;

namespace DotNetBungieAPI.Generated.Models.Destiny.Definitions;

/// <summary>
///     When a vendor provides services, this is the localized name of those services.
/// </summary>
public sealed class DestinyVendorServiceDefinition
{

    /// <summary>
    ///     The localized name of a service provided.
    /// </summary>
    [JsonPropertyName("name")]
    public string Name { get; init; }
}
