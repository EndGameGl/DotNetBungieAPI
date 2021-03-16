using NetBungieAPI.Services.ApiAccess.Interfaces;

namespace NetBungieAPI.Services.Interfaces
{
    public interface IBungieApiAccess
    {
        IAppMethodsAccess App { get; }
        IUserMethodsAccess User { get; }
        IContentMethodsAccess Content { get; }
        IForumMethodsAccess Forum { get; }
        IGroupV2MethodsAccess GroupV2 { get; }
        ITokenMethodsAccess Tokens { get; }
        IDestiny2MethodsAccess Destiny2 { get; }
        ICommunityContentMethodsAccess Community { get; }
        ITrendingMethodsAccess Trending { get; }
        IFireteamMethodsAccess Fireteam { get; }
        IMiscMethodsAccess Misc { get; }
    }
}
