using System.Threading;
using System.Threading.Tasks;
using NetBungieAPI.Authorization;
using NetBungieAPI.Models;
using NetBungieAPI.Models.Tokens;
using NetBungieAPI.Services.ApiAccess.Interfaces;

namespace NetBungieAPI.Services.UserScopedApiAccess
{
    public class UserScopedTokenMethodsAccess
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