namespace DotNetBungieAPI.Generated.Models.GroupsV2;

public class GroupOptionalConversationEditRequest
{
    [JsonPropertyName("chatEnabled")]
    public bool? ChatEnabled { get; set; }

    [JsonPropertyName("chatName")]
    public string ChatName { get; set; }

    [JsonPropertyName("chatSecurity")]
    public GroupsV2.ChatSecuritySetting? ChatSecurity { get; set; }
}
