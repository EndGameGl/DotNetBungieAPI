using System.Text.Json.Serialization;

namespace DotNetBungieAPI.Generated.Models.User.Models;

public sealed class GetCredentialTypesForAccountResponse
{

    [JsonPropertyName("credentialType")]
    public BungieCredentialType CredentialType { get; init; }

    [JsonPropertyName("credentialDisplayName")]
    public string CredentialDisplayName { get; init; }

    [JsonPropertyName("isPublic")]
    public bool IsPublic { get; init; }

    [JsonPropertyName("credentialAsString")]
    public string CredentialAsString { get; init; }
}
