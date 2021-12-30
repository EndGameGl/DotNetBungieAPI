using System.Text.Json.Serialization;

namespace DotNetBungieAPI.Generated.Models.Destiny;

[System.Flags]
public enum DestinyJoinClosedReasons : int
{
    None = 0,
    InMatchmaking = 1,
    Loading = 2,
    SoloMode = 4,
    InternalReasons = 8,
    DisallowedByGameState = 16,
    Offline = 32768
}
