using System.Threading;
using NetBungieAPI.Models;
using NetBungieAPI.Models.Forum;
using NetBungieAPI.Models.Queries;
using NetBungieAPI.Models.Tags;
using System.Threading.Tasks;

namespace NetBungieAPI.Services.ApiAccess.Interfaces
{
    public interface IForumMethodsAccess
    {
        /// <summary>
        /// Get topics from any forum.
        /// </summary>
        /// <param name="categoryFilter">A category filter</param>
        /// <param name="quickDate">A date filter.</param>
        /// <param name="sort">The sort mode.</param>
        /// <param name="group">The group, if any.</param>
        /// <param name="pageSize">Unused</param>
        /// <param name="page">Zero paged page number</param>
        /// <param name="tagstring">The tags to search, if any.</param>
        /// <param name="locales">Comma seperated list of locales posts must match to return in the result list. Default 'en'</param>
        /// <param name="token">Cancellation token</param>
        /// <returns></returns>
        ValueTask<BungieResponse<PostSearchResponse>> GetTopicsPaged(ForumPostCategoryEnums categoryFilter,
            ForumTopicsQuickDateEnum quickDate, ForumTopicsSortEnum sort, long group, int pageSize = 0, int page = 0,
            string tagstring = null, BungieLocales[] locales = null, CancellationToken token = default);

        /// <summary>
        /// Gets a listing of all topics marked as part of the core group.
        /// </summary>
        /// <param name="categoryFilter">The category filter.</param>
        /// <param name="quickDate">The date filter.</param>
        /// <param name="sort">The sort mode.</param>
        /// <param name="page">Zero base page</param>
        /// <param name="locales">Comma seperated list of locales posts must match to return in the result list. Default 'en'</param>
        /// <param name="token">Cancellation token</param>
        /// <returns></returns>
        ValueTask<BungieResponse<PostSearchResponse>> GetCoreTopicsPaged(ForumPostCategoryEnums categoryFilter,
            ForumTopicsQuickDateEnum quickDate, ForumTopicsSortEnum sort, int page = 0, BungieLocales[] locales = null,
            CancellationToken token = default);

        /// <summary>
        /// Returns a thread of posts at the given parent, optionally returning replies to those posts as well as the original parent.
        /// </summary>
        /// <param name="getParentPost"></param>
        /// <param name="page"></param>
        /// <param name="pageSize"></param>
        /// <param name="parentPostId"></param>
        /// <param name="replySize"></param>
        /// <param name="rootThreadMode"></param>
        /// <param name="sortMode"></param>
        /// <param name="showbanned">If this value is not null or empty, banned posts are requested to be returned</param>
        /// <param name="token">Cancellation token</param>
        /// <returns></returns>
        ValueTask<BungieResponse<PostSearchResponse>> GetPostsThreadedPaged(bool getParentPost, int page, int pageSize,
            long parentPostId, int replySize, bool rootThreadMode, ForumTopicsSortEnum sortMode,
            bool? showbanned = null, CancellationToken token = default);

        /// <summary>
        /// Returns a thread of posts starting at the topicId of the input childPostId, optionally returning replies to those posts as well as the original parent.
        /// </summary>
        /// <param name="page"></param>
        /// <param name="pageSize"></param>
        /// <param name="childPostId"></param>
        /// <param name="replySize"></param>
        /// <param name="rootThreadMode"></param>
        /// <param name="sortMode"></param>
        /// <param name="showbanned">If this value is not null or empty, banned posts are requested to be returned</param>
        /// <param name="token">Cancellation token</param>
        /// <returns></returns>
        ValueTask<BungieResponse<PostSearchResponse>> GetPostsThreadedPagedFromChild(int page, int pageSize,
            long childPostId, int replySize, bool rootThreadMode, ForumTopicsSortEnum sortMode,
            bool? showbanned = null, CancellationToken token = default);

        /// <summary>
        /// Returns the post specified and its immediate parent.
        /// </summary>
        /// <param name="childPostId"></param>
        /// <param name="showbanned">If this value is not null or empty, banned posts are requested to be returned</param>
        /// <param name="token">Cancellation token</param>
        /// <returns></returns>
        ValueTask<BungieResponse<PostSearchResponse>> GetPostAndParent(long childPostId, bool? showbanned = null,
            CancellationToken token = default);

        /// <summary>
        /// Returns the post specified and its immediate parent of posts that are awaiting approval.
        /// </summary>
        /// <param name="childPostId"></param>
        /// <param name="showbanned">If this value is not null or empty, banned posts are requested to be returned</param>
        /// <param name="token">Cancellation token</param>
        /// <returns></returns>
        ValueTask<BungieResponse<PostSearchResponse>> GetPostAndParentAwaitingApproval(long childPostId,
            bool? showbanned = null, CancellationToken token = default);

        /// <summary>
        /// Gets the post Id for the given content item's comments, if it exists.
        /// </summary>
        /// <param name="contentId"></param>
        /// <param name="token">Cancellation token</param>
        /// <returns></returns>
        ValueTask<BungieResponse<long>> GetTopicForContent(long contentId, CancellationToken token = default);

        /// <summary>
        /// Gets tag suggestions based on partial text entry, matching them with other tags previously used in the forums.
        /// </summary>
        /// <param name="partialtag">The partial tag input to generate suggestions from.</param>
        /// <param name="token">Cancellation token</param>
        /// <returns></returns>
        ValueTask<BungieResponse<TagResponse[]>> GetForumTagSuggestions(string partialtag,
            CancellationToken token = default);

        /// <summary>
        /// Gets the specified forum poll.
        /// </summary>
        /// <param name="topicId">The post id of the topic that has the poll.</param>
        /// <param name="token">Cancellation token</param>
        /// <returns></returns>
        ValueTask<BungieResponse<PostSearchResponse>> GetPoll(long topicId, CancellationToken token = default);

        /// <summary>
        /// Allows the caller to get a list of to 25 recruitment thread summary information objects.
        /// </summary>
        /// <param name="request">Request body</param>
        /// <param name="token">Cancellation token</param>
        /// <returns></returns>
        ValueTask<BungieResponse<ForumRecruitmentDetail[]>> GetRecruitmentThreadSummaries(long[] request,
            CancellationToken token = default);
    }
}