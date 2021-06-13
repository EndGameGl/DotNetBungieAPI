using NetBungieAPI.Models.Destiny.Definitions.SandboxPerks;
using System.Text.Json.Serialization;

namespace NetBungieAPI.Models.Destiny.Definitions.InventoryItems
{
    /// <summary>
    /// An intrinsic perk on an item, and the requirements for it to be activated.
    /// </summary>
    public sealed record DestinyItemPerkEntryDefinition : IDeepEquatable<DestinyItemPerkEntryDefinition>
    {
        /// <summary>
        /// A hash identifier for the DestinySandboxPerkDefinition being provided on the item.
        /// </summary>
        [JsonPropertyName("perkHash")]
        public DefinitionHashPointer<DestinySandboxPerkDefinition> Perk { get; init; } =
            DefinitionHashPointer<DestinySandboxPerkDefinition>.Empty;

        /// <summary>
        /// Indicates whether this perk should be shown, or if it should be shown disabled.
        /// </summary>
        [JsonPropertyName("perkVisibility")]
        public ItemPerkVisibility PerkVisibility { get; init; }

        /// <summary>
        /// If this perk is not active, this is the string to show for why it's not providing its benefits.
        /// </summary>
        [JsonPropertyName("requirementDisplayString")]
        public string RequirementDisplayString { get; init; }

        public bool DeepEquals(DestinyItemPerkEntryDefinition other)
        {
            return other != null &&
                   Perk.DeepEquals(other.Perk) &&
                   PerkVisibility == other.PerkVisibility &&
                   RequirementDisplayString == other.RequirementDisplayString;
        }
    }
}