using System.Threading.Tasks;
using NetBungieAPI.Repositories;
using NetBungieAPI.Services.UserScopedApiAccess;

namespace NetBungieAPI.Clients
{
    public interface IUserContextBungieClient
    {
        ILocalisedDestinyDefinitionRepositories Repository { get; }
        UserScopedAppMethodsAccess App { get; }
        UserScopedUserMethodsAccess User { get; }
        UserScopedTrendingMethodsAccess Trending { get; }
        UserScopedTokenMethodsAccess Tokens { get; }
        UserScopedMiscMethodsAccess Misc { get; }
        UserScopedGroupV2MethodsAccess GroupV2 { get; }
        UsedScopedForumMethodsAccess Forum { get; }
        UserScopedFireteamMethodsAccess Fireteam { get; }
        UserScopedContentMethodsAccess Content { get; }
        UserScopedCommunityContentMethodsAccess CommunityContent { get; }
        UserScopedDestiny2MethodsAccess Destiny2 { get; }
        Task ValidateToken();
    }
}