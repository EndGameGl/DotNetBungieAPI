namespace DotNetBungieAPI.Generated.Models.Trending;

public class TrendingCategory : IDeepEquatable<TrendingCategory>
{
    [JsonPropertyName("categoryName")]
    public string CategoryName { get; set; }

    [JsonPropertyName("entries")]
    public SearchResultOfTrendingEntry Entries { get; set; }

    [JsonPropertyName("categoryId")]
    public string CategoryId { get; set; }

    public bool DeepEquals(TrendingCategory? other)
    {
        return other is not null &&
               CategoryName == other.CategoryName &&
               (Entries is not null ? Entries.DeepEquals(other.Entries) : other.Entries is null) &&
               CategoryId == other.CategoryId;
    }

    public event PropertyChangedEventHandler? PropertyChanged;

    [NotifyPropertyChangedInvocator]
    protected virtual void OnPropertyChanged([CallerMemberName] string? propertyName = null)
    {
       PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
    }

    public void Update(TrendingCategory? other)
    {
        if (other is null) return;
        if (CategoryName != other.CategoryName)
        {
            CategoryName = other.CategoryName;
            OnPropertyChanged(nameof(CategoryName));
        }
        if (!Entries.DeepEquals(other.Entries))
        {
            Entries.Update(other.Entries);
            OnPropertyChanged(nameof(Entries));
        }
        if (CategoryId != other.CategoryId)
        {
            CategoryId = other.CategoryId;
            OnPropertyChanged(nameof(CategoryId));
        }
    }
}