using DotNetBungieAPI.Models;
using DotNetBungieAPI.Models.Destiny.Responses;
using DotNetBungieAPI.Models.User;

namespace DotNetBungieAPI.Data.Models.Profiles;

public class BungieNetProfile
{
    public UserMembershipData MembershipData { get; internal set; }
    public List<DestinyProfileAndCharacters> Profiles { get; } = new();

    public DestinyProfileAndCharacters this[BungieMembershipType bungieMembershipType]
    {
        get => Profiles.FirstOrDefault(x => x.Profile.UserInfo.MembershipType == bungieMembershipType);
    }
}