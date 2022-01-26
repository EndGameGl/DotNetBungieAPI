namespace DotNetBungieAPI.Generated.Models.Trending;

public class TrendingDetail : IDeepEquatable<TrendingDetail>
{
    [JsonPropertyName("identifier")]
    public string Identifier { get; set; }

    [JsonPropertyName("entityType")]
    public Trending.TrendingEntryType EntityType { get; set; }

    [JsonPropertyName("news")]
    public Trending.TrendingEntryNews News { get; set; }

    [JsonPropertyName("support")]
    public Trending.TrendingEntrySupportArticle Support { get; set; }

    [JsonPropertyName("destinyItem")]
    public Trending.TrendingEntryDestinyItem DestinyItem { get; set; }

    [JsonPropertyName("destinyActivity")]
    public Trending.TrendingEntryDestinyActivity DestinyActivity { get; set; }

    [JsonPropertyName("destinyRitual")]
    public Trending.TrendingEntryDestinyRitual DestinyRitual { get; set; }

    [JsonPropertyName("creation")]
    public Trending.TrendingEntryCommunityCreation Creation { get; set; }

    public bool DeepEquals(TrendingDetail? other)
    {
        return other is not null &&
               Identifier == other.Identifier &&
               EntityType == other.EntityType &&
               (News is not null ? News.DeepEquals(other.News) : other.News is null) &&
               (Support is not null ? Support.DeepEquals(other.Support) : other.Support is null) &&
               (DestinyItem is not null ? DestinyItem.DeepEquals(other.DestinyItem) : other.DestinyItem is null) &&
               (DestinyActivity is not null ? DestinyActivity.DeepEquals(other.DestinyActivity) : other.DestinyActivity is null) &&
               (DestinyRitual is not null ? DestinyRitual.DeepEquals(other.DestinyRitual) : other.DestinyRitual is null) &&
               (Creation is not null ? Creation.DeepEquals(other.Creation) : other.Creation is null);
    }

    public event PropertyChangedEventHandler? PropertyChanged;

    [NotifyPropertyChangedInvocator]
    protected virtual void OnPropertyChanged([CallerMemberName] string? propertyName = null)
    {
       PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
    }

    public void Update(TrendingDetail? other)
    {
        if (other is null) return;
        if (Identifier != other.Identifier)
        {
            Identifier = other.Identifier;
            OnPropertyChanged(nameof(Identifier));
        }
        if (EntityType != other.EntityType)
        {
            EntityType = other.EntityType;
            OnPropertyChanged(nameof(EntityType));
        }
        if (!News.DeepEquals(other.News))
        {
            News.Update(other.News);
            OnPropertyChanged(nameof(News));
        }
        if (!Support.DeepEquals(other.Support))
        {
            Support.Update(other.Support);
            OnPropertyChanged(nameof(Support));
        }
        if (!DestinyItem.DeepEquals(other.DestinyItem))
        {
            DestinyItem.Update(other.DestinyItem);
            OnPropertyChanged(nameof(DestinyItem));
        }
        if (!DestinyActivity.DeepEquals(other.DestinyActivity))
        {
            DestinyActivity.Update(other.DestinyActivity);
            OnPropertyChanged(nameof(DestinyActivity));
        }
        if (!DestinyRitual.DeepEquals(other.DestinyRitual))
        {
            DestinyRitual.Update(other.DestinyRitual);
            OnPropertyChanged(nameof(DestinyRitual));
        }
        if (!Creation.DeepEquals(other.Creation))
        {
            Creation.Update(other.Creation);
            OnPropertyChanged(nameof(Creation));
        }
    }
}