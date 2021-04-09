using NetBungieAPI.Models.Destiny.Definitions.Common;
using System.Collections.ObjectModel;
using System.Text.Json.Serialization;

namespace NetBungieAPI.Models.Destiny.Definitions.Vendors
{
    public sealed record DestinyVendorDisplayPropertiesDefinition : DestinyDisplayPropertiesDefinition, IDeepEquatable<DestinyVendorDisplayPropertiesDefinition>
    {
        [JsonPropertyName("largeIcon")]
        public string LargeIcon { get; init; }
        [JsonPropertyName("largeTransparentIcon")]
        public string LargeTransparentIcon { get; init; }
        [JsonPropertyName("mapIcon")]
        public string MapIcon { get; init; }
        [JsonPropertyName("originalIcon")]
        public string OriginalIcon { get; init; }
        [JsonPropertyName("requirementsDisplay")]
        public ReadOnlyCollection<DestinyVendorRequirementDisplayEntryDefinition> RequirementsDisplay { get; init; } = Defaults.EmptyReadOnlyCollection<DestinyVendorRequirementDisplayEntryDefinition>();
        [JsonPropertyName("smallTransparentIcon")]
        public string SmallTransparentIcon { get; init; }
        [JsonPropertyName("subtitle")]
        public string Subtitle { get; init; }

        public bool DeepEquals(DestinyVendorDisplayPropertiesDefinition other)
        {
            return other != null &&
                   Description == other.Description &&
                   HasIcon == other.HasIcon &&
                   Icon == other.Icon &&
                   Name == other.Name &&
                   HighResolutionIcon == other.HighResolutionIcon &&
                   IconSequences.DeepEqualsReadOnlyCollections(other.IconSequences) &&
                   LargeIcon == other.LargeIcon &&
                   LargeTransparentIcon == other.LargeTransparentIcon &&
                   MapIcon == other.MapIcon &&
                   OriginalIcon == other.OriginalIcon &&
                   RequirementsDisplay.DeepEqualsReadOnlyCollections(other.RequirementsDisplay) &&
                   SmallTransparentIcon == other.SmallTransparentIcon &&
                   Subtitle == other.Subtitle;
        }
    }
}
