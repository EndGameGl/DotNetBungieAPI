using System.Text.Json.Serialization;

namespace DotNetBungieAPI.Generated.Models.User;

public sealed class UserMembershipData
{

    [JsonPropertyName("destinyMemberships")]
    public List<GroupsV2.GroupUserInfoCard> DestinyMemberships { get; init; }

    [JsonPropertyName("primaryMembershipId")]
    public long? PrimaryMembershipId { get; init; }

    [JsonPropertyName("bungieNetUser")]
    public User.GeneralUser BungieNetUser { get; init; }
}
