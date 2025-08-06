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

internal sealed class GroupV2Api : IGroupV2Api
{
    private readonly IBungieClientConfiguration _configuration;
    private readonly IDotNetBungieApiHttpClient _dotNetBungieApiHttpClient;
    private readonly IBungieNetJsonSerializer _serializer;

    public GroupV2Api(
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
    ///     Returns a list of all available group avatars for the signed-in user.
    /// </summary>
    /// <param name="cancellationToken">Method cancellation token</param>
    public async Task<BungieResponse<Dictionary<int, string>>> GetAvailableAvatars(CancellationToken cancellationToken = default)
    {
        return await _dotNetBungieApiHttpClient.GetFromBungieNetPlatform<Dictionary<int, string>>("/GroupV2/GetAvailableAvatars/", cancellationToken);
    }

    /// <summary>
    ///     Returns a list of all available group themes.
    /// </summary>
    /// <param name="cancellationToken">Method cancellation token</param>
    public async Task<BungieResponse<Models.Config.GroupTheme[]>> GetAvailableThemes(CancellationToken cancellationToken = default)
    {
        return await _dotNetBungieApiHttpClient.GetFromBungieNetPlatform<Models.Config.GroupTheme[]>("/GroupV2/GetAvailableThemes/", cancellationToken);
    }

    /// <summary>
    ///     Gets the state of the user's clan invite preferences for a particular membership type - true if they wish to be invited to clans, false otherwise.
    /// </summary>
    /// <param name="mType">The Destiny membership type of the account we wish to access settings.</param>
    /// <param name="authorizationToken">Authorization information</param>
    /// <param name="cancellationToken">Method cancellation token</param>
    public async Task<BungieResponse<bool>> GetUserClanInviteSetting(
        Models.BungieMembershipType mType,
        AuthorizationTokenData authorizationToken,
        CancellationToken cancellationToken = default
    )
    {
        if (!_configuration.HasSufficientRights(ApplicationScopes.ReadUserData))
            throw new InsufficientScopeException(ApplicationScopes.ReadUserData);

        var url = StringBuilderPool
            .GetBuilder(cancellationToken)
            .Append($"/GroupV2/GetUserClanInviteSetting/{mType}/")
            .Build();
        return await _dotNetBungieApiHttpClient.GetFromBungieNetPlatform<bool>(url, cancellationToken, authToken: authorizationToken?.AccessToken);
    }

    /// <summary>
    ///     Gets groups recommended for you based on the groups to whom those you follow belong.
    /// </summary>
    /// <param name="createDateRange">Requested range in which to pull recommended groups</param>
    /// <param name="groupType">Type of groups requested</param>
    /// <param name="authorizationToken">Authorization information</param>
    /// <param name="cancellationToken">Method cancellation token</param>
    public async Task<BungieResponse<Models.GroupsV2.GroupV2Card[]>> GetRecommendedGroups(
        Models.GroupsV2.GroupDateRange createDateRange,
        Models.GroupsV2.GroupType groupType,
        AuthorizationTokenData authorizationToken,
        CancellationToken cancellationToken = default
    )
    {
        if (!_configuration.HasSufficientRights(ApplicationScopes.ReadGroups))
            throw new InsufficientScopeException(ApplicationScopes.ReadGroups);

        var url = StringBuilderPool
            .GetBuilder(cancellationToken)
            .Append($"/GroupV2/Recommended/{groupType}/{createDateRange}/")
            .Build();
        return await _dotNetBungieApiHttpClient.PostToBungieNetPlatform<Models.GroupsV2.GroupV2Card[]>(url, cancellationToken, authToken: authorizationToken?.AccessToken);
    }

    /// <summary>
    ///     Search for Groups.
    /// </summary>
    /// <param name="requestBody">Request body</param>
    /// <param name="cancellationToken">Method cancellation token</param>
    public async Task<BungieResponse<Models.GroupsV2.GroupSearchResponse>> GroupSearch(
        Models.GroupsV2.GroupQuery requestBody,
        CancellationToken cancellationToken = default
    )
    {
        var stream = new MemoryStream();
        await _serializer.SerializeAsync(stream, requestBody);
        stream.Position = 0;

        return await _dotNetBungieApiHttpClient.PostToBungieNetPlatform<Models.GroupsV2.GroupSearchResponse>("/GroupV2/Search/", cancellationToken, stream);
    }

    /// <summary>
    ///     Get information about a specific group of the given ID.
    /// </summary>
    /// <param name="groupId">Requested group's id.</param>
    /// <param name="cancellationToken">Method cancellation token</param>
    public async Task<BungieResponse<Models.GroupsV2.GroupResponse>> GetGroup(
        long groupId,
        CancellationToken cancellationToken = default
    )
    {
        var url = StringBuilderPool
            .GetBuilder(cancellationToken)
            .Append($"/GroupV2/{groupId}/")
            .Build();
        return await _dotNetBungieApiHttpClient.GetFromBungieNetPlatform<Models.GroupsV2.GroupResponse>(url, cancellationToken);
    }

    /// <summary>
    ///     Get information about a specific group with the given name and type.
    /// </summary>
    /// <param name="groupName">Exact name of the group to find.</param>
    /// <param name="groupType">Type of group to find.</param>
    /// <param name="cancellationToken">Method cancellation token</param>
    public async Task<BungieResponse<Models.GroupsV2.GroupResponse>> GetGroupByName(
        string groupName,
        Models.GroupsV2.GroupType groupType,
        CancellationToken cancellationToken = default
    )
    {
        var url = StringBuilderPool
            .GetBuilder(cancellationToken)
            .Append($"/GroupV2/Name/{groupName}/{groupType}/")
            .Build();
        return await _dotNetBungieApiHttpClient.GetFromBungieNetPlatform<Models.GroupsV2.GroupResponse>(url, cancellationToken);
    }

    /// <summary>
    ///     Get information about a specific group with the given name and type. The POST version.
    /// </summary>
    /// <param name="requestBody">Request body</param>
    /// <param name="cancellationToken">Method cancellation token</param>
    public async Task<BungieResponse<Models.GroupsV2.GroupResponse>> GetGroupByNameV2(
        Models.GroupsV2.GroupNameSearchRequest requestBody,
        CancellationToken cancellationToken = default
    )
    {
        var stream = new MemoryStream();
        await _serializer.SerializeAsync(stream, requestBody);
        stream.Position = 0;

        return await _dotNetBungieApiHttpClient.PostToBungieNetPlatform<Models.GroupsV2.GroupResponse>("/GroupV2/NameV2/", cancellationToken, stream);
    }

    /// <summary>
    ///     Gets a list of available optional conversation channels and their settings.
    /// </summary>
    /// <param name="groupId">Requested group's id.</param>
    /// <param name="cancellationToken">Method cancellation token</param>
    public async Task<BungieResponse<Models.GroupsV2.GroupOptionalConversation[]>> GetGroupOptionalConversations(
        long groupId,
        CancellationToken cancellationToken = default
    )
    {
        var url = StringBuilderPool
            .GetBuilder(cancellationToken)
            .Append($"/GroupV2/{groupId}/OptionalConversations/")
            .Build();
        return await _dotNetBungieApiHttpClient.GetFromBungieNetPlatform<Models.GroupsV2.GroupOptionalConversation[]>(url, cancellationToken);
    }

    /// <summary>
    ///     Edit an existing group. You must have suitable permissions in the group to perform this operation. This latest revision will only edit the fields you pass in - pass null for properties you want to leave unaltered.
    /// </summary>
    /// <param name="groupId">Group ID of the group to edit.</param>
    /// <param name="requestBody">Request body</param>
    /// <param name="authorizationToken">Authorization information</param>
    /// <param name="cancellationToken">Method cancellation token</param>
    public async Task<BungieResponse<int>> EditGroup(
        long groupId,
        Models.GroupsV2.GroupEditAction requestBody,
        AuthorizationTokenData authorizationToken,
        CancellationToken cancellationToken = default
    )
    {
        if (!_configuration.HasSufficientRights(ApplicationScopes.AdminGroups))
            throw new InsufficientScopeException(ApplicationScopes.AdminGroups);

        var url = StringBuilderPool
            .GetBuilder(cancellationToken)
            .Append($"/GroupV2/{groupId}/Edit/")
            .Build();
        var stream = new MemoryStream();
        await _serializer.SerializeAsync(stream, requestBody);
        stream.Position = 0;

        return await _dotNetBungieApiHttpClient.PostToBungieNetPlatform<int>(url, cancellationToken, content: stream, authToken: authorizationToken?.AccessToken);
    }

    /// <summary>
    ///     Edit an existing group's clan banner. You must have suitable permissions in the group to perform this operation. All fields are required.
    /// </summary>
    /// <param name="groupId">Group ID of the group to edit.</param>
    /// <param name="requestBody">Request body</param>
    /// <param name="authorizationToken">Authorization information</param>
    /// <param name="cancellationToken">Method cancellation token</param>
    public async Task<BungieResponse<int>> EditClanBanner(
        long groupId,
        Models.GroupsV2.ClanBanner requestBody,
        AuthorizationTokenData authorizationToken,
        CancellationToken cancellationToken = default
    )
    {
        if (!_configuration.HasSufficientRights(ApplicationScopes.AdminGroups))
            throw new InsufficientScopeException(ApplicationScopes.AdminGroups);

        var url = StringBuilderPool
            .GetBuilder(cancellationToken)
            .Append($"/GroupV2/{groupId}/EditClanBanner/")
            .Build();
        var stream = new MemoryStream();
        await _serializer.SerializeAsync(stream, requestBody);
        stream.Position = 0;

        return await _dotNetBungieApiHttpClient.PostToBungieNetPlatform<int>(url, cancellationToken, content: stream, authToken: authorizationToken?.AccessToken);
    }

    /// <summary>
    ///     Edit group options only available to a founder. You must have suitable permissions in the group to perform this operation.
    /// </summary>
    /// <param name="groupId">Group ID of the group to edit.</param>
    /// <param name="requestBody">Request body</param>
    /// <param name="authorizationToken">Authorization information</param>
    /// <param name="cancellationToken">Method cancellation token</param>
    public async Task<BungieResponse<int>> EditFounderOptions(
        long groupId,
        Models.GroupsV2.GroupOptionsEditAction requestBody,
        AuthorizationTokenData authorizationToken,
        CancellationToken cancellationToken = default
    )
    {
        if (!_configuration.HasSufficientRights(ApplicationScopes.AdminGroups))
            throw new InsufficientScopeException(ApplicationScopes.AdminGroups);

        var url = StringBuilderPool
            .GetBuilder(cancellationToken)
            .Append($"/GroupV2/{groupId}/EditFounderOptions/")
            .Build();
        var stream = new MemoryStream();
        await _serializer.SerializeAsync(stream, requestBody);
        stream.Position = 0;

        return await _dotNetBungieApiHttpClient.PostToBungieNetPlatform<int>(url, cancellationToken, content: stream, authToken: authorizationToken?.AccessToken);
    }

    /// <summary>
    ///     Add a new optional conversation/chat channel. Requires admin permissions to the group.
    /// </summary>
    /// <param name="groupId">Group ID of the group to edit.</param>
    /// <param name="requestBody">Request body</param>
    /// <param name="authorizationToken">Authorization information</param>
    /// <param name="cancellationToken">Method cancellation token</param>
    public async Task<BungieResponse<long>> AddOptionalConversation(
        long groupId,
        Models.GroupsV2.GroupOptionalConversationAddRequest requestBody,
        AuthorizationTokenData authorizationToken,
        CancellationToken cancellationToken = default
    )
    {
        if (!_configuration.HasSufficientRights(ApplicationScopes.AdminGroups))
            throw new InsufficientScopeException(ApplicationScopes.AdminGroups);

        var url = StringBuilderPool
            .GetBuilder(cancellationToken)
            .Append($"/GroupV2/{groupId}/OptionalConversations/Add/")
            .Build();
        var stream = new MemoryStream();
        await _serializer.SerializeAsync(stream, requestBody);
        stream.Position = 0;

        return await _dotNetBungieApiHttpClient.PostToBungieNetPlatform<long>(url, cancellationToken, content: stream, authToken: authorizationToken?.AccessToken);
    }

    /// <summary>
    ///     Edit the settings of an optional conversation/chat channel. Requires admin permissions to the group.
    /// </summary>
    /// <param name="conversationId">Conversation Id of the channel being edited.</param>
    /// <param name="groupId">Group ID of the group to edit.</param>
    /// <param name="requestBody">Request body</param>
    /// <param name="authorizationToken">Authorization information</param>
    /// <param name="cancellationToken">Method cancellation token</param>
    public async Task<BungieResponse<long>> EditOptionalConversation(
        long conversationId,
        long groupId,
        Models.GroupsV2.GroupOptionalConversationEditRequest requestBody,
        AuthorizationTokenData authorizationToken,
        CancellationToken cancellationToken = default
    )
    {
        if (!_configuration.HasSufficientRights(ApplicationScopes.AdminGroups))
            throw new InsufficientScopeException(ApplicationScopes.AdminGroups);

        var url = StringBuilderPool
            .GetBuilder(cancellationToken)
            .Append($"/GroupV2/{groupId}/OptionalConversations/Edit/{conversationId}/")
            .Build();
        var stream = new MemoryStream();
        await _serializer.SerializeAsync(stream, requestBody);
        stream.Position = 0;

        return await _dotNetBungieApiHttpClient.PostToBungieNetPlatform<long>(url, cancellationToken, content: stream, authToken: authorizationToken?.AccessToken);
    }

    /// <summary>
    ///     Get the list of members in a given group.
    /// </summary>
    /// <param name="currentpage">Page number (starting with 1). Each page has a fixed size of 50 items per page.</param>
    /// <param name="groupId">The ID of the group.</param>
    /// <param name="memberType">Filter out other member types. Use None for all members.</param>
    /// <param name="nameSearch">The name fragment upon which a search should be executed for members with matching display or unique names.</param>
    /// <param name="cancellationToken">Method cancellation token</param>
    public async Task<BungieResponse<Models.SearchResultOfGroupMember>> GetMembersOfGroup(
        int currentpage,
        long groupId,
        Models.GroupsV2.RuntimeGroupMemberType memberType,
        string nameSearch,
        CancellationToken cancellationToken = default
    )
    {
        var url = StringBuilderPool
            .GetBuilder(cancellationToken)
            .Append($"/GroupV2/{groupId}/Members/")
            .AddQueryParam("memberType", (int)memberType)
            .AddQueryParam("nameSearch", nameSearch)
            .Build();
        return await _dotNetBungieApiHttpClient.GetFromBungieNetPlatform<Models.SearchResultOfGroupMember>(url, cancellationToken);
    }

    /// <summary>
    ///     Get the list of members in a given group who are of admin level or higher.
    /// </summary>
    /// <param name="currentpage">Page number (starting with 1). Each page has a fixed size of 50 items per page.</param>
    /// <param name="groupId">The ID of the group.</param>
    /// <param name="cancellationToken">Method cancellation token</param>
    public async Task<BungieResponse<Models.SearchResultOfGroupMember>> GetAdminsAndFounderOfGroup(
        int currentpage,
        long groupId,
        CancellationToken cancellationToken = default
    )
    {
        var url = StringBuilderPool
            .GetBuilder(cancellationToken)
            .Append($"/GroupV2/{groupId}/AdminsAndFounder/")
            .Build();
        return await _dotNetBungieApiHttpClient.GetFromBungieNetPlatform<Models.SearchResultOfGroupMember>(url, cancellationToken);
    }

    /// <summary>
    ///     Edit the membership type of a given member. You must have suitable permissions in the group to perform this operation.
    /// </summary>
    /// <param name="groupId">ID of the group to which the member belongs.</param>
    /// <param name="membershipId">Membership ID to modify.</param>
    /// <param name="membershipType">Membership type of the provide membership ID.</param>
    /// <param name="memberType">New membertype for the specified member.</param>
    /// <param name="authorizationToken">Authorization information</param>
    /// <param name="cancellationToken">Method cancellation token</param>
    public async Task<BungieResponse<int>> EditGroupMembership(
        long groupId,
        long membershipId,
        Models.BungieMembershipType membershipType,
        Models.GroupsV2.RuntimeGroupMemberType memberType,
        AuthorizationTokenData authorizationToken,
        CancellationToken cancellationToken = default
    )
    {
        if (!_configuration.HasSufficientRights(ApplicationScopes.AdminGroups))
            throw new InsufficientScopeException(ApplicationScopes.AdminGroups);

        var url = StringBuilderPool
            .GetBuilder(cancellationToken)
            .Append($"/GroupV2/{groupId}/Members/{membershipType}/{membershipId}/SetMembershipType/{memberType}/")
            .Build();
        return await _dotNetBungieApiHttpClient.PostToBungieNetPlatform<int>(url, cancellationToken, authToken: authorizationToken?.AccessToken);
    }

    /// <summary>
    ///     Kick a member from the given group, forcing them to reapply if they wish to re-join the group. You must have suitable permissions in the group to perform this operation.
    /// </summary>
    /// <param name="groupId">Group ID to kick the user from.</param>
    /// <param name="membershipId">Membership ID to kick.</param>
    /// <param name="membershipType">Membership type of the provided membership ID.</param>
    /// <param name="authorizationToken">Authorization information</param>
    /// <param name="cancellationToken">Method cancellation token</param>
    public async Task<BungieResponse<Models.GroupsV2.GroupMemberLeaveResult>> KickMember(
        long groupId,
        long membershipId,
        Models.BungieMembershipType membershipType,
        AuthorizationTokenData authorizationToken,
        CancellationToken cancellationToken = default
    )
    {
        if (!_configuration.HasSufficientRights(ApplicationScopes.AdminGroups))
            throw new InsufficientScopeException(ApplicationScopes.AdminGroups);

        var url = StringBuilderPool
            .GetBuilder(cancellationToken)
            .Append($"/GroupV2/{groupId}/Members/{membershipType}/{membershipId}/Kick/")
            .Build();
        return await _dotNetBungieApiHttpClient.PostToBungieNetPlatform<Models.GroupsV2.GroupMemberLeaveResult>(url, cancellationToken, authToken: authorizationToken?.AccessToken);
    }

    /// <summary>
    ///     Bans the requested member from the requested group for the specified period of time.
    /// </summary>
    /// <param name="groupId">Group ID that has the member to ban.</param>
    /// <param name="membershipId">Membership ID of the member to ban from the group.</param>
    /// <param name="membershipType">Membership type of the provided membership ID.</param>
    /// <param name="requestBody">Request body</param>
    /// <param name="authorizationToken">Authorization information</param>
    /// <param name="cancellationToken">Method cancellation token</param>
    public async Task<BungieResponse<int>> BanMember(
        long groupId,
        long membershipId,
        Models.BungieMembershipType membershipType,
        Models.GroupsV2.GroupBanRequest requestBody,
        AuthorizationTokenData authorizationToken,
        CancellationToken cancellationToken = default
    )
    {
        if (!_configuration.HasSufficientRights(ApplicationScopes.AdminGroups))
            throw new InsufficientScopeException(ApplicationScopes.AdminGroups);

        var url = StringBuilderPool
            .GetBuilder(cancellationToken)
            .Append($"/GroupV2/{groupId}/Members/{membershipType}/{membershipId}/Ban/")
            .Build();
        var stream = new MemoryStream();
        await _serializer.SerializeAsync(stream, requestBody);
        stream.Position = 0;

        return await _dotNetBungieApiHttpClient.PostToBungieNetPlatform<int>(url, cancellationToken, content: stream, authToken: authorizationToken?.AccessToken);
    }

    /// <summary>
    ///     Unbans the requested member, allowing them to re-apply for membership.
    /// </summary>
    /// <param name="groupId"></param>
    /// <param name="membershipId">Membership ID of the member to unban from the group</param>
    /// <param name="membershipType">Membership type of the provided membership ID.</param>
    /// <param name="authorizationToken">Authorization information</param>
    /// <param name="cancellationToken">Method cancellation token</param>
    public async Task<BungieResponse<int>> UnbanMember(
        long groupId,
        long membershipId,
        Models.BungieMembershipType membershipType,
        AuthorizationTokenData authorizationToken,
        CancellationToken cancellationToken = default
    )
    {
        if (!_configuration.HasSufficientRights(ApplicationScopes.AdminGroups))
            throw new InsufficientScopeException(ApplicationScopes.AdminGroups);

        var url = StringBuilderPool
            .GetBuilder(cancellationToken)
            .Append($"/GroupV2/{groupId}/Members/{membershipType}/{membershipId}/Unban/")
            .Build();
        return await _dotNetBungieApiHttpClient.PostToBungieNetPlatform<int>(url, cancellationToken, authToken: authorizationToken?.AccessToken);
    }

    /// <summary>
    ///     Get the list of banned members in a given group. Only accessible to group Admins and above. Not applicable to all groups. Check group features.
    /// </summary>
    /// <param name="currentpage">Page number (starting with 1). Each page has a fixed size of 50 entries.</param>
    /// <param name="groupId">Group ID whose banned members you are fetching</param>
    /// <param name="authorizationToken">Authorization information</param>
    /// <param name="cancellationToken">Method cancellation token</param>
    public async Task<BungieResponse<Models.SearchResultOfGroupBan>> GetBannedMembersOfGroup(
        int currentpage,
        long groupId,
        AuthorizationTokenData authorizationToken,
        CancellationToken cancellationToken = default
    )
    {
        if (!_configuration.HasSufficientRights(ApplicationScopes.AdminGroups))
            throw new InsufficientScopeException(ApplicationScopes.AdminGroups);

        var url = StringBuilderPool
            .GetBuilder(cancellationToken)
            .Append($"/GroupV2/{groupId}/Banned/")
            .Build();
        return await _dotNetBungieApiHttpClient.GetFromBungieNetPlatform<Models.SearchResultOfGroupBan>(url, cancellationToken, authToken: authorizationToken?.AccessToken);
    }

    /// <summary>
    ///     Get the list of edits made to a given group. Only accessible to group Admins and above.
    /// </summary>
    /// <param name="currentpage">Page number (starting with 1). Each page has a fixed size of 50 entries.</param>
    /// <param name="groupId">Group ID whose edit history you are fetching</param>
    /// <param name="authorizationToken">Authorization information</param>
    /// <param name="cancellationToken">Method cancellation token</param>
    public async Task<BungieResponse<Models.SearchResultOfGroupEditHistory>> GetGroupEditHistory(
        int currentpage,
        long groupId,
        AuthorizationTokenData authorizationToken,
        CancellationToken cancellationToken = default
    )
    {
        if (!_configuration.HasSufficientRights(ApplicationScopes.AdminGroups))
            throw new InsufficientScopeException(ApplicationScopes.AdminGroups);

        var url = StringBuilderPool
            .GetBuilder(cancellationToken)
            .Append($"/GroupV2/{groupId}/EditHistory/")
            .Build();
        return await _dotNetBungieApiHttpClient.GetFromBungieNetPlatform<Models.SearchResultOfGroupEditHistory>(url, cancellationToken, authToken: authorizationToken?.AccessToken);
    }

    /// <summary>
    ///     An administrative method to allow the founder of a group or clan to give up their position to another admin permanently.
    /// </summary>
    /// <param name="founderIdNew">The new founder for this group. Must already be a group admin.</param>
    /// <param name="groupId">The target group id.</param>
    /// <param name="membershipType">Membership type of the provided founderIdNew.</param>
    /// <param name="cancellationToken">Method cancellation token</param>
    public async Task<BungieResponse<bool>> AbdicateFoundership(
        long founderIdNew,
        long groupId,
        Models.BungieMembershipType membershipType,
        CancellationToken cancellationToken = default
    )
    {
        var url = StringBuilderPool
            .GetBuilder(cancellationToken)
            .Append($"/GroupV2/{groupId}/Admin/AbdicateFoundership/{membershipType}/{founderIdNew}/")
            .Build();
        return await _dotNetBungieApiHttpClient.PostToBungieNetPlatform<bool>(url, cancellationToken);
    }

    /// <summary>
    ///     Get the list of users who are awaiting a decision on their application to join a given group. Modified to include application info.
    /// </summary>
    /// <param name="currentpage">Page number (starting with 1). Each page has a fixed size of 50 items per page.</param>
    /// <param name="groupId">ID of the group.</param>
    /// <param name="authorizationToken">Authorization information</param>
    /// <param name="cancellationToken">Method cancellation token</param>
    public async Task<BungieResponse<Models.SearchResultOfGroupMemberApplication>> GetPendingMemberships(
        int currentpage,
        long groupId,
        AuthorizationTokenData authorizationToken,
        CancellationToken cancellationToken = default
    )
    {
        if (!_configuration.HasSufficientRights(ApplicationScopes.AdminGroups))
            throw new InsufficientScopeException(ApplicationScopes.AdminGroups);

        var url = StringBuilderPool
            .GetBuilder(cancellationToken)
            .Append($"/GroupV2/{groupId}/Members/Pending/")
            .Build();
        return await _dotNetBungieApiHttpClient.GetFromBungieNetPlatform<Models.SearchResultOfGroupMemberApplication>(url, cancellationToken, authToken: authorizationToken?.AccessToken);
    }

    /// <summary>
    ///     Get the list of users who have been invited into the group.
    /// </summary>
    /// <param name="currentpage">Page number (starting with 1). Each page has a fixed size of 50 items per page.</param>
    /// <param name="groupId">ID of the group.</param>
    /// <param name="authorizationToken">Authorization information</param>
    /// <param name="cancellationToken">Method cancellation token</param>
    public async Task<BungieResponse<Models.SearchResultOfGroupMemberApplication>> GetInvitedIndividuals(
        int currentpage,
        long groupId,
        AuthorizationTokenData authorizationToken,
        CancellationToken cancellationToken = default
    )
    {
        if (!_configuration.HasSufficientRights(ApplicationScopes.AdminGroups))
            throw new InsufficientScopeException(ApplicationScopes.AdminGroups);

        var url = StringBuilderPool
            .GetBuilder(cancellationToken)
            .Append($"/GroupV2/{groupId}/Members/InvitedIndividuals/")
            .Build();
        return await _dotNetBungieApiHttpClient.GetFromBungieNetPlatform<Models.SearchResultOfGroupMemberApplication>(url, cancellationToken, authToken: authorizationToken?.AccessToken);
    }

    /// <summary>
    ///     Approve all of the pending users for the given group.
    /// </summary>
    /// <param name="groupId">ID of the group.</param>
    /// <param name="requestBody">Request body</param>
    /// <param name="authorizationToken">Authorization information</param>
    /// <param name="cancellationToken">Method cancellation token</param>
    public async Task<BungieResponse<Models.Entities.EntityActionResult[]>> ApproveAllPending(
        long groupId,
        Models.GroupsV2.GroupApplicationRequest requestBody,
        AuthorizationTokenData authorizationToken,
        CancellationToken cancellationToken = default
    )
    {
        if (!_configuration.HasSufficientRights(ApplicationScopes.AdminGroups))
            throw new InsufficientScopeException(ApplicationScopes.AdminGroups);

        var url = StringBuilderPool
            .GetBuilder(cancellationToken)
            .Append($"/GroupV2/{groupId}/Members/ApproveAll/")
            .Build();
        var stream = new MemoryStream();
        await _serializer.SerializeAsync(stream, requestBody);
        stream.Position = 0;

        return await _dotNetBungieApiHttpClient.PostToBungieNetPlatform<Models.Entities.EntityActionResult[]>(url, cancellationToken, content: stream, authToken: authorizationToken?.AccessToken);
    }

    /// <summary>
    ///     Deny all of the pending users for the given group.
    /// </summary>
    /// <param name="groupId">ID of the group.</param>
    /// <param name="requestBody">Request body</param>
    /// <param name="authorizationToken">Authorization information</param>
    /// <param name="cancellationToken">Method cancellation token</param>
    public async Task<BungieResponse<Models.Entities.EntityActionResult[]>> DenyAllPending(
        long groupId,
        Models.GroupsV2.GroupApplicationRequest requestBody,
        AuthorizationTokenData authorizationToken,
        CancellationToken cancellationToken = default
    )
    {
        if (!_configuration.HasSufficientRights(ApplicationScopes.AdminGroups))
            throw new InsufficientScopeException(ApplicationScopes.AdminGroups);

        var url = StringBuilderPool
            .GetBuilder(cancellationToken)
            .Append($"/GroupV2/{groupId}/Members/DenyAll/")
            .Build();
        var stream = new MemoryStream();
        await _serializer.SerializeAsync(stream, requestBody);
        stream.Position = 0;

        return await _dotNetBungieApiHttpClient.PostToBungieNetPlatform<Models.Entities.EntityActionResult[]>(url, cancellationToken, content: stream, authToken: authorizationToken?.AccessToken);
    }

    /// <summary>
    ///     Approve all of the pending users for the given group.
    /// </summary>
    /// <param name="groupId">ID of the group.</param>
    /// <param name="requestBody">Request body</param>
    /// <param name="authorizationToken">Authorization information</param>
    /// <param name="cancellationToken">Method cancellation token</param>
    public async Task<BungieResponse<Models.Entities.EntityActionResult[]>> ApprovePendingForList(
        long groupId,
        Models.GroupsV2.GroupApplicationListRequest requestBody,
        AuthorizationTokenData authorizationToken,
        CancellationToken cancellationToken = default
    )
    {
        if (!_configuration.HasSufficientRights(ApplicationScopes.AdminGroups))
            throw new InsufficientScopeException(ApplicationScopes.AdminGroups);

        var url = StringBuilderPool
            .GetBuilder(cancellationToken)
            .Append($"/GroupV2/{groupId}/Members/ApproveList/")
            .Build();
        var stream = new MemoryStream();
        await _serializer.SerializeAsync(stream, requestBody);
        stream.Position = 0;

        return await _dotNetBungieApiHttpClient.PostToBungieNetPlatform<Models.Entities.EntityActionResult[]>(url, cancellationToken, content: stream, authToken: authorizationToken?.AccessToken);
    }

    /// <summary>
    ///     Approve the given membershipId to join the group/clan as long as they have applied.
    /// </summary>
    /// <param name="groupId">ID of the group.</param>
    /// <param name="membershipId">The membership id being approved.</param>
    /// <param name="membershipType">Membership type of the supplied membership ID.</param>
    /// <param name="requestBody">Request body</param>
    /// <param name="authorizationToken">Authorization information</param>
    /// <param name="cancellationToken">Method cancellation token</param>
    public async Task<BungieResponse<bool>> ApprovePending(
        long groupId,
        long membershipId,
        Models.BungieMembershipType membershipType,
        Models.GroupsV2.GroupApplicationRequest requestBody,
        AuthorizationTokenData authorizationToken,
        CancellationToken cancellationToken = default
    )
    {
        if (!_configuration.HasSufficientRights(ApplicationScopes.AdminGroups))
            throw new InsufficientScopeException(ApplicationScopes.AdminGroups);

        var url = StringBuilderPool
            .GetBuilder(cancellationToken)
            .Append($"/GroupV2/{groupId}/Members/Approve/{membershipType}/{membershipId}/")
            .Build();
        var stream = new MemoryStream();
        await _serializer.SerializeAsync(stream, requestBody);
        stream.Position = 0;

        return await _dotNetBungieApiHttpClient.PostToBungieNetPlatform<bool>(url, cancellationToken, content: stream, authToken: authorizationToken?.AccessToken);
    }

    /// <summary>
    ///     Deny all of the pending users for the given group that match the passed-in .
    /// </summary>
    /// <param name="groupId">ID of the group.</param>
    /// <param name="requestBody">Request body</param>
    /// <param name="authorizationToken">Authorization information</param>
    /// <param name="cancellationToken">Method cancellation token</param>
    public async Task<BungieResponse<Models.Entities.EntityActionResult[]>> DenyPendingForList(
        long groupId,
        Models.GroupsV2.GroupApplicationListRequest requestBody,
        AuthorizationTokenData authorizationToken,
        CancellationToken cancellationToken = default
    )
    {
        if (!_configuration.HasSufficientRights(ApplicationScopes.AdminGroups))
            throw new InsufficientScopeException(ApplicationScopes.AdminGroups);

        var url = StringBuilderPool
            .GetBuilder(cancellationToken)
            .Append($"/GroupV2/{groupId}/Members/DenyList/")
            .Build();
        var stream = new MemoryStream();
        await _serializer.SerializeAsync(stream, requestBody);
        stream.Position = 0;

        return await _dotNetBungieApiHttpClient.PostToBungieNetPlatform<Models.Entities.EntityActionResult[]>(url, cancellationToken, content: stream, authToken: authorizationToken?.AccessToken);
    }

    /// <summary>
    ///     Get information about the groups that a given member has joined.
    /// </summary>
    /// <param name="filter">Filter apply to list of joined groups.</param>
    /// <param name="groupType">Type of group the supplied member founded.</param>
    /// <param name="membershipId">Membership ID to for which to find founded groups.</param>
    /// <param name="membershipType">Membership type of the supplied membership ID.</param>
    /// <param name="cancellationToken">Method cancellation token</param>
    public async Task<BungieResponse<Models.GroupsV2.GetGroupsForMemberResponse>> GetGroupsForMember(
        Models.GroupsV2.GroupsForMemberFilter filter,
        Models.GroupsV2.GroupType groupType,
        long membershipId,
        Models.BungieMembershipType membershipType,
        CancellationToken cancellationToken = default
    )
    {
        var url = StringBuilderPool
            .GetBuilder(cancellationToken)
            .Append($"/GroupV2/User/{membershipType}/{membershipId}/{filter}/{groupType}/")
            .Build();
        return await _dotNetBungieApiHttpClient.GetFromBungieNetPlatform<Models.GroupsV2.GetGroupsForMemberResponse>(url, cancellationToken);
    }

    /// <summary>
    ///     Allows a founder to manually recover a group they can see in game but not on bungie.net
    /// </summary>
    /// <param name="groupType">Type of group the supplied member founded.</param>
    /// <param name="membershipId">Membership ID to for which to find founded groups.</param>
    /// <param name="membershipType">Membership type of the supplied membership ID.</param>
    /// <param name="cancellationToken">Method cancellation token</param>
    public async Task<BungieResponse<Models.GroupsV2.GroupMembershipSearchResponse>> RecoverGroupForFounder(
        Models.GroupsV2.GroupType groupType,
        long membershipId,
        Models.BungieMembershipType membershipType,
        CancellationToken cancellationToken = default
    )
    {
        var url = StringBuilderPool
            .GetBuilder(cancellationToken)
            .Append($"/GroupV2/Recover/{membershipType}/{membershipId}/{groupType}/")
            .Build();
        return await _dotNetBungieApiHttpClient.GetFromBungieNetPlatform<Models.GroupsV2.GroupMembershipSearchResponse>(url, cancellationToken);
    }

    /// <summary>
    ///     Get information about the groups that a given member has applied to or been invited to.
    /// </summary>
    /// <param name="filter">Filter apply to list of potential joined groups.</param>
    /// <param name="groupType">Type of group the supplied member applied.</param>
    /// <param name="membershipId">Membership ID to for which to find applied groups.</param>
    /// <param name="membershipType">Membership type of the supplied membership ID.</param>
    /// <param name="cancellationToken">Method cancellation token</param>
    public async Task<BungieResponse<Models.GroupsV2.GroupPotentialMembershipSearchResponse>> GetPotentialGroupsForMember(
        Models.GroupsV2.GroupPotentialMemberStatus filter,
        Models.GroupsV2.GroupType groupType,
        long membershipId,
        Models.BungieMembershipType membershipType,
        CancellationToken cancellationToken = default
    )
    {
        var url = StringBuilderPool
            .GetBuilder(cancellationToken)
            .Append($"/GroupV2/User/Potential/{membershipType}/{membershipId}/{filter}/{groupType}/")
            .Build();
        return await _dotNetBungieApiHttpClient.GetFromBungieNetPlatform<Models.GroupsV2.GroupPotentialMembershipSearchResponse>(url, cancellationToken);
    }

    /// <summary>
    ///     Invite a user to join this group.
    /// </summary>
    /// <param name="groupId">ID of the group you would like to join.</param>
    /// <param name="membershipId">Membership id of the account being invited.</param>
    /// <param name="membershipType">MembershipType of the account being invited.</param>
    /// <param name="requestBody">Request body</param>
    /// <param name="authorizationToken">Authorization information</param>
    /// <param name="cancellationToken">Method cancellation token</param>
    public async Task<BungieResponse<Models.GroupsV2.GroupApplicationResponse>> IndividualGroupInvite(
        long groupId,
        long membershipId,
        Models.BungieMembershipType membershipType,
        Models.GroupsV2.GroupApplicationRequest requestBody,
        AuthorizationTokenData authorizationToken,
        CancellationToken cancellationToken = default
    )
    {
        if (!_configuration.HasSufficientRights(ApplicationScopes.AdminGroups))
            throw new InsufficientScopeException(ApplicationScopes.AdminGroups);

        var url = StringBuilderPool
            .GetBuilder(cancellationToken)
            .Append($"/GroupV2/{groupId}/Members/IndividualInvite/{membershipType}/{membershipId}/")
            .Build();
        var stream = new MemoryStream();
        await _serializer.SerializeAsync(stream, requestBody);
        stream.Position = 0;

        return await _dotNetBungieApiHttpClient.PostToBungieNetPlatform<Models.GroupsV2.GroupApplicationResponse>(url, cancellationToken, content: stream, authToken: authorizationToken?.AccessToken);
    }

    /// <summary>
    ///     Cancels a pending invitation to join a group.
    /// </summary>
    /// <param name="groupId">ID of the group you would like to join.</param>
    /// <param name="membershipId">Membership id of the account being cancelled.</param>
    /// <param name="membershipType">MembershipType of the account being cancelled.</param>
    /// <param name="authorizationToken">Authorization information</param>
    /// <param name="cancellationToken">Method cancellation token</param>
    public async Task<BungieResponse<Models.GroupsV2.GroupApplicationResponse>> IndividualGroupInviteCancel(
        long groupId,
        long membershipId,
        Models.BungieMembershipType membershipType,
        AuthorizationTokenData authorizationToken,
        CancellationToken cancellationToken = default
    )
    {
        if (!_configuration.HasSufficientRights(ApplicationScopes.AdminGroups))
            throw new InsufficientScopeException(ApplicationScopes.AdminGroups);

        var url = StringBuilderPool
            .GetBuilder(cancellationToken)
            .Append($"/GroupV2/{groupId}/Members/IndividualInviteCancel/{membershipType}/{membershipId}/")
            .Build();
        return await _dotNetBungieApiHttpClient.PostToBungieNetPlatform<Models.GroupsV2.GroupApplicationResponse>(url, cancellationToken, authToken: authorizationToken?.AccessToken);
    }

}
