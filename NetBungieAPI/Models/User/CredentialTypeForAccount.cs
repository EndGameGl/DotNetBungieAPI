using System.Text.Json.Serialization;

namespace NetBungieAPI.Models.User
{
    public sealed record CredentialTypeForAccount
    {
        [JsonPropertyName("credentialType")] public BungieCredentialType CredentialType { get; init; }

        [JsonPropertyName("credentialDisplayName")]
        public string CredentialDisplayName { get; init; }

        [JsonPropertyName("isPublic")] public bool IsPublic { get; init; }

        [JsonPropertyName("credentialAsString")]
        public string CredentialAsString { get; init; }
    }
}