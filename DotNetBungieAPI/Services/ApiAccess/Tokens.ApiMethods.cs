using System.IO;
using System.Threading;
using System.Threading.Tasks;
using DotNetBungieAPI.Models;
using DotNetBungieAPI.Models.Applications;
using DotNetBungieAPI.Models.Authorization;
using DotNetBungieAPI.Models.Exceptions;
using DotNetBungieAPI.Service.Abstractions;
using DotNetBungieAPI.Service.Abstractions.ApiAccess;

namespace DotNetBungieAPI.Services.ApiAccess;

internal sealed class TokensApi : ITokensApi
{
    private readonly IBungieClientConfiguration _configuration;
    private readonly IDotNetBungieApiHttpClient _dotNetBungieApiHttpClient;
    private readonly IBungieNetJsonSerializer _serializer;

    public TokensApi(
        IBungieClientConfiguration configuration,
        IDotNetBungieApiHttpClient dotNetBungieApiHttpClient,
        IBungieNetJsonSerializer serializer
    )
    {
        _configuration = _configuration;
        _dotNetBungieApiHttpClient = dotNetBungieApiHttpClient;
        _serializer = serializer;
    }

    /// <summary>
    ///     Twitch Drops self-repair function - scans twitch for drops not marked as fulfilled and resyncs them.
    /// </summary>
    /// <param name="authorizationToken">Authorization information</param>
    /// <param name="cancellationToken">Method cancellation token</param>
    public async Task<BungieResponse<bool>> ForceDropsRepair(
        AuthorizationTokenData authorizationToken,
        CancellationToken cancellationToken = default
    )
    {
        if (!_configuration.HasSufficientRights(ApplicationScopes.PartnerOfferGrant))
            throw new InsufficientScopeException(ApplicationScopes.PartnerOfferGrant);

        return await _dotNetBungieApiHttpClient.PostToBungieNetPlatform<bool>("/Tokens/Partner/ForceDropsRepair/", cancellationToken, authToken: authorizationToken?.AccessToken);
    }

    /// <summary>
    ///     Claim a partner offer as the authenticated user.
    /// </summary>
    /// <param name="requestBody">Request body</param>
    /// <param name="authorizationToken">Authorization information</param>
    /// <param name="cancellationToken">Method cancellation token</param>
    public async Task<BungieResponse<bool>> ClaimPartnerOffer(
        Models.Tokens.PartnerOfferClaimRequest requestBody,
        AuthorizationTokenData authorizationToken,
        CancellationToken cancellationToken = default
    )
    {
        if (!_configuration.HasSufficientRights(ApplicationScopes.PartnerOfferGrant))
            throw new InsufficientScopeException(ApplicationScopes.PartnerOfferGrant);

        var stream = new MemoryStream();
        await _serializer.SerializeAsync(stream, requestBody);
        stream.Position = 0;

        return await _dotNetBungieApiHttpClient.PostToBungieNetPlatform<bool>("/Tokens/Partner/ClaimOffer/", cancellationToken, stream, authToken: authorizationToken?.AccessToken);
    }

    /// <summary>
    ///     Apply a partner offer to the targeted user. This endpoint does not claim a new offer, but any already claimed offers will be applied to the game if not already.
    /// </summary>
    /// <param name="partnerApplicationId">The partner application identifier.</param>
    /// <param name="targetBnetMembershipId">The bungie.net user to apply missing offers to. If not self, elevated permissions are required.</param>
    /// <param name="authorizationToken">Authorization information</param>
    /// <param name="cancellationToken">Method cancellation token</param>
    public async Task<BungieResponse<bool>> ApplyMissingPartnerOffersWithoutClaim(
        int partnerApplicationId,
        long targetBnetMembershipId,
        AuthorizationTokenData authorizationToken,
        CancellationToken cancellationToken = default
    )
    {
        if (!_configuration.HasSufficientRights(ApplicationScopes.PartnerOfferGrant))
            throw new InsufficientScopeException(ApplicationScopes.PartnerOfferGrant);

        var url = StringBuilderPool
            .GetBuilder(cancellationToken)
            .Append($"/Tokens/Partner/ApplyMissingOffers/{partnerApplicationId}/{targetBnetMembershipId}/")
            .Build();
        return await _dotNetBungieApiHttpClient.PostToBungieNetPlatform<bool>(url, cancellationToken, authToken: authorizationToken?.AccessToken);
    }

    /// <summary>
    ///     Returns the partner sku and offer history of the targeted user. Elevated permissions are required to see users that are not yourself.
    /// </summary>
    /// <param name="partnerApplicationId">The partner application identifier.</param>
    /// <param name="targetBnetMembershipId">The bungie.net user to apply missing offers to. If not self, elevated permissions are required.</param>
    /// <param name="authorizationToken">Authorization information</param>
    /// <param name="cancellationToken">Method cancellation token</param>
    public async Task<BungieResponse<Models.Tokens.PartnerOfferSkuHistoryResponse[]>> GetPartnerOfferSkuHistory(
        int partnerApplicationId,
        long targetBnetMembershipId,
        AuthorizationTokenData authorizationToken,
        CancellationToken cancellationToken = default
    )
    {
        if (!_configuration.HasSufficientRights(ApplicationScopes.PartnerOfferGrant))
            throw new InsufficientScopeException(ApplicationScopes.PartnerOfferGrant);

        var url = StringBuilderPool
            .GetBuilder(cancellationToken)
            .Append($"/Tokens/Partner/History/{partnerApplicationId}/{targetBnetMembershipId}/")
            .Build();
        return await _dotNetBungieApiHttpClient.GetFromBungieNetPlatform<Models.Tokens.PartnerOfferSkuHistoryResponse[]>(url, cancellationToken, authToken: authorizationToken?.AccessToken);
    }

