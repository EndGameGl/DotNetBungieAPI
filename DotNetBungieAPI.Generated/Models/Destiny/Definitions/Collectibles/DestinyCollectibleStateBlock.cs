namespace DotNetBungieAPI.Generated.Models.Destiny.Definitions.Collectibles;

public class DestinyCollectibleStateBlock
{
    [JsonPropertyName("obscuredOverrideItemHash")]
    public uint? ObscuredOverrideItemHash { get; set; }

    [JsonPropertyName("requirements")]
    public Destiny.Definitions.Presentation.DestinyPresentationNodeRequirementsBlock? Requirements { get; set; }
}
