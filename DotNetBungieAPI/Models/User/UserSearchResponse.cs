namespace DotNetBungieAPI.Models.User;

public sealed record UserSearchResponse
{
    [JsonPropertyName("searchResults")]
    public ReadOnlyCollection<UserSearchResponseDetail> SearchResults { get; init; } =
        ReadOnlyCollections<UserSearchResponseDetail>.Empty;

    [JsonPropertyName("page")] public int Page { get; init; }

    [JsonPropertyName("hasMore")] public bool HasMore { get; init; }
}