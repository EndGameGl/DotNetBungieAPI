namespace DotNetBungieAPI.Generated.Models.Destiny.Definitions;

public class DestinyActivityLoadoutRequirement : IDeepEquatable<DestinyActivityLoadoutRequirement>
{
    [JsonPropertyName("equipmentSlotHash")]
    public uint EquipmentSlotHash { get; set; }

    [JsonPropertyName("allowedEquippedItemHashes")]
    public List<uint> AllowedEquippedItemHashes { get; set; }

    [JsonPropertyName("allowedWeaponSubTypes")]
    public List<Destiny.DestinyItemSubType> AllowedWeaponSubTypes { get; set; }

    public bool DeepEquals(DestinyActivityLoadoutRequirement? other)
    {
        return other is not null &&
               EquipmentSlotHash == other.EquipmentSlotHash &&
               AllowedEquippedItemHashes.DeepEqualsListNaive(other.AllowedEquippedItemHashes) &&
               AllowedWeaponSubTypes.DeepEqualsListNaive(other.AllowedWeaponSubTypes);
    }

    public event PropertyChangedEventHandler? PropertyChanged;

    [NotifyPropertyChangedInvocator]
    protected virtual void OnPropertyChanged([CallerMemberName] string? propertyName = null)
    {
       PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
    }

    public void Update(DestinyActivityLoadoutRequirement? other)
    {
        if (other is null) return;
        if (EquipmentSlotHash != other.EquipmentSlotHash)
        {
            EquipmentSlotHash = other.EquipmentSlotHash;
            OnPropertyChanged(nameof(EquipmentSlotHash));
        }
        if (!AllowedEquippedItemHashes.DeepEqualsListNaive(other.AllowedEquippedItemHashes))
        {
            AllowedEquippedItemHashes = other.AllowedEquippedItemHashes;
            OnPropertyChanged(nameof(AllowedEquippedItemHashes));
        }
        if (!AllowedWeaponSubTypes.DeepEqualsListNaive(other.AllowedWeaponSubTypes))
        {
            AllowedWeaponSubTypes = other.AllowedWeaponSubTypes;
            OnPropertyChanged(nameof(AllowedWeaponSubTypes));
        }
    }
}