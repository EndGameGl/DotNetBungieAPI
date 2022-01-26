namespace DotNetBungieAPI.Generated.Models.Destiny.Config;

public class GearAssetDataBaseDefinition : IDeepEquatable<GearAssetDataBaseDefinition>
{
    [JsonPropertyName("version")]
    public int Version { get; set; }

    [JsonPropertyName("path")]
    public string Path { get; set; }

    public bool DeepEquals(GearAssetDataBaseDefinition? other)
    {
        return other is not null &&
               Version == other.Version &&
               Path == other.Path;
    }
}