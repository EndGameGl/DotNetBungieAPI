using DotNetBungieAPI.Models.Forum;
using DotNetBungieAPI.Models.GroupsV2;
using DotNetBungieAPI.Models.Tags;
using DotNetBungieAPI.Models.User;

namespace DotNetBungieAPI.Models.Queries;

public sealed record PostSearchResponse : SearchResultBase
{
    [JsonPropertyName("relatedPosts")]
    public ReadOnlyCollection<PostResponse> RelatedPosts { get; init; } =
        ReadOnlyCollection<PostResponse>.Empty;

    [JsonPropertyName("authors")]
    public ReadOnlyCollection<GeneralUser> Authors { get; init; } =
        ReadOnlyCollection<GeneralUser>.Empty;

    [JsonPropertyName("groups")]
    public ReadOnlyCollection<GroupResponse> Groups { get; init; } =
        ReadOnlyCollection<GroupResponse>.Empty;

    [JsonPropertyName("searchedTags")]
    public ReadOnlyCollection<TagResponse> SearchedTags { get; init; } =
        ReadOnlyCollection<TagResponse>.Empty;

    [JsonPropertyName("polls")]
    public ReadOnlyCollection<PollResponse> Polls { get; init; } =
        ReadOnlyCollection<PollResponse>.Empty;

    [JsonPropertyName("recruitmentDetails")]
    public ReadOnlyCollection<ForumRecruitmentDetail> RecruitmentDetails { get; init; } =
        ReadOnlyCollection<ForumRecruitmentDetail>.Empty;

    [JsonPropertyName("availablePages")]
    public int? AvailablePages { get; init; }

    [JsonPropertyName("results")]
    public ReadOnlyCollection<PostResponse> Results { get; init; } =
        ReadOnlyCollection<PostResponse>.Empty;
}
