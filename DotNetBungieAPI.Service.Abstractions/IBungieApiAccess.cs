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
    IAppApi App { get; }

    /// <summary>
    ///     Access to https://bungie.net/Platform/User endpoint
    /// </summary>
    IUserApi User { get; }

    /// <summary>
    ///     Access to https://bungie.net/Platform/Content endpoint
    /// </summary>
    IContentApi Content { get; }

    /// <summary>
    ///     Access to https://bungie.net/Platform/Forum endpoint
    /// </summary>
    IForumApi Forum { get; }

    /// <summary>
    ///     Access to https://bungie.net/Platform/GroupV2 endpoint
    /// </summary>
    IGroupV2Api GroupV2 { get; }

    /// <summary>
    ///     Access to https://bungie.net/Platform/Tokens endpoint
    /// </summary>
    ITokensApi Tokens { get; }

    /// <summary>
    ///     Access to https://bungie.net/Platform/Destiny2 endpoint
    /// </summary>
    IDestiny2Api Destiny2 { get; }

    /// <summary>
    ///     Access to https://bungie.net/Platform/CommunityContent endpoint
    /// </summary>
    ICommunityContentApi Community { get; }

    /// <summary>
    ///     Access to https://bungie.net/Platform/Trending endpoint
    /// </summary>
    ITrendingApi Trending { get; }

    /// <summary>
    ///     Access to https://bungie.net/Platform/Fireteam endpoint
    /// </summary>
    IFireteamApi Fireteam { get; }

    /// <summary>
    ///     Access to https://bungie.net/Platform/Social endpoint
    /// </summary>
    ISocialApi Social { get; }

    /// <summary>
    ///     Access to unclassified endpoints
    /// </summary>
    IMiscApi Misc { get; }
}
