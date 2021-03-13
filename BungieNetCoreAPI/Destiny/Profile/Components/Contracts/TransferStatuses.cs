using System;

namespace NetBungieApi.Destiny.Profile.Components.Contracts
{
    [Flags]
    public enum TransferStatuses
    {
        CanTransfer = 0,
        ItemIsEquipped = 1,
        NotTransferrable = 2,
        NoRoomInDestination = 4
    }
}
