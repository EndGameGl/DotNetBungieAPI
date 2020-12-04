using Newtonsoft.Json;
using System.Collections.Generic;

namespace BungieNetCoreAPI.Destiny.Definitions.Vendors
{
    public class VendorDisplayProperties
    {
        public string Description { get; }
        public bool HasIcon { get; }
        public string Icon { get; }
        public string LargeIcon { get; }
        public string LargeTransparentIcon { get; }
        public string MapIcon { get; }
        public string Name { get; }
        public string OriginalIcon { get; }
        public List<VendorDisplayPropertiesRequirement> RequirementsDisplay { get; }
        public string SmallTransparentIcon { get; }
        public string Subtitle { get; }

        [JsonConstructor]
        private VendorDisplayProperties(string description, bool hasIcon, string icon, string largeIcon, string largeTransparentIcon, string mapIcon,
            string name, string originalIcon, List<VendorDisplayPropertiesRequirement> requirementsDisplay, string smallTransparentIcon, string subtitle)
        {
            Description = description;
            HasIcon = hasIcon;
            Icon = icon;
            LargeIcon = largeIcon;
            LargeTransparentIcon = largeTransparentIcon;
            MapIcon = mapIcon;
            Name = name;
            OriginalIcon = originalIcon;
            RequirementsDisplay = requirementsDisplay;
            SmallTransparentIcon = smallTransparentIcon;
            Subtitle = subtitle;
        }
    }
}
