using System;
using System.Text.Json.Serialization;

namespace NetBungieAPI.Models.Destiny
{
    [Flags, JsonConverter(typeof(JsonStringEnumConverter))]
    public enum EquipFailureReason
    {
        None = 0,
        ItemUnequippable = 1,
        ItemUniqueEquipRestricted = 2,
        ItemFailedUnlockCheck = 4,
        ItemFailedLevelCheck = 8,
        ItemNotOnCharacter = 16
    }
}
