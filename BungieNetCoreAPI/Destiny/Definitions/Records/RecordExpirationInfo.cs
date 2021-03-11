using Newtonsoft.Json;

namespace BungieNetCoreAPI.Destiny.Definitions.Records
{
    public class RecordExpirationInfo : IDeepEquatable<RecordExpirationInfo>
    {
        public string Description { get; }
        public bool HasExpiration { get; }
        public string Icon { get; }

        [JsonConstructor]
        internal RecordExpirationInfo(string description, bool hasExpiration, string icon)
        {
            Description = description;
            HasExpiration = hasExpiration;
            Icon = icon;
        }

        public bool DeepEquals(RecordExpirationInfo other)
        {
            return other != null &&
                   Description == other.Description &&
                   HasExpiration == other.HasExpiration &&
                   Icon == other.Icon;
        }
    }
}
