using DotNetBungieAPI.Models.GroupsV2;

namespace DotNetBungieAPI.Models.Queries;

public class GroupOptionalConversationAddRequest
{
    [JsonPropertyName("chatName")]
    public string ChatName { get; init; }

    [JsonPropertyName("chatSecurity")]
    public ChatSecuritySetting ChatSecurity { get; init; }
}
