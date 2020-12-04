using Newtonsoft.Json;

namespace BungieNetCoreAPI.Destiny.Definitions.Vendors
{
    public class VendorDisplayCategory
    {
        public uint DisplayCategoryHash { get; }
        public bool DisplayInBanner { get; }
        public DestinyDefinitionDisplayProperties DisplayProperties { get; }
        public string Identifier { get; }
        public int Index { get; }
        public int SortOrder { get; }

        [JsonConstructor]
        private VendorDisplayCategory(uint displayCategoryHash, bool displayInBanner, DestinyDefinitionDisplayProperties displayProperties, string identifier,
            int index, int sortOrder)
        {
            DisplayCategoryHash = displayCategoryHash;
            DisplayInBanner = displayInBanner;
            DisplayProperties = displayProperties;
            Identifier = identifier;
            Index = index;
            SortOrder = sortOrder;
        }
    }
}
