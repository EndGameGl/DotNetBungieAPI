using NetBungieAPI.Forum;
using NetBungieAPI.Services;
using NetBungieAPI.Services.ApiAccess.Interfaces;
using NetBungieAPI.Services.Interfaces;
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
            List<string> queryParams = new List<string>(2);
            if (!string.IsNullOrWhiteSpace(tagstring))
                queryParams.Add($"{(!string.IsNullOrWhiteSpace(tagstring) ? $"tagstring={tagstring}" : string.Empty)}");
            if (locales == null)
                locales = new DestinyLocales[] { DestinyLocales.EN };
            queryParams.Add($"locales={string.Join(",", locales.Select(x => x.LocaleToString()))}");

            return await _httpClient.GetFromPlatfromAndDeserialize<BungieResponse<PostSearchResponse>>($"/Forum/GetTopicsPaged/{page}/{pageSize}/{group}/{sort}/{quickDate}/{categoryFilter}/?{string.Join('&', queryParams)}");
        }
    }
}
