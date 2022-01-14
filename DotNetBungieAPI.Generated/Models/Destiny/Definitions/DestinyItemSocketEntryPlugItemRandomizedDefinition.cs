namespace DotNetBungieAPI.Generated.Models.Destiny.Definitions;

public sealed class DestinyItemSocketEntryPlugItemRandomizedDefinition
{

    /// <summary>
    ///     Indicates if the plug can be rolled on the current version of the item. For example, older versions of weapons may have plug rolls that are no longer possible on the current versions.
    /// </summary>
    [JsonPropertyName("currentlyCanRoll")]
    public bool CurrentlyCanRoll { get; init; }

    /// <summary>
    ///     The hash identifier of a DestinyInventoryItemDefinition representing the plug that can be inserted.
    /// </summary>
    [JsonPropertyName("plugItemHash")]
    public uint PlugItemHash { get; init; } // DestinyInventoryItemDefinition
}
