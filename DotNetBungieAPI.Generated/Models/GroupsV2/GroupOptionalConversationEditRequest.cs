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

    public event PropertyChangedEventHandler? PropertyChanged;

    [NotifyPropertyChangedInvocator]
    protected virtual void OnPropertyChanged([CallerMemberName] string? propertyName = null)
    {
       PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
    }

    public void Update(GroupOptionalConversationEditRequest? other)
    {
        if (other is null) return;
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