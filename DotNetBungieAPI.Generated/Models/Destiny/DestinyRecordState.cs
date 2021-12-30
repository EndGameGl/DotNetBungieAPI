using System.Text.Json.Serialization;

namespace DotNetBungieAPI.Generated.Models.Destiny;

[System.Flags]
public enum DestinyRecordState : int
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
