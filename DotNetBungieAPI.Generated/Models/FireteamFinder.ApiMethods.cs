namespace DotNetBungieAPI.Generated.Models;

public interface IFireteamFinderApi
{
    Task<ApiResponse<bool>> ActivateLobby(
        long destinyCharacterId,
        long destinyMembershipId,
        BungieMembershipType destinyMembershipType,
        long lobbyId,
        bool forceActivation
    );

    Task<ApiResponse<bool>> ActivateLobbyForNewListingId(
        long destinyCharacterId,
        long destinyMembershipId,
        BungieMembershipType destinyMembershipType,
        long lobbyId,
        bool forceActivation
    );

    Task<ApiResponse<FireteamFinder.DestinyFireteamFinderApplyToListingResponse>> ApplyToListing(
        FireteamFinder.DestinyFireteamFinderApplicationType applicationType,
        long destinyCharacterId,
        long destinyMembershipId,
        BungieMembershipType destinyMembershipType,
        long listingId
    );

    Task<ApiResponse<FireteamFinder.DestinyFireteamFinderBulkGetListingStatusResponse>> BulkGetListingStatus(
        long destinyCharacterId,
        long destinyMembershipId,
        BungieMembershipType destinyMembershipType,
        FireteamFinder.DestinyFireteamFinderBulkGetListingStatusRequest body
    );

    Task<ApiResponse<FireteamFinder.DestinyFireteamFinderGetApplicationResponse>> GetApplication(
        long applicationId,
        long destinyCharacterId,
        long destinyMembershipId,
        BungieMembershipType destinyMembershipType
    );

    Task<ApiResponse<FireteamFinder.DestinyFireteamFinderListing>> GetListing(
        long listingId
    );

    Task<ApiResponse<FireteamFinder.DestinyFireteamFinderGetListingApplicationsResponse>> GetListingApplications(
        long destinyCharacterId,
        long destinyMembershipId,
        BungieMembershipType destinyMembershipType,
        long listingId,
        long flags,
        string nextPageToken,
        int pageSize
    );

    Task<ApiResponse<FireteamFinder.DestinyFireteamFinderLobbyResponse>> GetLobby(
        long destinyCharacterId,
        long destinyMembershipId,
        BungieMembershipType destinyMembershipType,
        long lobbyId
    );

    Task<ApiResponse<FireteamFinder.DestinyFireteamFinderGetPlayerLobbiesResponse>> GetPlayerLobbies(
        long destinyCharacterId,
        long destinyMembershipId,
        BungieMembershipType destinyMembershipType,
        string nextPageToken,
        int pageSize
    );

    Task<ApiResponse<FireteamFinder.DestinyFireteamFinderGetPlayerApplicationsResponse>> GetPlayerApplications(
        long destinyCharacterId,
        long destinyMembershipId,
        BungieMembershipType destinyMembershipType,
        string nextPageToken,
        int pageSize
    );

    Task<ApiResponse<FireteamFinder.DestinyFireteamFinderGetPlayerOffersResponse>> GetPlayerOffers(
        long destinyCharacterId,
        long destinyMembershipId,
        BungieMembershipType destinyMembershipType,
        string nextPageToken,
        int pageSize
    );

    Task<ApiResponse<FireteamFinder.DestinyFireteamFinderGetCharacterActivityAccessResponse>> GetCharacterActivityAccess(
        long destinyCharacterId,
        long destinyMembershipId,
        BungieMembershipType destinyMembershipType
    );

    Task<ApiResponse<FireteamFinder.DestinyFireteamFinderOffer>> GetOffer(
        long destinyCharacterId,
        long destinyMembershipId,
        BungieMembershipType destinyMembershipType,
        long offerId
    );

    Task<ApiResponse<FireteamFinder.DestinyFireteamFinderGetLobbyOffersResponse>> GetLobbyOffers(
        long destinyCharacterId,
        long destinyMembershipId,
        BungieMembershipType destinyMembershipType,
        long lobbyId,
        string nextPageToken,
        int pageSize
    );

    Task<ApiResponse<FireteamFinder.DestinyFireteamFinderHostLobbyResponse>> HostLobby(
        long destinyCharacterId,
        long destinyMembershipId,
        BungieMembershipType destinyMembershipType,
        FireteamFinder.DestinyFireteamFinderHostLobbyRequest body
    );

    Task<ApiResponse<FireteamFinder.DestinyFireteamFinderLobbyResponse>> JoinLobby(
        long destinyCharacterId,
        long destinyMembershipId,
        BungieMembershipType destinyMembershipType,
        FireteamFinder.DestinyFireteamFinderJoinLobbyRequest body
    );

    Task<ApiResponse<bool>> KickPlayer(
        long destinyCharacterId,
        long destinyMembershipId,
        BungieMembershipType destinyMembershipType,
        long lobbyId,
        long targetMembershipId,
        FireteamFinder.DestinyFireteamFinderKickPlayerRequest body
    );

    Task<ApiResponse<bool>> LeaveApplication(
        long applicationId,
        long destinyCharacterId,
        long destinyMembershipId,
        BungieMembershipType destinyMembershipType
    );

    Task<ApiResponse<bool>> LeaveLobby(
        long destinyCharacterId,
        long destinyMembershipId,
        BungieMembershipType destinyMembershipType,
        long lobbyId
    );

    Task<ApiResponse<FireteamFinder.DestinyFireteamFinderRespondToApplicationResponse>> RespondToApplication(
        long applicationId,
        long destinyCharacterId,
        long destinyMembershipId,
        BungieMembershipType destinyMembershipType,
        FireteamFinder.DestinyFireteamFinderRespondToApplicationRequest body
    );

    Task<ApiResponse<FireteamFinder.DestinyFireteamFinderRespondToAuthenticationResponse>> RespondToAuthentication(
        long applicationId,
        long destinyCharacterId,
        long destinyMembershipId,
        BungieMembershipType destinyMembershipType,
        FireteamFinder.DestinyFireteamFinderRespondToAuthenticationRequest body
    );

    Task<ApiResponse<FireteamFinder.DestinyFireteamFinderRespondToOfferResponse>> RespondToOffer(
        long destinyCharacterId,
        long destinyMembershipId,
        BungieMembershipType destinyMembershipType,
        long offerId,
        FireteamFinder.DestinyFireteamFinderRespondToOfferRequest body
    );

    Task<ApiResponse<FireteamFinder.DestinyFireteamFinderSearchListingsByClanResponse>> SearchListingsByClan(
        long destinyCharacterId,
        long destinyMembershipId,
        BungieMembershipType destinyMembershipType,
        FireteamFinder.DestinyFireteamFinderSearchListingsByClanRequest body
    );

    Task<ApiResponse<FireteamFinder.DestinyFireteamFinderSearchListingsByFiltersResponse>> SearchListingsByFilters(
        long destinyCharacterId,
        long destinyMembershipId,
        BungieMembershipType destinyMembershipType,
        FireteamFinder.DestinyFireteamFinderSearchListingsByFiltersRequest body
    );

    Task<ApiResponse<FireteamFinder.DestinyFireteamFinderUpdateLobbySettingsResponse>> UpdateLobbySettings(
        long destinyCharacterId,
        long destinyMembershipId,
        BungieMembershipType destinyMembershipType,
        long lobbyId,
        FireteamFinder.DestinyFireteamFinderUpdateLobbySettingsRequest body
    );

}
