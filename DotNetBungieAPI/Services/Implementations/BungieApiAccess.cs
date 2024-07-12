using DotNetBungieAPI.Service.Abstractions;
using DotNetBungieAPI.Service.Abstractions.ApiAccess;

namespace DotNetBungieAPI.Services.Implementations;

internal sealed class BungieApiAccess : IBungieApiAccess
{
    public BungieApiAccess(
        IFireteamMethodsAccess fireteamMethodsAccess,
        IContentMethodsAccess contentMethodsAccess,
        IAppMethodsAccess appMethodsAccess,
        IForumMethodsAccess forumMethodsAccess,
        IUserMethodsAccess userMethodsAccess,
        IGroupV2MethodsAccess groupV2MethodsAccess,
        ITokensMethodsAccess tokenMethodsAccess,
        IDestiny2MethodsAccess destiny2MethodsAccess,
        ICommunityContentMethodsAccess communityContentMethodsAccess,
        ITrendingMethodsAccess trendingMethodsAccess,
        IMiscMethodsAccess miscMethodsAccess,
        IFireteamFinderMethodsAccess fireteamFinderMethodsAccess,
        ISocialMethodsAccess socialMethodsAccess,
        IRenderApiAccess renderApiAccess
    )
    {
        App = appMethodsAccess;
        User = userMethodsAccess;
        Content = contentMethodsAccess;
        Forum = forumMethodsAccess;
        GroupV2 = groupV2MethodsAccess;
        Tokens = tokenMethodsAccess;
        Destiny2 = destiny2MethodsAccess;
        Community = communityContentMethodsAccess;
        Trending = trendingMethodsAccess;
        Fireteam = fireteamMethodsAccess;
        FireteamFinder = fireteamFinderMethodsAccess;
        Misc = miscMethodsAccess;
        Social = socialMethodsAccess;
        RenderApi = renderApiAccess;
    }

    public IAppMethodsAccess App { get; }
    public IUserMethodsAccess User { get; }
    public IContentMethodsAccess Content { get; }
    public IForumMethodsAccess Forum { get; }
    public IGroupV2MethodsAccess GroupV2 { get; }
    public ITokensMethodsAccess Tokens { get; }
    public IDestiny2MethodsAccess Destiny2 { get; }
    public ICommunityContentMethodsAccess Community { get; }
    public ITrendingMethodsAccess Trending { get; }
    public IFireteamMethodsAccess Fireteam { get; }
    public IFireteamFinderMethodsAccess FireteamFinder { get; }
    public ISocialMethodsAccess Social { get; }
    public IMiscMethodsAccess Misc { get; }
    public IRenderApiAccess RenderApi { get; }
}
