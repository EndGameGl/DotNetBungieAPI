using Newtonsoft.Json;
using System.Collections.ObjectModel;

namespace NetBungieApi.Destiny.Definitions.Progressions
{
    /// <summary>
    /// This defines a single Step in a progression
    /// </summary>
    public class ProgressionStep : IDeepEquatable<ProgressionStep>
    {
        /// <summary>
        /// This appears to be, when you "level up", whether a visual effect will display and on what entity. See DestinyProgressionStepDisplayEffect for slightly more info.
        /// </summary>
        public ProgressionStepDisplayEffect DisplayEffectType { get; }
        /// <summary>
        /// If this progression step has a specific icon related to it, this is the icon to show.
        /// </summary>
        public string Icon { get; }
        /// <summary>
        /// The total amount of progression points/"experience" you will need to initially reach this step. If this is the last step and the progression is repeating indefinitely (DestinyProgressionDefinition.repeatLastStep), this will also be the progress needed to level it up further by repeating this step again.
        /// </summary>
        public int ProgressTotal { get; }
        /// <summary>
        /// Very rarely, Progressions will have localized text describing the Level of the progression. This will be that localized text, if it exists. Otherwise, the standard appears to be to simply show the level numerically.
        /// </summary>
        public string StepName { get; }
        /// <summary>
        /// A listing of items rewarded as a result of reaching this level.
        /// </summary>
        public ReadOnlyCollection<ProgressionStepReward> RewardItems { get; }

        [JsonConstructor]
        internal ProgressionStep(ProgressionStepDisplayEffect displayEffectType, string icon, int progressTotal, string stepName, ProgressionStepReward[] rewardItems)
        {
            DisplayEffectType = displayEffectType;
            Icon = icon;
            ProgressTotal = progressTotal;
            StepName = stepName;
            RewardItems = rewardItems.AsReadOnlyOrEmpty();
        }

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
