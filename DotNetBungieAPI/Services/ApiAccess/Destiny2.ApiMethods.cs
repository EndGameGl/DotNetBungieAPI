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

internal sealed class Destiny2Api : IDestiny2Api
{
    private readonly IBungieClientConfiguration _configuration;
    private readonly IDotNetBungieApiHttpClient _dotNetBungieApiHttpClient;
    private readonly IBungieNetJsonSerializer _serializer;

    public Destiny2Api(
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
    ///     Returns the current version of the manifest as a json object.
    /// </summary>
    /// <param name="cancellationToken">Method cancellation token</param>
    public async Task<BungieResponse<Models.Destiny.Config.DestinyManifest>> GetDestinyManifest(CancellationToken cancellationToken = default)
    {
        return await _dotNetBungieApiHttpClient.GetFromBungieNetPlatform<Models.Destiny.Config.DestinyManifest>("/Destiny2/Manifest/", cancellationToken);
    }

    /// <summary>
    ///     Returns the static definition of an entity of the given Type and hash identifier. Examine the API Documentation for the Type Names of entities that have their own definitions. Note that the return type will always *inherit from* DestinyDefinition, but the specific type returned will be the requested entity type if it can be found. Please don't use this as a chatty alternative to the Manifest database if you require large sets of data, but for simple and one-off accesses this should be handy.
    /// </summary>
    /// <param name="entityType">The type of entity for whom you would like results. These correspond to the entity's definition contract name. For instance, if you are looking for items, this property should be 'DestinyInventoryItemDefinition'. PREVIEW: This endpoint is still in beta, and may experience rough edges. The schema is tentatively in final form, but there may be bugs that prevent desirable operation.</param>
    /// <param name="hashIdentifier">The hash identifier for the specific Entity you want returned.</param>
    /// <param name="cancellationToken">Method cancellation token</param>
    public async Task<BungieResponse<Models.Destiny.Definitions.DestinyDefinition>> GetDestinyEntityDefinition(
        string entityType,
        uint hashIdentifier,
        CancellationToken cancellationToken = default
    )
    {
        var url = StringBuilderPool
            .GetBuilder(cancellationToken)
            .Append($"/Destiny2/Manifest/{entityType}/{hashIdentifier}/")
            .Build();
        return await _dotNetBungieApiHttpClient.GetFromBungieNetPlatform<Models.Destiny.Definitions.DestinyDefinition>(url, cancellationToken);
    }

    /// <summary>
    ///     Returns a list of Destiny memberships given a global Bungie Display Name. This method will hide overridden memberships due to cross save.
    /// </summary>
    /// <param name="membershipType">A valid non-BungieNet membership type, or All. Indicates which memberships to return. You probably want this set to All.</param>
    /// <param name="requestBody">Request body</param>
    /// <param name="cancellationToken">Method cancellation token</param>
    public async Task<BungieResponse<Models.User.UserInfoCard[]>> SearchDestinyPlayerByBungieName(
        Models.BungieMembershipType membershipType,
        Models.User.ExactSearchRequest requestBody,
        CancellationToken cancellationToken = default
    )
    {
        var url = StringBuilderPool
            .GetBuilder(cancellationToken)
            .Append($"/Destiny2/SearchDestinyPlayerByBungieName/{membershipType}/")
            .Build();
        var stream = new MemoryStream();
        await _serializer.SerializeAsync(stream, requestBody);
        stream.Position = 0;

        return await _dotNetBungieApiHttpClient.PostToBungieNetPlatform<Models.User.UserInfoCard[]>(url, cancellationToken, content: stream);
    }

    /// <summary>
    ///     Returns a summary information about all profiles linked to the requesting membership type/membership ID that have valid Destiny information. The passed-in Membership Type/Membership ID may be a Bungie.Net membership or a Destiny membership. It only returns the minimal amount of data to begin making more substantive requests, but will hopefully serve as a useful alternative to UserServices for people who just care about Destiny data. Note that it will only return linked accounts whose linkages you are allowed to view.
    /// </summary>
    /// <param name="getAllMemberships">(optional) if set to 'true', all memberships regardless of whether they're obscured by overrides will be returned. Normal privacy restrictions on account linking will still apply no matter what.</param>
    /// <param name="membershipId">The ID of the membership whose linked Destiny accounts you want returned. Make sure your membership ID matches its Membership Type: don't pass us a PSN membership ID and the XBox membership type, it's not going to work!</param>
    /// <param name="membershipType">The type for the membership whose linked Destiny accounts you want returned.</param>
    /// <param name="cancellationToken">Method cancellation token</param>
    public async Task<BungieResponse<Models.Destiny.Responses.DestinyLinkedProfilesResponse>> GetLinkedProfiles(
        long membershipId,
        Models.BungieMembershipType membershipType,
        bool getAllMemberships,
        CancellationToken cancellationToken = default
    )
    {
        var url = StringBuilderPool
            .GetBuilder(cancellationToken)
            .Append($"/Destiny2/{membershipType}/Profile/{membershipId}/LinkedProfiles/")
            .AddQueryParam("getAllMemberships", getAllMemberships)
            .Build();
        return await _dotNetBungieApiHttpClient.GetFromBungieNetPlatform<Models.Destiny.Responses.DestinyLinkedProfilesResponse>(url, cancellationToken);
    }

    /// <summary>
    ///     Returns Destiny Profile information for the supplied membership.
    /// </summary>
    /// <param name="components">A comma separated list of components to return (as strings or numeric values). See the DestinyComponentType enum for valid components to request. You must request at least one component to receive results.</param>
    /// <param name="destinyMembershipId">Destiny membership ID.</param>
    /// <param name="membershipType">A valid non-BungieNet membership type.</param>
    /// <param name="cancellationToken">Method cancellation token</param>
    public async Task<BungieResponse<Models.Destiny.Responses.DestinyProfileResponse>> GetProfile(
        long destinyMembershipId,
        Models.BungieMembershipType membershipType,
        Models.Destiny.DestinyComponentType[] components,
        CancellationToken cancellationToken = default
    )
    {
        var url = StringBuilderPool
            .GetBuilder(cancellationToken)
            .Append($"/Destiny2/{membershipType}/Profile/{destinyMembershipId}/")
            .AddQueryParam("components", components)
            .Build();
        return await _dotNetBungieApiHttpClient.GetFromBungieNetPlatform<Models.Destiny.Responses.DestinyProfileResponse>(url, cancellationToken);
    }

    /// <summary>
    ///     Returns character information for the supplied character.
    /// </summary>
    /// <param name="characterId">ID of the character.</param>
    /// <param name="components">A comma separated list of components to return (as strings or numeric values). See the DestinyComponentType enum for valid components to request. You must request at least one component to receive results.</param>
    /// <param name="destinyMembershipId">Destiny membership ID.</param>
    /// <param name="membershipType">A valid non-BungieNet membership type.</param>
    /// <param name="cancellationToken">Method cancellation token</param>
    public async Task<BungieResponse<Models.Destiny.Responses.DestinyCharacterResponse>> GetCharacter(
        long characterId,
        long destinyMembershipId,
        Models.BungieMembershipType membershipType,
        Models.Destiny.DestinyComponentType[] components,
        CancellationToken cancellationToken = default
    )
    {
        var url = StringBuilderPool
            .GetBuilder(cancellationToken)
            .Append($"/Destiny2/{membershipType}/Profile/{destinyMembershipId}/Character/{characterId}/")
            .AddQueryParam("components", components)
            .Build();
        return await _dotNetBungieApiHttpClient.GetFromBungieNetPlatform<Models.Destiny.Responses.DestinyCharacterResponse>(url, cancellationToken);
    }

    /// <summary>
    ///     Returns information on the weekly clan rewards and if the clan has earned them or not. Note that this will always report rewards as not redeemed.
    /// </summary>
    /// <param name="groupId">A valid group id of clan.</param>
    /// <param name="cancellationToken">Method cancellation token</param>
    public async Task<BungieResponse<Models.Destiny.Milestones.DestinyMilestone>> GetClanWeeklyRewardState(
        long groupId,
        CancellationToken cancellationToken = default
    )
    {
        var url = StringBuilderPool
            .GetBuilder(cancellationToken)
            .Append($"/Destiny2/Clan/{groupId}/WeeklyRewardState/")
            .Build();
        return await _dotNetBungieApiHttpClient.GetFromBungieNetPlatform<Models.Destiny.Milestones.DestinyMilestone>(url, cancellationToken);
    }

    /// <summary>
    ///     Returns the dictionary of values for the Clan Banner
    /// </summary>
    /// <param name="cancellationToken">Method cancellation token</param>
    public async Task<BungieResponse<Models.Config.ClanBanner.ClanBannerSource>> GetClanBannerSource(CancellationToken cancellationToken = default)
    {
        return await _dotNetBungieApiHttpClient.GetFromBungieNetPlatform<Models.Config.ClanBanner.ClanBannerSource>("/Destiny2/Clan/ClanBannerDictionary/", cancellationToken);
    }

    /// <summary>
    ///     Retrieve the details of an instanced Destiny Item. An instanced Destiny item is one with an ItemInstanceId. Non-instanced items, such as materials, have no useful instance-specific details and thus are not queryable here.
    /// </summary>
    /// <param name="components">A comma separated list of components to return (as strings or numeric values). See the DestinyComponentType enum for valid components to request. You must request at least one component to receive results.</param>
    /// <param name="destinyMembershipId">The membership ID of the destiny profile.</param>
    /// <param name="itemInstanceId">The Instance ID of the destiny item.</param>
    /// <param name="membershipType">A valid non-BungieNet membership type.</param>
    /// <param name="cancellationToken">Method cancellation token</param>
    public async Task<BungieResponse<Models.Destiny.Responses.DestinyItemResponse>> GetItem(
        long destinyMembershipId,
        long itemInstanceId,
        Models.BungieMembershipType membershipType,
        Models.Destiny.DestinyComponentType[] components,
        CancellationToken cancellationToken = default
    )
    {
        var url = StringBuilderPool
            .GetBuilder(cancellationToken)
            .Append($"/Destiny2/{membershipType}/Profile/{destinyMembershipId}/Item/{itemInstanceId}/")
            .AddQueryParam("components", components)
            .Build();
        return await _dotNetBungieApiHttpClient.GetFromBungieNetPlatform<Models.Destiny.Responses.DestinyItemResponse>(url, cancellationToken);
    }

    /// <summary>
    ///     Get currently available vendors from the list of vendors that can possibly have rotating inventory. Note that this does not include things like preview vendors and vendors-as-kiosks, neither of whom have rotating/dynamic inventories. Use their definitions as-is for those.
    /// </summary>
    /// <param name="characterId">The Destiny Character ID of the character for whom we're getting vendor info.</param>
    /// <param name="components">A comma separated list of components to return (as strings or numeric values). See the DestinyComponentType enum for valid components to request. You must request at least one component to receive results.</param>
    /// <param name="destinyMembershipId">Destiny membership ID of another user. You may be denied.</param>
    /// <param name="filter">The filter of what vendors and items to return, if any.</param>
    /// <param name="membershipType">A valid non-BungieNet membership type.</param>
    /// <param name="cancellationToken">Method cancellation token</param>
    public async Task<BungieResponse<Models.Destiny.Responses.DestinyVendorsResponse>> GetVendors(
        long characterId,
        long destinyMembershipId,
        Models.BungieMembershipType membershipType,
        Models.Destiny.DestinyComponentType[] components,
        Models.Destiny.DestinyVendorFilter filter,
        CancellationToken cancellationToken = default
    )
    {
        var url = StringBuilderPool
            .GetBuilder(cancellationToken)
            .Append($"/Destiny2/{membershipType}/Profile/{destinyMembershipId}/Character/{characterId}/Vendors/")
            .AddQueryParam("components", components)
            .AddQueryParam("filter", (int)filter)
            .Build();
        return await _dotNetBungieApiHttpClient.GetFromBungieNetPlatform<Models.Destiny.Responses.DestinyVendorsResponse>(url, cancellationToken);
    }

    /// <summary>
    ///     Get the details of a specific Vendor.
    /// </summary>
    /// <param name="characterId">The Destiny Character ID of the character for whom we're getting vendor info.</param>
    /// <param name="components">A comma separated list of components to return (as strings or numeric values). See the DestinyComponentType enum for valid components to request. You must request at least one component to receive results.</param>
    /// <param name="destinyMembershipId">Destiny membership ID of another user. You may be denied.</param>
    /// <param name="membershipType">A valid non-BungieNet membership type.</param>
    /// <param name="vendorHash">The Hash identifier of the Vendor to be returned.</param>
    /// <param name="cancellationToken">Method cancellation token</param>
    public async Task<BungieResponse<Models.Destiny.Responses.DestinyVendorResponse>> GetVendor(
        long characterId,
        long destinyMembershipId,
        Models.BungieMembershipType membershipType,
        uint vendorHash,
        Models.Destiny.DestinyComponentType[] components,
        CancellationToken cancellationToken = default
    )
    {
        var url = StringBuilderPool
            .GetBuilder(cancellationToken)
            .Append($"/Destiny2/{membershipType}/Profile/{destinyMembershipId}/Character/{characterId}/Vendors/{vendorHash}/")
            .AddQueryParam("components", components)
            .Build();
        return await _dotNetBungieApiHttpClient.GetFromBungieNetPlatform<Models.Destiny.Responses.DestinyVendorResponse>(url, cancellationToken);
    }

    /// <summary>
    ///     Get items available from vendors where the vendors have items for sale that are common for everyone. If any portion of the Vendor's available inventory is character or account specific, we will be unable to return their data from this endpoint due to the way that available inventory is computed. As I am often guilty of saying: 'It's a long story...'
    /// </summary>
    /// <param name="components">A comma separated list of components to return (as strings or numeric values). See the DestinyComponentType enum for valid components to request. You must request at least one component to receive results.</param>
    /// <param name="cancellationToken">Method cancellation token</param>
    public async Task<BungieResponse<Models.Destiny.Responses.DestinyPublicVendorsResponse>> GetPublicVendors(
        Models.Destiny.DestinyComponentType[] components,
        CancellationToken cancellationToken = default
    )
    {
        var url = StringBuilderPool
            .GetBuilder(cancellationToken)
            .AddQueryParam("components", components)
            .Build();
        return await _dotNetBungieApiHttpClient.GetFromBungieNetPlatform<Models.Destiny.Responses.DestinyPublicVendorsResponse>(url, cancellationToken);
    }

    /// <summary>
    ///     Given a Presentation Node that has Collectibles as direct descendants, this will return item details about those descendants in the context of the requesting character.
    /// </summary>
    /// <param name="characterId">The Destiny Character ID of the character for whom we're getting collectible detail info.</param>
    /// <param name="collectiblePresentationNodeHash">The hash identifier of the Presentation Node for whom we should return collectible details. Details will only be returned for collectibles that are direct descendants of this node.</param>
    /// <param name="components">A comma separated list of components to return (as strings or numeric values). See the DestinyComponentType enum for valid components to request. You must request at least one component to receive results.</param>
    /// <param name="destinyMembershipId">Destiny membership ID of another user. You may be denied.</param>
    /// <param name="membershipType">A valid non-BungieNet membership type.</param>
    /// <param name="cancellationToken">Method cancellation token</param>
    public async Task<BungieResponse<Models.Destiny.Responses.DestinyCollectibleNodeDetailResponse>> GetCollectibleNodeDetails(
        long characterId,
        uint collectiblePresentationNodeHash,
        long destinyMembershipId,
        Models.BungieMembershipType membershipType,
        Models.Destiny.DestinyComponentType[] components,
        CancellationToken cancellationToken = default
    )
    {
        var url = StringBuilderPool
            .GetBuilder(cancellationToken)
            .Append($"/Destiny2/{membershipType}/Profile/{destinyMembershipId}/Character/{characterId}/Collectibles/{collectiblePresentationNodeHash}/")
            .AddQueryParam("components", components)
            .Build();
        return await _dotNetBungieApiHttpClient.GetFromBungieNetPlatform<Models.Destiny.Responses.DestinyCollectibleNodeDetailResponse>(url, cancellationToken);
    }

    /// <summary>
    ///     Transfer an item to/from your vault. You must have a valid Destiny account. You must also pass BOTH a reference AND an instance ID if it's an instanced item. itshappening.gif
    /// </summary>
    /// <param name="requestBody">Request body</param>
    /// <param name="authorizationToken">Authorization information</param>
    /// <param name="cancellationToken">Method cancellation token</param>
    public async Task<BungieResponse<int>> TransferItem(
        Models.Destiny.Requests.DestinyItemTransferRequest requestBody,
        AuthorizationTokenData authorizationToken,
        CancellationToken cancellationToken = default
    )
    {
        if (!_configuration.HasSufficientRights(ApplicationScopes.MoveEquipDestinyItems))
            throw new InsufficientScopeException(ApplicationScopes.MoveEquipDestinyItems);

        var stream = new MemoryStream();
        await _serializer.SerializeAsync(stream, requestBody);
        stream.Position = 0;

        return await _dotNetBungieApiHttpClient.PostToBungieNetPlatform<int>("/Destiny2/Actions/Items/TransferItem/", cancellationToken, stream, authToken: authorizationToken?.AccessToken);
    }

    /// <summary>
    ///     Extract an item from the Postmaster, with whatever implications that may entail. You must have a valid Destiny account. You must also pass BOTH a reference AND an instance ID if it's an instanced item.
    /// </summary>
    /// <param name="requestBody">Request body</param>
    /// <param name="authorizationToken">Authorization information</param>
    /// <param name="cancellationToken">Method cancellation token</param>
    public async Task<BungieResponse<int>> PullFromPostmaster(
        Models.Destiny.Requests.Actions.DestinyPostmasterTransferRequest requestBody,
        AuthorizationTokenData authorizationToken,
        CancellationToken cancellationToken = default
    )
    {
        if (!_configuration.HasSufficientRights(ApplicationScopes.MoveEquipDestinyItems))
            throw new InsufficientScopeException(ApplicationScopes.MoveEquipDestinyItems);

        var stream = new MemoryStream();
        await _serializer.SerializeAsync(stream, requestBody);
        stream.Position = 0;

        return await _dotNetBungieApiHttpClient.PostToBungieNetPlatform<int>("/Destiny2/Actions/Items/PullFromPostmaster/", cancellationToken, stream, authToken: authorizationToken?.AccessToken);
    }

    /// <summary>
    ///     Equip an item. You must have a valid Destiny Account, and either be in a social space, in orbit, or offline.
    /// </summary>
    /// <param name="requestBody">Request body</param>
    /// <param name="authorizationToken">Authorization information</param>
    /// <param name="cancellationToken">Method cancellation token</param>
    public async Task<BungieResponse<int>> EquipItem(
        Models.Destiny.Requests.Actions.DestinyItemActionRequest requestBody,
        AuthorizationTokenData authorizationToken,
        CancellationToken cancellationToken = default
    )
    {
        if (!_configuration.HasSufficientRights(ApplicationScopes.MoveEquipDestinyItems))
            throw new InsufficientScopeException(ApplicationScopes.MoveEquipDestinyItems);

        var stream = new MemoryStream();
        await _serializer.SerializeAsync(stream, requestBody);
        stream.Position = 0;

        return await _dotNetBungieApiHttpClient.PostToBungieNetPlatform<int>("/Destiny2/Actions/Items/EquipItem/", cancellationToken, stream, authToken: authorizationToken?.AccessToken);
    }

    /// <summary>
    ///     Equip a list of items by itemInstanceIds. You must have a valid Destiny Account, and either be in a social space, in orbit, or offline. Any items not found on your character will be ignored.
    /// </summary>
    /// <param name="requestBody">Request body</param>
    /// <param name="authorizationToken">Authorization information</param>
    /// <param name="cancellationToken">Method cancellation token</param>
    public async Task<BungieResponse<Models.Destiny.DestinyEquipItemResults>> EquipItems(
        Models.Destiny.Requests.Actions.DestinyItemSetActionRequest requestBody,
        AuthorizationTokenData authorizationToken,
        CancellationToken cancellationToken = default
    )
    {
        if (!_configuration.HasSufficientRights(ApplicationScopes.MoveEquipDestinyItems))
            throw new InsufficientScopeException(ApplicationScopes.MoveEquipDestinyItems);

        var stream = new MemoryStream();
        await _serializer.SerializeAsync(stream, requestBody);
        stream.Position = 0;

        return await _dotNetBungieApiHttpClient.PostToBungieNetPlatform<Models.Destiny.DestinyEquipItemResults>("/Destiny2/Actions/Items/EquipItems/", cancellationToken, stream, authToken: authorizationToken?.AccessToken);
    }

    /// <summary>
    ///     Equip a loadout. You must have a valid Destiny Account, and either be in a social space, in orbit, or offline.
    /// </summary>
    /// <param name="requestBody">Request body</param>
    /// <param name="authorizationToken">Authorization information</param>
    /// <param name="cancellationToken">Method cancellation token</param>
    public async Task<BungieResponse<int>> EquipLoadout(
        Models.Destiny.Requests.Actions.DestinyLoadoutActionRequest requestBody,
        AuthorizationTokenData authorizationToken,
        CancellationToken cancellationToken = default
    )
    {
        if (!_configuration.HasSufficientRights(ApplicationScopes.MoveEquipDestinyItems))
            throw new InsufficientScopeException(ApplicationScopes.MoveEquipDestinyItems);

        var stream = new MemoryStream();
        await _serializer.SerializeAsync(stream, requestBody);
        stream.Position = 0;

        return await _dotNetBungieApiHttpClient.PostToBungieNetPlatform<int>("/Destiny2/Actions/Loadouts/EquipLoadout/", cancellationToken, stream, authToken: authorizationToken?.AccessToken);
    }

    /// <summary>
    ///     Snapshot a loadout with the currently equipped items.
    /// </summary>
    /// <param name="requestBody">Request body</param>
    /// <param name="authorizationToken">Authorization information</param>
    /// <param name="cancellationToken">Method cancellation token</param>
    public async Task<BungieResponse<int>> SnapshotLoadout(
        Models.Destiny.Requests.Actions.DestinyLoadoutUpdateActionRequest requestBody,
        AuthorizationTokenData authorizationToken,
        CancellationToken cancellationToken = default
    )
    {
        if (!_configuration.HasSufficientRights(ApplicationScopes.MoveEquipDestinyItems))
            throw new InsufficientScopeException(ApplicationScopes.MoveEquipDestinyItems);

        var stream = new MemoryStream();
        await _serializer.SerializeAsync(stream, requestBody);
        stream.Position = 0;

        return await _dotNetBungieApiHttpClient.PostToBungieNetPlatform<int>("/Destiny2/Actions/Loadouts/SnapshotLoadout/", cancellationToken, stream, authToken: authorizationToken?.AccessToken);
    }

    /// <summary>
    ///     Update the color, icon, and name of a loadout.
    /// </summary>
    /// <param name="requestBody">Request body</param>
    /// <param name="authorizationToken">Authorization information</param>
    /// <param name="cancellationToken">Method cancellation token</param>
    public async Task<BungieResponse<int>> UpdateLoadoutIdentifiers(
        Models.Destiny.Requests.Actions.DestinyLoadoutUpdateActionRequest requestBody,
        AuthorizationTokenData authorizationToken,
        CancellationToken cancellationToken = default
    )
    {
        if (!_configuration.HasSufficientRights(ApplicationScopes.MoveEquipDestinyItems))
            throw new InsufficientScopeException(ApplicationScopes.MoveEquipDestinyItems);

        var stream = new MemoryStream();
        await _serializer.SerializeAsync(stream, requestBody);
        stream.Position = 0;

        return await _dotNetBungieApiHttpClient.PostToBungieNetPlatform<int>("/Destiny2/Actions/Loadouts/UpdateLoadoutIdentifiers/", cancellationToken, stream, authToken: authorizationToken?.AccessToken);
    }

    /// <summary>
    ///     Clear the identifiers and items of a loadout.
    /// </summary>
    /// <param name="requestBody">Request body</param>
    /// <param name="authorizationToken">Authorization information</param>
    /// <param name="cancellationToken">Method cancellation token</param>
    public async Task<BungieResponse<int>> ClearLoadout(
        Models.Destiny.Requests.Actions.DestinyLoadoutActionRequest requestBody,
        AuthorizationTokenData authorizationToken,
        CancellationToken cancellationToken = default
    )
    {
        if (!_configuration.HasSufficientRights(ApplicationScopes.MoveEquipDestinyItems))
            throw new InsufficientScopeException(ApplicationScopes.MoveEquipDestinyItems);

        var stream = new MemoryStream();
        await _serializer.SerializeAsync(stream, requestBody);
        stream.Position = 0;

        return await _dotNetBungieApiHttpClient.PostToBungieNetPlatform<int>("/Destiny2/Actions/Loadouts/ClearLoadout/", cancellationToken, stream, authToken: authorizationToken?.AccessToken);
    }

    /// <summary>
    ///     Set the Lock State for an instanced item. You must have a valid Destiny Account.
    /// </summary>
    /// <param name="requestBody">Request body</param>
    /// <param name="authorizationToken">Authorization information</param>
    /// <param name="cancellationToken">Method cancellation token</param>
    public async Task<BungieResponse<int>> SetItemLockState(
        Models.Destiny.Requests.Actions.DestinyItemStateRequest requestBody,
        AuthorizationTokenData authorizationToken,
        CancellationToken cancellationToken = default
    )
    {
        if (!_configuration.HasSufficientRights(ApplicationScopes.MoveEquipDestinyItems))
            throw new InsufficientScopeException(ApplicationScopes.MoveEquipDestinyItems);

        var stream = new MemoryStream();
        await _serializer.SerializeAsync(stream, requestBody);
        stream.Position = 0;

        return await _dotNetBungieApiHttpClient.PostToBungieNetPlatform<int>("/Destiny2/Actions/Items/SetLockState/", cancellationToken, stream, authToken: authorizationToken?.AccessToken);
    }

    /// <summary>
    ///     Set the Tracking State for an instanced item, if that item is a Quest or Bounty. You must have a valid Destiny Account. Yeah, it's an item.
    /// </summary>
    /// <param name="requestBody">Request body</param>
    /// <param name="authorizationToken">Authorization information</param>
    /// <param name="cancellationToken">Method cancellation token</param>
    public async Task<BungieResponse<int>> SetQuestTrackedState(
        Models.Destiny.Requests.Actions.DestinyItemStateRequest requestBody,
        AuthorizationTokenData authorizationToken,
        CancellationToken cancellationToken = default
    )
    {
        if (!_configuration.HasSufficientRights(ApplicationScopes.MoveEquipDestinyItems))
            throw new InsufficientScopeException(ApplicationScopes.MoveEquipDestinyItems);

        var stream = new MemoryStream();
        await _serializer.SerializeAsync(stream, requestBody);
        stream.Position = 0;

        return await _dotNetBungieApiHttpClient.PostToBungieNetPlatform<int>("/Destiny2/Actions/Items/SetTrackedState/", cancellationToken, stream, authToken: authorizationToken?.AccessToken);
    }

    /// <summary>
    ///     Insert a plug into a socketed item. I know how it sounds, but I assure you it's much more G-rated than you might be guessing. We haven't decided yet whether this will be able to insert plugs that have side effects, but if we do it will require special scope permission for an application attempting to do so. You must have a valid Destiny Account, and either be in a social space, in orbit, or offline. Request must include proof of permission for 'InsertPlugs' from the account owner.
    /// </summary>
    /// <param name="requestBody">Request body</param>
    /// <param name="authorizationToken">Authorization information</param>
    /// <param name="cancellationToken">Method cancellation token</param>
    public async Task<BungieResponse<Models.Destiny.Responses.DestinyItemChangeResponse>> InsertSocketPlug(
        Models.Destiny.Requests.Actions.DestinyInsertPlugsActionRequest requestBody,
        AuthorizationTokenData authorizationToken,
        CancellationToken cancellationToken = default
    )
    {
        if (!_configuration.HasSufficientRights(ApplicationScopes.AdvancedWriteActions))
            throw new InsufficientScopeException(ApplicationScopes.AdvancedWriteActions);

        var stream = new MemoryStream();
        await _serializer.SerializeAsync(stream, requestBody);
        stream.Position = 0;

        return await _dotNetBungieApiHttpClient.PostToBungieNetPlatform<Models.Destiny.Responses.DestinyItemChangeResponse>("/Destiny2/Actions/Items/InsertSocketPlug/", cancellationToken, stream, authToken: authorizationToken?.AccessToken);
    }

    /// <summary>
    ///     Insert a 'free' plug into an item's socket. This does not require 'Advanced Write Action' authorization and is available to 3rd-party apps, but will only work on 'free and reversible' socket actions (Perks, Armor Mods, Shaders, Ornaments, etc.). You must have a valid Destiny Account, and the character must either be in a social space, in orbit, or offline.
    /// </summary>
    /// <param name="requestBody">Request body</param>
    /// <param name="authorizationToken">Authorization information</param>
    /// <param name="cancellationToken">Method cancellation token</param>
    public async Task<BungieResponse<Models.Destiny.Responses.DestinyItemChangeResponse>> InsertSocketPlugFree(
        Models.Destiny.Requests.Actions.DestinyInsertPlugsFreeActionRequest requestBody,
        AuthorizationTokenData authorizationToken,
        CancellationToken cancellationToken = default
    )
    {
        if (!_configuration.HasSufficientRights(ApplicationScopes.MoveEquipDestinyItems))
            throw new InsufficientScopeException(ApplicationScopes.MoveEquipDestinyItems);

        var stream = new MemoryStream();
        await _serializer.SerializeAsync(stream, requestBody);
        stream.Position = 0;

        return await _dotNetBungieApiHttpClient.PostToBungieNetPlatform<Models.Destiny.Responses.DestinyItemChangeResponse>("/Destiny2/Actions/Items/InsertSocketPlugFree/", cancellationToken, stream, authToken: authorizationToken?.AccessToken);
    }

    /// <summary>
    ///     Gets the available post game carnage report for the activity ID.
    /// </summary>
    /// <param name="activityId">The ID of the activity whose PGCR is requested.</param>
    /// <param name="cancellationToken">Method cancellation token</param>
    public async Task<BungieResponse<Models.Destiny.HistoricalStats.DestinyPostGameCarnageReportData>> GetPostGameCarnageReport(
        long activityId,
        CancellationToken cancellationToken = default
    )
    {
        var url = StringBuilderPool
            .GetBuilder(cancellationToken)
            .Append($"/Destiny2/Stats/PostGameCarnageReport/{activityId}/")
            .Build();
        return await _dotNetBungieApiHttpClient.GetFromBungieNetPlatform<Models.Destiny.HistoricalStats.DestinyPostGameCarnageReportData>(url, cancellationToken);
    }

    /// <summary>
    ///     Report a player that you met in an activity that was engaging in ToS-violating activities. Both you and the offending player must have played in the activityId passed in. Please use this judiciously and only when you have strong suspicions of violation, pretty please.
    /// </summary>
    /// <param name="activityId">The ID of the activity where you ran into the brigand that you're reporting.</param>
    /// <param name="requestBody">Request body</param>
    /// <param name="authorizationToken">Authorization information</param>
    /// <param name="cancellationToken">Method cancellation token</param>
    public async Task<BungieResponse<int>> ReportOffensivePostGameCarnageReportPlayer(
        long activityId,
        Models.Destiny.Reporting.Requests.DestinyReportOffensePgcrRequest requestBody,
        AuthorizationTokenData authorizationToken,
        CancellationToken cancellationToken = default
    )
    {
        if (!_configuration.HasSufficientRights(ApplicationScopes.BnetWrite))
            throw new InsufficientScopeException(ApplicationScopes.BnetWrite);

        var url = StringBuilderPool
            .GetBuilder(cancellationToken)
            .Append($"/Destiny2/Stats/PostGameCarnageReport/{activityId}/Report/")
            .Build();
        var stream = new MemoryStream();
        await _serializer.SerializeAsync(stream, requestBody);
        stream.Position = 0;

        return await _dotNetBungieApiHttpClient.PostToBungieNetPlatform<int>(url, cancellationToken, content: stream, authToken: authorizationToken?.AccessToken);
    }

    /// <summary>
    ///     Gets historical stats definitions.
    /// </summary>
    /// <param name="cancellationToken">Method cancellation token</param>
    public async Task<BungieResponse<Dictionary<string, Models.Destiny.HistoricalStats.Definitions.DestinyHistoricalStatsDefinition>>> GetHistoricalStatsDefinition(CancellationToken cancellationToken = default)
    {
        return await _dotNetBungieApiHttpClient.GetFromBungieNetPlatform<Dictionary<string, Models.Destiny.HistoricalStats.Definitions.DestinyHistoricalStatsDefinition>>("/Destiny2/Stats/Definition/", cancellationToken);
    }

    /// <summary>
    ///     Gets leaderboards with the signed in user's friends and the supplied destinyMembershipId as the focus. PREVIEW: This endpoint is still in beta, and may experience rough edges. The schema is in final form, but there may be bugs that prevent desirable operation.
    /// </summary>
    /// <param name="groupId">Group ID of the clan whose leaderboards you wish to fetch.</param>
    /// <param name="maxtop">Maximum number of top players to return. Use a large number to get entire leaderboard.</param>
    /// <param name="modes">List of game modes for which to get leaderboards. See the documentation for DestinyActivityModeType for valid values, and pass in string representation, comma delimited.</param>
    /// <param name="statid">ID of stat to return rather than returning all Leaderboard stats.</param>
    /// <param name="cancellationToken">Method cancellation token</param>
    public async Task<BungieResponse<Dictionary<string, Dictionary<string, Models.Destiny.HistoricalStats.DestinyLeaderboard>>>> GetClanLeaderboards(
        long groupId,
        int maxtop,
        string modes,
        string statid,
        CancellationToken cancellationToken = default
    )
    {
        var url = StringBuilderPool
            .GetBuilder(cancellationToken)
            .Append($"/Destiny2/Stats/Leaderboards/Clans/{groupId}/")
            .AddQueryParam("maxtop", maxtop)
            .AddQueryParam("modes", modes)
            .AddQueryParam("statid", statid)
            .Build();
        return await _dotNetBungieApiHttpClient.GetFromBungieNetPlatform<Dictionary<string, Dictionary<string, Models.Destiny.HistoricalStats.DestinyLeaderboard>>>(url, cancellationToken);
    }

    /// <summary>
    ///     Gets aggregated stats for a clan using the same categories as the clan leaderboards. PREVIEW: This endpoint is still in beta, and may experience rough edges. The schema is in final form, but there may be bugs that prevent desirable operation.
    /// </summary>
    /// <param name="groupId">Group ID of the clan whose leaderboards you wish to fetch.</param>
    /// <param name="modes">List of game modes for which to get leaderboards. See the documentation for DestinyActivityModeType for valid values, and pass in string representation, comma delimited.</param>
    /// <param name="cancellationToken">Method cancellation token</param>
    public async Task<BungieResponse<Models.Destiny.HistoricalStats.DestinyClanAggregateStat[]>> GetClanAggregateStats(
        long groupId,
        string modes,
        CancellationToken cancellationToken = default
    )
    {
        var url = StringBuilderPool
            .GetBuilder(cancellationToken)
            .Append($"/Destiny2/Stats/AggregateClanStats/{groupId}/")
            .AddQueryParam("modes", modes)
            .Build();
        return await _dotNetBungieApiHttpClient.GetFromBungieNetPlatform<Models.Destiny.HistoricalStats.DestinyClanAggregateStat[]>(url, cancellationToken);
    }

    /// <summary>
    ///     Gets leaderboards with the signed in user's friends and the supplied destinyMembershipId as the focus. PREVIEW: This endpoint has not yet been implemented. It is being returned for a preview of future functionality, and for public comment/suggestion/preparation.
    /// </summary>
    /// <param name="destinyMembershipId">The Destiny membershipId of the user to retrieve.</param>
    /// <param name="maxtop">Maximum number of top players to return. Use a large number to get entire leaderboard.</param>
    /// <param name="membershipType">A valid non-BungieNet membership type.</param>
    /// <param name="modes">List of game modes for which to get leaderboards. See the documentation for DestinyActivityModeType for valid values, and pass in string representation, comma delimited.</param>
    /// <param name="statid">ID of stat to return rather than returning all Leaderboard stats.</param>
    /// <param name="cancellationToken">Method cancellation token</param>
    public async Task<BungieResponse<Dictionary<string, Dictionary<string, Models.Destiny.HistoricalStats.DestinyLeaderboard>>>> GetLeaderboards(
        long destinyMembershipId,
        Models.BungieMembershipType membershipType,
        int maxtop,
        string modes,
        string statid,
        CancellationToken cancellationToken = default
    )
    {
        var url = StringBuilderPool
            .GetBuilder(cancellationToken)
            .Append($"/Destiny2/{membershipType}/Account/{destinyMembershipId}/Stats/Leaderboards/")
            .AddQueryParam("maxtop", maxtop)
            .AddQueryParam("modes", modes)
            .AddQueryParam("statid", statid)
            .Build();
        return await _dotNetBungieApiHttpClient.GetFromBungieNetPlatform<Dictionary<string, Dictionary<string, Models.Destiny.HistoricalStats.DestinyLeaderboard>>>(url, cancellationToken);
    }

    /// <summary>
    ///     Gets leaderboards with the signed in user's friends and the supplied destinyMembershipId as the focus. PREVIEW: This endpoint is still in beta, and may experience rough edges. The schema is in final form, but there may be bugs that prevent desirable operation.
    /// </summary>
    /// <param name="characterId">The specific character to build the leaderboard around for the provided Destiny Membership.</param>
    /// <param name="destinyMembershipId">The Destiny membershipId of the user to retrieve.</param>
    /// <param name="maxtop">Maximum number of top players to return. Use a large number to get entire leaderboard.</param>
    /// <param name="membershipType">A valid non-BungieNet membership type.</param>
    /// <param name="modes">List of game modes for which to get leaderboards. See the documentation for DestinyActivityModeType for valid values, and pass in string representation, comma delimited.</param>
    /// <param name="statid">ID of stat to return rather than returning all Leaderboard stats.</param>
    /// <param name="cancellationToken">Method cancellation token</param>
    public async Task<BungieResponse<Dictionary<string, Dictionary<string, Models.Destiny.HistoricalStats.DestinyLeaderboard>>>> GetLeaderboardsForCharacter(
        long characterId,
        long destinyMembershipId,
        Models.BungieMembershipType membershipType,
        int maxtop,
        string modes,
        string statid,
        CancellationToken cancellationToken = default
    )
    {
        var url = StringBuilderPool
            .GetBuilder(cancellationToken)
            .Append($"/Destiny2/Stats/Leaderboards/{membershipType}/{destinyMembershipId}/{characterId}/")
            .AddQueryParam("maxtop", maxtop)
            .AddQueryParam("modes", modes)
            .AddQueryParam("statid", statid)
            .Build();
        return await _dotNetBungieApiHttpClient.GetFromBungieNetPlatform<Dictionary<string, Dictionary<string, Models.Destiny.HistoricalStats.DestinyLeaderboard>>>(url, cancellationToken);
    }

    /// <summary>
    ///     Gets a page list of Destiny items.
    /// </summary>
    /// <param name="page">Page number to return, starting with 0.</param>
    /// <param name="searchTerm">The string to use when searching for Destiny entities.</param>
    /// <param name="type">The type of entity for whom you would like results. These correspond to the entity's definition contract name. For instance, if you are looking for items, this property should be 'DestinyInventoryItemDefinition'.</param>
    /// <param name="cancellationToken">Method cancellation token</param>
    public async Task<BungieResponse<Models.Destiny.Definitions.DestinyEntitySearchResult>> SearchDestinyEntities(
        string searchTerm,
        string type,
        int page,
        CancellationToken cancellationToken = default
    )
    {
        var url = StringBuilderPool
            .GetBuilder(cancellationToken)
            .Append($"/Destiny2/Armory/Search/{type}/{searchTerm}/")
            .AddQueryParam("page", page)
            .Build();
        return await _dotNetBungieApiHttpClient.GetFromBungieNetPlatform<Models.Destiny.Definitions.DestinyEntitySearchResult>(url, cancellationToken);
    }

    /// <summary>
    ///     Gets historical stats for indicated character.
    /// </summary>
    /// <param name="characterId">The id of the character to retrieve. You can omit this character ID or set it to 0 to get aggregate stats across all characters.</param>
    /// <param name="dayend">Last day to return when daily stats are requested. Use the format YYYY-MM-DD. Currently, we cannot allow more than 31 days of daily data to be requested in a single request.</param>
    /// <param name="daystart">First day to return when daily stats are requested. Use the format YYYY-MM-DD. Currently, we cannot allow more than 31 days of daily data to be requested in a single request.</param>
    /// <param name="destinyMembershipId">The Destiny membershipId of the user to retrieve.</param>
    /// <param name="groups">Group of stats to include, otherwise only general stats are returned. Comma separated list is allowed. Values: General, Weapons, Medals</param>
    /// <param name="membershipType">A valid non-BungieNet membership type.</param>
    /// <param name="modes">Game modes to return. See the documentation for DestinyActivityModeType for valid values, and pass in string representation, comma delimited.</param>
    /// <param name="periodType">Indicates a specific period type to return. Optional. May be: Daily, AllTime, or Activity</param>
    /// <param name="cancellationToken">Method cancellation token</param>
    public async Task<BungieResponse<Dictionary<string, Models.Destiny.HistoricalStats.DestinyHistoricalStatsByPeriod>>> GetHistoricalStats(
        long characterId,
        long destinyMembershipId,
        Models.BungieMembershipType membershipType,
        DateTime dayend,
        DateTime daystart,
        Models.Destiny.HistoricalStats.Definitions.DestinyStatsGroupType[] groups,
        Models.Destiny.HistoricalStats.Definitions.DestinyActivityModeType[] modes,
        Models.Destiny.HistoricalStats.Definitions.PeriodType periodType,
        CancellationToken cancellationToken = default
    )
    {
        var url = StringBuilderPool
            .GetBuilder(cancellationToken)
            .Append($"/Destiny2/{membershipType}/Account/{destinyMembershipId}/Character/{characterId}/Stats/")
            .AddQueryParam("dayend", dayend)
            .AddQueryParam("daystart", daystart)
            .AddQueryParam("groups", groups)
            .AddQueryParam("modes", modes)
            .AddQueryParam("periodType", (int)periodType)
            .Build();
        return await _dotNetBungieApiHttpClient.GetFromBungieNetPlatform<Dictionary<string, Models.Destiny.HistoricalStats.DestinyHistoricalStatsByPeriod>>(url, cancellationToken);
    }

    /// <summary>
    ///     Gets aggregate historical stats organized around each character for a given account.
    /// </summary>
    /// <param name="destinyMembershipId">The Destiny membershipId of the user to retrieve.</param>
    /// <param name="groups">Groups of stats to include, otherwise only general stats are returned. Comma separated list is allowed. Values: General, Weapons, Medals.</param>
    /// <param name="membershipType">A valid non-BungieNet membership type.</param>
    /// <param name="cancellationToken">Method cancellation token</param>
    public async Task<BungieResponse<Models.Destiny.HistoricalStats.DestinyHistoricalStatsAccountResult>> GetHistoricalStatsForAccount(
        long destinyMembershipId,
        Models.BungieMembershipType membershipType,
        Models.Destiny.HistoricalStats.Definitions.DestinyStatsGroupType[] groups,
        CancellationToken cancellationToken = default
    )
    {
        var url = StringBuilderPool
            .GetBuilder(cancellationToken)
            .Append($"/Destiny2/{membershipType}/Account/{destinyMembershipId}/Stats/")
            .AddQueryParam("groups", groups)
            .Build();
        return await _dotNetBungieApiHttpClient.GetFromBungieNetPlatform<Models.Destiny.HistoricalStats.DestinyHistoricalStatsAccountResult>(url, cancellationToken);
    }

    /// <summary>
    ///     Gets activity history stats for indicated character.
    /// </summary>
    /// <param name="characterId">The id of the character to retrieve.</param>
    /// <param name="count">Number of rows to return</param>
    /// <param name="destinyMembershipId">The Destiny membershipId of the user to retrieve.</param>
    /// <param name="membershipType">A valid non-BungieNet membership type.</param>
    /// <param name="mode">A filter for the activity mode to be returned. None returns all activities. See the documentation for DestinyActivityModeType for valid values, and pass in string representation.</param>
    /// <param name="page">Page number to return, starting with 0.</param>
    /// <param name="cancellationToken">Method cancellation token</param>
    public async Task<BungieResponse<Models.Destiny.HistoricalStats.DestinyActivityHistoryResults>> GetActivityHistory(
        long characterId,
        long destinyMembershipId,
        Models.BungieMembershipType membershipType,
        int count,
        Models.Destiny.HistoricalStats.Definitions.DestinyActivityModeType mode,
        int page,
        CancellationToken cancellationToken = default
    )
    {
        var url = StringBuilderPool
            .GetBuilder(cancellationToken)
            .Append($"/Destiny2/{membershipType}/Account/{destinyMembershipId}/Character/{characterId}/Stats/Activities/")
            .AddQueryParam("count", count)
            .AddQueryParam("mode", (int)mode)
            .AddQueryParam("page", page)
            .Build();
        return await _dotNetBungieApiHttpClient.GetFromBungieNetPlatform<Models.Destiny.HistoricalStats.DestinyActivityHistoryResults>(url, cancellationToken);
    }

    /// <summary>
    ///     Gets details about unique weapon usage, including all exotic weapons.
    /// </summary>
    /// <param name="characterId">The id of the character to retrieve.</param>
    /// <param name="destinyMembershipId">The Destiny membershipId of the user to retrieve.</param>
    /// <param name="membershipType">A valid non-BungieNet membership type.</param>
    /// <param name="cancellationToken">Method cancellation token</param>
    public async Task<BungieResponse<Models.Destiny.HistoricalStats.DestinyHistoricalWeaponStatsData>> GetUniqueWeaponHistory(
        long characterId,
        long destinyMembershipId,
        Models.BungieMembershipType membershipType,
        CancellationToken cancellationToken = default
    )
    {
        var url = StringBuilderPool
            .GetBuilder(cancellationToken)
            .Append($"/Destiny2/{membershipType}/Account/{destinyMembershipId}/Character/{characterId}/Stats/UniqueWeapons/")
            .Build();
        return await _dotNetBungieApiHttpClient.GetFromBungieNetPlatform<Models.Destiny.HistoricalStats.DestinyHistoricalWeaponStatsData>(url, cancellationToken);
    }

    /// <summary>
    ///     Gets all activities the character has participated in together with aggregate statistics for those activities.
    /// </summary>
    /// <param name="characterId">The specific character whose activities should be returned.</param>
    /// <param name="destinyMembershipId">The Destiny membershipId of the user to retrieve.</param>
    /// <param name="membershipType">A valid non-BungieNet membership type.</param>
    /// <param name="cancellationToken">Method cancellation token</param>
    public async Task<BungieResponse<Models.Destiny.HistoricalStats.DestinyAggregateActivityResults>> GetDestinyAggregateActivityStats(
        long characterId,
        long destinyMembershipId,
        Models.BungieMembershipType membershipType,
        CancellationToken cancellationToken = default
    )
    {
        var url = StringBuilderPool
            .GetBuilder(cancellationToken)
            .Append($"/Destiny2/{membershipType}/Account/{destinyMembershipId}/Character/{characterId}/Stats/AggregateActivityStats/")
            .Build();
        return await _dotNetBungieApiHttpClient.GetFromBungieNetPlatform<Models.Destiny.HistoricalStats.DestinyAggregateActivityResults>(url, cancellationToken);
    }

    /// <summary>
    ///     Gets custom localized content for the milestone of the given hash, if it exists.
    /// </summary>
    /// <param name="milestoneHash">The identifier for the milestone to be returned.</param>
    /// <param name="cancellationToken">Method cancellation token</param>
    public async Task<BungieResponse<Models.Destiny.Milestones.DestinyMilestoneContent>> GetPublicMilestoneContent(
        uint milestoneHash,
        CancellationToken cancellationToken = default
    )
    {
        var url = StringBuilderPool
            .GetBuilder(cancellationToken)
            .Append($"/Destiny2/Milestones/{milestoneHash}/Content/")
            .Build();
        return await _dotNetBungieApiHttpClient.GetFromBungieNetPlatform<Models.Destiny.Milestones.DestinyMilestoneContent>(url, cancellationToken);
    }

    /// <summary>
    ///     Gets public information about currently available Milestones.
    /// </summary>
    /// <param name="cancellationToken">Method cancellation token</param>
    public async Task<BungieResponse<Dictionary<uint, Models.Destiny.Milestones.DestinyPublicMilestone>>> GetPublicMilestones(CancellationToken cancellationToken = default)
    {
        return await _dotNetBungieApiHttpClient.GetFromBungieNetPlatform<Dictionary<uint, Models.Destiny.Milestones.DestinyPublicMilestone>>("/Destiny2/Milestones/", cancellationToken);
    }

    /// <summary>
    ///     Initialize a request to perform an advanced write action.
    /// </summary>
    /// <param name="requestBody">Request body</param>
    /// <param name="authorizationToken">Authorization information</param>
    /// <param name="cancellationToken">Method cancellation token</param>
    public async Task<BungieResponse<Models.Destiny.Advanced.AwaInitializeResponse>> AwaInitializeRequest(
        Models.Destiny.Advanced.AwaPermissionRequested requestBody,
        AuthorizationTokenData authorizationToken,
        CancellationToken cancellationToken = default
    )
    {
        if (!_configuration.HasSufficientRights(ApplicationScopes.AdvancedWriteActions))
            throw new InsufficientScopeException(ApplicationScopes.AdvancedWriteActions);

        var stream = new MemoryStream();
        await _serializer.SerializeAsync(stream, requestBody);
        stream.Position = 0;

        return await _dotNetBungieApiHttpClient.PostToBungieNetPlatform<Models.Destiny.Advanced.AwaInitializeResponse>("/Destiny2/Awa/Initialize/", cancellationToken, stream, authToken: authorizationToken?.AccessToken);
    }

    /// <summary>
    ///     Provide the result of the user interaction. Called by the Bungie Destiny App to approve or reject a request.
    /// </summary>
    /// <param name="requestBody">Request body</param>
    /// <param name="cancellationToken">Method cancellation token</param>
    public async Task<BungieResponse<int>> AwaProvideAuthorizationResult(
        Models.Destiny.Advanced.AwaUserResponse requestBody,
        CancellationToken cancellationToken = default
    )
    {
        var stream = new MemoryStream();
        await _serializer.SerializeAsync(stream, requestBody);
        stream.Position = 0;

        return await _dotNetBungieApiHttpClient.PostToBungieNetPlatform<int>("/Destiny2/Awa/AwaProvideAuthorizationResult/", cancellationToken, stream);
    }

    /// <summary>
    ///     Returns the action token if user approves the request.
    /// </summary>
    /// <param name="correlationId">The identifier for the advanced write action request.</param>
    /// <param name="authorizationToken">Authorization information</param>
    /// <param name="cancellationToken">Method cancellation token</param>
    public async Task<BungieResponse<Models.Destiny.Advanced.AwaAuthorizationResult>> AwaGetActionToken(
        string correlationId,
        AuthorizationTokenData authorizationToken,
        CancellationToken cancellationToken = default
    )
    {
        if (!_configuration.HasSufficientRights(ApplicationScopes.AdvancedWriteActions))
            throw new InsufficientScopeException(ApplicationScopes.AdvancedWriteActions);

        var url = StringBuilderPool
            .GetBuilder(cancellationToken)
            .Append($"/Destiny2/Awa/GetActionToken/{correlationId}/")
            .Build();
        return await _dotNetBungieApiHttpClient.GetFromBungieNetPlatform<Models.Destiny.Advanced.AwaAuthorizationResult>(url, cancellationToken, authToken: authorizationToken?.AccessToken);
    }

}
