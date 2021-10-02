using System.Text.Json.Serialization;

namespace DotNetBungieAPI.Models.Destiny.Milestones
{
    /// <summary>
    ///     Represents whatever information we can return about an explicit phase in an activity. In the future, I hope we'll
    ///     have more than just "guh, you done gone and did something," but for the forseeable future that's all we've got. I'm
    ///     making it more than just a list of booleans out of that overly-optimistic hope.
    /// </summary>
    public sealed record DestinyMilestoneActivityPhase
    {
        /// <summary>
        ///     Indicates if the phase has been completed.
        /// </summary>
        [JsonPropertyName("complete")]
        public bool IsComplete { get; init; }

        /// <summary>
        ///     In DestinyActivityDefinition, if the activity has phases, there will be a set of phases defined in the
        ///     "insertionPoints" property. This is the hash that maps to that phase.
        /// </summary>
        [JsonPropertyName("phaseHash")]
        public uint PhaseHash { get; init; }
    }
}