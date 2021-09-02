using System.Threading;
using System.Threading.Tasks;
using NetBungieAPI.Authorization;
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
        private readonly IConfigurationService _configuration;
        private readonly IHttpClientInstance _httpClient;

        internal TokenMethodsAccess(IHttpClientInstance httpClient, IConfigurationService configuration)
        {
            _httpClient = httpClient;
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

            return await _httpClient
                .GetFromBungieNetPlatform<PartnerOfferSkuHistoryResponse[]>(
                    url,
                    cancellationToken,
                    authorizationToken.AccessToken)
                .ConfigureAwait(false);
        }
    }
}