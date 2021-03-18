using NetBungieAPI.GroupsV2;
using NetBungieAPI.Responses;
using NetBungieAPI.User;
using Newtonsoft.Json;
using System.Collections.ObjectModel;

namespace NetBungieAPI.Forum
{
    public class PostSearchResponse : SearchResultBase
    {
        public ReadOnlyCollection<PostResponse> RelatedPosts { get; }
        public ReadOnlyCollection<GeneralUser> Authors { get; }
        public ReadOnlyCollection<GroupResponse> Groups { get; }
        public ReadOnlyCollection<TagResponse> SearchedTags { get; }
        public ReadOnlyCollection<PollResponse> Polls { get; }
        public ReadOnlyCollection<ForumRecruitmentDetail> RecruitmentDetails { get; }
        public int? AvailablePages { get; }
        public ReadOnlyCollection<PostResponse> Results { get; }
        [JsonConstructor]
        internal PostSearchResponse(PostResponse[] relatedPosts, GeneralUser[] authors, GroupResponse[] groups, TagResponse[] searchedTags,
            PollResponse[] polls, ForumRecruitmentDetail[] recruitmentDetails, int? availablePages, PostResponse[] results,
            int totalResults, bool hasMore, PagedQuery query, string replacementContinuationToken, bool useTotalResults)
            : base(totalResults, hasMore, query, replacementContinuationToken, useTotalResults)
        {
            RelatedPosts = relatedPosts.AsReadOnlyOrEmpty();
            Authors = authors.AsReadOnlyOrEmpty();
            Groups = groups.AsReadOnlyOrEmpty();
            SearchedTags = searchedTags.AsReadOnlyOrEmpty();
            Polls = polls.AsReadOnlyOrEmpty();
            RecruitmentDetails = recruitmentDetails.AsReadOnlyOrEmpty();
            AvailablePages = availablePages;
            Results = results.AsReadOnlyOrEmpty();
        }
    }
}
