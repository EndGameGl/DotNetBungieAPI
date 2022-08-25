using System.Collections.ObjectModel;
using DotNetBungieAPI.Models;
using DotNetBungieAPI.Models.Authorization;
using DotNetBungieAPI.Models.Requests;
using DotNetBungieAPI.Models.Tokens;

namespace DotNetBungieAPI.Service.Abstractions.ApiAccess;

/// <summary>
///     Access to https://bungie.net/Platform/Tokens endpoint
/// </summary>
public interface ITokensMethodsAccess
{
    /// <summary>
    ///     Twitch Drops self-repair function - scans twitch for drops not marked as fulfilled and resyncs them.
    /// </summary>
    /// <param name="authorizationToken">Auth token for respective user</param>
    /// <param name="cancellationToken">Cancellation token</param>
    /// <returns></returns>
    Task<BungieResponse<bool>> ForceDropsRepair(
        AuthorizationTokenData authorizationToken,
        CancellationToken cancellationToken = default);
    
    /// <summary>
    ///     Claim a partner offer as the authenticated user.
    /// </summary>
    /// <param name="request">Request body</param>
    /// <param name="authorizationToken">Auth token for respective user</param>
    /// <param name="cancellationToken">Cancellation token</param>
    /// <returns></returns>
    Task<BungieResponse<bool>> ClaimPartnerOffer(
        PartnerOfferClaimRequest request,
        AuthorizationTokenData authorizationToken,
        CancellationToken cancellationToken = default);

    /// <summary>
    ///     Apply a partner offer to the targeted user. This endpoint does not claim a new offer, but any already claimed offers will be applied to the game if not already.
    /// </summary>
    /// <param name="partnerApplicationId">The partner application identifier.</param>
    /// <param name="targetBnetMembershipId">The bungie.net user to apply missing offers to. If not self, elevated permissions are required.</param>
    /// <param name="authorizationToken">Auth token for respective user</param>
    /// <param name="cancellationToken">Cancellation token</param>
    /// <returns></returns>
    Task<BungieResponse<bool>> ApplyMissingPartnerOffersWithoutClaim(
        int partnerApplicationId,
        long targetBnetMembershipId,
        AuthorizationTokenData authorizationToken,
        CancellationToken cancellationToken = default);

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
    /// <param name="authorizationToken">Auth token for respective user</param>
    /// <returns></returns>
    Task<BungieResponse<ReadOnlyCollection<PartnerOfferSkuHistoryResponse>>> GetPartnerOfferSkuHistory(
        AuthorizationTokenData authorizationToken,
        int partnerApplicationId,
        long targetBnetMembershipId,
        CancellationToken cancellationToken = default);

    /// <summary>
    ///     Returns the partner rewards history of the targeted user, both partner offers and Twitch drops.
    /// </summary>
    /// <param name="targetBnetMembershipId">The bungie.net user to return reward history for.</param>
    /// <param name="partnerApplicationId">The partner application identifier.</param>
    /// <param name="authorizationToken">Auth token for respective user</param>
    /// <param name="cancellationToken">Cancellation token</param>
    /// <returns></returns>
    Task<BungieResponse<PartnerRewardHistoryResponse>> GetPartnerRewardHistory(
        long targetBnetMembershipId,
        int partnerApplicationId,
        AuthorizationTokenData authorizationToken,
        CancellationToken cancellationToken = default);

    /// <summary>
    ///     Returns the bungie rewards for the targeted user.
    /// </summary>
    /// <param name="membershipId">Bungie.net user membershipId for requested user rewards. If not self, elevated permissions are required.</param>
    /// <param name="authorizationToken">Auth token for respective user</param>
    /// <param name="cancellationToken">Cancellation token</param>
    /// <returns></returns>
    Task<BungieResponse<ReadOnlyDictionary<string, BungieRewardDisplay>>> GetBungieRewardsForUser(
        long membershipId,
        AuthorizationTokenData authorizationToken,
        CancellationToken cancellationToken = default);

    /// <summary>
    ///     Returns the bungie rewards for the targeted user when a platform membership Id and Type are used.
    /// </summary>
    /// <param name="membershipId">Users platform membershipId for requested user rewards. If not self, elevated permissions are required.</param>
    /// <param name="membershipType">The target Destiny 2 membership type.</param>
    /// <param name="authorizationToken">Auth token for respective user</param>
    /// <param name="cancellationToken">Cancellation token</param>
    /// <returns></returns>
    Task<BungieResponse<ReadOnlyDictionary<string, BungieRewardDisplay>>> GetBungieRewardsForPlatformUser(
        long membershipId,
        BungieMembershipType membershipType,
        AuthorizationTokenData authorizationToken,
        CancellationToken cancellationToken = default);

    /// <summary>
    ///     Returns a list of the current bungie rewards
    /// </summary>
    /// <param name="cancellationToken">Cancellation token</param>
    /// <returns></returns>
    Task<BungieResponse<ReadOnlyDictionary<string, BungieRewardDisplay>>> GetBungieRewardsList(
        CancellationToken cancellationToken = default);
}