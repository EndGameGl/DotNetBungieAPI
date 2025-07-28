namespace DotNetBungieAPI.Generated.Models.Destiny.Definitions.Artifacts;

public class DestinyArtifactTierDefinition
{
    /// <summary>
    ///     An identifier, unique within the Artifact, for this specific tier.
    /// </summary>
    [JsonPropertyName("tierHash")]
    public uint TierHash { get; set; }

    /// <summary>
    ///     The human readable title of this tier, if any.
    /// </summary>
    [JsonPropertyName("displayTitle")]
    public string DisplayTitle { get; set; }

    /// <summary>
    ///     A string representing the localized minimum requirement text for this Tier, if any.
    /// </summary>
    [JsonPropertyName("progressRequirementMessage")]
    public string ProgressRequirementMessage { get; set; }

    /// <summary>
    ///     The items that can be earned within this tier.
    /// </summary>
    [JsonPropertyName("items")]
    public Destiny.Definitions.Artifacts.DestinyArtifactTierItemDefinition[]? Items { get; set; }

    /// <summary>
    ///     The minimum number of "unlock points" that you must have used before you can unlock items from this tier.
    /// </summary>
    [JsonPropertyName("minimumUnlockPointsUsedRequirement")]
    public int MinimumUnlockPointsUsedRequirement { get; set; }
}
