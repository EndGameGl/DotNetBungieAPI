using System.IO;
using System.Threading;
using System.Threading.Tasks;
using DotNetBungieAPI.Models;
using DotNetBungieAPI.Models.FireteamFinder;
using DotNetBungieAPI.Service.Abstractions;
using DotNetBungieAPI.Service.Abstractions.ApiAccess;

namespace DotNetBungieAPI.Services.ApiAccess;

internal sealed class FireteamFinderMethodsAccess : IFireteamFinderMethodsAccess
{
    private readonly IDotNetBungieApiHttpClient _dotNetBungieApiHttpClient;
    private readonly IBungieNetJsonSerializer _serializer;

    public FireteamFinderMethodsAccess(
        IDotNetBungieApiHttpClient dotNetBungieApiHttpClient,
        IBungieNetJsonSerializer serializer
    )
    {
        _dotNetBungieApiHttpClient = dotNetBungieApiHttpClient;
        _serializer = serializer;
    }

    public async Task<BungieResponse<bool>> ActivateLobby(
        long destinyCharacterId,
        long destinyMembershipId,
        BungieMembershipType destinyMembershipType,
        long lobbyId,
        bool? forceActivation = null,
        CancellationToken cancellationToken = default
    )
    {
        var url = StringBuilderPool
            .GetBuilder(cancellationToken)
            .Append("/FireteamFinder/Lobby/Activate/")
            .AddUrlParam(lobbyId.ToString())
            .AddUrlParam(((int)destinyMembershipType).ToString())
            .AddUrlParam(destinyMembershipId.ToString())
            .AddUrlParam(destinyCharacterId.ToString())
            .Build();

        return await _dotNetBungieApiHttpClient
            .PostToBungieNetPlatform<bool>(url, cancellationToken)
            .ConfigureAwait(false);
    }

    public async Task<BungieResponse<bool>> ActivateLobbyForNewListingId(
        long destinyCharacterId,
        long destinyMembershipId,
        BungieMembershipType destinyMembershipType,
        long lobbyId,
        bool? forceActivation = null,
        CancellationToken cancellationToken = default
    )
    {
        var url = StringBuilderPool
            .GetBuilder(cancellationToken)
            .Append("/FireteamFinder/Lobby/ActivateForNewListingId/")
            .AddUrlParam(lobbyId.ToString())
            .AddUrlParam(((int)destinyMembershipType).ToString())
            .AddUrlParam(destinyMembershipId.ToString())
            .AddUrlParam(destinyCharacterId.ToString())
            .Build();

        return await _dotNetBungieApiHttpClient
            .PostToBungieNetPlatform<bool>(url, cancellationToken)
            .ConfigureAwait(false);
    }

    public async Task<BungieResponse<DestinyFireteamFinderApplyToListingResponse>> ApplyToListing(
        DestinyFireteamFinderApplicationType applicationType,
        long destinyCharacterId,
        long destinyMembershipId,
        BungieMembershipType destinyMembershipType,
        long listingId,
        CancellationToken cancellationToken = default
    )
    {
        var url = StringBuilderPool
            .GetBuilder(cancellationToken)
            .Append("/FireteamFinder/Listing/")
            .AddUrlParam(listingId.ToString())
            .Append("Apply/")
            .AddUrlParam(((int)applicationType).ToString())
            .AddUrlParam(((int)destinyMembershipType).ToString())
            .AddUrlParam(destinyMembershipId.ToString())
            .AddUrlParam(destinyCharacterId.ToString())
            .Build();

        return await _dotNetBungieApiHttpClient
            .PostToBungieNetPlatform<DestinyFireteamFinderApplyToListingResponse>(
                url,
                cancellationToken
            )
            .ConfigureAwait(false);
    }

