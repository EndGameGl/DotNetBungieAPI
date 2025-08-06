namespace DotNetBungieAPI.Models.Destiny.Sockets;

public sealed class DestinyItemPlugBase
{
    /// <summary>
    ///     The hash identifier of the DestinyInventoryItemDefinition that represents this plug.
    /// </summary>
    [JsonPropertyName("plugItemHash")]
    public DefinitionHashPointer<Destiny.Definitions.DestinyInventoryItemDefinition> PlugItemHash { get; init; }

    /// <summary>
    ///     If true, this plug has met all of its insertion requirements. Big if true.
    /// </summary>
    [JsonPropertyName("canInsert")]
    public bool CanInsert { get; init; }

    /// <summary>
    ///     If true, this plug will provide its benefits while inserted.
    /// </summary>
    [JsonPropertyName("enabled")]
    public bool Enabled { get; init; }

    /// <summary>
    ///     If the plug cannot be inserted for some reason, this will have the indexes into the plug item definition's plug.insertionRules property, so you can show the reasons why it can't be inserted.
    /// <para />
    ///     This list will be empty if the plug can be inserted.
    /// </summary>
    [JsonPropertyName("insertFailIndexes")]
    public int[]? InsertFailIndexes { get; init; }

    /// <summary>
    ///     If a plug is not enabled, this will be populated with indexes into the plug item definition's plug.enabledRules property, so that you can show the reasons why it is not enabled.
    /// <para />
    ///     This list will be empty if the plug is enabled.
    /// </summary>
    [JsonPropertyName("enableFailIndexes")]
    public int[]? EnableFailIndexes { get; init; }

    /// <summary>
    ///     If available, this is the stack size to display for the socket plug item.
    /// </summary>
    [JsonPropertyName("stackSize")]
    public int? StackSize { get; init; }

    /// <summary>
    ///     If available, this is the maximum stack size to display for the socket plug item.
    /// </summary>
    [JsonPropertyName("maxStackSize")]
    public int? MaxStackSize { get; init; }
}
