using System.Text.Json.Serialization;

namespace DotNetBungieAPI.Generated.Models.Destiny;

[System.Flags]
public enum EquipFailureReason : int
{
    None = 0,
    ItemUnequippable = 1,
    ItemUniqueEquipRestricted = 2,
    ItemFailedUnlockCheck = 4,
    ItemFailedLevelCheck = 8,
    ItemNotOnCharacter = 16
}
