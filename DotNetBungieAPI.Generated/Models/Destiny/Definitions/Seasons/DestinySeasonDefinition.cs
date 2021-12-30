using System.Text.Json.Serialization;

namespace DotNetBungieAPI.Generated.Models.Destiny.Definitions.Seasons;

public sealed class DestinySeasonDefinition
{

    [JsonPropertyName("displayProperties")]
    public Destiny.Definitions.Common.DestinyDisplayPropertiesDefinition DisplayProperties { get; init; }

    [JsonPropertyName("backgroundImagePath")]
    public string BackgroundImagePath { get; init; }

    [JsonPropertyName("seasonNumber")]
    public int SeasonNumber { get; init; }

    [JsonPropertyName("startDate")]
    public DateTime? StartDate { get; init; }

    [JsonPropertyName("endDate")]
    public DateTime? EndDate { get; init; }

    [JsonPropertyName("seasonPassHash")]
    public uint? SeasonPassHash { get; init; }

    [JsonPropertyName("seasonPassProgressionHash")]
    public uint? SeasonPassProgressionHash { get; init; }

    [JsonPropertyName("artifactItemHash")]
    public uint? ArtifactItemHash { get; init; }

    [JsonPropertyName("sealPresentationNodeHash")]
    public uint? SealPresentationNodeHash { get; init; }

    [JsonPropertyName("seasonalChallengesPresentationNodeHash")]
    public uint? SeasonalChallengesPresentationNodeHash { get; init; }

    [JsonPropertyName("preview")]
    public Destiny.Definitions.Seasons.DestinySeasonPreviewDefinition Preview { get; init; }

    [JsonPropertyName("hash")]
    public uint Hash { get; init; }

    [JsonPropertyName("index")]
    public int Index { get; init; }

    [JsonPropertyName("redacted")]
    public bool Redacted { get; init; }
}
