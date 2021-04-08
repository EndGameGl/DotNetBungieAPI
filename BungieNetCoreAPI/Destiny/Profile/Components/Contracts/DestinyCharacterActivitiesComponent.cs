using NetBungieAPI.Models.Destiny.Definitions.Activities;
using NetBungieAPI.Models.Destiny.Definitions.ActivityModes;
using Newtonsoft.Json;
using System;
using System.Collections.ObjectModel;

namespace NetBungieAPI.Destiny.Profile.Components.Contracts
{
    public class DestinyCharacterActivitiesComponent
    {
        public DateTime DateActivityStarted { get; init; }
        public ReadOnlyCollection<DestinyActivity> AvailableActivities { get; init; }
        public DefinitionHashPointer<DestinyActivityDefinition> CurrentActivity { get; init; }
        public DefinitionHashPointer<DestinyActivityModeDefinition> CurrentActivityMode { get; init; }
        public DestinyActivityModeType? CurrentActivityModeType { get; init; }
        public ReadOnlyCollection<DefinitionHashPointer<DestinyActivityModeDefinition>> CurrentActivityModes { get; init; }
        public ReadOnlyCollection<DestinyActivityModeType> CurrentActivityModeTypes { get; init; }
        public DefinitionHashPointer<DestinyActivityDefinition> CurrentPlaylistActivity { get; init; }
        public DefinitionHashPointer<DestinyActivityDefinition> LastCompletedStory { get; init; }

        [JsonConstructor]
        internal DestinyCharacterActivitiesComponent(DateTime dateActivityStarted, DestinyActivity[] availableActivities, uint currentActivityHash,
            uint currentActivityModeHash, DestinyActivityModeType? currentActivityModeType, uint[] currentActivityModeHashes, 
            DestinyActivityModeType[] currentActivityModeTypes, uint? currentPlaylistActivityHash, uint lastCompletedStoryHash)
        {
            DateActivityStarted = dateActivityStarted;
            AvailableActivities = availableActivities.AsReadOnlyOrEmpty();
            CurrentActivity = new DefinitionHashPointer<DestinyActivityDefinition>(currentActivityHash, DefinitionsEnum.DestinyActivityDefinition);
            CurrentActivityMode = new DefinitionHashPointer<DestinyActivityModeDefinition>(currentActivityModeHash, DefinitionsEnum.DestinyActivityModeDefinition);
            CurrentActivityModeType = currentActivityModeType;
            CurrentActivityModes = currentActivityModeHashes.DefinitionsAsReadOnlyOrEmpty<DestinyActivityModeDefinition>(DefinitionsEnum.DestinyActivityModeDefinition);
            CurrentActivityModeTypes = currentActivityModeTypes.AsReadOnlyOrEmpty();
            CurrentPlaylistActivity = new DefinitionHashPointer<DestinyActivityDefinition>(currentPlaylistActivityHash, DefinitionsEnum.DestinyActivityDefinition);
            LastCompletedStory = new DefinitionHashPointer<DestinyActivityDefinition>(lastCompletedStoryHash, DefinitionsEnum.DestinyActivityDefinition);
        }
    }
}
