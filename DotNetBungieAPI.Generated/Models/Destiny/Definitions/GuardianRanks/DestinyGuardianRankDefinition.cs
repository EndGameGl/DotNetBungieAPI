namespace DotNetBungieAPI.Generated.Models.Destiny.Definitions.GuardianRanks;

public class DestinyGuardianRankDefinition
{
    [JsonPropertyName("displayProperties")]
    public Destiny.Definitions.Common.DestinyDisplayPropertiesDefinition? DisplayProperties { get; set; }

    [JsonPropertyName("rankNumber")]
    public int RankNumber { get; set; }

    [Destiny2Definition<Destiny.Definitions.Presentation.DestinyPresentationNodeDefinition>("Destiny.Definitions.Presentation.DestinyPresentationNodeDefinition")]
    [JsonPropertyName("presentationNodeHash")]
    public uint PresentationNodeHash { get; set; }

    [JsonPropertyName("foregroundImagePath")]
    public string ForegroundImagePath { get; set; }

    [JsonPropertyName("overlayImagePath")]
    public string OverlayImagePath { get; set; }

    [JsonPropertyName("overlayMaskImagePath")]
    public string OverlayMaskImagePath { get; set; }

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
