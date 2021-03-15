using NetBungieAPI.Destiny.Definitions.InventoryItems;
using NetBungieAPI.Destiny.Definitions.Locations;
using NetBungieAPI.Destiny.Definitions.Objectives;
using Newtonsoft.Json;

namespace NetBungieAPI.Destiny.Definitions.Activities
{
    public class ActivityLocationMappingDefinition : IDeepEquatable<ActivityLocationMappingDefinition>
    {
        /// <summary>
        /// A hint that the UI uses to figure out how this location is activated by the player.
        /// </summary>
        public string ActivationSource { get; }
        /// <summary>
        /// If this is populated, this is the activity you have to be playing in order to see this location appear because of this mapping. (theoretically, a location can have multiple mappings, and some might require you to be in a specific activity when others don't)
        /// </summary>
        public DefinitionHashPointer<DestinyActivityDefinition> Activity { get; }
        /// <summary>
        /// The location that is revealed on the director by this mapping.
        /// </summary>
        public DefinitionHashPointer<DestinyLocationDefinition> Location { get; }
        /// <summary>
        /// If this is populated, it is the item that you must possess for this location to be active because of this mapping. (theoretically, a location can have multiple mappings, and some might require an item while others don't)
        /// </summary>
        public DefinitionHashPointer<DestinyInventoryItemDefinition> Item { get; }
        /// <summary>
        /// If this is populated, this is an objective related to the location.
        /// </summary>
        public DefinitionHashPointer<DestinyObjectiveDefinition> Objective { get; }

        [JsonConstructor]
        internal ActivityLocationMappingDefinition(string activationSource, uint? activityHash, uint? locationHash, uint? itemHash, uint? objectiveHash)
        {
            ActivationSource = activationSource;
            Activity = new DefinitionHashPointer<DestinyActivityDefinition>(activityHash, DefinitionsEnum.DestinyActivityDefinition);
            Location = new DefinitionHashPointer<DestinyLocationDefinition>(locationHash, DefinitionsEnum.DestinyLocationDefinition);
            Item = new DefinitionHashPointer<DestinyInventoryItemDefinition>(itemHash, DefinitionsEnum.DestinyInventoryItemDefinition);
            Objective = new DefinitionHashPointer<DestinyObjectiveDefinition>(objectiveHash, DefinitionsEnum.DestinyObjectiveDefinition);
        }

        public bool DeepEquals(ActivityLocationMappingDefinition other)
        {
            return other != null &&
                   ActivationSource == other.ActivationSource &&
                   Activity.DeepEquals(other.Activity) &&
                   Location.DeepEquals(other.Location) &&
                   Item.DeepEquals(other.Item) &&
                   Objective.DeepEquals(other.Objective);
        }
    }
}
