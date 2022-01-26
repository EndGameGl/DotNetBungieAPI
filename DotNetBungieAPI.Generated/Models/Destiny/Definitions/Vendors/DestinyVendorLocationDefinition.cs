namespace DotNetBungieAPI.Generated.Models.Destiny.Definitions.Vendors;

/// <summary>
///     These definitions represent vendors' locations and relevant display information at different times in the game.
/// </summary>
public class DestinyVendorLocationDefinition : IDeepEquatable<DestinyVendorLocationDefinition>
{
    /// <summary>
    ///     The hash identifier for a Destination at which this vendor may be located. Each destination where a Vendor may exist will only ever have a single entry.
    /// </summary>
    [JsonPropertyName("destinationHash")]
    public uint DestinationHash { get; set; }

    /// <summary>
    ///     The relative path to the background image representing this Vendor at this location, for use in a banner.
    /// </summary>
    [JsonPropertyName("backgroundImagePath")]
    public string BackgroundImagePath { get; set; }

    public bool DeepEquals(DestinyVendorLocationDefinition? other)
    {
        return other is not null &&
               DestinationHash == other.DestinationHash &&
               BackgroundImagePath == other.BackgroundImagePath;
    }

    public event PropertyChangedEventHandler? PropertyChanged;

    [NotifyPropertyChangedInvocator]
    protected virtual void OnPropertyChanged([CallerMemberName] string? propertyName = null)
    {
       PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
    }

    public void Update(DestinyVendorLocationDefinition? other)
    {
        if (other is null) return;
        if (DestinationHash != other.DestinationHash)
        {
            DestinationHash = other.DestinationHash;
            OnPropertyChanged(nameof(DestinationHash));
        }
        if (BackgroundImagePath != other.BackgroundImagePath)
        {
            BackgroundImagePath = other.BackgroundImagePath;
            OnPropertyChanged(nameof(BackgroundImagePath));
        }
    }
}