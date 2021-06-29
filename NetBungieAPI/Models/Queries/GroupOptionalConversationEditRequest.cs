using System.Text.Json.Serialization;
using NetBungieAPI.Models.GroupsV2;

namespace NetBungieAPI.Models.Queries
{
    public class GroupOptionalConversationEditRequest
    {
        [JsonPropertyName("chatEnabled")] public bool? ChatEnabled { get; init; }

        [JsonPropertyName("chatName")] public string ChatName { get; init; }

        [JsonPropertyName("chatSecurity")] public ChatSecuritySetting ChatSecurity { get; init; }
    }
}