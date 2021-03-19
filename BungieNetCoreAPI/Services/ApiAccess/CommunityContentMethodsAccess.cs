using NetBungieAPI.Forum;
using NetBungieAPI.Services;
using NetBungieAPI.Services.ApiAccess.Interfaces;
using NetBungieAPI.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;
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
        public async Task<BungieResponse<PostSearchResponse>> GetCommunityContent(ForumTopicsSortEnum sort, ForumMediaType mediaFilter, int page = 0)
        {
            return await _httpClient.GetFromPlatfromAndDeserialize<BungieResponse<PostSearchResponse>>($"/CommunityContent/Get/{(int)sort}/{(int)mediaFilter}/{page}/");
        }
    }
}
