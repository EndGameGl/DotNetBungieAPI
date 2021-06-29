using NetBungieAPI.Services.ApiAccess.Interfaces;

namespace NetBungieAPI.Services.Interfaces
{
    public interface IBungieApiAccess
    {
        IAppMethodsAccess App { get; init; }
        IUserMethodsAccess User { get; init; }
        IContentMethodsAccess Content { get; init; }
        IForumMethodsAccess Forum { get; init; }
        IGroupV2MethodsAccess GroupV2 { get; init; }
        ITokenMethodsAccess Tokens { get; init; }
        IDestiny2MethodsAccess Destiny2 { get; init; }
        ICommunityContentMethodsAccess Community { get; init; }
        ITrendingMethodsAccess Trending { get; init; }
        IFireteamMethodsAccess Fireteam { get; init; }
        IMiscMethodsAccess Misc { get; init; }
    }
}