using System.Threading;
using System.Threading.Tasks;
using DotNetBungieAPI.Clients;
using DotNetBungieAPI.Exceptions;
using DotNetBungieAPI.Models;
using DotNetBungieAPI.Models.Applications;
using DotNetBungieAPI.Models.Authorization;
using DotNetBungieAPI.Models.Tokens;
using DotNetBungieAPI.Service.Abstractions;
using DotNetBungieAPI.Service.Abstractions.ApiAccess;

namespace DotNetBungieAPI.Services.ApiAccess;

/// <summary>
///     <see cref="ITokenMethodsAccess" />
/// </summary>
internal sealed class TokensMethodsAccess : ITokensMethodsAccess
{
    private readonly IBungieClientConfiguration _configuration;
    private readonly IDotNetBungieApiHttpClient _dotNetBungieApiHttpClient;

    public TokensMethodsAccess(
        IDotNetBungieApiHttpClient dotNetBungieApiHttpClient,
        IBungieClientConfiguration configuration)
    {
        _dotNetBungieApiHttpClient = dotNetBungieApiHttpClient;
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

        return await _dotNetBungieApiHttpClient
            .GetFromBungieNetPlatform<PartnerOfferSkuHistoryResponse[]>(
                url,
                cancellationToken,
                authorizationToken.AccessToken)
            .ConfigureAwait(false);
    }

    public async ValueTask<BungieResponse<ReadOnlyDictionary<string, BungieRewardDisplay>>> GetBungieRewardsForUser(
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

    public async ValueTask<BungieResponse<ReadOnlyDictionary<string, BungieRewardDisplay>>> GetBungieRewardsList(
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