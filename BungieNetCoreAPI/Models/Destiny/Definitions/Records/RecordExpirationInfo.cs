using Newtonsoft.Json;

namespace NetBungieAPI.Destiny.Definitions.Records
{
    public class RecordExpirationInfo : IDeepEquatable<RecordExpirationInfo>
    {
        public string Description { get; init; }
        public bool HasExpiration { get; init; }
        public string Icon { get; init; }

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
