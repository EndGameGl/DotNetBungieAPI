namespace DotNetBungieAPI.Generated.Models;

public interface ITokensApi
{
    Task<ApiResponse<bool>> ForceDropsRepair(
        string authToken
    );

    Task<ApiResponse<bool>> ClaimPartnerOffer(
        Tokens.PartnerOfferClaimRequest body,
        string authToken
    );

    Task<ApiResponse<bool>> ApplyMissingPartnerOffersWithoutClaim(
        int partnerApplicationId,
        long targetBnetMembershipId,
        string authToken
    );

    Task<ApiResponse<Tokens.PartnerOfferSkuHistoryResponse[]>> GetPartnerOfferSkuHistory(
        int partnerApplicationId,
        long targetBnetMembershipId,
        string authToken
    );

    Task<ApiResponse<Tokens.PartnerRewardHistoryResponse>> GetPartnerRewardHistory(
        int partnerApplicationId,
        long targetBnetMembershipId,
        string authToken
    );

    Task<ApiResponse<Dictionary<string, Tokens.BungieRewardDisplay>>> GetBungieRewardsForUser(
        long membershipId,
        string authToken
    );

    Task<ApiResponse<Dictionary<string, Tokens.BungieRewardDisplay>>> GetBungieRewardsForPlatformUser(
        long membershipId,
        BungieMembershipType membershipType,
        string authToken
    );

    Task<ApiResponse<Dictionary<string, Tokens.BungieRewardDisplay>>> GetBungieRewardsList();

}