    public async Task<
        BungieResponse<DestinyFireteamFinderBulkGetListingStatusResponse>
    > BulkGetListingStatus(
        long destinyCharacterId,
        long destinyMembershipId,
        BungieMembershipType destinyMembershipType,
        DestinyFireteamFinderBulkGetListingStatusRequest body,
        CancellationToken cancellationToken = default
    )
    {
        var url = StringBuilderPool
            .GetBuilder(cancellationToken)
            .Append("/FireteamFinder/Listing/BulkStatus/")
            .AddUrlParam(((int)destinyMembershipType).ToString())
            .AddUrlParam(destinyMembershipId.ToString())
            .AddUrlParam(destinyCharacterId.ToString())
            .Build();

        var stream = new MemoryStream();
        await _serializer.SerializeAsync(stream, body).ConfigureAwait(false);
        stream.Position = 0;

        return await _dotNetBungieApiHttpClient
            .PostToBungieNetPlatform<DestinyFireteamFinderBulkGetListingStatusResponse>(
                url,
                cancellationToken,
                content: stream
            )
            .ConfigureAwait(false);
    }

    public async Task<BungieResponse<DestinyFireteamFinderGetApplicationResponse>> GetApplication(
        long applicationId,
        long destinyCharacterId,
        long destinyMembershipId,
        BungieMembershipType destinyMembershipType,
        CancellationToken cancellationToken = default
    )
    {
        var url = StringBuilderPool
            .GetBuilder(cancellationToken)
            .Append("/FireteamFinder/Application/")
            .AddUrlParam(applicationId.ToString())
            .AddUrlParam(((int)destinyMembershipType).ToString())
            .AddUrlParam(destinyMembershipId.ToString())
            .AddUrlParam(destinyCharacterId.ToString())
            .Build();

        return await _dotNetBungieApiHttpClient
            .GetFromBungieNetPlatform<DestinyFireteamFinderGetApplicationResponse>(
                url,
                cancellationToken
            )
            .ConfigureAwait(false);
    }

    public async Task<BungieResponse<DestinyFireteamFinderListing>> GetListing(
        long listingId,
        CancellationToken cancellationToken = default
    )
    {
        var url = StringBuilderPool
            .GetBuilder(cancellationToken)
            .Append("/FireteamFinder/Listing/")
            .AddUrlParam(listingId.ToString())
            .Build();

        return await _dotNetBungieApiHttpClient
            .GetFromBungieNetPlatform<DestinyFireteamFinderListing>(url, cancellationToken)
            .ConfigureAwait(false);
    }

