namespace DotNetBungieAPI.Models.Destiny.Definitions.Progressions
{
    /// <summary>
    ///     This defines a single Step in a progression
    /// </summary>
    public sealed record ProgressionStep : IDeepEquatable<ProgressionStep>
    {
        /// <summary>
        ///     This appears to be, when you "level up", whether a visual effect will display and on what entity. See
        ///     DestinyProgressionStepDisplayEffect for slightly more info.
        /// </summary>
        [JsonPropertyName("displayEffectType")]
        public DestinyProgressionStepDisplayEffect DisplayEffectType { get; init; }

        /// <summary>
        ///     If this progression step has a specific icon related to it, this is the icon to show.
        /// </summary>
        [JsonPropertyName("icon")]
        public BungieNetResource Icon { get; init; }

        /// <summary>
        ///     The total amount of progression points/"experience" you will need to initially reach this step. If this is the last
        ///     step and the progression is repeating indefinitely (DestinyProgressionDefinition.repeatLastStep), this will also be
        ///     the progress needed to level it up further by repeating this step again.
        /// </summary>
        [JsonPropertyName("progressTotal")]
        public int ProgressTotal { get; init; }

        /// <summary>
        ///     Very rarely, Progressions will have localized text describing the Level of the progression. This will be that
        ///     localized text, if it exists. Otherwise, the standard appears to be to simply show the level numerically.
        /// </summary>
        [JsonPropertyName("stepName")]
        public string StepName { get; init; }

        /// <summary>
        ///     A listing of items rewarded as a result of reaching this level.
        /// </summary>
        [JsonPropertyName("rewardItems")]
        public ReadOnlyCollection<DestinyItemQuantity> RewardItems { get; init; } =
            ReadOnlyCollections<DestinyItemQuantity>.Empty;

        public bool DeepEquals(ProgressionStep other)
        {
            return other != null &&
                   DisplayEffectType == other.DisplayEffectType &&
                   Icon == other.Icon &&
                   ProgressTotal == other.ProgressTotal &&
                   StepName == other.StepName &&
                   RewardItems.DeepEqualsReadOnlyCollections(other.RewardItems);
        }
    }
}