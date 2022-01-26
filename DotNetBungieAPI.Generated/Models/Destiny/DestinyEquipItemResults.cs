namespace DotNetBungieAPI.Generated.Models.Destiny;

/// <summary>
///     The results of a bulk Equipping operation performed through the Destiny API.
/// </summary>
public class DestinyEquipItemResults : IDeepEquatable<DestinyEquipItemResults>
{
    [JsonPropertyName("equipResults")]
    public List<Destiny.DestinyEquipItemResult> EquipResults { get; set; }

    public bool DeepEquals(DestinyEquipItemResults? other)
    {
        return other is not null &&
               EquipResults.DeepEqualsList(other.EquipResults);
    }

    public event PropertyChangedEventHandler? PropertyChanged;

    [NotifyPropertyChangedInvocator]
    protected virtual void OnPropertyChanged([CallerMemberName] string? propertyName = null)
    {
       PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
    }

    public void Update(DestinyEquipItemResults? other)
    {
        if (other is null) return;
        if (!EquipResults.DeepEqualsList(other.EquipResults))
        {
            EquipResults = other.EquipResults;
            OnPropertyChanged(nameof(EquipResults));
        }
    }
}