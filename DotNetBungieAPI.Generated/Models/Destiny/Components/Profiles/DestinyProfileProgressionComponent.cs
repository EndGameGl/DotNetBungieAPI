namespace DotNetBungieAPI.Generated.Models.Destiny.Components.Profiles;

/// <summary>
///     The set of progression-related information that applies at a Profile-wide level for your Destiny experience. This differs from the Jimi Hendrix Experience because there's less guitars on fire. Yet. #spoileralert?
/// <para />
///     This will include information such as Checklist info.
/// </summary>
public class DestinyProfileProgressionComponent : IDeepEquatable<DestinyProfileProgressionComponent>
{
    /// <summary>
    ///     The set of checklists that can be examined on a profile-wide basis, keyed by the hash identifier of the Checklist (DestinyChecklistDefinition)
    /// <para />
    ///     For each checklist returned, its value is itself a Dictionary keyed by the checklist's hash identifier with the value being a boolean indicating if it's been discovered yet.
    /// </summary>
    [JsonPropertyName("checklists")]
    public Dictionary<uint, Dictionary<uint, bool>> Checklists { get; set; }

    /// <summary>
    ///     Data related to your progress on the current season's artifact that is the same across characters.
    /// </summary>
    [JsonPropertyName("seasonalArtifact")]
    public Destiny.Artifacts.DestinyArtifactProfileScoped SeasonalArtifact { get; set; }

    public bool DeepEquals(DestinyProfileProgressionComponent? other)
    {
        return other is not null &&
               Checklists.DeepEqualsDictionaryNaive(other.Checklists) &&
               (SeasonalArtifact is not null ? SeasonalArtifact.DeepEquals(other.SeasonalArtifact) : other.SeasonalArtifact is null);
    }
}