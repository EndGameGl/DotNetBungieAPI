using NetBungieAPI.Models.Applications;

namespace NetBungieAPI.Clients.Settings
{
    /// <summary>
    /// Settings that are used for identifying client
    /// </summary>
    public class ClientIdentificationSettings
    {
        /// <summary>
        /// Client API key
        /// </summary>
        public string ApiKey { get; internal set; }

        /// <summary>
        /// Client ID
        /// </summary>
        public int? ClientId { get; internal set; }

        /// <summary>
        /// Client secret
        /// </summary>
        public string ClientSecret { get; internal set; }

        /// <summary>
        /// Client application scopes
        /// </summary>
        public ApplicationScopes ApplicationScopes { get; internal set; }

        /// <summary>
        /// Default settings
        /// </summary>
        public static ClientIdentificationSettings Default => new()
        {
            ApiKey = null,
            ClientId = null,
            ClientSecret = null,
            ApplicationScopes = ApplicationScopes.ReadBasicUserProfile
        };
    }
}