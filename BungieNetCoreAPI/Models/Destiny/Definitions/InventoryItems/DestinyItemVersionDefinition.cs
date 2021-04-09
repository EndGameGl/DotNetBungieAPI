using NetBungieAPI.Models.Destiny.Definitions.PowerCaps;
using System.Text.Json.Serialization;

namespace NetBungieAPI.Models.Destiny.Definitions.InventoryItems
{
    /// <summary>
    /// The version definition currently just holds a reference to the power cap.
    /// </summary>
    public sealed record DestinyItemVersionDefinition : IDeepEquatable<DestinyItemVersionDefinition>
    {
        /// <summary>
        /// A reference to the power cap for this item version.
        /// </summary>
        [JsonPropertyName("powerCapHash")]
        public DefinitionHashPointer<DestinyPowerCapDefinition> PowerCap { get; init; } = DefinitionHashPointer<DestinyPowerCapDefinition>.Empty;

        public bool DeepEquals(DestinyItemVersionDefinition other)
        {
            return other != null &&
                PowerCap.DeepEquals(other.PowerCap);
        }
    }
}
