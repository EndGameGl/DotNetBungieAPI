namespace DotNetBungieAPI.Generated.Models.Destiny.HistoricalStats;

public class DestinyHistoricalWeaponStats : IDeepEquatable<DestinyHistoricalWeaponStats>
{
    /// <summary>
    ///     The hash ID of the item definition that describes the weapon.
    /// </summary>
    [JsonPropertyName("referenceId")]
    public uint ReferenceId { get; set; }

    /// <summary>
    ///     Collection of stats for the period.
    /// </summary>
    [JsonPropertyName("values")]
    public Dictionary<string, Destiny.HistoricalStats.DestinyHistoricalStatsValue> Values { get; set; }

    public bool DeepEquals(DestinyHistoricalWeaponStats? other)
    {
        return other is not null &&
               ReferenceId == other.ReferenceId &&
               Values.DeepEqualsDictionary(other.Values);
    }

    public event PropertyChangedEventHandler? PropertyChanged;

    [NotifyPropertyChangedInvocator]
    protected virtual void OnPropertyChanged([CallerMemberName] string? propertyName = null)
    {
       PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
    }

    public void Update(DestinyHistoricalWeaponStats? other)
    {
        if (other is null) return;
        if (ReferenceId != other.ReferenceId)
        {
            ReferenceId = other.ReferenceId;
            OnPropertyChanged(nameof(ReferenceId));
        }
        if (!Values.DeepEqualsDictionary(other.Values))
        {
            Values = other.Values;
            OnPropertyChanged(nameof(Values));
        }
    }
}