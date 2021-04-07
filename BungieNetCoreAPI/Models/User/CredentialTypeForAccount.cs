using System.Text.Json.Serialization;

namespace NetBungieAPI.Models.User
{
    public sealed record CredentialTypeForAccount
    {
        [JsonPropertyName("credentialType")]
        public BungieCredentialType CredentialType { get; }

        [JsonPropertyName("credentialDisplayName")]
        public string CredentialDisplayName { get; }

        [JsonPropertyName("isPublic")]
        public bool IsPublic { get; }

        [JsonPropertyName("credentialAsString")]
        public string CredentialAsString { get; }
    }
}
