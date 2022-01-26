namespace DotNetBungieAPI.Generated.Models.Trending;

public class TrendingCategories : IDeepEquatable<TrendingCategories>
{
    [JsonPropertyName("categories")]
    public List<Trending.TrendingCategory> Categories { get; set; }

    public bool DeepEquals(TrendingCategories? other)
    {
        return other is not null &&
               Categories.DeepEqualsList(other.Categories);
    }

    public event PropertyChangedEventHandler? PropertyChanged;

    [NotifyPropertyChangedInvocator]
    protected virtual void OnPropertyChanged([CallerMemberName] string? propertyName = null)
    {
       PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
    }

    public void Update(TrendingCategories? other)
    {
        if (other is null) return;
        if (!Categories.DeepEqualsList(other.Categories))
        {
            Categories = other.Categories;
            OnPropertyChanged(nameof(Categories));
        }
    }
}