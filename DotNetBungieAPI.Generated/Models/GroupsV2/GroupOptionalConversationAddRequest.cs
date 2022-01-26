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

    public event PropertyChangedEventHandler? PropertyChanged;

    [NotifyPropertyChangedInvocator]
    protected virtual void OnPropertyChanged([CallerMemberName] string? propertyName = null)
    {
       PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
    }

    public void Update(GroupOptionalConversationAddRequest? other)
    {
        if (other is null) return;
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