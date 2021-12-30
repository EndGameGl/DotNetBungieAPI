using System.Text.Json.Serialization;

namespace DotNetBungieAPI.Generated.Models.GroupsV2;

public sealed class GroupOptionalConversation
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
    public GroupsV2.ChatSecuritySetting ChatSecurity { get; init; }
}
