using NetBungieAPI.Models.GroupsV2;
using System.Text.Json.Serialization;

namespace NetBungieAPI.Models.Queries
{
    public class GroupNameSearchRequest
    {
        [JsonPropertyName("groupName")]
        public string GroupName { get; init; }

        [JsonPropertyName("groupType")]
        public GroupType GroupType { get; init; }
    }
}
