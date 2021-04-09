using NetBungieAPI.Models.Destiny.Definitions.SandboxPerks;
using System.Text.Json.Serialization;

namespace NetBungieAPI.Models.Destiny.Definitions.InventoryItems
{
    public sealed record DestinyItemPerkEntryDefinition : IDeepEquatable<DestinyItemPerkEntryDefinition>
    {
        [JsonPropertyName("perkHash")]
        public DefinitionHashPointer<DestinySandboxPerkDefinition> Perk { get; init; } = DefinitionHashPointer<DestinySandboxPerkDefinition>.Empty;
        [JsonPropertyName("perkVisibility")]
        public ItemPerkVisibility PerkVisibility { get; init; }
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
