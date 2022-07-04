using DotNetBungieAPI.Models.Destiny.Artifacts;
using DotNetBungieAPI.Models.Destiny.Definitions.Checklists;
using DotNetBungieAPI.Models.Destiny.Definitions.Factions;
using DotNetBungieAPI.Models.Destiny.Definitions.InventoryItems;
using DotNetBungieAPI.Models.Destiny.Definitions.Milestones;
using DotNetBungieAPI.Models.Destiny.Definitions.Progressions;
using DotNetBungieAPI.Models.Destiny.Milestones;
using DotNetBungieAPI.Models.Destiny.Progressions;
using DotNetBungieAPI.Models.Destiny.Quests;

namespace DotNetBungieAPI.Models.Destiny.Components;

/// <summary>
///     This component returns anything that could be considered "Progression" on a user: data where the user is gaining
///     levels, reputation, completions, rewards, etc...
/// </summary>
public sealed record DestinyCharacterProgressionComponent
{
    /// <summary>
    ///     A Dictionary of all known progressions for the Character, keyed by the Progression's hash.
    /// </summary>
    [JsonPropertyName("progressions")]
    public ReadOnlyDictionary<DefinitionHashPointer<DestinyProgressionDefinition>, DestinyProgression>
        Progressions { get; init; } =
        ReadOnlyDictionaries<DefinitionHashPointer<DestinyProgressionDefinition>, DestinyProgression>.Empty;

    /// <summary>
    ///     A dictionary of all known Factions, keyed by the Faction's hash. It contains data about this character's status
    ///     with the faction.
    /// </summary>
    [JsonPropertyName("factions")]
    public ReadOnlyDictionary<DefinitionHashPointer<DestinyFactionDefinition>, DestinyFactionProgression>
        Factions { get; init; } =
        ReadOnlyDictionaries<DefinitionHashPointer<DestinyFactionDefinition>, DestinyFactionProgression>.Empty;

    /// <summary>
    ///     Milestones are related to the simple progressions shown in the game, but return additional and hopefully helpful
    ///     information for users about the specifics of the Milestone's status.
    /// </summary>
    [JsonPropertyName("milestones")]
    public ReadOnlyDictionary<DefinitionHashPointer<DestinyMilestoneDefinition>, DestinyMilestone>
        Milestones { get; init; } =
        ReadOnlyDictionaries<DefinitionHashPointer<DestinyMilestoneDefinition>, DestinyMilestone>.Empty;

    /// <summary>
    ///     If the user has any active quests, the quests' statuses will be returned here.
    ///     <para />
    ///     Note that quests have been largely supplanted by Milestones, but that doesn't mean that they won't make a comeback
    ///     independent of milestones at some point.
    /// </summary>
    [JsonPropertyName("quests")]
    public ReadOnlyCollection<DestinyQuestStatus> Quests { get; init; } =
        ReadOnlyCollections<DestinyQuestStatus>.Empty;

    /// <summary>
    ///     Sometimes, you have items in your inventory that don't have instances, but still have Objective information. This
    ///     provides you that objective information for uninstanced items.
    ///     <para />
    ///     This dictionary is keyed by the item's hash: which you can use to look up the name and description for the overall
    ///     task(s) implied by the objective. The value is the list of objectives for this item, and their statuses.
    /// </summary>
    [JsonPropertyName("uninstancedItemObjectives")]
    public
        ReadOnlyDictionary<DefinitionHashPointer<DestinyInventoryItemDefinition>,
            ReadOnlyCollection<UninstancedItemObjective>> UninstancedItemObjectives { get; init; } =
        ReadOnlyDictionaries<DefinitionHashPointer<DestinyInventoryItemDefinition>,
            ReadOnlyCollection<UninstancedItemObjective>>.Empty;

    /// <summary>
    ///     Sometimes, you have items in your inventory that don't have instances, but still have perks (for example: Trials passage cards). This gives you the perk information for uninstanced items.
    /// <para />
    ///     This dictionary is keyed by item hash, which you can use to look up the corresponding item definition. The value is the list of perks states for the item.
    /// </summary>
    [JsonPropertyName("uninstancedItemPerks")]
    public
        ReadOnlyDictionary<DefinitionHashPointer<DestinyInventoryItemDefinition>, DestinyItemPerksComponent>
        UninstancedItemPerks { get; init; } =
        ReadOnlyDictionaries<DefinitionHashPointer<DestinyInventoryItemDefinition>, DestinyItemPerksComponent>.Empty;

    /// <summary>
    ///     The set of checklists that can be examined for this specific character, keyed by the hash identifier of the
    ///     Checklist (DestinyChecklistDefinition)
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
    ///     Data related to your progress on the current season's artifact that can vary per character.
    /// </summary>
    [JsonPropertyName("seasonalArtifact")]
    public DestinyArtifactCharacterScoped SeasonalArtifact { get; init; }
}