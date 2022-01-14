namespace DotNetBungieAPI.Generated.Models.GroupsV2;

public sealed class GroupOptionalConversationEditRequest
{

    [JsonPropertyName("chatEnabled")]
    public bool? ChatEnabled { get; init; }

    [JsonPropertyName("chatName")]
    public string ChatName { get; init; }

    [JsonPropertyName("chatSecurity")]
    public int? ChatSecurity { get; init; }
}
