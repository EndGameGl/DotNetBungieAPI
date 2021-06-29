﻿using System.Collections.ObjectModel;
using System.Text.Json.Serialization;
using NetBungieAPI.Models.Destiny.Artifacts;
using NetBungieAPI.Models.Destiny.Definitions.Checklists;
using NetBungieAPI.Models.Destiny.Definitions.Factions;
using NetBungieAPI.Models.Destiny.Definitions.InventoryItems;
using NetBungieAPI.Models.Destiny.Definitions.Milestones;
using NetBungieAPI.Models.Destiny.Definitions.ProgressionMappings;
using NetBungieAPI.Models.Destiny.Milestones;
using NetBungieAPI.Models.Destiny.Progressions;
using NetBungieAPI.Models.Destiny.Quests;

namespace NetBungieAPI.Models.Destiny.Components
{
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
        public ReadOnlyDictionary<DefinitionHashPointer<DestinyProgressionMappingDefinition>, DestinyProgression>
            Progressions { get; init; } =
            Defaults
                .EmptyReadOnlyDictionary<DefinitionHashPointer<DestinyProgressionMappingDefinition>,
                    DestinyProgression>();

        /// <summary>
        ///     A dictionary of all known Factions, keyed by the Faction's hash. It contains data about this character's status
        ///     with the faction.
        /// </summary>
        [JsonPropertyName("factions")]
        public ReadOnlyDictionary<DefinitionHashPointer<DestinyFactionDefinition>, DestinyFactionProgression>
            Factions { get; init; } =
            Defaults
                .EmptyReadOnlyDictionary<DefinitionHashPointer<DestinyFactionDefinition>, DestinyFactionProgression>();

        /// <summary>
        ///     Milestones are related to the simple progressions shown in the game, but return additional and hopefully helpful
        ///     information for users about the specifics of the Milestone's status.
        /// </summary>
        [JsonPropertyName("milestones")]
        public ReadOnlyDictionary<DefinitionHashPointer<DestinyMilestoneDefinition>, DestinyMilestone>
            Milestones { get; init; } =
            Defaults.EmptyReadOnlyDictionary<DefinitionHashPointer<DestinyMilestoneDefinition>, DestinyMilestone>();

        /// <summary>
        ///     If the user has any active quests, the quests' statuses will be returned here.
        ///     <para />
        ///     Note that quests have been largely supplanted by Milestones, but that doesn't mean that they won't make a comeback
        ///     independent of milestones at some point.
        /// </summary>
        [JsonPropertyName("quests")]
        public ReadOnlyCollection<DestinyQuestStatus> Quests { get; init; } =
            Defaults.EmptyReadOnlyCollection<DestinyQuestStatus>();

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
                ReadOnlyCollection<UninstancedItemObjective>> UninstancedItemObjectives { get; init; } = Defaults
            .EmptyReadOnlyDictionary<DefinitionHashPointer<DestinyInventoryItemDefinition>,
                ReadOnlyCollection<UninstancedItemObjective>>();

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
            Defaults
                .EmptyReadOnlyDictionary<DefinitionHashPointer<DestinyChecklistDefinition>,
                    ReadOnlyDictionary<uint, bool>>();

        /// <summary>
        ///     Data related to your progress on the current season's artifact that can vary per character.
        /// </summary>
        [JsonPropertyName("seasonalArtifact")]
        public DestinyArtifactCharacterScoped SeasonalArtifact { get; init; }
    }
}