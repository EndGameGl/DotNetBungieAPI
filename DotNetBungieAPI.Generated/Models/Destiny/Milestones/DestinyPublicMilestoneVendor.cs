using System.Text.Json.Serialization;

namespace DotNetBungieAPI.Generated.Models.Destiny.Milestones;

public sealed class DestinyPublicMilestoneVendor
{

    [JsonPropertyName("vendorHash")]
    public uint VendorHash { get; init; }

    [JsonPropertyName("previewItemHash")]
    public uint? PreviewItemHash { get; init; }
}
