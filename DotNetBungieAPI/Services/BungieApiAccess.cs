using DotNetBungieAPI.Services.ApiAccess.Interfaces;
using DotNetBungieAPI.Services.Interfaces;

namespace DotNetBungieAPI.Services
{
    public class BungieApiAccess : IBungieApiAccess
    {
        internal BungieApiAccess(
            IFireteamMethodsAccess fireteamMethodsAccess,
            IContentMethodsAccess contentMethodsAccess,
            IAppMethodsAccess appMethodsAccess,
            IForumMethodsAccess forumMethodsAccess,
            IUserMethodsAccess userMethodsAccess,
            IGroupV2MethodsAccess groupV2MethodsAccess,
            ITokenMethodsAccess tokenMethodsAccess,
            IDestiny2MethodsAccess destiny2MethodsAccess,
            ICommunityContentMethodsAccess communityContentMethodsAccess,
            ITrendingMethodsAccess trendingMethodsAccess,
            IMiscMethodsAccess miscMethodsAccess,
            ISocialMethodsAccess socialMethodsAccess)
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
            Social = socialMethodsAccess;
        }

        public IAppMethodsAccess App { get; init; }
        public IUserMethodsAccess User { get; init; }
        public IContentMethodsAccess Content { get; init; }
        public IForumMethodsAccess Forum { get; init; }
        public IGroupV2MethodsAccess GroupV2 { get; init; }
        public ITokenMethodsAccess Tokens { get; init; }
        public IDestiny2MethodsAccess Destiny2 { get; init; }
        public ICommunityContentMethodsAccess Community { get; init; }
        public ITrendingMethodsAccess Trending { get; init; }
        public IFireteamMethodsAccess Fireteam { get; init; }
        public ISocialMethodsAccess Social { get; init; }
        public IMiscMethodsAccess Misc { get; init; }

        public static IBungieApiAccess Create()
        {
            return StaticUnityContainer.GetService<IBungieApiAccess>();
        }
    }
}