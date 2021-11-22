namespace DotNetBungieAPI.Models.Destiny.Definitions.Objectives
{
    /// <summary>
    ///     Defines the conditions under which stat modifications will be applied to a Character while participating in an
    ///     objective.
    /// </summary>
    public class DestinyObjectiveStatEntryDefinition : IDeepEquatable<DestinyObjectiveStatEntryDefinition>
    {
        /// <summary>
        ///     The stat being modified, and the value used.
        /// </summary>
        [JsonPropertyName("stat")]
        public DestinyItemInvestmentStatDefinition Stat { get; init; }

        /// <summary>
        ///     Whether it will be applied as long as the objective is active, when it's completed, or until it's completed.
        /// </summary>
        [JsonPropertyName("style")]
        public DestinyObjectiveGrantStyle Style { get; init; }

        public bool DeepEquals(DestinyObjectiveStatEntryDefinition other)
        {
            return other != null &&
                   (Stat != null ? Stat.DeepEquals(other.Stat) : other.Stat == null) &&
                   Style == other.Style;
        }
    }
}