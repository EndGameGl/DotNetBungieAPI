using NetBungieAPI.Models.Destiny.Definitions.Common;
using NetBungieAPI.Models.Destiny.Definitions.Progressions;
using System.Text.Json.Serialization;

namespace NetBungieAPI.Models.Destiny.Definitions.Vendors
{
    public sealed record DestinyDisplayCategoryDefinition : IDeepEquatable<DestinyDisplayCategoryDefinition>
    {
        [JsonPropertyName("index")]
        public int Index { get; init; }
        [JsonPropertyName("identifier")]
        public string Identifier { get; init; }
        [JsonPropertyName("displayCategoryHash")]
        public uint DisplayCategoryHash { get; init; }
        [JsonPropertyName("displayProperties")]
        public DestinyDisplayPropertiesDefinition DisplayProperties { get; init; }
        [JsonPropertyName("displayInBanner")]
        public bool DisplayInBanner { get; init; }
        [JsonPropertyName("progressionHash")]
        public DefinitionHashPointer<DestinyProgressionDefinition> Progression { get; init; } = DefinitionHashPointer<DestinyProgressionDefinition>.Empty;
        [JsonPropertyName("sortOrder")]
        public VendorDisplayCategorySortOrder SortOrder { get; init; }
        [JsonPropertyName("displayStyleHash")]
        public uint? DisplayStyleHash { get; init; }
        [JsonPropertyName("displayStyleIdentifier")]
        public string DisplayStyleIdentifier { get; init; }

        public bool DeepEquals(DestinyDisplayCategoryDefinition other)
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
