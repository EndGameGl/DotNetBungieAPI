namespace DotNetBungieAPI.Generated.Models;

public class DestinyBaseItemComponentSetOfint64 : IDeepEquatable<DestinyBaseItemComponentSetOfint64>
{
    [JsonPropertyName("objectives")]
    public DictionaryComponentResponseOfint64AndDestinyItemObjectivesComponent Objectives { get; set; }

    [JsonPropertyName("perks")]
    public DictionaryComponentResponseOfint64AndDestinyItemPerksComponent Perks { get; set; }

    public bool DeepEquals(DestinyBaseItemComponentSetOfint64? other)
    {
        return other is not null &&
               (Objectives is not null ? Objectives.DeepEquals(other.Objectives) : other.Objectives is null) &&
               (Perks is not null ? Perks.DeepEquals(other.Perks) : other.Perks is null);
    }

    public event PropertyChangedEventHandler? PropertyChanged;

    [NotifyPropertyChangedInvocator]
    protected virtual void OnPropertyChanged([CallerMemberName] string? propertyName = null)
    {
       PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
    }

    public void Update(DestinyBaseItemComponentSetOfint64? other)
    {
        if (other is null) return;
        if (!Objectives.DeepEquals(other.Objectives))
        {
            Objectives.Update(other.Objectives);
            OnPropertyChanged(nameof(Objectives));
        }
        if (!Perks.DeepEquals(other.Perks))
        {
            Perks.Update(other.Perks);
            OnPropertyChanged(nameof(Perks));
        }
    }
}