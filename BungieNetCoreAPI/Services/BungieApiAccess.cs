using NetBungieAPI.Services.ApiAccess.Interfaces;
using NetBungieAPI.Services.Interfaces;

namespace NetBungieAPI.Services
{
    public class BungieApiAccess : IBungieApiAccess
    {
        public IAppMethodsAccess App { get; }
        public IUserMethodsAccess User { get; }
        public IContentMethodsAccess Content { get; }
        public IForumMethodsAccess Forum { get; }
        public IGroupV2MethodsAccess GroupV2 { get; }
        public ITokenMethodsAccess Tokens { get; }
        public IDestiny2MethodsAccess Destiny2 { get; }
        public ICommunityContentMethodsAccess Community { get; }
        public ITrendingMethodsAccess Trending { get; }
        public IFireteamMethodsAccess Fireteam { get; }
        public IMiscMethodsAccess Misc { get; }

        internal BungieApiAccess(IFireteamMethodsAccess fireteamMethodsAccess, IContentMethodsAccess contentMethodsAccess,
            IAppMethodsAccess appMethodsAccess, IForumMethodsAccess forumMethodsAccess, IUserMethodsAccess userMethodsAccess,
            IGroupV2MethodsAccess groupV2MethodsAccess, ITokenMethodsAccess tokenMethodsAccess, IDestiny2MethodsAccess destiny2MethodsAccess,
            ICommunityContentMethodsAccess communityContentMethodsAccess, ITrendingMethodsAccess trendingMethodsAccess,
            IMiscMethodsAccess miscMethodsAccess)
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
            Misc = miscMethodsAccess;
        }

        public static IBungieApiAccess Create() => StaticUnityContainer.GetService<IBungieApiAccess>();
    }
}
