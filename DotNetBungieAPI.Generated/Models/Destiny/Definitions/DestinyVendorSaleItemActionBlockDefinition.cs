namespace DotNetBungieAPI.Generated.Models.Destiny.Definitions;

/// <summary>
///     Not terribly useful, some basic cooldown interaction info.
/// </summary>
public class DestinyVendorSaleItemActionBlockDefinition : IDeepEquatable<DestinyVendorSaleItemActionBlockDefinition>
{
    [JsonPropertyName("executeSeconds")]
    public float ExecuteSeconds { get; set; }

    [JsonPropertyName("isPositive")]
    public bool IsPositive { get; set; }

    public bool DeepEquals(DestinyVendorSaleItemActionBlockDefinition? other)
    {
        return other is not null &&
               ExecuteSeconds == other.ExecuteSeconds &&
               IsPositive == other.IsPositive;
    }

    public event PropertyChangedEventHandler? PropertyChanged;

    [NotifyPropertyChangedInvocator]
    protected virtual void OnPropertyChanged([CallerMemberName] string? propertyName = null)
    {
       PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
    }

    public void Update(DestinyVendorSaleItemActionBlockDefinition? other)
    {
        if (other is null) return;
        if (ExecuteSeconds != other.ExecuteSeconds)
        {
            ExecuteSeconds = other.ExecuteSeconds;
            OnPropertyChanged(nameof(ExecuteSeconds));
        }
        if (IsPositive != other.IsPositive)
        {
            IsPositive = other.IsPositive;
            OnPropertyChanged(nameof(IsPositive));
        }
    }
}