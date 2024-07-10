namespace DotNetBungieAPI.Models.Requests;

public class UserSearchPrefixRequest
{
    public UserSearchPrefixRequest(string displayNamePrefix)
    {
        DisplayNamePrefix = string.IsNullOrWhiteSpace(displayNamePrefix)
            ? throw new ArgumentException("Name can't be null")
            : displayNamePrefix;
    }

    [JsonPropertyName("displayNamePrefix")]
    public string DisplayNamePrefix { get; }
}
