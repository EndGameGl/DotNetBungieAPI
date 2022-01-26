namespace DotNetBungieAPI.Generated.Models.Destiny.HistoricalStats;

public class DestinyHistoricalWeaponStatsData : IDeepEquatable<DestinyHistoricalWeaponStatsData>
{
    /// <summary>
    ///     List of weapons and their perspective values.
    /// </summary>
    [JsonPropertyName("weapons")]
    public List<Destiny.HistoricalStats.DestinyHistoricalWeaponStats> Weapons { get; set; }

    public bool DeepEquals(DestinyHistoricalWeaponStatsData? other)
    {
        return other is not null &&
               Weapons.DeepEqualsList(other.Weapons);
    }

    public event PropertyChangedEventHandler? PropertyChanged;

    [NotifyPropertyChangedInvocator]
    protected virtual void OnPropertyChanged([CallerMemberName] string? propertyName = null)
    {
       PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
    }

    public void Update(DestinyHistoricalWeaponStatsData? other)
    {
        if (other is null) return;
        if (!Weapons.DeepEqualsList(other.Weapons))
        {
            Weapons = other.Weapons;
            OnPropertyChanged(nameof(Weapons));
        }
    }
}