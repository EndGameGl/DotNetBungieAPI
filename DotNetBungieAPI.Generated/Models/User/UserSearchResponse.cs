namespace DotNetBungieAPI.Generated.Models.User;

public class UserSearchResponse : IDeepEquatable<UserSearchResponse>
{
    [JsonPropertyName("searchResults")]
    public List<User.UserSearchResponseDetail> SearchResults { get; set; }

    [JsonPropertyName("page")]
    public int Page { get; set; }

    [JsonPropertyName("hasMore")]
    public bool HasMore { get; set; }

    public bool DeepEquals(UserSearchResponse? other)
    {
        return other is not null &&
               SearchResults.DeepEqualsList(other.SearchResults) &&
               Page == other.Page &&
               HasMore == other.HasMore;
    }
}