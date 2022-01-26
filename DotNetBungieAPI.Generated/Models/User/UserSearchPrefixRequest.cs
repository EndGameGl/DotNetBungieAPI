namespace DotNetBungieAPI.Generated.Models.User;

public class UserSearchPrefixRequest : IDeepEquatable<UserSearchPrefixRequest>
{
    [JsonPropertyName("displayNamePrefix")]
    public string DisplayNamePrefix { get; set; }

    public bool DeepEquals(UserSearchPrefixRequest? other)
    {
        return other is not null &&
               DisplayNamePrefix == other.DisplayNamePrefix;
    }
}