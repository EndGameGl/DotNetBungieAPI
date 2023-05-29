using DotNetBungieAPI.Service.Abstractions.ApiAccess;

namespace DotNetBungieAPI.Service.Abstractions;

/// <summary>
///     Access interface for all API methods
/// </summary>
public interface IBungieApiAccess
{
    /// <summary>
    ///     Access to https://bungie.net/Platform/App endpoint
    /// </summary>
    IAppMethodsAccess App { get; }

    /// <summary>
    ///     Access to https://bungie.net/Platform/User endpoint
    /// </summary>
    IUserMethodsAccess User { get; }

    /// <summary>
    ///     Access to https://bungie.net/Platform/Content endpoint
    /// </summary>
    IContentMethodsAccess Content { get; }

    /// <summary>
    ///     Access to https://bungie.net/Platform/Forum endpoint
    /// </summary>
    IForumMethodsAccess Forum { get; }

    /// <summary>
    ///     Access to https://bungie.net/Platform/GroupV2 endpoint
    /// </summary>
    IGroupV2MethodsAccess GroupV2 { get; }

    /// <summary>
    ///     Access to https://bungie.net/Platform/Tokens endpoint
    /// </summary>
    ITokensMethodsAccess Tokens { get; }

    /// <summary>
    ///     Access to https://bungie.net/Platform/Destiny2 endpoint
    /// </summary>
    IDestiny2MethodsAccess Destiny2 { get; }

    /// <summary>
    ///     Access to https://bungie.net/Platform/CommunityContent endpoint
    /// </summary>
    ICommunityContentMethodsAccess Community { get; }

    /// <summary>
    ///     Access to https://bungie.net/Platform/Trending endpoint
    /// </summary>
    ITrendingMethodsAccess Trending { get; }

    /// <summary>
    ///     Access to https://bungie.net/Platform/Fireteam endpoint
    /// </summary>
    IFireteamMethodsAccess Fireteam { get; }

    /// <summary>
    ///     Access to https://bungie.net/Platform/Social endpoint
    /// </summary>
    ISocialMethodsAccess Social { get; }

    /// <summary>
    ///     Access to unclassified endpoints
    /// </summary>
    IMiscMethodsAccess Misc { get; }

    /// <summary>
    ///     Unfinished api to get data related to rendering
    /// </summary>
    IRenderApiAccess RenderApi { get; }
}
