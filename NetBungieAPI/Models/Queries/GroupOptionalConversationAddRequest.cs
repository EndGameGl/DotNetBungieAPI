using System.Text.Json.Serialization;
using NetBungieAPI.Models.GroupsV2;

namespace NetBungieAPI.Models.Queries
{
    public class GroupOptionalConversationAddRequest
    {
        [JsonPropertyName("chatName")] public string ChatName { get; init; }

        [JsonPropertyName("chatSecurity")] public ChatSecuritySetting ChatSecurity { get; init; }
    }
}