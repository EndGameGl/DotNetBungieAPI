using System;

namespace NetBungieApi.Destiny.Profile.Components.Contracts
{
    [Flags]
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
