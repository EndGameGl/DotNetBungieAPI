using NetBungieAPI.Models.Destiny.Activities;
using NetBungieAPI.Models.Destiny.Definitions.Activities;
using NetBungieAPI.Models.Destiny.Definitions.ActivityModes;
using System;
using System.Collections.ObjectModel;
using System.Text.Json.Serialization;

namespace NetBungieAPI.Models.Destiny.Components
{
    public sealed record DestinyCharacterActivitiesComponent
    {
        [JsonPropertyName("dateActivityStarted")]
        public DateTime DateActivityStarted { get; init; }
        [JsonPropertyName("availableActivities")]
        public ReadOnlyCollection<DestinyActivity> AvailableActivities { get; init; } = Defaults.EmptyReadOnlyCollection<DestinyActivity>();
        [JsonPropertyName("currentActivityHash")]
        public DefinitionHashPointer<DestinyActivityDefinition> CurrentActivity { get; init; } = DefinitionHashPointer<DestinyActivityDefinition>.Empty;
        [JsonPropertyName("currentActivityModeHash")]
        public DefinitionHashPointer<DestinyActivityModeDefinition> CurrentActivityMode { get; init; } = DefinitionHashPointer<DestinyActivityModeDefinition>.Empty;
        [JsonPropertyName("currentActivityModeType")]
        public DestinyActivityModeType? CurrentActivityModeType { get; init; }
        [JsonPropertyName("currentActivityModeHashes")]
        public ReadOnlyCollection<DefinitionHashPointer<DestinyActivityModeDefinition>> CurrentActivityModes { get; init; } = Defaults.EmptyReadOnlyCollection<DefinitionHashPointer<DestinyActivityModeDefinition>>();
        [JsonPropertyName("currentActivityModeTypes")]
        public ReadOnlyCollection<DestinyActivityModeType> CurrentActivityModeTypes { get; init; } = Defaults.EmptyReadOnlyCollection<DestinyActivityModeType>();
        [JsonPropertyName("currentPlaylistActivityHash")]
        public DefinitionHashPointer<DestinyActivityDefinition> CurrentPlaylistActivity { get; init; } = DefinitionHashPointer<DestinyActivityDefinition>.Empty;
        [JsonPropertyName("lastCompletedStoryHash")]
        public DefinitionHashPointer<DestinyActivityDefinition> LastCompletedStory { get; init; } = DefinitionHashPointer<DestinyActivityDefinition>.Empty;
    }
}
