namespace DotNetBungieAPI.Generated.Models.GroupsV2;

public class GroupOptionalConversationEditRequest : IDeepEquatable<GroupOptionalConversationEditRequest>
{
    [JsonPropertyName("chatEnabled")]
    public bool? ChatEnabled { get; set; }

    [JsonPropertyName("chatName")]
    public string ChatName { get; set; }

    [JsonPropertyName("chatSecurity")]
    public int? ChatSecurity { get; set; }

    public bool DeepEquals(GroupOptionalConversationEditRequest? other)
    {
        return other is not null &&
               ChatEnabled == other.ChatEnabled &&
               ChatName == other.ChatName &&
               ChatSecurity == other.ChatSecurity;
    }
}