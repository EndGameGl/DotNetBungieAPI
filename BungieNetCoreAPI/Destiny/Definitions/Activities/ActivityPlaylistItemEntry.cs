using BungieNetCoreAPI.Destiny.Definitions.ActivityModes;
using Newtonsoft.Json;
using System.Collections.Generic;

namespace BungieNetCoreAPI.Destiny.Definitions.Activities
{
    public class ActivityPlaylistItemEntry
    {
        public DefinitionHashPointer<DestinyActivityDefinition> Activity { get; }
        public List<DefinitionHashPointer<DestinyActivityModeDefinition>> ActivityModes { get; }
        public List<DestinyActivityModeType> ActivityModeTypes { get; }
        public DefinitionHashPointer<DestinyActivityDefinition> DirectActivityMode { get; }
        public DestinyActivityModeType DirectActivityModeType { get; }
        public int Weight { get; }

        [JsonConstructor]
        private ActivityPlaylistItemEntry(uint activityHash, List<uint> activityModeHashes, List<DestinyActivityModeType> activityModeTypes, uint directActivityModeHash,
            DestinyActivityModeType directActivityModeType, int weight)
        {
            Activity = new DefinitionHashPointer<DestinyActivityDefinition>(activityHash, "DestinyActivityDefinition", GlobalDefinitionsCacheRepository.CurrentLocaleLoadContext);
            if (activityModeHashes == null)
                ActivityModes = new List<DefinitionHashPointer<DestinyActivityModeDefinition>>();
            else
            {
                ActivityModes = new List<DefinitionHashPointer<DestinyActivityModeDefinition>>();
                foreach (var activityModeHash in activityModeHashes)
                {
                    ActivityModes.Add(new DefinitionHashPointer<DestinyActivityModeDefinition>(activityModeHash, "DestinyActivityModeDefinition", GlobalDefinitionsCacheRepository.CurrentLocaleLoadContext));
                }
            }
            if (activityModeTypes == null)
                ActivityModeTypes = new List<DestinyActivityModeType>();
            else
                ActivityModeTypes = activityModeTypes;
            DirectActivityMode = new DefinitionHashPointer<DestinyActivityDefinition>(directActivityModeHash, "DestinyActivityDefinition", GlobalDefinitionsCacheRepository.CurrentLocaleLoadContext);
            DirectActivityModeType = directActivityModeType;
            Weight = weight;
        }
    }
}
