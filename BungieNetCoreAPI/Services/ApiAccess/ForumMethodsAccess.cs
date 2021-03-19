using NetBungieAPI.Forum;
using NetBungieAPI.Services;
using NetBungieAPI.Services.ApiAccess.Interfaces;
using NetBungieAPI.Services.Interfaces;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NetBungieAPI.Services.ApiAccess
{
    public class ForumMethodsAccess : IForumMethodsAccess
    {
        private IHttpClientInstance _httpClient;
        internal ForumMethodsAccess(IHttpClientInstance httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task<BungieResponse<PostSearchResponse>> GetTopicsPaged(ForumPostCategoryEnums categoryFilter, ForumTopicsQuickDateEnum quickDate, ForumTopicsSortEnum sort, long group, 
            int pageSize = 0, int page = 0, string tagstring = null, DestinyLocales[] locales = null)
        {
            RequestQueryBuilder builder = new RequestQueryBuilder();
            if (!string.IsNullOrWhiteSpace(tagstring))
                builder.Add("tagstring", tagstring);
            if (locales == null)
                locales = new DestinyLocales[] { DestinyLocales.EN };
            builder.Add("locales", string.Join(",", locales.Select(x => x.LocaleToString())));

            return await _httpClient.GetFromPlatfromAndDeserialize<BungieResponse<PostSearchResponse>>($"/Forum/GetTopicsPaged/{page}/{pageSize}/{group}/{sort}/{quickDate}/{categoryFilter}/{builder.Build()}");
        }
        public async Task<BungieResponse<PostSearchResponse>> GetCoreTopicsPaged(ForumPostCategoryEnums categoryFilter, ForumTopicsQuickDateEnum quickDate, ForumTopicsSortEnum sort, int page = 0, DestinyLocales[] locales = null)
        {
            RequestQueryBuilder builder = new RequestQueryBuilder();
            if (locales == null)
                locales = new DestinyLocales[] { DestinyLocales.EN };
            builder.Add("locales", string.Join(",", locales.Select(x => x.LocaleToString())));

            return await _httpClient.GetFromPlatfromAndDeserialize<BungieResponse<PostSearchResponse>>($"/Forum/GetCoreTopicsPaged/{page}/{sort}/{quickDate}/{categoryFilter}/{builder.Build()}");
        }
        public async Task<BungieResponse<PostSearchResponse>> GetPostsThreadedPaged(bool getParentPost, int page, int pageSize, long parentPostId, int replySize, bool rootThreadMode, ForumTopicsSortEnum sortMode, bool? showbanned = null)
        {
            return await _httpClient.GetFromPlatfromAndDeserialize<BungieResponse<PostSearchResponse>>($"/Forum/GetPostsThreadedPaged/{parentPostId}/{page}/{pageSize}/{replySize}/{getParentPost}/{rootThreadMode}/{sortMode}/{(showbanned.HasValue ? $"?showbanned={showbanned}" : "")}" );
        }
        public async Task<BungieResponse<PostSearchResponse>> GetPostsThreadedPagedFromChild(int page, int pageSize, long childPostId, int replySize, bool rootThreadMode, ForumTopicsSortEnum sortMode, bool? showbanned = null)
        {
            return await _httpClient.GetFromPlatfromAndDeserialize<BungieResponse<PostSearchResponse>>($"/Forum/GetPostsThreadedPagedFromChild/{childPostId}/{page}/{pageSize}/{replySize}/{rootThreadMode}/{sortMode}/{(showbanned.HasValue ? $"?showbanned={showbanned}" : "")}");
        }
        public async Task<BungieResponse<PostSearchResponse>> GetPostAndParent(long childPostId, bool? showbanned = null)
        {
            return await _httpClient.GetFromPlatfromAndDeserialize<BungieResponse<PostSearchResponse>>($"/Forum/GetPostAndParent/{childPostId}/{(showbanned.HasValue ? $"?showbanned={showbanned}" : "")}");
        }
        public async Task<BungieResponse<PostSearchResponse>> GetPostAndParentAwaitingApproval(long childPostId, bool? showbanned = null)
        {
            return await _httpClient.GetFromPlatfromAndDeserialize<BungieResponse<PostSearchResponse>>($"/Forum/GetPostAndParentAwaitingApproval/{childPostId}/{(showbanned.HasValue ? $"?showbanned={showbanned}" : "")}");
        }
        public async Task<BungieResponse<long>> GetTopicForContent(long contentId)
        {
            return await _httpClient.GetFromPlatfromAndDeserialize<BungieResponse<long>>($"/Forum/GetTopicForContent/{contentId}/");
        }
        public async Task<BungieResponse<TagResponse[]>> GetForumTagSuggestions(string partialtag)
        {
            return await _httpClient.GetFromPlatfromAndDeserialize<BungieResponse<TagResponse[]>>($"/Forum/GetForumTagSuggestions/?partialtag={partialtag}");
        }
        public async Task<BungieResponse<PostSearchResponse>> GetPoll(long topicId)
        {
            return await _httpClient.GetFromPlatfromAndDeserialize<BungieResponse<PostSearchResponse>>($"/Forum/Poll/{topicId}/");
        }
        public async Task<BungieResponse<ForumRecruitmentDetail[]>> GetRecruitmentThreadSummaries(long[] request)
        {
            string body = JsonConvert.SerializeObject(request);
            return await _httpClient.PostToPlatformAndDeserialize<BungieResponse<ForumRecruitmentDetail[]>>($"/Forum/Recruit/Summaries/", body);
        }
    }
}
