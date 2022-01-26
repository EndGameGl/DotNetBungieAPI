namespace DotNetBungieAPI.Generated.Models.Destiny.Definitions.Sockets;

/// <summary>
///     Data related to what happens while a plug is being inserted, mostly for UI purposes.
/// </summary>
public class DestinyInsertPlugActionDefinition : IDeepEquatable<DestinyInsertPlugActionDefinition>
{
    /// <summary>
    ///     How long it takes for the Plugging of the item to be completed once it is initiated, if you care.
    /// </summary>
    [JsonPropertyName("actionExecuteSeconds")]
    public int ActionExecuteSeconds { get; set; }

    /// <summary>
    ///     The type of action being performed when you act on this Socket Type. The most common value is "insert plug", but there are others as well (for instance, a "Masterwork" socket may allow for Re-initialization, and an Infusion socket allows for items to be consumed to upgrade the item)
    /// </summary>
    [JsonPropertyName("actionType")]
    public Destiny.SocketTypeActionType ActionType { get; set; }

    public bool DeepEquals(DestinyInsertPlugActionDefinition? other)
    {
        return other is not null &&
               ActionExecuteSeconds == other.ActionExecuteSeconds &&
               ActionType == other.ActionType;
    }

    public event PropertyChangedEventHandler? PropertyChanged;

    [NotifyPropertyChangedInvocator]
    protected virtual void OnPropertyChanged([CallerMemberName] string? propertyName = null)
    {
       PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
    }

    public void Update(DestinyInsertPlugActionDefinition? other)
    {
        if (other is null) return;
        if (ActionExecuteSeconds != other.ActionExecuteSeconds)
        {
            ActionExecuteSeconds = other.ActionExecuteSeconds;
            OnPropertyChanged(nameof(ActionExecuteSeconds));
        }
        if (ActionType != other.ActionType)
        {
            ActionType = other.ActionType;
            OnPropertyChanged(nameof(ActionType));
        }
    }
}