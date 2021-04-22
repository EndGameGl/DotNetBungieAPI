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
        ValueTask<BungieResponse<PartnerOfferSkuHistoryResponse[]>> GetPartnerOfferSkuHistory(
            int partnerApplicationId,
            long targetBnetMembershipId, CancellationToken token = default);
    }
}