namespace DotNetBungieAPI.Generated.Models.Destiny.Definitions.Animations;

public class DestinyAnimationReference : IDeepEquatable<DestinyAnimationReference>
{
    [JsonPropertyName("animName")]
    public string AnimName { get; set; }

    [JsonPropertyName("animIdentifier")]
    public string AnimIdentifier { get; set; }

    [JsonPropertyName("path")]
    public string Path { get; set; }

    public bool DeepEquals(DestinyAnimationReference? other)
    {
        return other is not null &&
               AnimName == other.AnimName &&
               AnimIdentifier == other.AnimIdentifier &&
               Path == other.Path;
    }
}