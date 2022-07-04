using DotNetBungieAPI.Models.GroupsV2;

namespace DotNetBungieAPI.Models.Queries;

public sealed record GroupMemberLeaveResult
{
    [JsonPropertyName("group")] public GroupV2 Group { get; init; }

    [JsonPropertyName("groupDeleted")] public bool GroupDeleted { get; init; }
}