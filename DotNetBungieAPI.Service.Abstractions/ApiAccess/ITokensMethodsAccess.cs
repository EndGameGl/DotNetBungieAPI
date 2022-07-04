using System.Collections.ObjectModel;
using DotNetBungieAPI.Models;
using DotNetBungieAPI.Models.Authorization;
using DotNetBungieAPI.Models.Tokens;

namespace DotNetBungieAPI.Service.Abstractions.ApiAccess;

/// <summary>
///     Access to https://bungie.net/Platform/Tokens endpoint
/// </summary>
public interface ITokensMethodsAccess
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

    /// <summary>
    ///     Returns the bungie rewards for the targeted user.
    /// </summary>
    /// <param name="membershipId">bungie.net user membershipId for requested user rewards. If not self, elevated permissions are required.</param>
    /// <param name="authorizationToken"></param>
    /// <param name="cancellationToken"></param>
    /// <returns></returns>
    ValueTask<BungieResponse<ReadOnlyDictionary<string, BungieRewardDisplay>>> GetBungieRewardsForUser(
        long membershipId,
        AuthorizationTokenData authorizationToken,
        CancellationToken cancellationToken = default);

    ValueTask<BungieResponse<ReadOnlyDictionary<string, BungieRewardDisplay>>> GetBungieRewardsList(
        CancellationToken cancellationToken = default);
}