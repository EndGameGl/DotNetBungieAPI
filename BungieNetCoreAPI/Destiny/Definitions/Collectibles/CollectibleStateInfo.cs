using NetBungieApi.Destiny.Definitions.InventoryItems;
using Newtonsoft.Json;

namespace NetBungieApi.Destiny.Definitions.Collectibles
{
    public class CollectibleStateInfo : IDeepEquatable<CollectibleStateInfo>
    {
        public DefinitionHashPointer<DestinyInventoryItemDefinition> ObscuredOverrideItem { get; }
        public CollectibleStateInfoRequirements Requirements { get; }

        [JsonConstructor]
        internal CollectibleStateInfo(uint? obscuredOverrideItemHash, CollectibleStateInfoRequirements requirements)
        {
            ObscuredOverrideItem = new DefinitionHashPointer<DestinyInventoryItemDefinition>(obscuredOverrideItemHash, DefinitionsEnum.DestinyInventoryItemDefinition);
            Requirements = requirements;
        }

        public bool DeepEquals(CollectibleStateInfo other)
        {
            return other != null &&
                Requirements.DeepEquals(other.Requirements);
        }
    }
}
