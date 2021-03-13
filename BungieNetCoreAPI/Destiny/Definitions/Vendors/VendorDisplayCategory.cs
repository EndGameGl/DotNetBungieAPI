using NetBungieApi.Destiny.Definitions.Progressions;
using Newtonsoft.Json;

namespace NetBungieApi.Destiny.Definitions.Vendors
{
    public class VendorDisplayCategory : IDeepEquatable<VendorDisplayCategory>
    {
        public int Index { get; }
        public string Identifier { get; }
        public uint DisplayCategoryHash { get; }
        public DestinyDefinitionDisplayProperties DisplayProperties { get; }
        public bool DisplayInBanner { get; }
        public DefinitionHashPointer<DestinyProgressionDefinition> Progression { get; }
        public VendorDisplayCategorySortOrder SortOrder { get; }
        public uint? DisplayStyleHash { get; }
        public string DisplayStyleIdentifier { get; }

        [JsonConstructor]
        internal VendorDisplayCategory(uint displayCategoryHash, bool displayInBanner, DestinyDefinitionDisplayProperties displayProperties, string identifier,
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
