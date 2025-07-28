namespace DotNetBungieAPI.Generated.Models.Forum;

public class PostSearchResponse
{
    [JsonPropertyName("relatedPosts")]
    public Forum.PostResponse[]? RelatedPosts { get; set; }

    [JsonPropertyName("authors")]
    public User.GeneralUser[]? Authors { get; set; }

    [JsonPropertyName("groups")]
    public GroupsV2.GroupResponse[]? Groups { get; set; }

    [JsonPropertyName("searchedTags")]
    public Tags.Models.Contracts.TagResponse[]? SearchedTags { get; set; }

    [JsonPropertyName("polls")]
    public Forum.PollResponse[]? Polls { get; set; }

    [JsonPropertyName("recruitmentDetails")]
    public Forum.ForumRecruitmentDetail[]? RecruitmentDetails { get; set; }

    [JsonPropertyName("availablePages")]
    public int? AvailablePages { get; set; }

    [JsonPropertyName("results")]
    public Forum.PostResponse[]? Results { get; set; }

    [JsonPropertyName("totalResults")]
    public int TotalResults { get; set; }

    [JsonPropertyName("hasMore")]
    public bool HasMore { get; set; }

    [JsonPropertyName("query")]
    public Queries.PagedQuery? Query { get; set; }

    [JsonPropertyName("replacementContinuationToken")]
    public string ReplacementContinuationToken { get; set; }

    /// <summary>
    ///     If useTotalResults is true, then totalResults represents an accurate count.
    /// <para />
    ///     If False, it does not, and may be estimated/only the size of the current page.
    /// <para />
    ///     Either way, you should probably always only trust hasMore.
    /// <para />
    ///     This is a long-held historical throwback to when we used to do paging with known total results. Those queries toasted our database, and we were left to hastily alter our endpoints and create backward- compatible shims, of which useTotalResults is one.
    /// </summary>
    [JsonPropertyName("useTotalResults")]
    public bool UseTotalResults { get; set; }
}
