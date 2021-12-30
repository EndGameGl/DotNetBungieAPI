using System.Text.Json.Serialization;

namespace DotNetBungieAPI.Generated.Models.Destiny;

[System.Flags]
public enum TransferStatuses : int
{
    CanTransfer = 0,
    ItemIsEquipped = 1,
    NotTransferrable = 2,
    NoRoomInDestination = 4
}
