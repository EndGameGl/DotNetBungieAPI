using NetBungieAPI.Destiny.Definitions.Progressions;
using Newtonsoft.Json;

namespace NetBungieAPI.Destiny.Definitions.Vendors
{
    public class VendorDisplayCategory : IDeepEquatable<VendorDisplayCategory>
    {
        public int Index { get; init; }
        public string Identifier { get; init; }
        public uint DisplayCategoryHash { get; init; }
        public DestinyDisplayPropertiesDefinition DisplayProperties { get; init; }
        public bool DisplayInBanner { get; init; }
        public DefinitionHashPointer<DestinyProgressionDefinition> Progression { get; init; }
        public VendorDisplayCategorySortOrder SortOrder { get; init; }
        public uint? DisplayStyleHash { get; init; }
        public string DisplayStyleIdentifier { get; init; }

        [JsonConstructor]
        internal VendorDisplayCategory(uint displayCategoryHash, bool displayInBanner, DestinyDisplayPropertiesDefinition displayProperties, string identifier,
            int index, VendorDisplayCategorySortOrder sortOrder, uint? progressionHash, uint? displayStyleHash, string displayStyleIdentifier)
        {
            DisplayCategoryHash = displayCategoryHash;
            DisplayInBanner = displayInBanner;
            DisplayProperties = displayProperties;
            Identifier = identifier;
            Index = index;
            SortOrder = sortOrder;
            Progression = new DefinitionHashPointer<DestinyProgressionDefinition>(progressionHash, DefinitionsEnum.DestinyProgressionDefinition);
            DisplayStyleHash = displayStyleHash;
            DisplayStyleIdentifier = displayStyleIdentifier;
        }

        public bool DeepEquals(VendorDisplayCategory other)
        {
            return other != null &&
                   Index == other.Index &&
                   Identifier == other.Identifier &&
                   DisplayCategoryHash == other.DisplayCategoryHash &&
                   DisplayProperties.DeepEquals(other.DisplayProperties) &&
                   DisplayInBanner == other.DisplayInBanner &&
                   Progression.DeepEquals(other.Progression) &&
                   SortOrder == other.SortOrder &&
                   DisplayStyleHash == other.DisplayStyleHash &&
                   DisplayStyleIdentifier == other.DisplayStyleIdentifier;
        }
    }
}
