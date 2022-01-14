namespace DotNetBungieAPI.Generated.Models.Destiny.Definitions;

/// <summary>
///     This defines a single Step in a progression (which roughly equates to a level. See DestinyProgressionDefinition for caveats).
/// </summary>
public sealed class DestinyProgressionStepDefinition
{

    /// <summary>
    ///     Very rarely, Progressions will have localized text describing the Level of the progression. This will be that localized text, if it exists. Otherwise, the standard appears to be to simply show the level numerically.
    /// </summary>
    [JsonPropertyName("stepName")]
    public string StepName { get; init; }

    /// <summary>
    ///     This appears to be, when you "level up", whether a visual effect will display and on what entity. See DestinyProgressionStepDisplayEffect for slightly more info.
    /// </summary>
    [JsonPropertyName("displayEffectType")]
    public Destiny.DestinyProgressionStepDisplayEffect DisplayEffectType { get; init; }

    /// <summary>
    ///     The total amount of progression points/"experience" you will need to initially reach this step. If this is the last step and the progression is repeating indefinitely (DestinyProgressionDefinition.repeatLastStep), this will also be the progress needed to level it up further by repeating this step again.
    /// </summary>
    [JsonPropertyName("progressTotal")]
    public int ProgressTotal { get; init; }

    /// <summary>
    ///     A listing of items rewarded as a result of reaching this level.
    /// </summary>
    [JsonPropertyName("rewardItems")]
    public List<Destiny.DestinyItemQuantity> RewardItems { get; init; }

    /// <summary>
    ///     If this progression step has a specific icon related to it, this is the icon to show.
    /// </summary>
    [JsonPropertyName("icon")]
    public string Icon { get; init; }
}
