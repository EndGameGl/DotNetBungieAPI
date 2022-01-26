namespace DotNetBungieAPI.Generated.Models.Destiny.Definitions;

/// <summary>
///     Compare this sackType to the sack identifier in the DestinyInventoryItemDefinition.vendorSackType property of items. If they match, show this sack with this interaction.
/// </summary>
public class DestinyVendorInteractionSackEntryDefinition : IDeepEquatable<DestinyVendorInteractionSackEntryDefinition>
{
    [JsonPropertyName("sackType")]
    public uint SackType { get; set; }

    public bool DeepEquals(DestinyVendorInteractionSackEntryDefinition? other)
    {
        return other is not null &&
               SackType == other.SackType;
    }
}