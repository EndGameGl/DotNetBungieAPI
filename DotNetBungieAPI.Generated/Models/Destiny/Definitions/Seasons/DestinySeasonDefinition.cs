namespace DotNetBungieAPI.Generated.Models.Destiny.Definitions.Seasons;

/// <summary>
///     Defines a canonical "Season" of Destiny: a range of a few months where the game highlights certain challenges, provides new loot, has new Clan-related rewards and celebrates various seasonal events.
/// </summary>
public class DestinySeasonDefinition
{
    [JsonPropertyName("displayProperties")]
    public Destiny.Definitions.Common.DestinyDisplayPropertiesDefinition DisplayProperties { get; set; }

    [JsonPropertyName("backgroundImagePath")]
    public string BackgroundImagePath { get; set; }

    [JsonPropertyName("seasonNumber")]
    public int SeasonNumber { get; set; }

    [JsonPropertyName("startDate")]
    public DateTime StartDate { get; set; }

    [JsonPropertyName("endDate")]
    public DateTime EndDate { get; set; }

    [JsonPropertyName("seasonPassHash")]
    public uint SeasonPassHash { get; set; }

    [JsonPropertyName("seasonPassProgressionHash")]
    public uint SeasonPassProgressionHash { get; set; }

    [JsonPropertyName("artifactItemHash")]
    public uint ArtifactItemHash { get; set; }

    [JsonPropertyName("sealPresentationNodeHash")]
    public uint SealPresentationNodeHash { get; set; }

    [JsonPropertyName("seasonalChallengesPresentationNodeHash")]
    public uint SeasonalChallengesPresentationNodeHash { get; set; }

    /// <summary>
    ///     Optional - Defines the promotional text, images, and links to preview this season.
    /// </summary>
    [JsonPropertyName("preview")]
    public object Preview { get; set; }

    /// <summary>
    ///     The unique identifier for this entity. Guaranteed to be unique for the type of entity, but not globally.
    /// <para />
    ///     When entities refer to each other in Destiny content, it is this hash that they are referring to.
    /// </summary>
    [JsonPropertyName("hash")]
    public uint Hash { get; set; }

    /// <summary>
    ///     The index of the entity as it was found in the investment tables.
    /// </summary>
    [JsonPropertyName("index")]
    public int Index { get; set; }

    /// <summary>
    ///     If this is true, then there is an entity with this identifier/type combination, but BNet is not yet allowed to show it. Sorry!
    /// </summary>
    [JsonPropertyName("redacted")]
    public bool Redacted { get; set; }
}
