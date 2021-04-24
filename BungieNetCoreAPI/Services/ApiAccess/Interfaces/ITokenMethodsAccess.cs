using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using NetBungieAPI.Models;
using NetBungieAPI.Models.Tokens;

namespace NetBungieAPI.Services.ApiAccess.Interfaces
{
    public interface ITokenMethodsAccess
    {
        /// <summary>
        /// Returns the partner sku and offer history of the targeted user. Elevated permissions are required to see users that are not yourself.
        /// </summary>
        /// <param name="partnerApplicationId">The partner application identifier.</param>
        /// <param name="targetBnetMembershipId">The bungie.net user to apply missing offers to. If not self, elevated permissions are required.</param>
        /// <param name="token">Cancellation token</param>
        /// <returns></returns>
        ValueTask<BungieResponse<PartnerOfferSkuHistoryResponse[]>> GetPartnerOfferSkuHistory(
            int partnerApplicationId, long targetBnetMembershipId, CancellationToken token = default);
    }
}