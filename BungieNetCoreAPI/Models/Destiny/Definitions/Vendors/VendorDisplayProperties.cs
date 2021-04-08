using Newtonsoft.Json;
using System.Collections.ObjectModel;

namespace NetBungieAPI.Destiny.Definitions.Vendors
{
    public class VendorDisplayProperties : DestinyDisplayPropertiesDefinition, IDeepEquatable<VendorDisplayProperties>
    {
        public string LargeIcon { get; init; }
        public string LargeTransparentIcon { get; init; }
        public string MapIcon { get; init; }
        public string OriginalIcon { get; init; }
        public ReadOnlyCollection<VendorDisplayPropertiesRequirement> RequirementsDisplay { get; init; }
        public string SmallTransparentIcon { get; init; }
        public string Subtitle { get; init; }

        [JsonConstructor]
        internal VendorDisplayProperties(string description, bool hasIcon, string icon, string largeIcon, string largeTransparentIcon, string mapIcon,
            string name, string originalIcon, VendorDisplayPropertiesRequirement[] requirementsDisplay, string smallTransparentIcon, string subtitle,
            string highResIcon, DestinyDefinitionDisplayPropertiesIconSequenceEntry[] iconSequences)
            : base(description, hasIcon, icon, name, highResIcon, iconSequences)
        {
            LargeIcon = largeIcon;
            LargeTransparentIcon = largeTransparentIcon;
            MapIcon = mapIcon;
            OriginalIcon = originalIcon;
            RequirementsDisplay = requirementsDisplay.AsReadOnlyOrEmpty();
            SmallTransparentIcon = smallTransparentIcon;
            Subtitle = subtitle;
        }

        public bool DeepEquals(VendorDisplayProperties other)
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
