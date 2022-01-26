namespace DotNetBungieAPI.Generated.Models.User.Models;

public class GetCredentialTypesForAccountResponse : IDeepEquatable<GetCredentialTypesForAccountResponse>
{
    [JsonPropertyName("credentialType")]
    public BungieCredentialType CredentialType { get; set; }

    [JsonPropertyName("credentialDisplayName")]
    public string CredentialDisplayName { get; set; }

    [JsonPropertyName("isPublic")]
    public bool IsPublic { get; set; }

    [JsonPropertyName("credentialAsString")]
    public string CredentialAsString { get; set; }

    public bool DeepEquals(GetCredentialTypesForAccountResponse? other)
    {
        return other is not null &&
               CredentialType == other.CredentialType &&
               CredentialDisplayName == other.CredentialDisplayName &&
               IsPublic == other.IsPublic &&
               CredentialAsString == other.CredentialAsString;
    }
}