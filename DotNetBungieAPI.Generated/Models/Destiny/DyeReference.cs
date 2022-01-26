namespace DotNetBungieAPI.Generated.Models.Destiny;

public class DyeReference : IDeepEquatable<DyeReference>
{
    [JsonPropertyName("channelHash")]
    public uint ChannelHash { get; set; }

    [JsonPropertyName("dyeHash")]
    public uint DyeHash { get; set; }

    public bool DeepEquals(DyeReference? other)
    {
        return other is not null &&
               ChannelHash == other.ChannelHash &&
               DyeHash == other.DyeHash;
    }

    public event PropertyChangedEventHandler? PropertyChanged;

    [NotifyPropertyChangedInvocator]
    protected virtual void OnPropertyChanged([CallerMemberName] string? propertyName = null)
    {
       PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
    }

    public void Update(DyeReference? other)
    {
        if (other is null) return;
        if (ChannelHash != other.ChannelHash)
        {
            ChannelHash = other.ChannelHash;
            OnPropertyChanged(nameof(ChannelHash));
        }
        if (DyeHash != other.DyeHash)
        {
            DyeHash = other.DyeHash;
            OnPropertyChanged(nameof(DyeHash));
        }
    }
}