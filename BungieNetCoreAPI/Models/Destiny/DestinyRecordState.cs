using System;
using System.Text.Json.Serialization;

namespace NetBungieAPI.Models.Destiny
{
    [Flags, JsonConverter(typeof(JsonStringEnumConverter))]
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
