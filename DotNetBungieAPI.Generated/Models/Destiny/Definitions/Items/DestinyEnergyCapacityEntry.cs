namespace DotNetBungieAPI.Generated.Models.Destiny.Definitions.Items;

/// <summary>
///     Items can have Energy Capacity, and plugs can provide that capacity such as on a piece of Armor in Armor 2.0. This is how much "Energy" can be spent on activating plugs for this item.
/// </summary>
public class DestinyEnergyCapacityEntry : IDeepEquatable<DestinyEnergyCapacityEntry>
{
    /// <summary>
    ///     How much energy capacity this plug provides.
    /// </summary>
    [JsonPropertyName("capacityValue")]
    public int CapacityValue { get; set; }

    /// <summary>
    ///     Energy provided by a plug is always of a specific type - this is the hash identifier for the energy type for which it provides Capacity.
    /// </summary>
    [JsonPropertyName("energyTypeHash")]
    public uint EnergyTypeHash { get; set; }

    /// <summary>
    ///     The Energy Type for this energy capacity, in enum form for easy use.
    /// </summary>
    [JsonPropertyName("energyType")]
    public Destiny.DestinyEnergyType EnergyType { get; set; }

    public bool DeepEquals(DestinyEnergyCapacityEntry? other)
    {
        return other is not null &&
               CapacityValue == other.CapacityValue &&
               EnergyTypeHash == other.EnergyTypeHash &&
               EnergyType == other.EnergyType;
    }

    public event PropertyChangedEventHandler? PropertyChanged;

    [NotifyPropertyChangedInvocator]
    protected virtual void OnPropertyChanged([CallerMemberName] string? propertyName = null)
    {
       PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
    }

    public void Update(DestinyEnergyCapacityEntry? other)
    {
        if (other is null) return;
        if (CapacityValue != other.CapacityValue)
        {
            CapacityValue = other.CapacityValue;
            OnPropertyChanged(nameof(CapacityValue));
        }
        if (EnergyTypeHash != other.EnergyTypeHash)
        {
            EnergyTypeHash = other.EnergyTypeHash;
            OnPropertyChanged(nameof(EnergyTypeHash));
        }
        if (EnergyType != other.EnergyType)
        {
            EnergyType = other.EnergyType;
            OnPropertyChanged(nameof(EnergyType));
        }
    }
}