    /// <summary>
    ///     Returns the partner rewards history of the targeted user, both partner offers and Twitch drops.
    /// </summary>
    /// <param name="partnerApplicationId">The partner application identifier.</param>
    /// <param name="targetBnetMembershipId">The bungie.net user to return reward history for.</param>
    /// <param name="authorizationToken">Authorization information</param>
    /// <param name="cancellationToken">Method cancellation token</param>
    public async Task<BungieResponse<Models.Tokens.PartnerRewardHistoryResponse>> GetPartnerRewardHistory(
        int partnerApplicationId,
        long targetBnetMembershipId,
        AuthorizationTokenData authorizationToken,
        CancellationToken cancellationToken = default
    )
    {
        if (!_configuration.HasSufficientRights(ApplicationScopes.PartnerOfferGrant))
            throw new InsufficientScopeException(ApplicationScopes.PartnerOfferGrant);

        var url = StringBuilderPool
            .GetBuilder(cancellationToken)
            .Append($"/Tokens/Partner/History/{targetBnetMembershipId}/Application/{partnerApplicationId}/")
            .Build();
        return await _dotNetBungieApiHttpClient.GetFromBungieNetPlatform<Models.Tokens.PartnerRewardHistoryResponse>(url, cancellationToken, authToken: authorizationToken?.AccessToken);
    }

    /// <summary>
    ///     Returns the bungie rewards for the targeted user.
    /// </summary>
    /// <param name="membershipId">bungie.net user membershipId for requested user rewards. If not self, elevated permissions are required.</param>
    /// <param name="authorizationToken">Authorization information</param>
    /// <param name="cancellationToken">Method cancellation token</param>
    public async Task<BungieResponse<Dictionary<string, Models.Tokens.BungieRewardDisplay>>> GetBungieRewardsForUser(
        long membershipId,
        AuthorizationTokenData authorizationToken,
        CancellationToken cancellationToken = default
    )
    {
        if (!_configuration.HasSufficientRights(ApplicationScopes.ReadAndApplyTokens))
            throw new InsufficientScopeException(ApplicationScopes.ReadAndApplyTokens);

        var url = StringBuilderPool
            .GetBuilder(cancellationToken)
            .Append($"/Tokens/Rewards/GetRewardsForUser/{membershipId}/")
            .Build();
        return await _dotNetBungieApiHttpClient.GetFromBungieNetPlatform<Dictionary<string, Models.Tokens.BungieRewardDisplay>>(url, cancellationToken, authToken: authorizationToken?.AccessToken);
    }

    /// <summary>
    ///     Returns the bungie rewards for the targeted user when a platform membership Id and Type are used.
    /// </summary>
    /// <param name="membershipId">users platform membershipId for requested user rewards. If not self, elevated permissions are required.</param>
    /// <param name="membershipType">The target Destiny 2 membership type.</param>
    /// <param name="authorizationToken">Authorization information</param>
    /// <param name="cancellationToken">Method cancellation token</param>
    public async Task<BungieResponse<Dictionary<string, Models.Tokens.BungieRewardDisplay>>> GetBungieRewardsForPlatformUser(
        long membershipId,
        Models.BungieMembershipType membershipType,
        AuthorizationTokenData authorizationToken,
        CancellationToken cancellationToken = default
    )
    {
        if (!_configuration.HasSufficientRights(ApplicationScopes.ReadAndApplyTokens))
            throw new InsufficientScopeException(ApplicationScopes.ReadAndApplyTokens);

        var url = StringBuilderPool
            .GetBuilder(cancellationToken)
            .Append($"/Tokens/Rewards/GetRewardsForPlatformUser/{membershipId}/{membershipType}/")
            .Build();
        return await _dotNetBungieApiHttpClient.GetFromBungieNetPlatform<Dictionary<string, Models.Tokens.BungieRewardDisplay>>(url, cancellationToken, authToken: authorizationToken?.AccessToken);
    }

    /// <summary>
    ///     Returns a list of the current bungie rewards
    /// </summary>
    /// <param name="cancellationToken">Method cancellation token</param>
    public async Task<BungieResponse<Dictionary<string, Models.Tokens.BungieRewardDisplay>>> GetBungieRewardsList(CancellationToken cancellationToken = default)
    {
        return await _dotNetBungieApiHttpClient.GetFromBungieNetPlatform<Dictionary<string, Models.Tokens.BungieRewardDisplay>>("/Tokens/Rewards/BungieRewards/", cancellationToken);
    }

}
