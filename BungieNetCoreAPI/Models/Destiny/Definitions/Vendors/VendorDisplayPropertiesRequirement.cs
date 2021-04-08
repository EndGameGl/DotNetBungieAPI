using Newtonsoft.Json;

namespace NetBungieAPI.Destiny.Definitions.Vendors
{
    public class VendorDisplayPropertiesRequirement : IDeepEquatable<VendorDisplayPropertiesRequirement>
    {
        public string Icon { get; init; }
        public string Name { get; init; }
        public string Source { get; init; }
        public string Type { get; init; }

        [JsonConstructor]
        internal VendorDisplayPropertiesRequirement(string icon, string name, string source, string type)
        {
            Icon = icon;
            Name = name;
            Source = source;
            Type = type;
        }

        public bool DeepEquals(VendorDisplayPropertiesRequirement other)
        {
            return other != null &&
                   Icon == other.Icon &&
                   Name == other.Name &&
                   Source == other.Source &&
                   Type == other.Type;
        }
    }
}
