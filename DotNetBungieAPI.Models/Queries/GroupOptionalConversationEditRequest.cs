using DotNetBungieAPI.Models.GroupsV2;

namespace DotNetBungieAPI.Models.Queries;

public class GroupOptionalConversationEditRequest
{
    [JsonPropertyName("chatEnabled")]
    public bool? ChatEnabled { get; init; }

    [JsonPropertyName("chatName")]
    public string ChatName { get; init; }

    [JsonPropertyName("chatSecurity")]
    public ChatSecuritySetting ChatSecurity { get; init; }
}
