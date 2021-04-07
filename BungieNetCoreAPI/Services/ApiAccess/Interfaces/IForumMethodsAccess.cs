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
        /// <param name="categoryFilter"></param>
        /// <param name="quickDate"></param>
        /// <param name="sort"></param>
        /// <param name="group"></param>
        /// <param name="pageSize"></param>
        /// <param name="page"></param>
        /// <param name="tagstring"></param>
        /// <param name="locales"></param>
        /// <returns></returns>
        Task<BungieResponse<PostSearchResponse>> GetTopicsPaged(ForumPostCategoryEnums categoryFilter, ForumTopicsQuickDateEnum quickDate, ForumTopicsSortEnum sort, long group, int pageSize = 0, int page = 0, string tagstring = null, DestinyLocales[] locales = null);
        /// <summary>
        /// Gets a listing of all topics marked as part of the core group.
        /// </summary>
        /// <param name="categoryFilter"></param>
        /// <param name="quickDate"></param>
        /// <param name="sort"></param>
        /// <param name="page"></param>
        /// <param name="locales"></param>
        /// <returns></returns>
        Task<BungieResponse<PostSearchResponse>> GetCoreTopicsPaged(ForumPostCategoryEnums categoryFilter, ForumTopicsQuickDateEnum quickDate, ForumTopicsSortEnum sort, int page = 0, DestinyLocales[] locales = null);
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
        /// <param name="showbanned"></param>
        /// <returns></returns>
        Task<BungieResponse<PostSearchResponse>> GetPostsThreadedPaged(bool getParentPost, int page, int pageSize, long parentPostId, int replySize, bool rootThreadMode, ForumTopicsSortEnum sortMode, bool? showbanned = null);
        /// <summary>
        /// Returns a thread of posts starting at the topicId of the input childPostId, optionally returning replies to those posts as well as the original parent.
        /// </summary>
        /// <param name="page"></param>
        /// <param name="pageSize"></param>
        /// <param name="childPostId"></param>
        /// <param name="replySize"></param>
        /// <param name="rootThreadMode"></param>
        /// <param name="sortMode"></param>
        /// <param name="showbanned"></param>
        /// <returns></returns>
        Task<BungieResponse<PostSearchResponse>> GetPostsThreadedPagedFromChild(int page, int pageSize, long childPostId, int replySize, bool rootThreadMode, ForumTopicsSortEnum sortMode, bool? showbanned = null);
        /// <summary>
        /// Returns the post specified and its immediate parent.
        /// </summary>
        /// <param name="childPostId"></param>
        /// <param name="showbanned"></param>
        /// <returns></returns>
        Task<BungieResponse<PostSearchResponse>> GetPostAndParent(long childPostId, bool? showbanned = null);
        /// <summary>
        /// Returns the post specified and its immediate parent of posts that are awaiting approval.
        /// </summary>
        /// <param name="childPostId"></param>
        /// <param name="showbanned"></param>
        /// <returns></returns>
        Task<BungieResponse<PostSearchResponse>> GetPostAndParentAwaitingApproval(long childPostId, bool? showbanned = null);
        /// <summary>
        /// Gets the post Id for the given content item's comments, if it exists.
        /// </summary>
        /// <param name="contentId"></param>
        /// <returns></returns>
        Task<BungieResponse<long>> GetTopicForContent(long contentId);
        /// <summary>
        /// Gets tag suggestions based on partial text entry, matching them with other tags previously used in the forums.
        /// </summary>
        /// <param name="partialtag"></param>
        /// <returns></returns>
        Task<BungieResponse<TagResponse[]>> GetForumTagSuggestions(string partialtag);
        /// <summary>
        /// Gets the specified forum poll.
        /// </summary>
        /// <param name="topicId"></param>
        /// <returns></returns>
        Task<BungieResponse<PostSearchResponse>> GetPoll(long topicId);
        /// <summary>
        /// Allows the caller to get a list of to 25 recruitment thread summary information objects.
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        Task<BungieResponse<ForumRecruitmentDetail[]>> GetRecruitmentThreadSummaries(long[] request);
    }
}
