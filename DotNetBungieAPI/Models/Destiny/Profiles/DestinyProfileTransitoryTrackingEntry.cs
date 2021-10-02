using System;
using System.Text.Json.Serialization;
using DotNetBungieAPI.Models.Destiny.Definitions.Activities;
using DotNetBungieAPI.Models.Destiny.Definitions.InventoryItems;
using DotNetBungieAPI.Models.Destiny.Definitions.Locations;
using DotNetBungieAPI.Models.Destiny.Definitions.Objectives;

namespace DotNetBungieAPI.Models.Destiny.Profiles
{
    /// <summary>
    ///     This represents a single "thing" being tracked by the player.
    ///     <para />
    ///     This can point to many types of entities, but only a subset of them will actually have a valid hash identifier for
    ///     whatever it is being pointed to.
    ///     <para />
    ///     It's up to you to interpret what it means when various combinations of these entries have values being tracked.
    /// </summary>
    public sealed record DestinyProfileTransitoryTrackingEntry
    {
        /// <summary>
        ///     OPTIONAL - If this is tracking a DestinyLocationDefinition, this is the identifier for that location.
        /// </summary>
        [JsonPropertyName("locationHash")]
        public DefinitionHashPointer<DestinyLocationDefinition> Location { get; init; } =
            DefinitionHashPointer<DestinyLocationDefinition>.Empty;

        /// <summary>
        ///     OPTIONAL - If this is tracking the status of a DestinyInventoryItemDefinition, this is the identifier for that
        ///     item.
        /// </summary>
        [JsonPropertyName("itemHash")]
        public DefinitionHashPointer<DestinyInventoryItemDefinition> Item { get; init; } =
            DefinitionHashPointer<DestinyInventoryItemDefinition>.Empty;

        /// <summary>
        ///     OPTIONAL - If this is tracking the status of a DestinyObjectiveDefinition, this is the identifier for that
        ///     objective.
        /// </summary>
        [JsonPropertyName("objectiveHash")]
        public DefinitionHashPointer<DestinyObjectiveDefinition> Objective { get; init; } =
            DefinitionHashPointer<DestinyObjectiveDefinition>.Empty;

        /// <summary>
        ///     OPTIONAL - If this is tracking the status of a DestinyActivityDefinition, this is the identifier for that activity.
        /// </summary>
        [JsonPropertyName("activityHash")]
        public DefinitionHashPointer<DestinyActivityDefinition> Activity { get; init; } =
            DefinitionHashPointer<DestinyActivityDefinition>.Empty;

        /// <summary>
        ///     OPTIONAL - If this is tracking the status of a quest, this is the identifier for the DestinyInventoryItemDefinition
        ///     that containst that questline data.
        /// </summary>
        [JsonPropertyName("questlineItemHash")]
        public DefinitionHashPointer<DestinyInventoryItemDefinition> QuestlineItem { get; init; } =
            DefinitionHashPointer<DestinyInventoryItemDefinition>.Empty;

        /// <summary>
        ///     OPTIONAL - I've got to level with you, I don't really know what this is. Is it when you started tracking it? Is it
        ///     only populated for tracked items that have time limits?
        /// </summary>
        [JsonPropertyName("trackedDate")]
        public DateTime? TrackedDate { get; init; }
    }
}