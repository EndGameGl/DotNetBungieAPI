namespace DotNetBungieAPI.Models.User;

public sealed class UserSearchPrefixRequest
{
    [JsonPropertyName("displayNamePrefix")]
    public string DisplayNamePrefix { get; init; }
}
