using System.Collections.ObjectModel;
using System.Text.Json.Serialization;
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
            Defaults.EmptyReadOnlyCollection<PostResponse>();

        [JsonPropertyName("authors")]
        public ReadOnlyCollection<GeneralUser> Authors { get; init; } = Defaults.EmptyReadOnlyCollection<GeneralUser>();

        [JsonPropertyName("groups")]
        public ReadOnlyCollection<GroupResponse> Groups { get; init; } =
            Defaults.EmptyReadOnlyCollection<GroupResponse>();

        [JsonPropertyName("searchedTags")]
        public ReadOnlyCollection<TagResponse> SearchedTags { get; init; } =
            Defaults.EmptyReadOnlyCollection<TagResponse>();

        [JsonPropertyName("polls")]
        public ReadOnlyCollection<PollResponse> Polls { get; init; } = Defaults.EmptyReadOnlyCollection<PollResponse>();

        [JsonPropertyName("recruitmentDetails")]
        public ReadOnlyCollection<ForumRecruitmentDetail> RecruitmentDetails { get; init; } =
            Defaults.EmptyReadOnlyCollection<ForumRecruitmentDetail>();

        [JsonPropertyName("availablePages")] public int? AvailablePages { get; init; }

        [JsonPropertyName("results")]
        public ReadOnlyCollection<PostResponse> Results { get; init; } =
            Defaults.EmptyReadOnlyCollection<PostResponse>();
    }
}