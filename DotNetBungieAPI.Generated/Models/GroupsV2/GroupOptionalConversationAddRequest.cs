namespace DotNetBungieAPI.Generated.Models.GroupsV2;

public class GroupOptionalConversationAddRequest : IDeepEquatable<GroupOptionalConversationAddRequest>
{
    [JsonPropertyName("chatName")]
    public string ChatName { get; set; }

    [JsonPropertyName("chatSecurity")]
    public GroupsV2.ChatSecuritySetting ChatSecurity { get; set; }

    public bool DeepEquals(GroupOptionalConversationAddRequest? other)
    {
        return other is not null &&
               ChatName == other.ChatName &&
               ChatSecurity == other.ChatSecurity;
    }
}