namespace DotNetBungieAPI.Generated.Models.Destiny.Definitions.Sockets;

public class DestinySocketTypeScalarMaterialRequirementEntry : IDeepEquatable<DestinySocketTypeScalarMaterialRequirementEntry>
{
    [JsonPropertyName("currencyItemHash")]
    public uint CurrencyItemHash { get; set; }

    [JsonPropertyName("scalarValue")]
    public int ScalarValue { get; set; }

    public bool DeepEquals(DestinySocketTypeScalarMaterialRequirementEntry? other)
    {
        return other is not null &&
               CurrencyItemHash == other.CurrencyItemHash &&
               ScalarValue == other.ScalarValue;
    }

    public event PropertyChangedEventHandler? PropertyChanged;

    [NotifyPropertyChangedInvocator]
    protected virtual void OnPropertyChanged([CallerMemberName] string? propertyName = null)
    {
       PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
    }

    public void Update(DestinySocketTypeScalarMaterialRequirementEntry? other)
    {
        if (other is null) return;
        if (CurrencyItemHash != other.CurrencyItemHash)
        {
            CurrencyItemHash = other.CurrencyItemHash;
            OnPropertyChanged(nameof(CurrencyItemHash));
        }
        if (ScalarValue != other.ScalarValue)
        {
            ScalarValue = other.ScalarValue;
            OnPropertyChanged(nameof(ScalarValue));
        }
    }
}