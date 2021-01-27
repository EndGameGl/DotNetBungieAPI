using Newtonsoft.Json;

namespace BungieNetCoreAPI.Destiny.Definitions.ActivityGraphs
{
    /// <summary>
    /// Unlock Expressions are the foundation of the game's gating mechanics and investment-related restrictions. They can test Unlock Flags and Unlock Values for certain states, using a sufficient amount of logical operators such that unlock expressions are effectively Turing complete.
    /// </summary>
    public class ActivityGraphLinkedGraphEntryUnlockExpression : IDeepEquatable<ActivityGraphLinkedGraphEntryUnlockExpression>
    {
        /// <summary>
        /// A shortcut for determining the most restrictive gating that this expression performs.
        /// </summary>
        public DestinyGatingScope Scope { get; }

        [JsonConstructor]
        internal ActivityGraphLinkedGraphEntryUnlockExpression(DestinyGatingScope scope)
        {
            Scope = scope;
        }

        public bool DeepEquals(ActivityGraphLinkedGraphEntryUnlockExpression other)
        {
            return other != null && Scope == other.Scope;
        }
    }
}
