using System.Collections.ObjectModel;
using System.Text.Json.Serialization;
using DotNetBungieAPI.Defaults;
using DotNetBungieAPI.Models.Forum;
using DotNetBungieAPI.Models.GroupsV2;
using DotNetBungieAPI.Models.Tags;
using DotNetBungieAPI.Models.User;

namespace DotNetBungieAPI.Models.Queries
{
    public sealed record PostSearchResponse : SearchResultBase
    {
        [JsonPropertyName("relatedPosts")]
        public ReadOnlyCollection<PostResponse> RelatedPosts { get; init; } =
            ReadOnlyCollections<PostResponse>.Empty;

        [JsonPropertyName("authors")]
        public ReadOnlyCollection<GeneralUser> Authors { get; init; } = ReadOnlyCollections<GeneralUser>.Empty;

        [JsonPropertyName("groups")]
        public ReadOnlyCollection<GroupResponse> Groups { get; init; } =
            ReadOnlyCollections<GroupResponse>.Empty;

        [JsonPropertyName("searchedTags")]
        public ReadOnlyCollection<TagResponse> SearchedTags { get; init; } =
            ReadOnlyCollections<TagResponse>.Empty;

        [JsonPropertyName("polls")]
        public ReadOnlyCollection<PollResponse> Polls { get; init; } = ReadOnlyCollections<PollResponse>.Empty;

        [JsonPropertyName("recruitmentDetails")]
        public ReadOnlyCollection<ForumRecruitmentDetail> RecruitmentDetails { get; init; } =
            ReadOnlyCollections<ForumRecruitmentDetail>.Empty;

        [JsonPropertyName("availablePages")] public int? AvailablePages { get; init; }

        [JsonPropertyName("results")]
        public ReadOnlyCollection<PostResponse> Results { get; init; } = ReadOnlyCollections<PostResponse>.Empty;
    }
}