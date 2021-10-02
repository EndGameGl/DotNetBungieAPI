using System.Text.Json.Serialization;

namespace DotNetBungieAPI.Models.Destiny.Definitions.Activities
{
    /// <summary>
    ///     Represents a status string that could be conditionally displayed about an activity. Note that externally, you can
    ///     only see the strings themselves. Internally we combine this information with server state to determine which
    ///     strings should be shown.
    /// </summary>
    public sealed record DestinyActivityUnlockStringDefinition : IDeepEquatable<DestinyActivityUnlockStringDefinition>
    {
        /// <summary>
        ///     The string to be displayed if the conditions are met.
        /// </summary>
        [JsonPropertyName("displayString")]
        public string DisplayString { get; init; }

        public bool DeepEquals(DestinyActivityUnlockStringDefinition other)
        {
            return other != null && DisplayString == other.DisplayString;
        }
    }
}