namespace DotNetBungieAPI.Generated.Models.User;

public sealed class UserSearchResponse
{

    [JsonPropertyName("searchResults")]
    public List<User.UserSearchResponseDetail> SearchResults { get; init; }

    [JsonPropertyName("page")]
    public int Page { get; init; }

    [JsonPropertyName("hasMore")]
    public bool HasMore { get; init; }
}
