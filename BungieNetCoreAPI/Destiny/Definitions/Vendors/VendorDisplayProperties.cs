using Newtonsoft.Json;
using System.Collections.ObjectModel;

namespace BungieNetCoreAPI.Destiny.Definitions.Vendors
{
    public class VendorDisplayProperties : DestinyDefinitionDisplayProperties, IDeepEquatable<VendorDisplayProperties>
    {
        public string LargeIcon { get; }
        public string LargeTransparentIcon { get; }
        public string MapIcon { get; }
        public string OriginalIcon { get; }
        public ReadOnlyCollection<VendorDisplayPropertiesRequirement> RequirementsDisplay { get; }
        public string SmallTransparentIcon { get; }
        public string Subtitle { get; }

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
