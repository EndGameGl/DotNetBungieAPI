using System.Threading;
using System.Threading.Tasks;
using DotNetBungieAPI.Authorization;
using DotNetBungieAPI.Models;
using DotNetBungieAPI.Models.Tokens;

namespace DotNetBungieAPI.Services.ApiAccess.Interfaces;

/// <summary>
///     Access to https://bungie.net/Platform/Tokens endpoint
/// </summary>
public interface ITokenMethodsAccess
{
    /// <summary>
    ///     Returns the partner sku and offer history of the targeted user. Elevated permissions are required to see users that
    ///     are not yourself.
    /// </summary>
    /// <param name="partnerApplicationId">The partner application identifier.</param>
    /// <param name="targetBnetMembershipId">
    ///     The bungie.net user to apply missing offers to. If not self, elevated permissions
    ///     are required.
    /// </param>
    /// <param name="cancellationToken">Cancellation token</param>
    /// ///
    /// <param name="authorizationToken">Authorization token</param>
    /// <returns></returns>
    ValueTask<BungieResponse<PartnerOfferSkuHistoryResponse[]>> GetPartnerOfferSkuHistory(
        AuthorizationTokenData authorizationToken,
        int partnerApplicationId,
        long targetBnetMembershipId,
        CancellationToken cancellationToken = default);
}