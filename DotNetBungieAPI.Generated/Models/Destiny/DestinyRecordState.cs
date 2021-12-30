using System.Text.Json.Serialization;

namespace DotNetBungieAPI.Generated.Models.Destiny;

/// <summary>
///     A Flags enumeration/bitmask where each bit represents a possible state that a Record/Triumph can be in.
/// </summary>
[System.Flags]
public enum DestinyRecordState : int
{
    /// <summary>
    ///     If there are no flags set, the record is in a state where it *could* be redeemed, but it has not been yet.
    /// </summary>
    None = 0,
    /// <summary>
    ///     If this is set, the completed record has been redeemed.
    /// </summary>
    RecordRedeemed = 1,
    /// <summary>
    ///     If this is set, there's a reward available from this Record but it's unavailable for redemption.
    /// </summary>
    RewardUnavailable = 2,
    /// <summary>
    ///     If this is set, the objective for this Record has not yet been completed.
    /// </summary>
    ObjectiveNotCompleted = 4,
    /// <summary>
    ///     If this is set, the game recommends that you replace the display text of this Record with DestinyRecordDefinition.stateInfo.obscuredString.
    /// </summary>
    Obscured = 8,
    /// <summary>
    ///     If this is set, the game recommends that you not show this record. Do what you will with this recommendation.
    /// </summary>
    Invisible = 16,
    /// <summary>
    ///     If this is set, you can't complete this record because you lack some permission that's required to complete it.
    /// </summary>
    EntitlementUnowned = 32,
    /// <summary>
    ///     If this is set, the record has a title (check DestinyRecordDefinition for title info) and you can equip it.
    /// </summary>
    CanEquipTitle = 64
}
