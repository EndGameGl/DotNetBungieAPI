namespace DotNetBungieAPI.Generated.Models.User.Models;

public class GetCredentialTypesForAccountResponse
{
    [JsonPropertyName("credentialType")]
    public BungieCredentialType? CredentialType { get; set; }

    [JsonPropertyName("credentialDisplayName")]
    public string? CredentialDisplayName { get; set; }

    [JsonPropertyName("isPublic")]
    public bool? IsPublic { get; set; }

    [JsonPropertyName("credentialAsString")]
    public string? CredentialAsString { get; set; }
}
