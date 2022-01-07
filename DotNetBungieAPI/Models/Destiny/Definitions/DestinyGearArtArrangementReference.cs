using DotNetBungieAPI.Models.Destiny.Definitions.Classes;

namespace DotNetBungieAPI.Models.Destiny.Definitions;

public sealed record DestinyGearArtArrangementReference : IDeepEquatable<DestinyGearArtArrangementReference>
{
    [JsonPropertyName("artArrangementHash")]
    public uint ArtArrangementHash { get; init; }

    [JsonPropertyName("classHash")]
    public DefinitionHashPointer<DestinyClassDefinition> ClassHash { get; init; } =
        DefinitionHashPointer<DestinyClassDefinition>.Empty;

    public bool DeepEquals(DestinyGearArtArrangementReference other)
    {
        return other != null &&
               ArtArrangementHash == other.ArtArrangementHash &&
               ClassHash == other.ClassHash;
    }
}