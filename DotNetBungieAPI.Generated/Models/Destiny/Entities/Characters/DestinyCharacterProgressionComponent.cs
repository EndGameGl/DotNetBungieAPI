using System.Text.Json.Serialization;

namespace DotNetBungieAPI.Generated.Models.Destiny.Entities.Characters;

/// <summary>
///     This component returns anything that could be considered "Progression" on a user: data where the user is gaining levels, reputation, completions, rewards, etc...
/// </summary>
public sealed class DestinyCharacterProgressionComponent
{

    /// <summary>
    ///     A Dictionary of all known progressions for the Character, keyed by the Progression's hash.
    /// <para />
    ///     Not all progressions have user-facing data, but those who do will have that data contained in the DestinyProgressionDefinition.
    /// </summary>
    [JsonPropertyName("progressions")]
    public Dictionary<uint, Destiny.DestinyProgression> Progressions { get; init; }

    /// <summary>
    ///     A dictionary of all known Factions, keyed by the Faction's hash. It contains data about this character's status with the faction.
    /// </summary>
    [JsonPropertyName("factions")]
    public Dictionary<uint, Destiny.Progression.DestinyFactionProgression> Factions { get; init; }

    /// <summary>
    ///     Milestones are related to the simple progressions shown in the game, but return additional and hopefully helpful information for users about the specifics of the Milestone's status.
    /// </summary>
    [JsonPropertyName("milestones")]
    public Dictionary<uint, Destiny.Milestones.DestinyMilestone> Milestones { get; init; }

    /// <summary>
    ///     If the user has any active quests, the quests' statuses will be returned here.
    /// <para />
    ///      Note that quests have been largely supplanted by Milestones, but that doesn't mean that they won't make a comeback independent of milestones at some point.
    /// <para />
    ///      (Fun fact: quests came back as I feared they would, but we never looped back to populate this... I'm going to put that in the backlog.)
    /// </summary>
    [JsonPropertyName("quests")]
    public List<Destiny.Quests.DestinyQuestStatus> Quests { get; init; }

    /// <summary>
    ///     Sometimes, you have items in your inventory that don't have instances, but still have Objective information. This provides you that objective information for uninstanced items. 
    /// <para />
    ///     This dictionary is keyed by the item's hash: which you can use to look up the name and description for the overall task(s) implied by the objective. The value is the list of objectives for this item, and their statuses.
    /// </summary>
    [JsonPropertyName("uninstancedItemObjectives")]
    public Dictionary<uint, List<Destiny.Quests.DestinyObjectiveProgress>> UninstancedItemObjectives { get; init; }

    /// <summary>
    ///     Sometimes, you have items in your inventory that don't have instances, but still have perks (for example: Trials passage cards). This gives you the perk information for uninstanced items.
    /// <para />
    ///     This dictionary is keyed by item hash, which you can use to look up the corresponding item definition. The value is the list of perks states for the item.
    /// </summary>
    [JsonPropertyName("uninstancedItemPerks")]
    public Dictionary<uint, Destiny.Entities.Items.DestinyItemPerksComponent> UninstancedItemPerks { get; init; }

    /// <summary>
    ///     The set of checklists that can be examined for this specific character, keyed by the hash identifier of the Checklist (DestinyChecklistDefinition)
    /// <para />
    ///     For each checklist returned, its value is itself a Dictionary keyed by the checklist's hash identifier with the value being a boolean indicating if it's been discovered yet.
    /// </summary>
    [JsonPropertyName("checklists")]
    public Dictionary<uint, Dictionary<uint, bool>> Checklists { get; init; }

    /// <summary>
    ///     Data related to your progress on the current season's artifact that can vary per character.
    /// </summary>
    [JsonPropertyName("seasonalArtifact")]
    public Destiny.Artifacts.DestinyArtifactCharacterScoped SeasonalArtifact { get; init; }
}
