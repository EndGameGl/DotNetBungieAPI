namespace DotNetBungieAPI.Generated.Models.GroupsV2;

public class GroupOptionalConversationAddRequest
{
    [JsonPropertyName("chatName")]
    public string? ChatName { get; set; }

    [JsonPropertyName("chatSecurity")]
    public GroupsV2.ChatSecuritySetting? ChatSecurity { get; set; }
}
