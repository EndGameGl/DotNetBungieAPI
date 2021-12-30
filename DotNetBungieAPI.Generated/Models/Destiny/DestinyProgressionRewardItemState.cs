using System.Text.Json.Serialization;

namespace DotNetBungieAPI.Generated.Models.Destiny;

[System.Flags]
public enum DestinyProgressionRewardItemState : int
{
    None = 0,
    Invisible = 1,
    Earned = 2,
    Claimed = 4,
    ClaimAllowed = 8
}
