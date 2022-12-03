using System.IO;
using System.Threading;
using System.Threading.Tasks;
using DotNetBungieAPI.Models;
using DotNetBungieAPI.Models.Applications;
using DotNetBungieAPI.Models.Authorization;
using DotNetBungieAPI.Models.Exceptions;
using DotNetBungieAPI.Models.Requests;
using DotNetBungieAPI.Models.Tokens;
using DotNetBungieAPI.Service.Abstractions;
using DotNetBungieAPI.Service.Abstractions.ApiAccess;

namespace DotNetBungieAPI.Services.ApiAccess;

/// <summary>
///     <inheritdoc />
/// </summary>
internal sealed class TokensMethodsAccess : ITokensMethodsAccess
{
    private readonly IBungieClientConfiguration _configuration;
    private readonly IBungieNetJsonSerializer _serializer;
    private readonly IDotNetBungieApiHttpClient _dotNetBungieApiHttpClient;

    public TokensMethodsAccess(
        IDotNetBungieApiHttpClient dotNetBungieApiHttpClient,
        IBungieClientConfiguration configuration,
        IBungieNetJsonSerializer serializer)
    {
        _dotNetBungieApiHttpClient = dotNetBungieApiHttpClient;
        _configuration = configuration;
        _serializer = serializer;
    }

    public async Task<BungieResponse<bool>> ForceDropsRepair(
        AuthorizationTokenData authorizationToken,
        CancellationToken cancellationToken = default)
    {
        if (!_configuration.HasSufficientRights(ApplicationScopes.PartnerOfferGrant))
            throw new InsufficientScopeException(ApplicationScopes.PartnerOfferGrant);

        var url = StringBuilderPool
            .GetBuilder(cancellationToken)
            .Append("/Tokens/Partner/ForceDropsRepair/")
            .Build();

        return await _dotNetBungieApiHttpClient
            .PostToBungieNetPlatform<bool>(
                url,
                cancellationToken,
                null,
                authorizationToken.AccessToken)
            .ConfigureAwait(false);
    }

    public async Task<BungieResponse<bool>> ClaimPartnerOffer(
        PartnerOfferClaimRequest request,
        AuthorizationTokenData authorizationToken,
        CancellationToken cancellationToken = default)
    {
        if (!_configuration.HasSufficientRights(ApplicationScopes.PartnerOfferGrant))
            throw new InsufficientScopeException(ApplicationScopes.PartnerOfferGrant);

        var url = StringBuilderPool
            .GetBuilder(cancellationToken)
            .Append("/Tokens/Partner/ClaimOffer/")
            .Build();

        var stream = new MemoryStream();
        await _serializer.SerializeAsync(stream, request);

        return await _dotNetBungieApiHttpClient
            .PostToBungieNetPlatform<bool>(
                url,
                cancellationToken,
                stream,
                authorizationToken.AccessToken)
            .ConfigureAwait(false);
    }

    public async Task<BungieResponse<bool>> ApplyMissingPartnerOffersWithoutClaim(
        int partnerApplicationId,
        long targetBnetMembershipId,
        AuthorizationTokenData authorizationToken,
        CancellationToken cancellationToken = default)
    {
        if (!_configuration.HasSufficientRights(ApplicationScopes.PartnerOfferGrant))
            throw new InsufficientScopeException(ApplicationScopes.PartnerOfferGrant);

        var url = StringBuilderPool
            .GetBuilder(cancellationToken)
            .Append("/Tokens/Partner/ApplyMissingOffers/")
            .AddUrlParam(partnerApplicationId.ToString())
            .AddUrlParam(targetBnetMembershipId.ToString())
            .Build();

        return await _dotNetBungieApiHttpClient
            .PostToBungieNetPlatform<bool>(
                url,
                cancellationToken,
                authToken: authorizationToken.AccessToken)
            .ConfigureAwait(false);
    }

