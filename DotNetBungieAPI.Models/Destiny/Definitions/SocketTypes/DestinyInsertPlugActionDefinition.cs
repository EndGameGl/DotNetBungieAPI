namespace DotNetBungieAPI.Models.Destiny.Definitions.SocketTypes;

/// <summary>
///     Data related to what happens while a plug is being inserted, mostly for UI purposes.
/// </summary>
public sealed record DestinyInsertPlugActionDefinition : IDeepEquatable<DestinyInsertPlugActionDefinition>
{
    /// <summary>
    ///     How long it takes for the Plugging of the item to be completed once it is initiated, if you care.
    /// </summary>
    [JsonPropertyName("actionExecuteSeconds")]
    public int ActionExecuteSeconds { get; init; }

    [JsonPropertyName("actionSoundHash")] public int ActionSoundHash { get; init; }

    /// <summary>
    ///     The type of action being performed when you act on this Socket Type. The most common value is "insert plug", but
    ///     there are others as well (for instance, a "Masterwork" socket may allow for Re-initialization, and an Infusion
    ///     socket allows for items to be consumed to upgrade the item)
    /// </summary>
    [JsonPropertyName("actionType")]
    public SocketTypeActionType ActionType { get; init; }

    [JsonPropertyName("isPositiveAction")] public bool IsPositiveAction { get; init; }

    public bool DeepEquals(DestinyInsertPlugActionDefinition other)
    {
        return other != null &&
               ActionExecuteSeconds == other.ActionExecuteSeconds &&
               ActionSoundHash == other.ActionSoundHash &&
               ActionType == other.ActionType &&
               IsPositiveAction == other.IsPositiveAction;
    }
}