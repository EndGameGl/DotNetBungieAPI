using NetBungieAPI.Services.ApiAccess.Interfaces;

namespace NetBungieAPI.Services.Interfaces
{
    /// <summary>
    /// Access interface for all API methods
    /// </summary>
    public interface IBungieApiAccess
    {
        /// <summary>
        /// Access to https://bungie.net/Platform/App endpoint
        /// </summary>
        IAppMethodsAccess App { get; init; }

        /// <summary>
        /// Access to https://bungie.net/Platform/User endpoint
        /// </summary>
        IUserMethodsAccess User { get; init; }

        /// <summary>
        /// Access to https://bungie.net/Platform/Content endpoint
        /// </summary>
        IContentMethodsAccess Content { get; init; }

        /// <summary>
        /// Access to https://bungie.net/Platform/Forum endpoint
        /// </summary>
        IForumMethodsAccess Forum { get; init; }

        /// <summary>
        /// Access to https://bungie.net/Platform/GroupV2 endpoint
        /// </summary>
        IGroupV2MethodsAccess GroupV2 { get; init; }

        /// <summary>
        /// Access to https://bungie.net/Platform/Tokens endpoint
        /// </summary>
        ITokenMethodsAccess Tokens { get; init; }

        /// <summary>
        /// Access to https://bungie.net/Platform/Destiny2 endpoint
        /// </summary>
        IDestiny2MethodsAccess Destiny2 { get; init; }

        /// <summary>
        /// Access to https://bungie.net/Platform/CommunityContent endpoint
        /// </summary>
        ICommunityContentMethodsAccess Community { get; init; }

        /// <summary>
        /// Access to https://bungie.net/Platform/Trending endpoint
        /// </summary>
        ITrendingMethodsAccess Trending { get; init; }

        /// <summary>
        /// Access to https://bungie.net/Platform/Fireteam endpoint
        /// </summary>
        IFireteamMethodsAccess Fireteam { get; init; }

        /// <summary>
        /// Access to https://bungie.net/Platform/Social endpoint
        /// </summary>
        ISocialMethodsAccess Social { get; init; }

        /// <summary>
        /// Access to unclassified endpoints
        /// </summary>
        IMiscMethodsAccess Misc { get; init; }
    }
}