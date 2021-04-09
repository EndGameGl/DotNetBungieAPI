using System;
using System.Text.Json.Serialization;

namespace NetBungieAPI.Models.Destiny
{
    [Flags, JsonConverter(typeof(JsonStringEnumConverter))]
    public enum TransferStatuses
    {
        CanTransfer = 0,
        ItemIsEquipped = 1,
        NotTransferrable = 2,
        NoRoomInDestination = 4
    }
}
