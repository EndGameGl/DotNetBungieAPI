namespace DotNetBungieAPI.Generated.Models.Forum;

public class PostSearchResponse
{
    [JsonPropertyName("relatedPosts")]
    public List<Forum.PostResponse> RelatedPosts { get; set; }

    [JsonPropertyName("authors")]
    public List<User.GeneralUser> Authors { get; set; }

    [JsonPropertyName("groups")]
    public List<GroupsV2.GroupResponse> Groups { get; set; }

    [JsonPropertyName("searchedTags")]
    public List<Tags.Models.Contracts.TagResponse> SearchedTags { get; set; }

    [JsonPropertyName("polls")]
    public List<Forum.PollResponse> Polls { get; set; }

    [JsonPropertyName("recruitmentDetails")]
    public List<Forum.ForumRecruitmentDetail> RecruitmentDetails { get; set; }

    [JsonPropertyName("availablePages")]
    public int? AvailablePages { get; set; }

    [JsonPropertyName("results")]
    public List<Forum.PostResponse> Results { get; set; }

    [JsonPropertyName("totalResults")]
    public int? TotalResults { get; set; }

    [JsonPropertyName("hasMore")]
    public bool? HasMore { get; set; }

    [JsonPropertyName("query")]
    public Queries.PagedQuery? Query { get; set; }

    [JsonPropertyName("replacementContinuationToken")]
    public string? ReplacementContinuationToken { get; set; }

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
    public bool? UseTotalResults { get; set; }
}