    public async Task<
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
    )
    {
        var url = StringBuilderPool
            .GetBuilder(cancellationToken)
            .Append("/FireteamFinder/Listing/")
            .AddUrlParam(listingId.ToString())
            .AddUrlParam(((int)destinyMembershipType).ToString())
            .AddUrlParam(destinyMembershipId.ToString())
            .AddUrlParam(destinyCharacterId.ToString())
            .AddQueryParam(nameof(pageSize), pageSize.ToString())
            .AddQueryParam(
                nameof(nextPageToken),
                nextPageToken,
                () => !string.IsNullOrWhiteSpace(nextPageToken)
            )
            .AddQueryParam(nameof(flags), flags.ToString(), () => flags > 0)
            .Build();

        return await _dotNetBungieApiHttpClient
            .GetFromBungieNetPlatform<DestinyFireteamFinderGetListingApplicationsResponse>(
                url,
                cancellationToken
            )
            .ConfigureAwait(false);
    }

    public async Task<BungieResponse<DestinyFireteamFinderLobbyResponse>> GetLobby(
        long destinyCharacterId,
        long destinyMembershipId,
        BungieMembershipType destinyMembershipType,
        long lobbyId,
        CancellationToken cancellationToken = default
    )
    {
        var url = StringBuilderPool
            .GetBuilder(cancellationToken)
            .Append("/FireteamFinder/Lobby/")
            .AddUrlParam(lobbyId.ToString())
            .AddUrlParam(((int)destinyMembershipType).ToString())
            .AddUrlParam(destinyMembershipId.ToString())
            .AddUrlParam(destinyCharacterId.ToString())
            .Build();

        return await _dotNetBungieApiHttpClient
            .GetFromBungieNetPlatform<DestinyFireteamFinderLobbyResponse>(url, cancellationToken)
            .ConfigureAwait(false);
    }

    public async Task<BungieResponse<DestinyFireteamFinderGetLobbyOffersResponse>> GetLobbyOffers(
        long destinyCharacterId,
        long destinyMembershipId,
        BungieMembershipType destinyMembershipType,
        long lobbyId,
        int pageSize,
        string? nextPageToken = null,
        CancellationToken cancellationToken = default
    )
    {
        var url = StringBuilderPool
            .GetBuilder(cancellationToken)
            .Append("/FireteamFinder/Lobby/")
            .AddUrlParam(lobbyId.ToString())
            .Append("Offers/")
            .AddUrlParam(((int)destinyMembershipType).ToString())
            .AddUrlParam(destinyMembershipId.ToString())
            .AddUrlParam(destinyCharacterId.ToString())
            .Build();

        return await _dotNetBungieApiHttpClient
            .GetFromBungieNetPlatform<DestinyFireteamFinderGetLobbyOffersResponse>(
                url,
                cancellationToken
            )
            .ConfigureAwait(false);
    }

    public async Task<BungieResponse<DestinyFireteamFinderOffer>> GetOffer(
        long destinyCharacterId,
        long destinyMembershipId,
        BungieMembershipType destinyMembershipType,
        long offerId,
        CancellationToken cancellationToken = default
    )
    {
        var url = StringBuilderPool
            .GetBuilder(cancellationToken)
            .Append("/FireteamFinder/Offer/")
            .AddUrlParam(offerId.ToString())
            .AddUrlParam(((int)destinyMembershipType).ToString())
            .AddUrlParam(destinyMembershipId.ToString())
            .AddUrlParam(destinyCharacterId.ToString())
            .Build();

        return await _dotNetBungieApiHttpClient
            .GetFromBungieNetPlatform<DestinyFireteamFinderOffer>(url, cancellationToken)
            .ConfigureAwait(false);
    }

    public async Task<
        BungieResponse<DestinyFireteamFinderGetPlayerApplicationsResponse>
    > GetPlayerApplications(
        long destinyCharacterId,
        long destinyMembershipId,
        BungieMembershipType destinyMembershipType,
        int pageSize,
        string? nextPageToken = null,
        CancellationToken cancellationToken = default
    )
    {
        var url = StringBuilderPool
            .GetBuilder(cancellationToken)
            .Append("/FireteamFinder/PlayerApplications/")
            .AddUrlParam(((int)destinyMembershipType).ToString())
            .AddUrlParam(destinyMembershipId.ToString())
            .AddUrlParam(destinyCharacterId.ToString())
            .Build();

        return await _dotNetBungieApiHttpClient
            .GetFromBungieNetPlatform<DestinyFireteamFinderGetPlayerApplicationsResponse>(
                url,
                cancellationToken
            )
            .ConfigureAwait(false);
    }

    public async Task<
        BungieResponse<DestinyFireteamFinderGetPlayerLobbiesResponse>
    > GetPlayerLobbies(
        long destinyCharacterId,
        long destinyMembershipId,
        BungieMembershipType destinyMembershipType,
        int pageSize,
        string? nextPageToken = null,
        CancellationToken cancellationToken = default
    )
    {
        var url = StringBuilderPool
            .GetBuilder(cancellationToken)
            .Append("/FireteamFinder/PlayerLobbies/")
            .AddUrlParam(((int)destinyMembershipType).ToString())
            .AddUrlParam(destinyMembershipId.ToString())
            .AddUrlParam(destinyCharacterId.ToString())
            .Build();

        return await _dotNetBungieApiHttpClient
            .GetFromBungieNetPlatform<DestinyFireteamFinderGetPlayerLobbiesResponse>(
                url,
                cancellationToken
            )
            .ConfigureAwait(false);
    }

    public async Task<BungieResponse<DestinyFireteamFinderGetPlayerOffersResponse>> GetPlayerOffers(
        long destinyCharacterId,
        long destinyMembershipId,
        BungieMembershipType destinyMembershipType,
        int pageSize,
        string? nextPageToken = null,
        CancellationToken cancellationToken = default
    )
    {
        var url = StringBuilderPool
            .GetBuilder(cancellationToken)
            .Append("/FireteamFinder/PlayerOffers/")
            .AddUrlParam(((int)destinyMembershipType).ToString())
            .AddUrlParam(destinyMembershipId.ToString())
            .AddUrlParam(destinyCharacterId.ToString())
            .Build();

        return await _dotNetBungieApiHttpClient
            .GetFromBungieNetPlatform<DestinyFireteamFinderGetPlayerOffersResponse>(
                url,
                cancellationToken
            )
            .ConfigureAwait(false);
    }

    public async Task<
        BungieResponse<DestinyFireteamFinderGetCharacterActivityAccessResponse>
    > GetCharacterActivityAccess(
        long destinyCharacterId,
        long destinyMembershipId,
        BungieMembershipType destinyMembershipType,
        CancellationToken cancellationToken = default
    )
    {
        var url = StringBuilderPool
            .GetBuilder(cancellationToken)
            .Append("/FireteamFinder/CharacterActivityAccess/")
            .AddUrlParam(((int)destinyMembershipType).ToString())
            .AddUrlParam(destinyMembershipId.ToString())
            .AddUrlParam(destinyCharacterId.ToString())
            .Build();

        return await _dotNetBungieApiHttpClient
            .GetFromBungieNetPlatform<DestinyFireteamFinderGetCharacterActivityAccessResponse>(
                url,
                cancellationToken
            )
            .ConfigureAwait(false);
    }

    public async Task<BungieResponse<DestinyFireteamFinderHostLobbyResponse>> HostLobby(
        long destinyCharacterId,
        long destinyMembershipId,
        BungieMembershipType destinyMembershipType,
        DestinyFireteamFinderLobbySettings body,
        CancellationToken cancellationToken = default
    )
    {
        var url = StringBuilderPool
            .GetBuilder(cancellationToken)
            .Append("/FireteamFinder/Lobby/Host/")
            .AddUrlParam(((int)destinyMembershipType).ToString())
            .AddUrlParam(destinyMembershipId.ToString())
            .AddUrlParam(destinyCharacterId.ToString())
            .Build();

        var stream = new MemoryStream();
        await _serializer.SerializeAsync(stream, body).ConfigureAwait(false);
        stream.Position = 0;
        return await _dotNetBungieApiHttpClient
            .PostToBungieNetPlatform<DestinyFireteamFinderHostLobbyResponse>(
                url,
                cancellationToken,
                stream
            )
            .ConfigureAwait(false);
    }

    public async Task<BungieResponse<DestinyFireteamFinderLobbyResponse>> JoinLobby(
        long destinyCharacterId,
        long destinyMembershipId,
        BungieMembershipType destinyMembershipType,
        DestinyFireteamFinderJoinLobbyRequest body,
        CancellationToken cancellationToken = default
    )
    {
        var url = StringBuilderPool
            .GetBuilder(cancellationToken)
            .Append("/FireteamFinder/Lobby/Join/")
            .AddUrlParam(((int)destinyMembershipType).ToString())
            .AddUrlParam(destinyMembershipId.ToString())
            .AddUrlParam(destinyCharacterId.ToString())
            .Build();

        var stream = new MemoryStream();
        await _serializer.SerializeAsync(stream, body).ConfigureAwait(false);
        stream.Position = 0;
        return await _dotNetBungieApiHttpClient
            .PostToBungieNetPlatform<DestinyFireteamFinderLobbyResponse>(
                url,
                cancellationToken,
                stream
            )
            .ConfigureAwait(false);
    }

    public async Task<BungieResponse<bool>> KickPlayer(
        long destinyCharacterId,
        long destinyMembershipId,
        BungieMembershipType destinyMembershipType,
        long lobbyId,
        long targetMembershipId,
        DestinyFireteamFinderKickPlayerRequest body,
        CancellationToken cancellationToken = default
    )
    {
        var url = StringBuilderPool
            .GetBuilder(cancellationToken)
            .Append("/FireteamFinder/Lobby/")
            .AddUrlParam(lobbyId.ToString())
            .Append("KickPlayer/")
            .AddUrlParam(targetMembershipId.ToString())
            .AddUrlParam(((int)destinyMembershipType).ToString())
            .AddUrlParam(destinyMembershipId.ToString())
            .AddUrlParam(destinyCharacterId.ToString())
            .Build();

        var stream = new MemoryStream();
        await _serializer.SerializeAsync(stream, body).ConfigureAwait(false);
        stream.Position = 0;
        return await _dotNetBungieApiHttpClient
            .PostToBungieNetPlatform<bool>(url, cancellationToken, stream)
            .ConfigureAwait(false);
    }

    public async Task<BungieResponse<bool>> LeaveApplication(
        long applicationId,
        long destinyCharacterId,
        long destinyMembershipId,
        BungieMembershipType destinyMembershipType,
        CancellationToken cancellationToken = default
    )
    {
        var url = StringBuilderPool
            .GetBuilder(cancellationToken)
            .Append("/FireteamFinder/Application/Leave/")
            .AddUrlParam(applicationId.ToString())
            .AddUrlParam(((int)destinyMembershipType).ToString())
            .AddUrlParam(destinyMembershipId.ToString())
            .AddUrlParam(destinyCharacterId.ToString())
            .Build();

        return await _dotNetBungieApiHttpClient
            .PostToBungieNetPlatform<bool>(url, cancellationToken)
            .ConfigureAwait(false);
    }

    public async Task<BungieResponse<bool>> LeaveLobby(
        long destinyCharacterId,
        long destinyMembershipId,
        BungieMembershipType destinyMembershipType,
        long lobbyId,
        CancellationToken cancellationToken = default
    )
    {
        var url = StringBuilderPool
            .GetBuilder(cancellationToken)
            .Append("/FireteamFinder/Lobby/Leave/")
            .AddUrlParam(lobbyId.ToString())
            .AddUrlParam(((int)destinyMembershipType).ToString())
            .AddUrlParam(destinyMembershipId.ToString())
            .AddUrlParam(destinyCharacterId.ToString())
            .Build();

        return await _dotNetBungieApiHttpClient
            .PostToBungieNetPlatform<bool>(url, cancellationToken)
            .ConfigureAwait(false);
    }

    public async Task<
        BungieResponse<DestinyFireteamFinderRespondToApplicationResponse>
    > RespondToApplication(
        long applicationId,
        long destinyCharacterId,
        long destinyMembershipId,
        BungieMembershipType destinyMembershipType,
        DestinyFireteamFinderRespondToApplicationRequest body,
        CancellationToken cancellationToken = default
    )
    {
        var url = StringBuilderPool
            .GetBuilder(cancellationToken)
            .Append("/FireteamFinder/Application/Respond/")
            .AddUrlParam(applicationId.ToString())
            .AddUrlParam(((int)destinyMembershipType).ToString())
            .AddUrlParam(destinyMembershipId.ToString())
            .AddUrlParam(destinyCharacterId.ToString())
            .Build();

        var stream = new MemoryStream();
        await _serializer.SerializeAsync(stream, body).ConfigureAwait(false);
        stream.Position = 0;
        return await _dotNetBungieApiHttpClient
            .PostToBungieNetPlatform<DestinyFireteamFinderRespondToApplicationResponse>(
                url,
                cancellationToken,
                stream
            )
            .ConfigureAwait(false);
    }

    public async Task<
        BungieResponse<DestinyFireteamFinderRespondToAuthenticationResponse>
    > RespondToAuthentication(
        long applicationId,
        long destinyCharacterId,
        long destinyMembershipId,
        BungieMembershipType destinyMembershipType,
        DestinyFireteamFinderRespondToAuthenticationRequest body,
        CancellationToken cancellationToken = default
    )
    {
        var url = StringBuilderPool
            .GetBuilder(cancellationToken)
            .Append("/FireteamFinder/Authentication/Respond/")
            .AddUrlParam(applicationId.ToString())
            .AddUrlParam(((int)destinyMembershipType).ToString())
            .AddUrlParam(destinyMembershipId.ToString())
            .AddUrlParam(destinyCharacterId.ToString())
            .Build();

        var stream = new MemoryStream();
        await _serializer.SerializeAsync(stream, body).ConfigureAwait(false);
        stream.Position = 0;
        return await _dotNetBungieApiHttpClient
            .PostToBungieNetPlatform<DestinyFireteamFinderRespondToAuthenticationResponse>(
                url,
                cancellationToken,
                stream
            )
            .ConfigureAwait(false);
    }

    public async Task<BungieResponse<DestinyFireteamFinderRespondToOfferResponse>> RespondToOffer(
        long destinyCharacterId,
        long destinyMembershipId,
        BungieMembershipType destinyMembershipType,
        long offerId,
        DestinyFireteamFinderRespondToOfferRequest body,
        CancellationToken cancellationToken = default
    )
    {
        var url = StringBuilderPool
            .GetBuilder(cancellationToken)
            .Append("/FireteamFinder/Offer/Respond/")
            .AddUrlParam(offerId.ToString())
            .AddUrlParam(((int)destinyMembershipType).ToString())
            .AddUrlParam(destinyMembershipId.ToString())
            .AddUrlParam(destinyCharacterId.ToString())
            .Build();

        var stream = new MemoryStream();
        await _serializer.SerializeAsync(stream, body).ConfigureAwait(false);
        stream.Position = 0;
        return await _dotNetBungieApiHttpClient
            .PostToBungieNetPlatform<DestinyFireteamFinderRespondToOfferResponse>(
                url,
                cancellationToken,
                stream
            )
            .ConfigureAwait(false);
    }

    public async Task<
        BungieResponse<DestinyFireteamFinderSearchListingsByClanResponse>
    > SearchListingsByClan(
        long destinyCharacterId,
        long destinyMembershipId,
        BungieMembershipType destinyMembershipType,
        DestinyFireteamFinderSearchListingsByClanRequest body,
        CancellationToken cancellationToken = default
    )
    {
        var url = StringBuilderPool
            .GetBuilder(cancellationToken)
            .Append("/FireteamFinder/Search/Clan/")
            .AddUrlParam(((int)destinyMembershipType).ToString())
            .AddUrlParam(destinyMembershipId.ToString())
            .AddUrlParam(destinyCharacterId.ToString())
            .Build();

        var stream = new MemoryStream();
        await _serializer.SerializeAsync(stream, body).ConfigureAwait(false);
        stream.Position = 0;
        return await _dotNetBungieApiHttpClient
            .PostToBungieNetPlatform<DestinyFireteamFinderSearchListingsByClanResponse>(
                url,
                cancellationToken,
                stream
            )
            .ConfigureAwait(false);
    }

    public async Task<
        BungieResponse<DestinyFireteamFinderSearchListingsByFiltersResponse>
    > SearchListingsByFilters(
        long destinyCharacterId,
        long destinyMembershipId,
        BungieMembershipType destinyMembershipType,
        DestinyFireteamFinderSearchListingsByFiltersRequest body,
        CancellationToken cancellationToken = default
    )
    {
        var url = StringBuilderPool
            .GetBuilder(cancellationToken)
            .Append("/FireteamFinder/Search/")
            .AddUrlParam(((int)destinyMembershipType).ToString())
            .AddUrlParam(destinyMembershipId.ToString())
            .AddUrlParam(destinyCharacterId.ToString())
            .Build();

        var stream = new MemoryStream();
        await _serializer.SerializeAsync(stream, body).ConfigureAwait(false);
        stream.Position = 0;
        return await _dotNetBungieApiHttpClient
            .PostToBungieNetPlatform<DestinyFireteamFinderSearchListingsByFiltersResponse>(
                url,
                cancellationToken,
                stream
            )
            .ConfigureAwait(false);
    }

    public async Task<
        BungieResponse<DestinyFireteamFinderUpdateLobbySettingsResponse>
    > UpdateLobbySettings(
        long destinyCharacterId,
        long destinyMembershipId,
        BungieMembershipType destinyMembershipType,
        long lobbyId,
        DestinyFireteamFinderUpdateLobbySettingsRequest body,
        CancellationToken cancellationToken = default
    )
    {
        var url = StringBuilderPool
            .GetBuilder(cancellationToken)
            .Append("/FireteamFinder/Lobby/UpdateSettings/")
            .AddUrlParam(lobbyId.ToString())
            .AddUrlParam(((int)destinyMembershipType).ToString())
            .AddUrlParam(destinyMembershipId.ToString())
            .AddUrlParam(destinyCharacterId.ToString())
            .Build();

        var stream = new MemoryStream();
        await _serializer.SerializeAsync(stream, body).ConfigureAwait(false);
        stream.Position = 0;
        return await _dotNetBungieApiHttpClient
            .PostToBungieNetPlatform<DestinyFireteamFinderUpdateLobbySettingsResponse>(
                url,
                cancellationToken,
                stream
            )
            .ConfigureAwait(false);
    }
}
