namespace DotNetBungieAPI.Generated.Models.Destiny.Definitions;

/// <summary>
///     This defines a single Step in a progression (which roughly equates to a level. See DestinyProgressionDefinition for caveats).
/// </summary>
public class DestinyProgressionStepDefinition : IDeepEquatable<DestinyProgressionStepDefinition>
{
    /// <summary>
    ///     Very rarely, Progressions will have localized text describing the Level of the progression. This will be that localized text, if it exists. Otherwise, the standard appears to be to simply show the level numerically.
    /// </summary>
    [JsonPropertyName("stepName")]
    public string StepName { get; set; }

    /// <summary>
    ///     This appears to be, when you "level up", whether a visual effect will display and on what entity. See DestinyProgressionStepDisplayEffect for slightly more info.
    /// </summary>
    [JsonPropertyName("displayEffectType")]
    public Destiny.DestinyProgressionStepDisplayEffect DisplayEffectType { get; set; }

    /// <summary>
    ///     The total amount of progression points/"experience" you will need to initially reach this step. If this is the last step and the progression is repeating indefinitely (DestinyProgressionDefinition.repeatLastStep), this will also be the progress needed to level it up further by repeating this step again.
    /// </summary>
    [JsonPropertyName("progressTotal")]
    public int ProgressTotal { get; set; }

    /// <summary>
    ///     A listing of items rewarded as a result of reaching this level.
    /// </summary>
    [JsonPropertyName("rewardItems")]
    public List<Destiny.DestinyItemQuantity> RewardItems { get; set; }

    /// <summary>
    ///     If this progression step has a specific icon related to it, this is the icon to show.
    /// </summary>
    [JsonPropertyName("icon")]
    public string Icon { get; set; }

    public bool DeepEquals(DestinyProgressionStepDefinition? other)
    {
        return other is not null &&
               StepName == other.StepName &&
               DisplayEffectType == other.DisplayEffectType &&
               ProgressTotal == other.ProgressTotal &&
               RewardItems.DeepEqualsList(other.RewardItems) &&
               Icon == other.Icon;
    }

    public event PropertyChangedEventHandler? PropertyChanged;

    [NotifyPropertyChangedInvocator]
    protected virtual void OnPropertyChanged([CallerMemberName] string? propertyName = null)
    {
       PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
    }

    public void Update(DestinyProgressionStepDefinition? other)
    {
        if (other is null) return;
        if (StepName != other.StepName)
        {
            StepName = other.StepName;
            OnPropertyChanged(nameof(StepName));
        }
        if (DisplayEffectType != other.DisplayEffectType)
        {
            DisplayEffectType = other.DisplayEffectType;
            OnPropertyChanged(nameof(DisplayEffectType));
        }
        if (ProgressTotal != other.ProgressTotal)
        {
            ProgressTotal = other.ProgressTotal;
            OnPropertyChanged(nameof(ProgressTotal));
        }
        if (!RewardItems.DeepEqualsList(other.RewardItems))
        {
            RewardItems = other.RewardItems;
            OnPropertyChanged(nameof(RewardItems));
        }
        if (Icon != other.Icon)
        {
            Icon = other.Icon;
            OnPropertyChanged(nameof(Icon));
        }
    }
}