using System.IO;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using NetBungieAPI.Models;
using NetBungieAPI.Models.Forum;
using NetBungieAPI.Models.Queries;
using NetBungieAPI.Models.Tags;
using NetBungieAPI.Services.ApiAccess.Interfaces;
using NetBungieAPI.Services.Interfaces;

namespace NetBungieAPI.Services.ApiAccess
{
    public class ForumMethodsAccess : IForumMethodsAccess
    {
        private readonly IHttpClientInstance _httpClient;
        private readonly IJsonSerializationHelper _serializationHelper;

        internal ForumMethodsAccess(IHttpClientInstance httpClient, IJsonSerializationHelper serializationHelper)
        {
            _httpClient = httpClient;
            _serializationHelper = serializationHelper;
        }

        public async ValueTask<BungieResponse<PostSearchResponse>> GetTopicsPaged(
            ForumPostCategoryEnums categoryFilter,
            ForumTopicsQuickDateEnum quickDate,
            ForumTopicsSortEnum sort, long group,
            int pageSize = 0,
            int page = 0,
            string tagstring = null,
            BungieLocales[] locales = null,
            CancellationToken token = default)
        {
            var url = StringBuilderPool
                .GetBuilder(token)
                .Append("/Forum/GetTopicsPaged/")
                .AddUrlParam(page.ToString())
                .AddUrlParam(pageSize.ToString())
                .AddUrlParam(group.ToString())
                .AddUrlParam(((byte) sort).ToString())
                .AddUrlParam(((int) quickDate).ToString())
                .AddUrlParam(((int) categoryFilter).ToString())
                .AddQueryParam("tagstring", tagstring, () => string.IsNullOrWhiteSpace(tagstring))
                .AddQueryParam("locales", string.Join(",", locales.Select(x => x.LocaleToString())))
                .Build();

            return await _httpClient.GetFromBungieNetPlatform<PostSearchResponse>(url, token);
        }

        public async ValueTask<BungieResponse<PostSearchResponse>> GetCoreTopicsPaged(
            ForumPostCategoryEnums categoryFilter,
            ForumTopicsQuickDateEnum quickDate,
            ForumTopicsSortEnum sort,
            int page = 0,
            BungieLocales[] locales = null,
            CancellationToken token = default)
        {
            var url = StringBuilderPool
                .GetBuilder(token)
                .Append("/Forum/GetCoreTopicsPaged/")
                .AddUrlParam(page.ToString())
                .AddUrlParam(((byte) sort).ToString())
                .AddUrlParam(((int) quickDate).ToString())
                .AddUrlParam(((int) categoryFilter).ToString())
                .AddQueryParam("locales", string.Join(",", locales.Select(x => x.LocaleToString())))
                .Build();

            return await _httpClient.GetFromBungieNetPlatform<PostSearchResponse>(url, token);
        }

        public async ValueTask<BungieResponse<PostSearchResponse>> GetPostsThreadedPaged(
            bool getParentPost,
            int page,
            int pageSize,
            long parentPostId,
            int replySize,
            bool rootThreadMode,
            ForumTopicsSortEnum sortMode,
            bool? showbanned = null,
            CancellationToken token = default)
        {
            var url = StringBuilderPool
                .GetBuilder(token)
                .Append("/Forum/GetPostsThreadedPaged/")
                .AddUrlParam(parentPostId.ToString())
                .AddUrlParam(page.ToString())
                .AddUrlParam(pageSize.ToString())
                .AddUrlParam(replySize.ToString())
                .AddUrlParam(getParentPost.ToString())
                .AddUrlParam(rootThreadMode.ToString())
                .AddUrlParam(((byte) sortMode).ToString())
                .AddQueryParam("showbanned", showbanned.ToString(), () => showbanned.HasValue)
                .Build();

            return await _httpClient.GetFromBungieNetPlatform<PostSearchResponse>(url, token);
        }

        public async ValueTask<BungieResponse<PostSearchResponse>> GetPostsThreadedPagedFromChild(
            int page,
            int pageSize,
            long childPostId,
            int replySize,
            bool rootThreadMode,
            ForumTopicsSortEnum sortMode,
            bool? showbanned = null,
            CancellationToken token = default)
        {
            var url = StringBuilderPool
                .GetBuilder(token)
                .Append("/Forum/GetPostsThreadedPagedFromChild/")
                .AddUrlParam(childPostId.ToString())
                .AddUrlParam(page.ToString())
                .AddUrlParam(pageSize.ToString())
                .AddUrlParam(replySize.ToString())
                .AddUrlParam(rootThreadMode.ToString())
                .AddUrlParam(((byte) sortMode).ToString())
                .AddQueryParam("showbanned", showbanned.ToString(), () => showbanned.HasValue)
                .Build();

            return await _httpClient.GetFromBungieNetPlatform<PostSearchResponse>(url, token);
        }

        public async ValueTask<BungieResponse<PostSearchResponse>> GetPostAndParent(
            long childPostId,
            bool? showbanned = null,
            CancellationToken token = default)
        {
            var url = StringBuilderPool
                .GetBuilder(token)
                .Append("/Forum/GetPostAndParent/")
                .AddUrlParam(childPostId.ToString())
                .AddQueryParam("showbanned", showbanned.ToString(), () => showbanned.HasValue)
                .Build();

            return await _httpClient.GetFromBungieNetPlatform<PostSearchResponse>(url, token);
        }

        public async ValueTask<BungieResponse<PostSearchResponse>> GetPostAndParentAwaitingApproval(
            long childPostId,
            bool? showbanned = null,
            CancellationToken token = default)
        {
            var url = StringBuilderPool
                .GetBuilder(token)
                .Append("/Forum/GetPostAndParentAwaitingApproval/")
                .AddUrlParam(childPostId.ToString())
                .AddQueryParam("showbanned", showbanned.ToString(), () => showbanned.HasValue)
                .Build();

            return await _httpClient.GetFromBungieNetPlatform<PostSearchResponse>(url, token);
        }

        public async ValueTask<BungieResponse<long>> GetTopicForContent(
            long contentId,
            CancellationToken token = default)
        {
            var url = StringBuilderPool
                .GetBuilder(token)
                .Append("/Forum/GetTopicForContent/")
                .AddUrlParam(contentId.ToString())
                .Build();

            return await _httpClient.GetFromBungieNetPlatform<long>(url, token);
        }

        public async ValueTask<BungieResponse<TagResponse[]>> GetForumTagSuggestions(
            string partialtag,
            CancellationToken token = default)
        {
            var url = StringBuilderPool
                .GetBuilder(token)
                .Append("/Forum/GetForumTagSuggestions/")
                .AddQueryParam("partialtag", partialtag)
                .Build();

            return await _httpClient.GetFromBungieNetPlatform<TagResponse[]>(url, token);
        }

        public async ValueTask<BungieResponse<PostSearchResponse>> GetPoll(
            long topicId,
            CancellationToken token = default)
        {
            var url = StringBuilderPool
                .GetBuilder(token)
                .Append("/Forum/Poll/")
                .AddUrlParam(topicId.ToString())
                .Build();

            return await _httpClient.GetFromBungieNetPlatform<PostSearchResponse>(url, token);
        }

        public async ValueTask<BungieResponse<ForumRecruitmentDetail[]>> GetRecruitmentThreadSummaries(
            long[] request,
            CancellationToken token = default)
        {
            await using var stream = new MemoryStream();
            await _serializationHelper.SerializeAsync(stream, request);
            return await _httpClient.PostToBungieNetPlatform<ForumRecruitmentDetail[]>("/Forum/Recruit/Summaries/",
                token, stream);
        }
    }
}