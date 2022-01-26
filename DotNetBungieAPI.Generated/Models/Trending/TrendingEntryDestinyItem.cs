namespace DotNetBungieAPI.Generated.Models.Trending;

public class TrendingEntryDestinyItem : IDeepEquatable<TrendingEntryDestinyItem>
{
    [JsonPropertyName("itemHash")]
    public uint ItemHash { get; set; }

    public bool DeepEquals(TrendingEntryDestinyItem? other)
    {
        return other is not null &&
               ItemHash == other.ItemHash;
    }

    public event PropertyChangedEventHandler? PropertyChanged;

    [NotifyPropertyChangedInvocator]
    protected virtual void OnPropertyChanged([CallerMemberName] string? propertyName = null)
    {
       PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
    }

    public void Update(TrendingEntryDestinyItem? other)
    {
        if (other is null) return;
        if (ItemHash != other.ItemHash)
        {
            ItemHash = other.ItemHash;
            OnPropertyChanged(nameof(ItemHash));
        }
    }
}