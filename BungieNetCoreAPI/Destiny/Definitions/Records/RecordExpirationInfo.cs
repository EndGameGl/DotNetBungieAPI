using Newtonsoft.Json;

namespace BungieNetCoreAPI.Destiny.Definitions.Records
{
    public class RecordExpirationInfo
    {
        public string Description { get; }
        public bool HasExpiration { get; }

        [JsonConstructor]
        private RecordExpirationInfo(string description, bool hasExpiration)
        {
            Description = description;
            HasExpiration = hasExpiration;
        }
    }
}
