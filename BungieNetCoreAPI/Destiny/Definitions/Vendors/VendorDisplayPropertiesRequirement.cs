using Newtonsoft.Json;

namespace NetBungieApi.Destiny.Definitions.Vendors
{
    public class VendorDisplayPropertiesRequirement : IDeepEquatable<VendorDisplayPropertiesRequirement>
    {
        public string Icon { get; }
        public string Name { get; }
        public string Source { get; }
        public string Type { get; }

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
