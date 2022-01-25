namespace DotNetBungieAPI.Generated.Models.User;

public class UserSearchResponse
{
    [JsonPropertyName("searchResults")]
    public List<User.UserSearchResponseDetail> SearchResults { get; set; }

    [JsonPropertyName("page")]
    public int Page { get; set; }

    [JsonPropertyName("hasMore")]
    public bool HasMore { get; set; }
}
