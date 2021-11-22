namespace DotNetBungieAPI.Models.GroupsV2
{
    public record GroupMembershipBase
    {
        [JsonPropertyName("group")] public GroupV2 Group { get; init; }
    }
}