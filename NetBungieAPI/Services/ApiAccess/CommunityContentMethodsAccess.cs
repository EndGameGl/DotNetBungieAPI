using System.Threading;
using NetBungieAPI.Models;
using NetBungieAPI.Models.Forum;
using NetBungieAPI.Models.Queries;
using NetBungieAPI.Services.ApiAccess.Interfaces;
using NetBungieAPI.Services.Interfaces;
using System.Threading.Tasks;

namespace NetBungieAPI
{
    public class CommunityContentMethodsAccess : ICommunityContentMethodsAccess
    {
        private IHttpClientInstance _httpClient;

        internal CommunityContentMethodsAccess(IHttpClientInstance httpClient)
        {
            _httpClient = httpClient;
        }

        public async ValueTask<BungieResponse<PostSearchResponse>> GetCommunityContent(
            ForumTopicsSortEnum sort,
            ForumMediaType mediaFilter,
            int page = 0, 
            CancellationToken token = default)
        {
            var url = StringBuilderPool
                .GetBuilder(token)
                .Append("/CommunityContent/Get/")
                .AddUrlParam(((byte) sort).ToString())
                .AddUrlParam(((int) mediaFilter).ToString())
                .AddUrlParam(page.ToString())
                .Build();
            return await _httpClient.GetFromBungieNetPlatform<PostSearchResponse>(url, token);
        }
    }
}