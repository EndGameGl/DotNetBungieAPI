namespace DotNetBungieAPI.Models.Destiny.Definitions.Animations;

public sealed class DestinyAnimationReference
{
    [JsonPropertyName("animName")]
    public string AnimName { get; init; }

    [JsonPropertyName("animIdentifier")]
    public string AnimIdentifier { get; init; }

    [JsonPropertyName("path")]
    public string Path { get; init; }
}
