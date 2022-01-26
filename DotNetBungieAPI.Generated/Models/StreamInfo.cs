namespace DotNetBungieAPI.Generated.Models;

public class StreamInfo : IDeepEquatable<StreamInfo>
{
    [JsonPropertyName("ChannelName")]
    public string ChannelName { get; set; }

    public bool DeepEquals(StreamInfo? other)
    {
        return other is not null &&
               ChannelName == other.ChannelName;
    }

    public event PropertyChangedEventHandler? PropertyChanged;

    [NotifyPropertyChangedInvocator]
    protected virtual void OnPropertyChanged([CallerMemberName] string? propertyName = null)
    {
       PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
    }

    public void Update(StreamInfo? other)
    {
        if (other is null) return;
        if (ChannelName != other.ChannelName)
        {
            ChannelName = other.ChannelName;
            OnPropertyChanged(nameof(ChannelName));
        }
    }
}