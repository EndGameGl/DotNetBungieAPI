using Newtonsoft.Json;

namespace NetBungieApi.Destiny.Definitions.Activities
{
    /// <summary>
    /// Represents a status string that could be conditionally displayed about an activity. Note that externally, you can only see the strings themselves. Internally we combine this information with server state to determine which strings should be shown.
    /// </summary>
    public class ActivityUnlockString : IDeepEquatable<ActivityUnlockString>
    {
        /// <summary>
        /// The string to be displayed if the conditions are met.
        /// </summary>
        public string DisplayString { get; }

        [JsonConstructor]
        internal ActivityUnlockString(string displayString)
        {
            DisplayString = displayString;
        }

        public bool DeepEquals(ActivityUnlockString other)
        {
            return other != null && DisplayString == other.DisplayString;
        }
    }
}
