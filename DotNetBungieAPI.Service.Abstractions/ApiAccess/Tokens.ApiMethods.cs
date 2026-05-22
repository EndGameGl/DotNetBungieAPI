using DotNetBungieAPI.Models;
using DotNetBungieAPI.Models.Authorization;

namespace DotNetBungieAPI.Service.Abstractions.ApiAccess;

public interface ITokensApi
{
    Task<BungieResponse<bool>> ForceDropsRepair(
        AuthorizationTokenData? authorizationToken = null,
        CancellationToken cancellationToken = default
    );

    Task<BungieResponse<bool>> ClaimPartnerOffer(
        Models.Tokens.PartnerOfferClaimRequest requestBody,
        AuthorizationTokenData? authorizationToken = null,
        CancellationToken cancellationToken = default
    );

    Task<BungieResponse<bool>> ApplyMissingPartnerOffersWithoutClaim(
        int partnerApplicationId,
        long targetBnetMembershipId,
        AuthorizationTokenData? authorizationToken = null,
        CancellationToken cancellationToken = default
    );

    Task<BungieResponse<Models.Tokens.PartnerOfferSkuHistoryResponse[]>> GetPartnerOfferSkuHistory(
        int partnerApplicationId,
        long targetBnetMembershipId,
        AuthorizationTokenData? authorizationToken = null,
        CancellationToken cancellationToken = default
    );

    Task<BungieResponse<Models.Tokens.PartnerRewardHistoryResponse>> GetPartnerRewardHistory(
        int partnerApplicationId,
        long targetBnetMembershipId,
        AuthorizationTokenData? authorizationToken = null,
        CancellationToken cancellationToken = default
    );

    Task<BungieResponse<Dictionary<string, Models.Tokens.BungieRewardDisplay>>> GetBungieRewardsForUser(
        long membershipId,
        AuthorizationTokenData? authorizationToken = null,
        CancellationToken cancellationToken = default
    );

    Task<BungieResponse<Dictionary<string, Models.Tokens.BungieRewardDisplay>>> GetBungieRewardsForPlatformUser(
        long membershipId,
        Models.BungieMembershipType membershipType,
        AuthorizationTokenData? authorizationToken = null,
        CancellationToken cancellationToken = default
    );

    Task<BungieResponse<Dictionary<string, Models.Tokens.BungieRewardDisplay>>> GetBungieRewardsList(AuthorizationTokenData? authorizationToken = null, CancellationToken cancellationToken = default);

}
