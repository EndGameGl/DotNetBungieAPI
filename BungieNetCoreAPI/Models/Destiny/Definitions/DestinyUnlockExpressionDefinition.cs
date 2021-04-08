using System.Text.Json.Serialization;

namespace NetBungieAPI.Models.Destiny.Definitions
{
    public sealed record DestinyUnlockExpressionDefinition : IDeepEquatable<DestinyUnlockExpressionDefinition>
    {
        /// <summary>
        /// A shortcut for determining the most restrictive gating that this expression performs.
        /// </summary>
        [JsonPropertyName("scope")]
        public DestinyGatingScope Scope { get; init; }

        public bool DeepEquals(DestinyUnlockExpressionDefinition other)
        {
            return other != null && Scope == other.Scope;
        }
    }
}
