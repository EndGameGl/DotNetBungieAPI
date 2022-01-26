namespace DotNetBungieAPI.Generated.Models.Destiny.Definitions.Artifacts;

public class DestinyArtifactTierItemDefinition : IDeepEquatable<DestinyArtifactTierItemDefinition>
{
    /// <summary>
    ///     The identifier of the Plug Item unlocked by activating this item in the Artifact.
    /// </summary>
    [JsonPropertyName("itemHash")]
    public uint ItemHash { get; set; }

    public bool DeepEquals(DestinyArtifactTierItemDefinition? other)
    {
        return other is not null &&
               ItemHash == other.ItemHash;
    }
}