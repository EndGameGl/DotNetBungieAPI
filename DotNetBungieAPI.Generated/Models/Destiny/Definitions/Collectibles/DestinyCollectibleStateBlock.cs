using System.Text.Json.Serialization;

namespace DotNetBungieAPI.Generated.Models.Destiny.Definitions.Collectibles;

public sealed class DestinyCollectibleStateBlock
{

    [JsonPropertyName("obscuredOverrideItemHash")]
    public uint? ObscuredOverrideItemHash { get; init; } // DestinyInventoryItemDefinition

    [JsonPropertyName("requirements")]
    public Destiny.Definitions.Presentation.DestinyPresentationNodeRequirementsBlock Requirements { get; init; }
}
