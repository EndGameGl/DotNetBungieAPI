using BungieNetCoreAPI.Destiny.Definitions.Activities;
using BungieNetCoreAPI.Destiny.Definitions.ActivityModes;
using Newtonsoft.Json;
using System;
using System.Collections.ObjectModel;

namespace BungieNetCoreAPI.Destiny.Profile.Components.Contracts
{
    public class ComponentDestinyCharacterActivities
    {
        public DateTime DateActivityStarted { get; }
        public ReadOnlyCollection<DestinyActivity> AvailableActivities { get; }
        public DefinitionHashPointer<DestinyActivityDefinition> CurrentActivity { get; }
        public DefinitionHashPointer<DestinyActivityModeDefinition> CurrentActivityMode { get; }
        public DestinyActivityModeType? CurrentActivityModeType { get; }
        public ReadOnlyCollection<DefinitionHashPointer<DestinyActivityModeDefinition>> CurrentActivityModes { get; }
        public ReadOnlyCollection<DestinyActivityModeType> CurrentActivityModeTypes { get; }
        public DefinitionHashPointer<DestinyActivityDefinition> CurrentPlaylistActivity { get; }
        public DefinitionHashPointer<DestinyActivityDefinition> LastCompletedStory { get; }

        [JsonConstructor]
        internal ComponentDestinyCharacterActivities(DateTime dateActivityStarted, DestinyActivity[] availableActivities, uint currentActivityHash,
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
