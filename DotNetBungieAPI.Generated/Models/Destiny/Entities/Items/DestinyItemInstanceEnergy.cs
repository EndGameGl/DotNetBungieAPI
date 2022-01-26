namespace DotNetBungieAPI.Generated.Models.Destiny.Entities.Items;

public class DestinyItemInstanceEnergy : IDeepEquatable<DestinyItemInstanceEnergy>
{
    /// <summary>
    ///     The type of energy for this item. Plugs that require Energy can only be inserted if they have the "Any" Energy Type or the matching energy type of this item. This is a reference to the DestinyEnergyTypeDefinition for the energy type, where you can find extended info about it.
    /// </summary>
    [JsonPropertyName("energyTypeHash")]
    public uint EnergyTypeHash { get; set; }

    /// <summary>
    ///     This is the enum version of the Energy Type value, for convenience.
    /// </summary>
    [JsonPropertyName("energyType")]
    public Destiny.DestinyEnergyType EnergyType { get; set; }

    /// <summary>
    ///     The total capacity of Energy that the item currently has, regardless of if it is currently being used.
    /// </summary>
    [JsonPropertyName("energyCapacity")]
    public int EnergyCapacity { get; set; }

    /// <summary>
    ///     The amount of Energy currently in use by inserted plugs.
    /// </summary>
    [JsonPropertyName("energyUsed")]
    public int EnergyUsed { get; set; }

    /// <summary>
    ///     The amount of energy still available for inserting new plugs.
    /// </summary>
    [JsonPropertyName("energyUnused")]
    public int EnergyUnused { get; set; }

    public bool DeepEquals(DestinyItemInstanceEnergy? other)
    {
        return other is not null &&
               EnergyTypeHash == other.EnergyTypeHash &&
               EnergyType == other.EnergyType &&
               EnergyCapacity == other.EnergyCapacity &&
               EnergyUsed == other.EnergyUsed &&
               EnergyUnused == other.EnergyUnused;
    }

    public event PropertyChangedEventHandler? PropertyChanged;

    [NotifyPropertyChangedInvocator]
    protected virtual void OnPropertyChanged([CallerMemberName] string? propertyName = null)
    {
       PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
    }

    public void Update(DestinyItemInstanceEnergy? other)
    {
        if (other is null) return;
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
        if (EnergyCapacity != other.EnergyCapacity)
        {
            EnergyCapacity = other.EnergyCapacity;
            OnPropertyChanged(nameof(EnergyCapacity));
        }
        if (EnergyUsed != other.EnergyUsed)
        {
            EnergyUsed = other.EnergyUsed;
            OnPropertyChanged(nameof(EnergyUsed));
        }
        if (EnergyUnused != other.EnergyUnused)
        {
            EnergyUnused = other.EnergyUnused;
            OnPropertyChanged(nameof(EnergyUnused));
        }
    }
}