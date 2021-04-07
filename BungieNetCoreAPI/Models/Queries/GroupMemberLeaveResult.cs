using NetBungieAPI.Models.GroupsV2;
using System.Text.Json.Serialization;

namespace NetBungieAPI.Models.Queries
{
    public sealed record GroupMemberLeaveResult
    {
        [JsonPropertyName("group")]
        public GroupV2 Group { get; init; }

        [JsonPropertyName("groupDeleted")]
        public bool GroupDeleted { get; init; }
    }
}
