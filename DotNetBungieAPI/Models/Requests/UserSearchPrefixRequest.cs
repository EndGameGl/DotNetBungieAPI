namespace DotNetBungieAPI.Models.Requests;

public class UserSearchPrefixRequest
{
    public UserSearchPrefixRequest(string displayNamePrefix)
    {
        DisplayNamePrefix = Conditions.NotNullOrWhiteSpace(displayNamePrefix);
    }

    [JsonPropertyName("displayNamePrefix")]
    public string DisplayNamePrefix { get; }
}