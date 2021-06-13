using NetBungieAPI.Models.Applications;

namespace NetBungieAPI.Clients.Settings
{
    public class ClientIdentificationSettings
    {
        public string ApiKey { get; internal set; }
        public int? ClientId { get; internal set; }
        public string ClientSecret { get; internal set; }
        public ApplicationScopes ApplicationScopes { get; internal set; }

        public static ClientIdentificationSettings Default => new ClientIdentificationSettings()
        {
            ApiKey = null,
            ClientId = null,
            ClientSecret = null,
            ApplicationScopes = ApplicationScopes.ReadBasicUserProfile
        };
    }
}