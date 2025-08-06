namespace DotNetBungieAPI.Models.GroupsV2;

/// <summary>
///     A small infocard of group information, usually used for when a list of groups are returned
/// </summary>
public sealed class GroupV2Card
{
    [JsonPropertyName("groupId")]
    public long GroupId { get; init; }

    [JsonPropertyName("name")]
    public string Name { get; init; }

    [JsonPropertyName("groupType")]
    public GroupsV2.GroupType GroupType { get; init; }

    [JsonPropertyName("creationDate")]
    public DateTime CreationDate { get; init; }

    [JsonPropertyName("about")]
    public string About { get; init; }

    [JsonPropertyName("motto")]
    public string Motto { get; init; }

    [JsonPropertyName("memberCount")]
    public int MemberCount { get; init; }

    [JsonPropertyName("locale")]
    public string Locale { get; init; }

    [JsonPropertyName("membershipOption")]
    public GroupsV2.MembershipOption MembershipOption { get; init; }

    [JsonPropertyName("capabilities")]
    public GroupsV2.Capabilities Capabilities { get; init; }

    [JsonPropertyName("remoteGroupId")]
    public long? RemoteGroupId { get; init; }

    [JsonPropertyName("clanInfo")]
    public GroupsV2.GroupV2ClanInfo? ClanInfo { get; init; }

    [JsonPropertyName("avatarPath")]
    public string AvatarPath { get; init; }

    [JsonPropertyName("theme")]
    public string Theme { get; init; }
}
