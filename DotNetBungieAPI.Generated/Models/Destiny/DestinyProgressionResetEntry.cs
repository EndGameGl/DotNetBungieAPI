namespace DotNetBungieAPI.Generated.Models.Destiny;

/// <summary>
///     Represents a season and the number of resets you had in that season.
/// <para />
///      We do not necessarily - even for progressions with resets - track it over all seasons. So be careful and check the season numbers being returned.
/// </summary>
public class DestinyProgressionResetEntry : IDeepEquatable<DestinyProgressionResetEntry>
{
    [JsonPropertyName("season")]
    public int Season { get; set; }

    [JsonPropertyName("resets")]
    public int Resets { get; set; }

    public bool DeepEquals(DestinyProgressionResetEntry? other)
    {
        return other is not null &&
               Season == other.Season &&
               Resets == other.Resets;
    }

    public event PropertyChangedEventHandler? PropertyChanged;

    [NotifyPropertyChangedInvocator]
    protected virtual void OnPropertyChanged([CallerMemberName] string? propertyName = null)
    {
       PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
    }

    public void Update(DestinyProgressionResetEntry? other)
    {
        if (other is null) return;
        if (Season != other.Season)
        {
            Season = other.Season;
            OnPropertyChanged(nameof(Season));
        }
        if (Resets != other.Resets)
        {
            Resets = other.Resets;
            OnPropertyChanged(nameof(Resets));
        }
    }
}