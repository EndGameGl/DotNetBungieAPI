namespace DotNetBungieAPI.Generated.Models.Destiny.Definitions;

/// <summary>
///     If an item can have an action performed on it (like "Dismantle"), it will be defined here if you care.
/// </summary>
public class DestinyItemActionBlockDefinition : IDeepEquatable<DestinyItemActionBlockDefinition>
{
    /// <summary>
    ///     Localized text for the verb of the action being performed.
    /// </summary>
    [JsonPropertyName("verbName")]
    public string VerbName { get; set; }

    /// <summary>
    ///     Localized text describing the action being performed.
    /// </summary>
    [JsonPropertyName("verbDescription")]
    public string VerbDescription { get; set; }

    /// <summary>
    ///     The content has this property, however it's not entirely clear how it is used.
    /// </summary>
    [JsonPropertyName("isPositive")]
    public bool IsPositive { get; set; }

    /// <summary>
    ///     If the action has an overlay screen associated with it, this is the name of that screen. Unfortunately, we cannot return the screen's data itself.
    /// </summary>
    [JsonPropertyName("overlayScreenName")]
    public string OverlayScreenName { get; set; }

    /// <summary>
    ///     The icon associated with the overlay screen for the action, if any.
    /// </summary>
    [JsonPropertyName("overlayIcon")]
    public string OverlayIcon { get; set; }

    /// <summary>
    ///     The number of seconds to delay before allowing this action to be performed again.
    /// </summary>
    [JsonPropertyName("requiredCooldownSeconds")]
    public int RequiredCooldownSeconds { get; set; }

    /// <summary>
    ///     If the action requires other items to exist or be destroyed, this is the list of those items and requirements.
    /// </summary>
    [JsonPropertyName("requiredItems")]
    public List<Destiny.Definitions.DestinyItemActionRequiredItemDefinition> RequiredItems { get; set; }

    /// <summary>
    ///     If performing this action earns you Progression, this is the list of progressions and values granted for those progressions by performing this action.
    /// </summary>
    [JsonPropertyName("progressionRewards")]
    public List<Destiny.Definitions.DestinyProgressionRewardDefinition> ProgressionRewards { get; set; }

    /// <summary>
    ///     The internal identifier for the action.
    /// </summary>
    [JsonPropertyName("actionTypeLabel")]
    public string ActionTypeLabel { get; set; }

    /// <summary>
    ///     Theoretically, an item could have a localized string for a hint about the location in which the action should be performed. In practice, no items yet have this property.
    /// </summary>
    [JsonPropertyName("requiredLocation")]
    public string RequiredLocation { get; set; }

    /// <summary>
    ///     The identifier hash for the Cooldown associated with this action. We have not pulled this data yet for you to have more data to use for cooldowns.
    /// </summary>
    [JsonPropertyName("requiredCooldownHash")]
    public uint RequiredCooldownHash { get; set; }

    /// <summary>
    ///     If true, the item is deleted when the action completes.
    /// </summary>
    [JsonPropertyName("deleteOnAction")]
    public bool DeleteOnAction { get; set; }

    /// <summary>
    ///     If true, the entire stack is deleted when the action completes.
    /// </summary>
    [JsonPropertyName("consumeEntireStack")]
    public bool ConsumeEntireStack { get; set; }

    /// <summary>
    ///     If true, this action will be performed as soon as you earn this item. Some rewards work this way, providing you a single item to pick up from a reward-granting vendor in-game and then immediately consuming itself to provide you multiple items.
    /// </summary>
    [JsonPropertyName("useOnAcquire")]
    public bool UseOnAcquire { get; set; }

    public bool DeepEquals(DestinyItemActionBlockDefinition? other)
    {
        return other is not null &&
               VerbName == other.VerbName &&
               VerbDescription == other.VerbDescription &&
               IsPositive == other.IsPositive &&
               OverlayScreenName == other.OverlayScreenName &&
               OverlayIcon == other.OverlayIcon &&
               RequiredCooldownSeconds == other.RequiredCooldownSeconds &&
               RequiredItems.DeepEqualsList(other.RequiredItems) &&
               ProgressionRewards.DeepEqualsList(other.ProgressionRewards) &&
               ActionTypeLabel == other.ActionTypeLabel &&
               RequiredLocation == other.RequiredLocation &&
               RequiredCooldownHash == other.RequiredCooldownHash &&
               DeleteOnAction == other.DeleteOnAction &&
               ConsumeEntireStack == other.ConsumeEntireStack &&
               UseOnAcquire == other.UseOnAcquire;
    }

    public event PropertyChangedEventHandler? PropertyChanged;

    [NotifyPropertyChangedInvocator]
    protected virtual void OnPropertyChanged([CallerMemberName] string? propertyName = null)
    {
       PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
    }

    public void Update(DestinyItemActionBlockDefinition? other)
    {
        if (other is null) return;
        if (VerbName != other.VerbName)
        {
            VerbName = other.VerbName;
            OnPropertyChanged(nameof(VerbName));
        }
        if (VerbDescription != other.VerbDescription)
        {
            VerbDescription = other.VerbDescription;
            OnPropertyChanged(nameof(VerbDescription));
        }
        if (IsPositive != other.IsPositive)
        {
            IsPositive = other.IsPositive;
            OnPropertyChanged(nameof(IsPositive));
        }
        if (OverlayScreenName != other.OverlayScreenName)
        {
            OverlayScreenName = other.OverlayScreenName;
            OnPropertyChanged(nameof(OverlayScreenName));
        }
        if (OverlayIcon != other.OverlayIcon)
        {
            OverlayIcon = other.OverlayIcon;
            OnPropertyChanged(nameof(OverlayIcon));
        }
        if (RequiredCooldownSeconds != other.RequiredCooldownSeconds)
        {
            RequiredCooldownSeconds = other.RequiredCooldownSeconds;
            OnPropertyChanged(nameof(RequiredCooldownSeconds));
        }
        if (!RequiredItems.DeepEqualsList(other.RequiredItems))
        {
            RequiredItems = other.RequiredItems;
            OnPropertyChanged(nameof(RequiredItems));
        }
        if (!ProgressionRewards.DeepEqualsList(other.ProgressionRewards))
        {
            ProgressionRewards = other.ProgressionRewards;
            OnPropertyChanged(nameof(ProgressionRewards));
        }
        if (ActionTypeLabel != other.ActionTypeLabel)
        {
            ActionTypeLabel = other.ActionTypeLabel;
            OnPropertyChanged(nameof(ActionTypeLabel));
        }
        if (RequiredLocation != other.RequiredLocation)
        {
            RequiredLocation = other.RequiredLocation;
            OnPropertyChanged(nameof(RequiredLocation));
        }
        if (RequiredCooldownHash != other.RequiredCooldownHash)
        {
            RequiredCooldownHash = other.RequiredCooldownHash;
            OnPropertyChanged(nameof(RequiredCooldownHash));
        }
        if (DeleteOnAction != other.DeleteOnAction)
        {
            DeleteOnAction = other.DeleteOnAction;
            OnPropertyChanged(nameof(DeleteOnAction));
        }
        if (ConsumeEntireStack != other.ConsumeEntireStack)
        {
            ConsumeEntireStack = other.ConsumeEntireStack;
            OnPropertyChanged(nameof(ConsumeEntireStack));
        }
        if (UseOnAcquire != other.UseOnAcquire)
        {
            UseOnAcquire = other.UseOnAcquire;
            OnPropertyChanged(nameof(UseOnAcquire));
        }
    }
}