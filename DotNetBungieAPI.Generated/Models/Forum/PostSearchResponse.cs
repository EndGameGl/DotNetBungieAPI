using System.Text.Json.Serialization;

namespace DotNetBungieAPI.Generated.Models.Forum;

public sealed class PostSearchResponse
{

    [JsonPropertyName("relatedPosts")]
    public List<Forum.PostResponse> RelatedPosts { get; init; }

    [JsonPropertyName("authors")]
    public List<User.GeneralUser> Authors { get; init; }

    [JsonPropertyName("groups")]
    public List<GroupsV2.GroupResponse> Groups { get; init; }

    [JsonPropertyName("searchedTags")]
    public List<Tags.Models.Contracts.TagResponse> SearchedTags { get; init; }

    [JsonPropertyName("polls")]
    public List<Forum.PollResponse> Polls { get; init; }

    [JsonPropertyName("recruitmentDetails")]
    public List<Forum.ForumRecruitmentDetail> RecruitmentDetails { get; init; }

    [JsonPropertyName("availablePages")]
    public int? AvailablePages { get; init; }

    [JsonPropertyName("results")]
    public List<Forum.PostResponse> Results { get; init; }

    [JsonPropertyName("totalResults")]
    public int TotalResults { get; init; }

    [JsonPropertyName("hasMore")]
    public bool HasMore { get; init; }

    [JsonPropertyName("query")]
    public Queries.PagedQuery Query { get; init; }

    [JsonPropertyName("replacementContinuationToken")]
    public string ReplacementContinuationToken { get; init; }

    [JsonPropertyName("useTotalResults")]
    public bool UseTotalResults { get; init; }
}
