using System.Text.Json.Serialization;

namespace DotNetBungieAPI.Generated.Models.Destiny;

[System.Flags]
public enum ItemState : int
{
    None = 0,
    Locked = 1,
    Tracked = 2,
    Masterwork = 4
}
