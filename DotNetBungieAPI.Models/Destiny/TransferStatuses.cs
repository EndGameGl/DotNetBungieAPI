namespace DotNetBungieAPI.Models.Destiny;

/// <summary>
///     Whether you can transfer an item, and why not if you can't.
/// </summary>
[System.Flags]
public enum TransferStatuses : int
{
    /// <summary>
    ///     The item can be transferred.
    /// </summary>
    CanTransfer = 0,

    /// <summary>
    ///     You can't transfer the item because it is equipped on a character.
    /// </summary>
    ItemIsEquipped = 1,

    /// <summary>
    ///     The item is defined as not transferrable in its DestinyInventoryItemDefinition.nonTransferrable property.
    /// </summary>
    NotTransferrable = 2,

    /// <summary>
    ///     You could transfer the item, but the place you're trying to put it has run out of room! Check your remaining Vault and/or character space.
    /// </summary>
    NoRoomInDestination = 4
}
