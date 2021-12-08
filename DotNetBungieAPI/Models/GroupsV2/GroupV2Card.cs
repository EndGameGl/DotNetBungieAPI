namespace DotNetBungieAPI.Models.GroupsV2;

public record GroupV2Card
{
    [JsonPropertyName("groupId")] public long GroupId { get; init; }

    [JsonPropertyName("name")] public string Name { get; init; }

    [JsonPropertyName("groupType")] public GroupType GroupType { get; init; }

    [JsonPropertyName("creationDate")] public DateTime CreationDate { get; init; }

    [JsonPropertyName("about")] public string About { get; init; }

    [JsonPropertyName("motto")] public string Motto { get; init; }

    [JsonPropertyName("memberCount")] public int MemberCount { get; init; }

    [JsonPropertyName("locale")] public string Locale { get; init; }

    [JsonPropertyName("membershipOption")] public MembershipOption MembershipOption { get; init; }

    [JsonPropertyName("capabilities")] public Capabilities Capabilities { get; init; }

    [JsonPropertyName("clanInfo")] public GroupV2ClanInfo ClanInfo { get; init; }

    [JsonPropertyName("avatarPath")] public string AvatarPath { get; init; }

    [JsonPropertyName("theme")] public string Theme { get; init; }
}