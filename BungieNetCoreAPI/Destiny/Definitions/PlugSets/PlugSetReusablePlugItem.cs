using NetBungieAPI.Destiny.Definitions.InventoryItems;
using Newtonsoft.Json;

namespace NetBungieAPI.Destiny.Definitions.PlugSets
{
    public class PlugSetReusablePlugItem : IDeepEquatable<PlugSetReusablePlugItem>
    {
        public double Weight { get; }
        public double AlternateWeight { get; }
        public DefinitionHashPointer<DestinyInventoryItemDefinition> PlugItem { get; }
        public bool CurrentlyCanRoll { get; }

        [JsonConstructor]
        internal PlugSetReusablePlugItem(double weight, double alternateWeight, uint plugItemHash, bool currentlyCanRoll)
        {
            Weight = weight;
            AlternateWeight = alternateWeight;
            PlugItem = new DefinitionHashPointer<DestinyInventoryItemDefinition>(plugItemHash, DefinitionsEnum.DestinyInventoryItemDefinition);
            CurrentlyCanRoll = currentlyCanRoll;
        }

        public bool DeepEquals(PlugSetReusablePlugItem other)
        {
            return other != null &&
                   Weight == other.Weight &&
                   AlternateWeight == other.AlternateWeight &&
                   PlugItem.DeepEquals(other.PlugItem) &&
                   CurrentlyCanRoll == other.CurrentlyCanRoll;
        }
    }
}
