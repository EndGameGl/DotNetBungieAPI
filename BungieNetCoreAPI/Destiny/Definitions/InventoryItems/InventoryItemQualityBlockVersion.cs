using NetBungieApi.Destiny.Definitions.PowerCaps;
using Newtonsoft.Json;

namespace NetBungieApi.Destiny.Definitions.InventoryItems
{
    /// <summary>
    /// The version definition currently just holds a reference to the power cap.
    /// </summary>
    public class InventoryItemQualityBlockVersion : IDeepEquatable<InventoryItemQualityBlockVersion>
    {
        /// <summary>
        /// A reference to the power cap for this item version.
        /// </summary>
        public DefinitionHashPointer<DestinyPowerCapDefinition> PowerCap { get; }

        [JsonConstructor]
        internal InventoryItemQualityBlockVersion(uint powerCapHash)
        {
            PowerCap = new DefinitionHashPointer<DestinyPowerCapDefinition>(powerCapHash, DefinitionsEnum.DestinyPowerCapDefinition);
        }

        public bool DeepEquals(InventoryItemQualityBlockVersion other)
        {
            return other != null &&
                PowerCap.DeepEquals(other.PowerCap);
        }
    }
}
