using DotNetBungieAPI.Authorization;
using DotNetBungieAPI.Models;
using DotNetBungieAPI.Models.Tokens;
using DotNetBungieAPI.Services.ApiAccess.Interfaces;
using System.Threading;
using System.Threading.Tasks;

namespace DotNetBungieAPI.Services.ApiAccess.UserScoped
{
    public sealed class UserScopedTokenMethodsAccess
    {
        private readonly ITokenMethodsAccess _apiAccess;
        private readonly AuthorizationTokenData _token;

        internal UserScopedTokenMethodsAccess(
            ITokenMethodsAccess apiAccess,
            AuthorizationTokenData token)
        {
            _apiAccess = apiAccess;
            _token = token;
        }

        public async ValueTask<BungieResponse<PartnerOfferSkuHistoryResponse[]>> GetPartnerOfferSkuHistory(
            int partnerApplicationId,
            long targetBnetMembershipId,
            CancellationToken token = default)
        {
            return await _apiAccess.GetPartnerOfferSkuHistory(_token, partnerApplicationId, targetBnetMembershipId,
                token);
        }
    }
}