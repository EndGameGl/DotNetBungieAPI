using Newtonsoft.Json;

namespace BungieNetCoreAPI.Destiny.Definitions.Vendors
{
    public class VendorDisplayPropertiesRequirement
    {
        public string Icon { get; }
        public string Name { get; }
        public string Source { get; }
        public string Type { get; }

        [JsonConstructor]
        private VendorDisplayPropertiesRequirement(string icon, string name, string source, string type)
        {
            Icon = icon;
            Name = name;
            Source = source;
            Type = type;
        }
    }
}
