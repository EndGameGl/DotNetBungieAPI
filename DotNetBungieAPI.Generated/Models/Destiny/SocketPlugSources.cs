using System.Text.Json.Serialization;

namespace DotNetBungieAPI.Generated.Models.Destiny;

[System.Flags]
public enum SocketPlugSources : int
{
    None = 0,
    InventorySourced = 1,
    ReusablePlugItems = 2,
    ProfilePlugSet = 4,
    CharacterPlugSet = 8
}
