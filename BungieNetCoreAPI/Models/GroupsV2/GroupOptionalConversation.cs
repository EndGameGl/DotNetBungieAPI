using System.Text.Json.Serialization;

namespace NetBungieAPI.Models.GroupsV2
{
    public record GroupOptionalConversation
    {
        [JsonPropertyName("groupId")]
        public long GroupId { get; init; }

        [JsonPropertyName("conversationId")]
        public long ConversationId { get; init; }

        [JsonPropertyName("chatEnabled")]
        public bool ChatEnabled { get; init; }

        [JsonPropertyName("chatName")]
        public string ChatName { get; init; }

        [JsonPropertyName("chatSecurity")]
        public ChatSecuritySetting ChatSecurity { get; init; }
    }
}
