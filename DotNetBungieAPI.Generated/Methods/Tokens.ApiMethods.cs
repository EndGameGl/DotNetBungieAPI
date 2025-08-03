using DotNetBungieAPI.Generated.Models;

namespace DotNetBungieAPI.Generated.Methods;

public interface ITokensApi
{
    Task<ApiResponse<bool>> ForceDropsRepair(
        string authToken
    );

    Task<ApiResponse<bool>> ClaimPartnerOffer(
        Models.Tokens.PartnerOfferClaimRequest body,
        string authToken
    );

    Task<ApiResponse<bool>> ApplyMissingPartnerOffersWithoutClaim(
        int partnerApplicationId,
        long targetBnetMembershipId,
        string authToken
    );

    Task<ApiResponse<Models.Tokens.PartnerOfferSkuHistoryResponse[]>> GetPartnerOfferSkuHistory(
        int partnerApplicationId,
        long targetBnetMembershipId,
        string authToken
    );

    Task<ApiResponse<Models.Tokens.PartnerRewardHistoryResponse>> GetPartnerRewardHistory(
        int partnerApplicationId,
        long targetBnetMembershipId,
        string authToken
    );

    Task<ApiResponse<Dictionary<string, Models.Tokens.BungieRewardDisplay>>> GetBungieRewardsForUser(
        long membershipId,
        string authToken
    );

    Task<ApiResponse<Dictionary<string, Models.Tokens.BungieRewardDisplay>>> GetBungieRewardsForPlatformUser(
        long membershipId,
        Models.BungieMembershipType membershipType,
        string authToken
    );

    Task<ApiResponse<Dictionary<string, Models.Tokens.BungieRewardDisplay>>> GetBungieRewardsList();

}
