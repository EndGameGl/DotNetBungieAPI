using System.Threading;
using System.Threading.Tasks;
using DotNetBungieAPI.Models;
using DotNetBungieAPI.Models.Content;
using DotNetBungieAPI.Models.Queries;
using DotNetBungieAPI.Services.ApiAccess.Interfaces;
using DotNetBungieAPI.Services.Interfaces;

namespace DotNetBungieAPI.Services.ApiAccess
{
    /// <summary>
    /// <see cref="IContentMethodsAccess"/>
    /// </summary>
    public class ContentMethodsAccess : IContentMethodsAccess
    {
        private readonly IDotNetBungieApiHttpClient _dotNetBungieApiHttpClient;

        internal ContentMethodsAccess(IDotNetBungieApiHttpClient dotNetBungieApiHttpClient)
        {
            _dotNetBungieApiHttpClient = dotNetBungieApiHttpClient;
        }

        public async ValueTask<BungieResponse<ContentTypeDescription>> GetContentType(
            string type,
            CancellationToken cancellationToken = default)
        {
            var url = StringBuilderPool
                .GetBuilder(cancellationToken)
                .Append("/Content/GetContentType/")
                .AddUrlParam(type)
                .Build();
            return await _dotNetBungieApiHttpClient
                .GetFromBungieNetPlatform<ContentTypeDescription>(url, cancellationToken)
                .ConfigureAwait(false);
        }

        public async ValueTask<BungieResponse<ContentItemPublicContract>> GetContentById(
            long id,
            string locale,
            bool head = false,
            CancellationToken cancellationToken = default)
        {
            var url = StringBuilderPool
                .GetBuilder(cancellationToken)
                .Append("/Content/GetContentById/")
                .AddUrlParam(id.ToString())
                .AddUrlParam(locale)
                .AddQueryParam("head", head.ToString())
                .Build();
            return await _dotNetBungieApiHttpClient
                .GetFromBungieNetPlatform<ContentItemPublicContract>(url, cancellationToken)
                .ConfigureAwait(false);
        }

        public async ValueTask<BungieResponse<ContentItemPublicContract>> GetContentByTagAndType(
            string tag,
            string type,
            string locale,
            CancellationToken cancellationToken = default)
        {
            var url = StringBuilderPool
                .GetBuilder(cancellationToken)
                .Append("/Content/GetContentByTagAndType/")
                .AddUrlParam(tag)
                .AddUrlParam(type)
                .AddUrlParam(locale)
                .Build();
            return await _dotNetBungieApiHttpClient
                .GetFromBungieNetPlatform<ContentItemPublicContract>(url, cancellationToken)
                .ConfigureAwait(false);
        }

        public async ValueTask<BungieResponse<SearchResultOfContentItemPublicContract>> SearchContentWithText(
            string locale,
            string[] types,
            string searchtext,
            string source,
            string tag,
            int currentpage = 1,
            CancellationToken cancellationToken = default)
        {
            var url = StringBuilderPool
                .GetBuilder(cancellationToken)
                .Append("/Content/Search/")
                .AddUrlParam(locale)
                .AddQueryParam("ctype", string.Join(" ", types))
                .AddQueryParam("currentpage", currentpage.ToString())
                .AddQueryParam("searchtext", searchtext)
                .AddQueryParam("source", source, () => !string.IsNullOrEmpty(source))
                .AddQueryParam("tag", tag)
                .Build();
            return await _dotNetBungieApiHttpClient
                .GetFromBungieNetPlatform<SearchResultOfContentItemPublicContract>(url, cancellationToken)
                .ConfigureAwait(false);
        }

        public async ValueTask<BungieResponse<SearchResultOfContentItemPublicContract>> SearchContentByTagAndType(
            string locale,
            string tag,
            string type,
            int currentpage = 1,
            CancellationToken cancellationToken = default)
        {
            var url = StringBuilderPool
                .GetBuilder(cancellationToken)
                .Append("/Content/SearchContentByTagAndType/")
                .AddUrlParam(tag)
                .AddUrlParam(type)
                .AddUrlParam(locale)
                .AddQueryParam("currentpage", currentpage.ToString())
                .Build();
            return await _dotNetBungieApiHttpClient
                .GetFromBungieNetPlatform<SearchResultOfContentItemPublicContract>(url, cancellationToken)
                .ConfigureAwait(false);
        }
    }
}