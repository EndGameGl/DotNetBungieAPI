using BungieNetCoreAPI.Destiny.Definitions.Activities;
using Newtonsoft.Json;

namespace BungieNetCoreAPI.Destiny.Definitions.Milestones
{
    public class MilestoneQuestActivityVariant : IDeepEquatable<MilestoneQuestActivityVariant>
    {
        public DefinitionHashPointer<DestinyActivityDefinition> Activity { get; }
        public int Order { get; }

        [JsonConstructor]
        internal MilestoneQuestActivityVariant(uint activityHash, int order)
        {
            Activity = new DefinitionHashPointer<DestinyActivityDefinition>(activityHash, DefinitionsEnum.DestinyActivityDefinition);
            Order = order;
        }

        public bool DeepEquals(MilestoneQuestActivityVariant other)
        {
            return other != null &&
                   Activity.DeepEquals(other.Activity) &&
                   Order == other.Order;
        }
    }
}
