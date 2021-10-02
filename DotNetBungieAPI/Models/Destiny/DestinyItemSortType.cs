namespace DotNetBungieAPI.Models.Destiny
{
    /// <summary>
    ///     Determines how items are sorted in an inventory bucket.
    /// </summary>
    public enum DestinyItemSortType
    {
        ItemId = 0,
        Timestamp = 1,
        StackSize = 2
    }
}