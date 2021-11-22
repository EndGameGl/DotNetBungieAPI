using DotNetBungieAPI.Models;
using DotNetBungieAPI.Models.Forum;
using DotNetBungieAPI.Models.Queries;
using DotNetBungieAPI.Services.ApiAccess.Interfaces;
using DotNetBungieAPI.Services.Interfaces;
using System.Threading;
using System.Threading.Tasks;

namespace DotNetBungieAPI.Services.ApiAccess
{
    /// <summary>
    /// <see cref="ICommunityContentMethodsAccess"/>
    /// </summary>
    internal sealed class CommunityContentMethodsAccess : ICommunityContentMethodsAccess
    {
        private readonly IDotNetBungieApiHttpClient _dotNetBungieApiHttpClient;

        public CommunityContentMethodsAccess(IDotNetBungieApiHttpClient dotNetBungieApiHttpClient)
        {
            _dotNetBungieApiHttpClient = dotNetBungieApiHttpClient;
        }

        public async ValueTask<BungieResponse<PostSearchResponse>> GetCommunityContent(
            ForumTopicsSortEnum sort,
            ForumMediaType mediaFilter,
            int page = 0,
            CancellationToken cancellationToken = default)
        {
            var url = StringBuilderPool
                .GetBuilder(cancellationToken)
                .Append("/CommunityContent/Get/")
                .AddUrlParam(((byte)sort).ToString())
                .AddUrlParam(((int)mediaFilter).ToString())
                .AddUrlParam(page.ToString())
                .Build();
            return await _dotNetBungieApiHttpClient
                .GetFromBungieNetPlatform<PostSearchResponse>(url, cancellationToken)
                .ConfigureAwait(false);
        }
    }
}