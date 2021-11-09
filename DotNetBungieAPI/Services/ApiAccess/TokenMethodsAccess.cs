using DotNetBungieAPI.Authorization;
using DotNetBungieAPI.Clients;
using DotNetBungieAPI.Exceptions;
using DotNetBungieAPI.Models;
using DotNetBungieAPI.Models.Applications;
using DotNetBungieAPI.Models.Tokens;
using DotNetBungieAPI.Services.ApiAccess.Interfaces;
using DotNetBungieAPI.Services.Interfaces;
using System.Threading;
using System.Threading.Tasks;

namespace DotNetBungieAPI.Services.ApiAccess
{
    /// <summary>
    /// <see cref="ITokenMethodsAccess"/>
    /// </summary>
    internal sealed class TokenMethodsAccess : ITokenMethodsAccess
    {
        private readonly BungieClientConfiguration _configuration;
        private readonly IDotNetBungieApiHttpClient _dotNetBungieApiHttpClient;

        public TokenMethodsAccess(
            IDotNetBungieApiHttpClient dotNetBungieApiHttpClient,
            BungieClientConfiguration configuration)
        {
            _dotNetBungieApiHttpClient = dotNetBungieApiHttpClient;
            _configuration = configuration;
        }

        public async ValueTask<BungieResponse<PartnerOfferSkuHistoryResponse[]>> GetPartnerOfferSkuHistory(
            AuthorizationTokenData authorizationToken,
            int partnerApplicationId,
            long targetBnetMembershipId,
            CancellationToken cancellationToken = default)
        {
            if (!_configuration.HasSufficientRights(ApplicationScopes.PartnerOfferGrant))
                throw new InsufficientScopeException(ApplicationScopes.PartnerOfferGrant);

            var url = StringBuilderPool
                .GetBuilder(cancellationToken)
                .Append("/Tokens/Partner/History/")
                .AddUrlParam(partnerApplicationId.ToString())
                .AddUrlParam(targetBnetMembershipId.ToString())
                .Build();

            return await _dotNetBungieApiHttpClient
                .GetFromBungieNetPlatform<PartnerOfferSkuHistoryResponse[]>(
                    url,
                    cancellationToken,
                    authorizationToken.AccessToken)
                .ConfigureAwait(false);
        }
    }
}