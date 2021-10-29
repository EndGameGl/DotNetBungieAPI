using System.Collections.ObjectModel;
using System.Text.Json.Serialization;
using DotNetBungieAPI.Defaults;
using DotNetBungieAPI.Models.Destiny.Definitions.Activities;
using DotNetBungieAPI.Models.Destiny.Definitions.Objectives;

namespace DotNetBungieAPI.Models.Destiny.Definitions.InventoryItems
{
    /// <summary>
    ///     An item can have objectives on it. In practice, these are the exclusive purview of "Quest Step" items:
    ///     DestinyInventoryItemDefinitions that represent a specific step in a Quest.
    ///     <para />
    ///     Quest steps have 1:M objectives that we end up processing and returning in live data as DestinyQuestStatus data,
    ///     and other useful information.
    /// </summary>
    public sealed record DestinyItemObjectiveBlockDefinition : IDeepEquatable<DestinyItemObjectiveBlockDefinition>
    {
        /// <summary>
        ///     For every entry in objectiveHashes, there is a corresponding entry in this array at the same index. If the
        ///     objective is meant to be associated with a specific DestinyActivityDefinition, there will be a valid hash at that
        ///     index. Otherwise, it will be invalid (0).
        /// </summary>
        [JsonPropertyName("displayActivityHashes")]
        public ReadOnlyCollection<DefinitionHashPointer<DestinyActivityDefinition>> DisplayActivities { get; init; } =
            ReadOnlyCollections<DefinitionHashPointer<DestinyActivityDefinition>>.Empty;

        /// <summary>
        ///     The localized string for narrative text related to this quest step, if any.
        /// </summary>
        [JsonPropertyName("narrative")]
        public string Narrative { get; init; }

        /// <summary>
        ///     Objectives (DestinyObjectiveDefinition) that are part of this Quest Step, in the order that they should be
        ///     rendered.
        /// </summary>
        [JsonPropertyName("objectiveHashes")]
        public ReadOnlyCollection<DefinitionHashPointer<DestinyObjectiveDefinition>> Objectives { get; init; } =
            ReadOnlyCollections<DefinitionHashPointer<DestinyObjectiveDefinition>>.Empty;

        /// <summary>
        ///     The localized string describing an action to be performed associated with the objectives, if any.
        /// </summary>
        [JsonPropertyName("objectiveVerbName")]
        public string ObjectiveVerbName { get; init; }

        /// <summary>
        ///     One entry per Objective on the item, it will have related display information.
        /// </summary>
        [JsonPropertyName("perObjectiveDisplayProperties")]
        public ReadOnlyCollection<DestinyObjectiveDisplayProperties> PerObjectiveDisplayProperties { get; init; } =
            ReadOnlyCollections<DestinyObjectiveDisplayProperties>.Empty;

        /// <summary>
        ///     A hashed value for the questTypeIdentifier, because apparently I like to be redundant.
        /// </summary>
        [JsonPropertyName("questTypeHash")]
        public uint QuestTypeHash { get; init; }

        /// <summary>
        ///     The identifier for the type of quest being performed, if any. Not associated with any fixed definition, yet.
        /// </summary>
        [JsonPropertyName("questTypeIdentifier")]
        public string QuestTypeIdentifier { get; init; }

        /// <summary>
        ///     The DestinyInventoryItemDefinition representing the Quest to which this Quest Step belongs.
        /// </summary>
        [JsonPropertyName("questlineItemHash")]
        public DefinitionHashPointer<DestinyInventoryItemDefinition> QuestlineItem { get; init; } =
            DefinitionHashPointer<DestinyInventoryItemDefinition>.Empty;

        /// <summary>
        ///     If True, all objectives must be completed for the step to be completed. If False, any one objective can be
        ///     completed for the step to be completed.
        /// </summary>
        [JsonPropertyName("requireFullObjectiveCompletion")]
        public bool RequireFullObjectiveCompletion { get; init; }

        [JsonPropertyName("displayAsStatTracker")]
        public bool DisplayAsStatTracker { get; init; }

        public bool DeepEquals(DestinyItemObjectiveBlockDefinition other)
        {
            return other != null &&
                   DisplayActivities.DeepEqualsReadOnlyCollections(other.DisplayActivities) &&
                   Narrative == other.Narrative &&
                   Objectives.DeepEqualsReadOnlyCollections(other.Objectives) &&
                   ObjectiveVerbName == other.ObjectiveVerbName &&
                   PerObjectiveDisplayProperties.DeepEqualsReadOnlyCollections(other.PerObjectiveDisplayProperties) &&
                   QuestTypeHash == other.QuestTypeHash &&
                   QuestTypeIdentifier == other.QuestTypeIdentifier &&
                   QuestlineItem.DeepEquals(other.QuestlineItem) &&
                   RequireFullObjectiveCompletion == other.RequireFullObjectiveCompletion &&
                   DisplayAsStatTracker == other.DisplayAsStatTracker;
        }
    }
}