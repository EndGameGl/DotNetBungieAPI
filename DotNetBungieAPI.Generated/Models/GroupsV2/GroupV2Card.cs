namespace DotNetBungieAPI.Generated.Models.GroupsV2;

/// <summary>
///     A small infocard of group information, usually used for when a list of groups are returned
/// </summary>
public class GroupV2Card : IDeepEquatable<GroupV2Card>
{
    [JsonPropertyName("groupId")]
    public long GroupId { get; set; }

    [JsonPropertyName("name")]
    public string Name { get; set; }

    [JsonPropertyName("groupType")]
    public GroupsV2.GroupType GroupType { get; set; }

    [JsonPropertyName("creationDate")]
    public DateTime CreationDate { get; set; }

    [JsonPropertyName("about")]
    public string About { get; set; }

    [JsonPropertyName("motto")]
    public string Motto { get; set; }

    [JsonPropertyName("memberCount")]
    public int MemberCount { get; set; }

    [JsonPropertyName("locale")]
    public string Locale { get; set; }

    [JsonPropertyName("membershipOption")]
    public GroupsV2.MembershipOption MembershipOption { get; set; }

    [JsonPropertyName("capabilities")]
    public GroupsV2.Capabilities Capabilities { get; set; }

    [JsonPropertyName("clanInfo")]
    public GroupsV2.GroupV2ClanInfo ClanInfo { get; set; }

    [JsonPropertyName("avatarPath")]
    public string AvatarPath { get; set; }

    [JsonPropertyName("theme")]
    public string Theme { get; set; }

    public bool DeepEquals(GroupV2Card? other)
    {
        return other is not null &&
               GroupId == other.GroupId &&
               Name == other.Name &&
               GroupType == other.GroupType &&
               CreationDate == other.CreationDate &&
               About == other.About &&
               Motto == other.Motto &&
               MemberCount == other.MemberCount &&
               Locale == other.Locale &&
               MembershipOption == other.MembershipOption &&
               Capabilities == other.Capabilities &&
               (ClanInfo is not null ? ClanInfo.DeepEquals(other.ClanInfo) : other.ClanInfo is null) &&
               AvatarPath == other.AvatarPath &&
               Theme == other.Theme;
    }
}