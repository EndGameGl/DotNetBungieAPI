using NetBungieAPI.Destiny.Definitions.DamageTypes;
using NetBungieAPI.Destiny.Definitions.TalentGrids;
using Newtonsoft.Json;

namespace NetBungieAPI.Destiny.Definitions.InventoryItems
{
    /// <summary>
    /// This defines information that can only come from a talent grid on an item. Items mostly have negligible talent grid data these days, but instanced items still retain grids as a source for some of this common information.
    /// <para/>
    /// Builds/Subclasses are the only items left that still have talent grids with meaningful Nodes.
    /// </summary>
    public class InventoryItemTalentGrid : IDeepEquatable<InventoryItemTalentGrid>
    {
        public DamageType HudDamageType { get; }
        public string ItemDetailString { get; }
        public DefinitionHashPointer<DestinyTalentGridDefinition> TalentGrid { get; }
        public string BuildName { get; }
        public string HudIcon { get; }

        [JsonConstructor]
        internal InventoryItemTalentGrid(DamageType hudDamageType, string itemDetailString, uint talentGridHash, string buildName, string hudIcon)
        {
            HudDamageType = hudDamageType;
            ItemDetailString = itemDetailString;
            TalentGrid = new DefinitionHashPointer<DestinyTalentGridDefinition>(talentGridHash, DefinitionsEnum.DestinyTalentGridDefinition);
            BuildName = buildName;
            HudIcon = hudIcon;
        }

        public bool DeepEquals(InventoryItemTalentGrid other)
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
