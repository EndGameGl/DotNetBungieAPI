namespace DotNetBungieAPI.Generated.Models.GroupsV2;

public class GroupOptionalConversation : IDeepEquatable<GroupOptionalConversation>
{
    [JsonPropertyName("groupId")]
    public long GroupId { get; set; }

    [JsonPropertyName("conversationId")]
    public long ConversationId { get; set; }

    [JsonPropertyName("chatEnabled")]
    public bool ChatEnabled { get; set; }

    [JsonPropertyName("chatName")]
    public string ChatName { get; set; }

    [JsonPropertyName("chatSecurity")]
    public GroupsV2.ChatSecuritySetting ChatSecurity { get; set; }

    public bool DeepEquals(GroupOptionalConversation? other)
    {
        return other is not null &&
               GroupId == other.GroupId &&
               ConversationId == other.ConversationId &&
               ChatEnabled == other.ChatEnabled &&
               ChatName == other.ChatName &&
               ChatSecurity == other.ChatSecurity;
    }

    public event PropertyChangedEventHandler? PropertyChanged;

    [NotifyPropertyChangedInvocator]
    protected virtual void OnPropertyChanged([CallerMemberName] string? propertyName = null)
    {
       PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
    }

    public void Update(GroupOptionalConversation? other)
    {
        if (other is null) return;
        if (GroupId != other.GroupId)
        {
            GroupId = other.GroupId;
            OnPropertyChanged(nameof(GroupId));
        }
        if (ConversationId != other.ConversationId)
        {
            ConversationId = other.ConversationId;
            OnPropertyChanged(nameof(ConversationId));
        }
        if (ChatEnabled != other.ChatEnabled)
        {
            ChatEnabled = other.ChatEnabled;
            OnPropertyChanged(nameof(ChatEnabled));
        }
        if (ChatName != other.ChatName)
        {
            ChatName = other.ChatName;
            OnPropertyChanged(nameof(ChatName));
        }
        if (ChatSecurity != other.ChatSecurity)
        {
            ChatSecurity = other.ChatSecurity;
            OnPropertyChanged(nameof(ChatSecurity));
        }
    }
}