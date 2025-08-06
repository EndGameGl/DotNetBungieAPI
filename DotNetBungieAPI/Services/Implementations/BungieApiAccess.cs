using DotNetBungieAPI.Service.Abstractions;
using DotNetBungieAPI.Service.Abstractions.ApiAccess;

namespace DotNetBungieAPI.Services.Implementations;

internal sealed class BungieApiAccess : IBungieApiAccess
{
    public IAppApi App { get; }
    public IUserApi User { get; }
    public IContentApi Content { get; }
    public IForumApi Forum { get; }
    public IGroupV2Api GroupV2 { get; }
    public ITokensApi Tokens { get; }
    public IDestiny2Api Destiny2 { get; }
    public ICommunityContentApi Community { get; }
    public ITrendingApi Trending { get; }
    public IFireteamApi Fireteam { get; }
    public ISocialApi Social { get; }
    public IMiscApi Misc { get; }

    public BungieApiAccess(
        IAppApi app,
        IUserApi user,
        IContentApi content,
        IForumApi forum,
        IGroupV2Api groupV2,
        ITokensApi tokens,
        IDestiny2Api destiny2,
        ICommunityContentApi community,
        ITrendingApi trending,
        IFireteamApi fireteam,
        ISocialApi social,
        IMiscApi misc
    )
    {
        App = app;
        User = user;
        Content = content;
        Forum = forum;
        GroupV2 = groupV2;
        Tokens = tokens;
        Destiny2 = destiny2;
        Community = community;
        Trending = trending;
        Fireteam = fireteam;
        Social = social;
        Misc = misc;
    }
}
