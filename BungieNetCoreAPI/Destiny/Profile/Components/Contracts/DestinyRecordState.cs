using System;

namespace NetBungieApi.Destiny.Profile.Components.Contracts
{
    [Flags]
    public enum DestinyRecordState
    {
        None = 0,
        RecordRedeemed = 1,
        RewardUnavailable = 2,
        ObjectiveNotCompleted = 4,
        Obscured = 8,
        Invisible = 16,
        EntitlementUnowned = 32,
        CanEquipTitle = 64
    }
}
