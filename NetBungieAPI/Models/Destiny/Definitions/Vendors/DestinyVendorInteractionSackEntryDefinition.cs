using System.Text.Json.Serialization;

namespace NetBungieAPI.Models.Destiny.Definitions.Vendors
{
    public sealed record
        DestinyVendorInteractionSackEntryDefinition : IDeepEquatable<DestinyVendorInteractionSackEntryDefinition>
    {
        /// <summary>
        ///     Compare this sackType to the sack identifier in the DestinyInventoryItemDefinition.vendorSackType property of
        ///     items. If they match, show this sack with this interaction.
        /// </summary>
        [JsonPropertyName("sackType")]
        public uint SackType { get; init; }

        public bool DeepEquals(DestinyVendorInteractionSackEntryDefinition other)
        {
            return other != null &&
                   SackType == other.SackType;
        }
    }
}