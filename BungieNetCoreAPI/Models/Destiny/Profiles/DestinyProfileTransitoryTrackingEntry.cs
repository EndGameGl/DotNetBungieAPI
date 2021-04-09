using NetBungieAPI.Models.Destiny.Definitions.Activities;
using NetBungieAPI.Models.Destiny.Definitions.InventoryItems;
using NetBungieAPI.Models.Destiny.Definitions.Locations;
using NetBungieAPI.Models.Destiny.Definitions.Objectives;
using System;
using System.Text.Json.Serialization;

namespace NetBungieAPI.Models.Destiny.Profiles
{
    public sealed record DestinyProfileTransitoryTrackingEntry
    {
        [JsonPropertyName("locationHash")]
        public DefinitionHashPointer<DestinyLocationDefinition> Location { get; init; } = DefinitionHashPointer<DestinyLocationDefinition>.Empty;
        [JsonPropertyName("itemHash")]
        public DefinitionHashPointer<DestinyInventoryItemDefinition> Item { get; init; } = DefinitionHashPointer<DestinyInventoryItemDefinition>.Empty;
        [JsonPropertyName("objectiveHash")]
        public DefinitionHashPointer<DestinyObjectiveDefinition> Objective { get; init; } = DefinitionHashPointer<DestinyObjectiveDefinition>.Empty;
        [JsonPropertyName("activityHash")]
        public DefinitionHashPointer<DestinyActivityDefinition> Activity { get; init; } = DefinitionHashPointer<DestinyActivityDefinition>.Empty;
        [JsonPropertyName("questlineItemHash")]
        public DefinitionHashPointer<DestinyInventoryItemDefinition> QuestlineItem { get; init; } = DefinitionHashPointer<DestinyInventoryItemDefinition>.Empty;
        [JsonPropertyName("trackedDate")]
        public DateTime? TrackedDate { get; init; }
    }
}
