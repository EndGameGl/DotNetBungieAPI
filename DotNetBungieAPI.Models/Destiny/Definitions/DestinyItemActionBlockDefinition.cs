namespace DotNetBungieAPI.Models.Destiny.Definitions;

/// <summary>
///     If an item can have an action performed on it (like "Dismantle"), it will be defined here if you care.
/// </summary>
public sealed class DestinyItemActionBlockDefinition
{
    /// <summary>
    ///     Localized text for the verb of the action being performed.
    /// </summary>
    [JsonPropertyName("verbName")]
    public string VerbName { get; init; }

    /// <summary>
    ///     Localized text describing the action being performed.
    /// </summary>
    [JsonPropertyName("verbDescription")]
    public string VerbDescription { get; init; }

    /// <summary>
    ///     The content has this property, however it's not entirely clear how it is used.
    /// </summary>
    [JsonPropertyName("isPositive")]
    public bool IsPositive { get; init; }

    /// <summary>
    ///     If the action has an overlay screen associated with it, this is the name of that screen. Unfortunately, we cannot return the screen's data itself.
    /// </summary>
    [JsonPropertyName("overlayScreenName")]
    public string OverlayScreenName { get; init; }

    /// <summary>
    ///     The icon associated with the overlay screen for the action, if any.
    /// </summary>
    [JsonPropertyName("overlayIcon")]
    public string OverlayIcon { get; init; }

    /// <summary>
    ///     The number of seconds to delay before allowing this action to be performed again.
    /// </summary>
    [JsonPropertyName("requiredCooldownSeconds")]
    public int RequiredCooldownSeconds { get; init; }

    /// <summary>
    ///     If the action requires other items to exist or be destroyed, this is the list of those items and requirements.
    /// </summary>
    [JsonPropertyName("requiredItems")]
    public Destiny.Definitions.DestinyItemActionRequiredItemDefinition[]? RequiredItems { get; init; }

    /// <summary>
    ///     If performing this action earns you Progression, this is the list of progressions and values granted for those progressions by performing this action.
    /// </summary>
    [JsonPropertyName("progressionRewards")]
    public Destiny.Definitions.DestinyProgressionRewardDefinition[]? ProgressionRewards { get; init; }

    /// <summary>
    ///     The internal identifier for the action.
    /// </summary>
    [JsonPropertyName("actionTypeLabel")]
    public string ActionTypeLabel { get; init; }

    /// <summary>
    ///     Theoretically, an item could have a localized string for a hint about the location in which the action should be performed. In practice, no items yet have this property.
    /// </summary>
    [JsonPropertyName("requiredLocation")]
    public string RequiredLocation { get; init; }

    /// <summary>
    ///     The identifier hash for the Cooldown associated with this action. We have not pulled this data yet for you to have more data to use for cooldowns.
    /// </summary>
    [JsonPropertyName("requiredCooldownHash")]
    public uint RequiredCooldownHash { get; init; }

    /// <summary>
    ///     If true, the item is deleted when the action completes.
    /// </summary>
    [JsonPropertyName("deleteOnAction")]
    public bool DeleteOnAction { get; init; }

    /// <summary>
    ///     If true, the entire stack is deleted when the action completes.
    /// </summary>
    [JsonPropertyName("consumeEntireStack")]
    public bool ConsumeEntireStack { get; init; }

    /// <summary>
    ///     If true, this action will be performed as soon as you earn this item. Some rewards work this way, providing you a single item to pick up from a reward-granting vendor in-game and then immediately consuming itself to provide you multiple items.
    /// </summary>
    [JsonPropertyName("useOnAcquire")]
    public bool UseOnAcquire { get; init; }
}
