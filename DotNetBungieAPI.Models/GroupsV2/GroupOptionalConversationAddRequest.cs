namespace DotNetBungieAPI.Models.GroupsV2;

public sealed class GroupOptionalConversationAddRequest
{
    [JsonPropertyName("chatName")]
    public string ChatName { get; init; }

    [JsonPropertyName("chatSecurity")]
    public GroupsV2.ChatSecuritySetting ChatSecurity { get; init; }
}
