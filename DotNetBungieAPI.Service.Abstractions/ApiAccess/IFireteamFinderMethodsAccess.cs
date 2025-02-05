using DotNetBungieAPI.Models;
using DotNetBungieAPI.Models.FireteamFinder;

namespace DotNetBungieAPI.Service.Abstractions.ApiAccess;

/// <summary>
///     Access to https://bungie.net/Platform/FireteamFinder endpoint
/// </summary>
public interface IFireteamFinderMethodsAccess
{
    /// <summary>
    ///     Activates a lobby and initializes it as an active Fireteam.
    /// </summary>
    /// <param name="destinyCharacterId">A valid Destiny character ID.</param>
    /// <param name="destinyMembershipId">A valid Destiny membership ID.</param>
    /// <param name="destinyMembershipType">A valid Destiny membership type.</param>
    /// <param name="lobbyId">The ID of the lobby to activate.</param>
    /// <param name="forceActivation">Optional boolean to forcibly activate the lobby, kicking pending applicants.</param>
    /// <param name="cancellationToken">Cancellation token</param>
    /// <returns></returns>
    Task<BungieResponse<bool>> ActivateLobby(
        long destinyCharacterId,
        long destinyMembershipId,
        BungieMembershipType destinyMembershipType,
        long lobbyId,
        bool? forceActivation = null,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    ///     Activates a lobby and initializes it as an active Fireteam, returning the updated Listing ID.
    /// </summary>
    /// <param name="destinyCharacterId">A valid Destiny character ID.</param>
    /// <param name="destinyMembershipId">A valid Destiny membership ID.</param>
    /// <param name="destinyMembershipType">A valid Destiny membership type.</param>
    /// <param name="lobbyId">The ID of the lobby to activate.</param>
    /// <param name="forceActivation">Optional boolean to forcibly activate the lobby, kicking pending applicants.</param>
    /// <param name="cancellationToken">Cancellation token</param>
    /// <returns></returns>
    Task<BungieResponse<bool>> ActivateLobbyForNewListingId(
        long destinyCharacterId,
        long destinyMembershipId,
        BungieMembershipType destinyMembershipType,
        long lobbyId,
        bool? forceActivation = null,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    ///     Applies to have a character join a fireteam.
    /// </summary>
    /// <param name="applicationType">The type of application to apply</param>
    /// <param name="destinyCharacterId">A valid Destiny character ID.</param>
    /// <param name="destinyMembershipId">A valid Destiny membership ID.</param>
    /// <param name="destinyMembershipType">A valid Destiny membership type.</param>
    /// <param name="listingId">The id of the listing to apply to</param>
    /// <param name="cancellationToken">Cancellation token</param>
    /// <returns></returns>
    Task<BungieResponse<DestinyFireteamFinderApplyToListingResponse>> ApplyToListing(
        DestinyFireteamFinderApplicationType applicationType,
        long destinyCharacterId,
        long destinyMembershipId,
        BungieMembershipType destinyMembershipType,
        long listingId,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    ///     Retrieves Fireteam listing statuses in bulk.
    /// </summary>
    /// <param name="destinyCharacterId">A valid Destiny character ID.</param>
    /// <param name="destinyMembershipId">A valid Destiny membership ID.</param>
    /// <param name="destinyMembershipType">A valid Destiny membership type.</param>
    /// <param name="body">Request body</param>
    /// <param name="cancellationToken">Cancellation token</param>
    /// <returns></returns>
    Task<BungieResponse<DestinyFireteamFinderBulkGetListingStatusResponse>> BulkGetListingStatus(
        long destinyCharacterId,
        long destinyMembershipId,
        BungieMembershipType destinyMembershipType,
        DestinyFireteamFinderBulkGetListingStatusRequest body,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    ///     Retrieves a Fireteam application.
    /// </summary>
    /// <param name="applicationId"></param>
    /// <param name="destinyCharacterId">A valid Destiny character ID.</param>
    /// <param name="destinyMembershipId">A valid Destiny membership ID.</param>
    /// <param name="destinyMembershipType">A valid Destiny membership type.</param>
    /// <param name="cancellationToken">Cancellation token</param>
    /// <returns></returns>
    Task<BungieResponse<DestinyFireteamFinderGetApplicationResponse>> GetApplication(
        long applicationId,
        long destinyCharacterId,
        long destinyMembershipId,
        BungieMembershipType destinyMembershipType,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    ///     Retrieves a Fireteam listing.
    /// </summary>
    /// <param name="listingId">The ID of the listing to retrieve.</param>
    /// <param name="cancellationToken">Cancellation token</param>
    /// <returns></returns>
    Task<BungieResponse<DestinyFireteamFinderListing>> GetListing(
        long listingId,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    ///     Retrieves all applications to a Fireteam Finder listing.
    /// </summary>
    /// <param name="destinyCharacterId">A valid Destiny character ID.</param>
    /// <param name="destinyMembershipId">A valid Destiny membership ID.</param>
    /// <param name="destinyMembershipType">A valid Destiny membership type.</param>
    /// <param name="listingId">The ID of the listing whose applications to retrieve.</param>
    /// <param name="flags">Optional flag representing a filter on the state of the application.</param>
    /// <param name="nextPageToken">An optional token from a previous response to fetch the next page of results.</param>
    /// <param name="pageSize">The maximum number of results to be returned with this page.</param>
    /// <param name="cancellationToken">Cancellation token</param>
    /// <returns></returns>
    Task<
        BungieResponse<DestinyFireteamFinderGetListingApplicationsResponse>
    > GetListingApplications(
        long destinyCharacterId,
        long destinyMembershipId,
        BungieMembershipType destinyMembershipType,
        long listingId,
        long flags,
        string nextPageToken,
        int pageSize,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    ///     Retrieves the information for a Fireteam lobby.
    /// </summary>
    /// <param name="destinyCharacterId">A valid Destiny character ID.</param>
    /// <param name="destinyMembershipId">A valid Destiny membership ID.</param>
    /// <param name="destinyMembershipType">A valid Destiny membership type.</param>
    /// <param name="lobbyId">The ID of the lobby to retrieve.</param>
    /// <param name="cancellationToken">Cancellation token</param>
    /// <returns></returns>
    Task<BungieResponse<DestinyFireteamFinderLobbyResponse>> GetLobby(
        long destinyCharacterId,
        long destinyMembershipId,
        BungieMembershipType destinyMembershipType,
        long lobbyId,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    ///     Retrieves the information for a Fireteam lobby.
    /// </summary>
    /// <param name="destinyCharacterId">A valid Destiny character ID.</param>
    /// <param name="destinyMembershipId">A valid Destiny membership ID.</param>
    /// <param name="destinyMembershipType">A valid Destiny membership type.</param>
    /// <param name="pageSize">The maximum number of results to be returned with this page.</param>
    /// <param name="nextPageToken">An optional token from a previous response to fetch the next page of results.</param>
    /// <param name="cancellationToken">Cancellation token</param>
    /// <returns></returns>
    Task<BungieResponse<DestinyFireteamFinderGetPlayerLobbiesResponse>> GetPlayerLobbies(
        long destinyCharacterId,
        long destinyMembershipId,
        BungieMembershipType destinyMembershipType,
        int pageSize,
        string? nextPageToken = null,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    ///     Retrieves Fireteam applications that this player has sent or recieved.
    /// </summary>
    /// <param name="destinyCharacterId">A valid Destiny character ID.</param>
    /// <param name="destinyMembershipId">A valid Destiny membership ID.</param>
    /// <param name="destinyMembershipType">A valid Destiny membership type.</param>
    /// <param name="pageSize">The maximum number of results to be returned with this page.</param>
    /// <param name="nextPageToken">An optional token from a previous response to fetch the next page of results.</param>
    /// <param name="cancellationToken">Cancellation token</param>
    /// <returns></returns>
    Task<BungieResponse<DestinyFireteamFinderGetPlayerApplicationsResponse>> GetPlayerApplications(
        long destinyCharacterId,
        long destinyMembershipId,
        BungieMembershipType destinyMembershipType,
        int pageSize,
        string? nextPageToken = null,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    ///     Retrieves Fireteam offers that this player has recieved.
    /// </summary>
    /// <param name="destinyCharacterId">A valid Destiny character ID.</param>
    /// <param name="destinyMembershipId">A valid Destiny membership ID.</param>
    /// <param name="destinyMembershipType">A valid Destiny membership type.</param>
    /// <param name="pageSize">The maximum number of results to be returned with this page.</param>
    /// <param name="nextPageToken">An optional token from a previous response to fetch the next page of results.</param>
    /// <param name="cancellationToken">Cancellation token</param>
    /// <returns></returns>
    Task<BungieResponse<DestinyFireteamFinderGetPlayerOffersResponse>> GetPlayerOffers(
        long destinyCharacterId,
        long destinyMembershipId,
        BungieMembershipType destinyMembershipType,
        int pageSize,
        string? nextPageToken = null,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    ///     Retrieves the information for a Fireteam lobby.
    /// </summary>
    /// <param name="destinyCharacterId">A valid Destiny character ID.</param>
    /// <param name="destinyMembershipId">A valid Destiny membership ID.</param>
    /// <param name="destinyMembershipType">A valid Destiny membership type.</param>
    /// <param name="cancellationToken">Cancellation token</param>
    /// <returns></returns>
    Task<
        BungieResponse<DestinyFireteamFinderGetCharacterActivityAccessResponse>
    > GetCharacterActivityAccess(
        long destinyCharacterId,
        long destinyMembershipId,
        BungieMembershipType destinyMembershipType,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    ///     Retrieves an offer to a Fireteam lobby.
    /// </summary>
    /// <param name="destinyCharacterId">A valid Destiny character ID.</param>
    /// <param name="destinyMembershipId">A valid Destiny membership ID.</param>
    /// <param name="destinyMembershipType">A valid Destiny membership type.</param>
    /// <param name="offerId">The unique ID of the offer.</param>
    /// <param name="cancellationToken">Cancellation token</param>
    /// <returns></returns>
    Task<BungieResponse<DestinyFireteamFinderOffer>> GetOffer(
        long destinyCharacterId,
        long destinyMembershipId,
        BungieMembershipType destinyMembershipType,
        long offerId,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    ///     Retrieves all offers relevant to a Fireteam lobby.
    /// </summary>
    /// <param name="destinyCharacterId">A valid Destiny character ID.</param>
    /// <param name="destinyMembershipId">A valid Destiny membership ID.</param>
    /// <param name="destinyMembershipType">A valid Destiny membership type.</param>
    /// <param name="lobbyId">The unique ID of the lobby.</param>
    /// <param name="pageSize">The maximum number of results to be returned with this page.</param>
    /// <param name="nextPageToken">An optional token from a previous response to fetch the next page of results.</param>
    /// <param name="cancellationToken">Cancellation token</param>
    /// <returns></returns>
    Task<BungieResponse<DestinyFireteamFinderGetLobbyOffersResponse>> GetLobbyOffers(
        long destinyCharacterId,
        long destinyMembershipId,
        BungieMembershipType destinyMembershipType,
        long lobbyId,
        int pageSize,
        string? nextPageToken = null,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    ///     Creates a new Fireteam lobby and Fireteam Finder listing.
    /// </summary>
    /// <param name="destinyCharacterId">A valid Destiny character ID.</param>
    /// <param name="destinyMembershipId">A valid Destiny membership ID.</param>
    /// <param name="destinyMembershipType">A valid Destiny membership type.</param>
    /// <param name="body">Request body</param>
    /// <param name="cancellationToken">Cancellation token</param>
    /// <returns></returns>
    Task<BungieResponse<DestinyFireteamFinderHostLobbyResponse>> HostLobby(
        long destinyCharacterId,
        long destinyMembershipId,
        BungieMembershipType destinyMembershipType,
        DestinyFireteamFinderLobbySettings body,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    ///     Sends a request to join an available Fireteam lobby.
    /// </summary>
    /// <param name="destinyCharacterId">A valid Destiny character ID.</param>
    /// <param name="destinyMembershipId">A valid Destiny membership ID.</param>
    /// <param name="destinyMembershipType">A valid Destiny membership type.</param>
    /// <param name="body">Request body</param>
    /// <param name="cancellationToken">Cancellation token</param>
    /// <returns></returns>
    Task<BungieResponse<DestinyFireteamFinderLobbyResponse>> JoinLobby(
        long destinyCharacterId,
        long destinyMembershipId,
        BungieMembershipType destinyMembershipType,
        DestinyFireteamFinderJoinLobbyRequest body,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    ///     Kicks a player from a Fireteam Finder lobby.
    /// </summary>
    /// <param name="destinyCharacterId">A valid Destiny character ID.</param>
    /// <param name="destinyMembershipId">A valid Destiny membership ID.</param>
    /// <param name="destinyMembershipType">A valid Destiny membership type.</param>
    /// <param name="lobbyId">The ID of the lobby to kick the player from.</param>
    /// <param name="targetMembershipId">A valid Destiny membership ID of the player to kick.</param>
    /// <param name="body">Request body</param>
    /// <param name="cancellationToken">Cancellation token</param>
    /// <returns></returns>
    Task<BungieResponse<bool>> KickPlayer(
        long destinyCharacterId,
        long destinyMembershipId,
        BungieMembershipType destinyMembershipType,
        long lobbyId,
        long targetMembershipId,
        DestinyFireteamFinderKickPlayerRequest body,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    ///     Sends a request to leave a Fireteam listing application.
    /// </summary>
    /// <param name="applicationId">The ID of the application to leave.</param>
    /// <param name="destinyCharacterId">A valid Destiny character ID.</param>
    /// <param name="destinyMembershipId">A valid Destiny membership ID.</param>
    /// <param name="destinyMembershipType">A valid Destiny membership type.</param>
    /// <param name="cancellationToken">Cancellation token</param>
    /// <returns></returns>
    Task<BungieResponse<bool>> LeaveApplication(
        long applicationId,
        long destinyCharacterId,
        long destinyMembershipId,
        BungieMembershipType destinyMembershipType,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    ///     Sends a request to leave a Fireteam lobby.
    /// </summary>
    /// <param name="destinyCharacterId">A valid Destiny character ID.</param>
    /// <param name="destinyMembershipId">A valid Destiny membership ID.</param>
    /// <param name="destinyMembershipType">A valid Destiny membership type.</param>
    /// <param name="lobbyId">The ID of the lobby to leave.</param>
    /// <param name="cancellationToken">Cancellation token</param>
    /// <returns></returns>
    Task<BungieResponse<bool>> LeaveLobby(
        long destinyCharacterId,
        long destinyMembershipId,
        BungieMembershipType destinyMembershipType,
        long lobbyId,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    ///     Responds to an application sent to a Fireteam lobby.
    /// </summary>
    /// <param name="applicationId">The application ID to respond to.</param>
    /// <param name="destinyCharacterId">A valid Destiny character ID.</param>
    /// <param name="destinyMembershipId">A valid Destiny membership ID.</param>
    /// <param name="destinyMembershipType">A valid Destiny membership type.</param>
    /// <param name="body">Request body</param>
    /// <param name="cancellationToken">Cancellation token</param>
    /// <returns></returns>
    Task<BungieResponse<DestinyFireteamFinderRespondToApplicationResponse>> RespondToApplication(
        long applicationId,
        long destinyCharacterId,
        long destinyMembershipId,
        BungieMembershipType destinyMembershipType,
        DestinyFireteamFinderRespondToApplicationRequest body,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    ///     Responds to an authentication request for a Fireteam.
    /// </summary>
    /// <param name="applicationId">The ID of the application whose authentication to confirm.</param>
    /// <param name="destinyCharacterId">A valid Destiny character ID.</param>
    /// <param name="destinyMembershipId">A valid Destiny membership ID.</param>
    /// <param name="destinyMembershipType">A valid Destiny membership type.</param>
    /// <param name="body">Request body</param>
    /// <param name="cancellationToken">Cancellation token</param>
    /// <returns></returns>
    Task<
        BungieResponse<DestinyFireteamFinderRespondToAuthenticationResponse>
    > RespondToAuthentication(
        long applicationId,
        long destinyCharacterId,
        long destinyMembershipId,
        BungieMembershipType destinyMembershipType,
        DestinyFireteamFinderRespondToAuthenticationRequest body,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    ///     Responds to a Fireteam lobby offer.
    /// </summary>
    /// <param name="destinyCharacterId">A valid Destiny character ID.</param>
    /// <param name="destinyMembershipId">A valid Destiny membership ID.</param>
    /// <param name="destinyMembershipType">A valid Destiny membership type.</param>
    /// <param name="offerId">The unique ID of the offer.</param>
    /// <param name="body">Request body</param>
    /// <param name="cancellationToken">Cancellation token</param>
    /// <returns></returns>
    Task<BungieResponse<DestinyFireteamFinderRespondToOfferResponse>> RespondToOffer(
        long destinyCharacterId,
        long destinyMembershipId,
        BungieMembershipType destinyMembershipType,
        long offerId,
        DestinyFireteamFinderRespondToOfferRequest body,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    ///     Returns search results for available Fireteams provided a clan.
    /// </summary>
    /// <param name="destinyCharacterId">A valid Destiny character ID.</param>
    /// <param name="destinyMembershipId">A valid Destiny membership ID.</param>
    /// <param name="destinyMembershipType">A valid Destiny membership type.</param>
    /// <param name="body">Request body</param>
    /// <param name="cancellationToken">Cancellation token</param>
    /// <returns></returns>
    Task<BungieResponse<DestinyFireteamFinderSearchListingsByClanResponse>> SearchListingsByClan(
        long destinyCharacterId,
        long destinyMembershipId,
        BungieMembershipType destinyMembershipType,
        DestinyFireteamFinderSearchListingsByClanRequest body,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    ///     Returns search results for available Fireteams provided search filters.
    /// </summary>
    /// <param name="destinyCharacterId">A valid Destiny character ID.</param>
    /// <param name="destinyMembershipId">A valid Destiny membership ID.</param>
    /// <param name="destinyMembershipType">A valid Destiny membership type.</param>
    /// <param name="overrideOfflineFilter">Optional boolean to bypass the offline-only check, so the client can pull fireteam from the game.</param>
    /// <param name="body">Request body</param>
    /// <param name="cancellationToken">Cancellation token</param>
    /// <returns></returns>
    Task<
        BungieResponse<DestinyFireteamFinderSearchListingsByFiltersResponse>
    > SearchListingsByFilters(
        long destinyCharacterId,
        long destinyMembershipId,
        BungieMembershipType destinyMembershipType,
        bool overrideOfflineFilter,
        DestinyFireteamFinderSearchListingsByFiltersRequest body,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    ///     Updates the settings for a Fireteam lobby.
    /// </summary>
    /// <param name="destinyCharacterId">A valid Destiny character ID.</param>
    /// <param name="destinyMembershipId">A valid Destiny membership ID.</param>
    /// <param name="destinyMembershipType">A valid Destiny membership type.</param>
    /// <param name="lobbyId">The ID of the lobby to update.</param>
    /// <param name="body">Request body</param>
    /// <param name="cancellationToken">Cancellation token</param>
    /// <returns></returns>
    Task<BungieResponse<DestinyFireteamFinderUpdateLobbySettingsResponse>> UpdateLobbySettings(
        long destinyCharacterId,
        long destinyMembershipId,
        BungieMembershipType destinyMembershipType,
        long lobbyId,
        DestinyFireteamFinderUpdateLobbySettingsRequest body,
        CancellationToken cancellationToken = default
    );
}