    public async Task<BungieResponse<ReadOnlyCollection<PartnerOfferSkuHistoryResponse>>> GetPartnerOfferSkuHistory(
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
            .GetFromBungieNetPlatform<ReadOnlyCollection<PartnerOfferSkuHistoryResponse>>(
                url,
                cancellationToken,
                authorizationToken.AccessToken)
            .ConfigureAwait(false);
    }

    public async Task<BungieResponse<PartnerRewardHistoryResponse>> GetPartnerRewardHistory(
        long targetBnetMembershipId,
        int partnerApplicationId,
        AuthorizationTokenData authorizationToken,
        CancellationToken cancellationToken = default)
    {
        if (!_configuration.HasSufficientRights(ApplicationScopes.PartnerOfferGrant))
            throw new InsufficientScopeException(ApplicationScopes.PartnerOfferGrant);

        var url = StringBuilderPool
            .GetBuilder(cancellationToken)
            .Append("/Tokens/Partner/History/")
            .AddUrlParam(targetBnetMembershipId.ToString())
            .Append("Application/")
            .AddUrlParam(partnerApplicationId.ToString())
            .Build();

        return await _dotNetBungieApiHttpClient
            .GetFromBungieNetPlatform<PartnerRewardHistoryResponse>(
                url,
                cancellationToken,
                authorizationToken.AccessToken)
            .ConfigureAwait(false);
    }

    public async Task<BungieResponse<ReadOnlyDictionary<string, BungieRewardDisplay>>> GetBungieRewardsForUser(
        long membershipId,
        AuthorizationTokenData authorizationToken,
        CancellationToken cancellationToken = default)
    {
        if (!_configuration.HasSufficientRights(ApplicationScopes.ReadAndApplyTokens))
            throw new InsufficientScopeException(ApplicationScopes.ReadAndApplyTokens);

        var url = StringBuilderPool
            .GetBuilder(cancellationToken)
            .Append("/Tokens/Rewards/GetRewardsForUser/")
            .AddUrlParam(membershipId.ToString())
            .Build();

        return await _dotNetBungieApiHttpClient
            .GetFromBungieNetPlatform<ReadOnlyDictionary<string, BungieRewardDisplay>>(
                url,
                cancellationToken,
                authorizationToken.AccessToken)
            .ConfigureAwait(false);
    }

    public async Task<BungieResponse<ReadOnlyDictionary<string, BungieRewardDisplay>>> GetBungieRewardsForPlatformUser(
        long membershipId,
        BungieMembershipType membershipType,
        AuthorizationTokenData authorizationToken,
        CancellationToken cancellationToken = default)
    {
        if (!_configuration.HasSufficientRights(ApplicationScopes.ReadAndApplyTokens))
            throw new InsufficientScopeException(ApplicationScopes.ReadAndApplyTokens);

        var url = StringBuilderPool
            .GetBuilder(cancellationToken)
            .Append("/Tokens/Rewards/GetRewardsForPlatformUser/")
            .AddUrlParam(membershipId.ToString())
            .AddUrlParam(((byte)membershipType).ToString())
            .Build();

        return await _dotNetBungieApiHttpClient
            .GetFromBungieNetPlatform<ReadOnlyDictionary<string, BungieRewardDisplay>>(
                url,
                cancellationToken,
                authorizationToken.AccessToken)
            .ConfigureAwait(false);
    }

    public async Task<BungieResponse<ReadOnlyDictionary<string, BungieRewardDisplay>>> GetBungieRewardsList(
        CancellationToken cancellationToken = default)
    {
        var url = StringBuilderPool
            .GetBuilder(cancellationToken)
            .Append("/Tokens/Rewards/BungieRewards/")
            .Build();

        return await _dotNetBungieApiHttpClient
            .GetFromBungieNetPlatform<ReadOnlyDictionary<string, BungieRewardDisplay>>(
                url,
                cancellationToken)
            .ConfigureAwait(false);
    }
}