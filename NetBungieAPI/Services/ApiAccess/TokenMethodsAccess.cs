using System.Threading;
using System.Threading.Tasks;
using NetBungieAPI.Authorization;
using NetBungieAPI.Clients;
using NetBungieAPI.Exceptions;
using NetBungieAPI.Models;
using NetBungieAPI.Models.Applications;
using NetBungieAPI.Models.Tokens;
using NetBungieAPI.Services.ApiAccess.Interfaces;
using NetBungieAPI.Services.Interfaces;

namespace NetBungieAPI.Services.ApiAccess
{
    /// <summary>
    /// <see cref="ITokenMethodsAccess"/>
    /// </summary>
    public class TokenMethodsAccess : ITokenMethodsAccess
    {
        private readonly BungieClientConfiguration _configuration;
        private readonly IDotNetBungieApiHttpClient _dotNetBungieApiHttpClient;

        internal TokenMethodsAccess(
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