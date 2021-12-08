using DotNetBungieAPI.Models.Destiny.Artifacts;
using DotNetBungieAPI.Models.Destiny.Definitions.Checklists;

namespace DotNetBungieAPI.Models.Destiny.Components;

/// <summary>
///     The set of progression-related information that applies at a Profile-wide level for your Destiny experience.
///     <para />
///     This will include information such as Checklist info.
/// </summary>
public sealed record DestinyProfileProgressionComponent
{
    /// <summary>
    ///     The set of checklists that can be examined on a profile-wide basis, keyed by the hash identifier of the Checklist
    ///     (DestinyChecklistDefinition)
    ///     <para />
    ///     For each checklist returned, its value is itself a Dictionary keyed by the checklist's hash identifier with the
    ///     value being a boolean indicating if it's been discovered yet.
    /// </summary>
    [JsonPropertyName("checklists")]
    public ReadOnlyDictionary<DefinitionHashPointer<DestinyChecklistDefinition>, ReadOnlyDictionary<uint, bool>>
        Checklists { get; init; } =
        ReadOnlyDictionaries<DefinitionHashPointer<DestinyChecklistDefinition>, ReadOnlyDictionary<uint, bool>>
            .Empty;

    /// <summary>
    ///     Data related to your progress on the current season's artifact that is the same across characters.
    /// </summary>
    [JsonPropertyName("seasonalArtifact")]
    public DestinyArtifactProfileScoped SeasonalArtifact { get; init; }
}