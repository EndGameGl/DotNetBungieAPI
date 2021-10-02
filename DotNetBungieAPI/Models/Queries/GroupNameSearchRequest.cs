using System.Text.Json.Serialization;
using DotNetBungieAPI.Models.GroupsV2;

namespace DotNetBungieAPI.Models.Queries
{
    public class GroupNameSearchRequest
    {
        [JsonPropertyName("groupName")] public string GroupName { get; init; }

        [JsonPropertyName("groupType")] public GroupType GroupType { get; init; }
    }
}