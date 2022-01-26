namespace DotNetBungieAPI.Generated.Models.Destiny.Components.StringVariables;

public class DestinyStringVariablesComponent : IDeepEquatable<DestinyStringVariablesComponent>
{
    [JsonPropertyName("integerValuesByHash")]
    public Dictionary<uint, int> IntegerValuesByHash { get; set; }

    public bool DeepEquals(DestinyStringVariablesComponent? other)
    {
        return other is not null &&
               IntegerValuesByHash.DeepEqualsDictionaryNaive(other.IntegerValuesByHash);
    }

    public event PropertyChangedEventHandler? PropertyChanged;

    [NotifyPropertyChangedInvocator]
    protected virtual void OnPropertyChanged([CallerMemberName] string? propertyName = null)
    {
       PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
    }

    public void Update(DestinyStringVariablesComponent? other)
    {
        if (other is null) return;
        if (!IntegerValuesByHash.DeepEqualsDictionaryNaive(other.IntegerValuesByHash))
        {
            IntegerValuesByHash = other.IntegerValuesByHash;
            OnPropertyChanged(nameof(IntegerValuesByHash));
        }
    }
}