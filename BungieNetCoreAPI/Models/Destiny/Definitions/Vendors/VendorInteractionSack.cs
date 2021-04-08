using Newtonsoft.Json;

namespace NetBungieAPI.Destiny.Definitions.Vendors
{
    public class VendorInteractionSack : IDeepEquatable<VendorInteractionSack>
    {
        /// <summary>
        /// Compare this sackType to the sack identifier in the DestinyInventoryItemDefinition.vendorSackType property of items. If they match, show this sack with this interaction.
        /// </summary>
        public uint SackType { get; init; }

        [JsonConstructor]
        internal VendorInteractionSack(uint sackType)
        {
            SackType = sackType;
        }

        public bool DeepEquals(VendorInteractionSack other)
        {
            return other != null &&
                   SackType == other.SackType;
        }
    }
}
