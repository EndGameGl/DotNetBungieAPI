using NetBungieAPI.Models.Destiny.Definitions.TalentGrids;
using System.Text.Json.Serialization;

namespace NetBungieAPI.Models.Destiny.Definitions.InventoryItems
{
    /// <summary>
    /// This defines information that can only come from a talent grid on an item. Items mostly have negligible talent grid data these days, but instanced items still retain grids as a source for some of this common information.
    /// <para/>
    /// Builds/Subclasses are the only items left that still have talent grids with meaningful Nodes.
    /// </summary>
    public sealed record DestinyItemTalentGridBlockDefinition : IDeepEquatable<DestinyItemTalentGridBlockDefinition>
    {
        [JsonPropertyName("hudDamageType")]
        public DamageType HudDamageType { get; init; }
        [JsonPropertyName("itemDetailString")]
        public string ItemDetailString { get; init; }
        [JsonPropertyName("talentGridHash")]
        public DefinitionHashPointer<DestinyTalentGridDefinition> TalentGrid { get; init; } = DefinitionHashPointer<DestinyTalentGridDefinition>.Empty;
        [JsonPropertyName("buildName")]
        public string BuildName { get; init; }
        [JsonPropertyName("hudIcon")]
        public string HudIcon { get; init; }

        public bool DeepEquals(DestinyItemTalentGridBlockDefinition other)
        {
            return other != null &&
                   HudDamageType == other.HudDamageType &&
                   ItemDetailString == other.ItemDetailString &&
                   TalentGrid.DeepEquals(other.TalentGrid) &&
                   BuildName == other.BuildName &&
                   HudIcon == other.HudIcon;
        }
    }
}
