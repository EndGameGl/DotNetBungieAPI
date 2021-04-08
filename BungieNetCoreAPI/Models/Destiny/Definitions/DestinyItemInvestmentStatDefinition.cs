using NetBungieAPI.Models.Destiny.Definitions.Stats;
using System.Text.Json.Serialization;

namespace NetBungieAPI.Models.Destiny.Definitions
{
    public sealed record DestinyItemInvestmentStatDefinition : IDeepEquatable<DestinyItemInvestmentStatDefinition>
    {
        [JsonPropertyName("statTypeHash")]
        public DefinitionHashPointer<DestinyStatDefinition> StatType { get; init; } = DefinitionHashPointer<DestinyStatDefinition>.Empty;
        /// <summary>
        /// The raw "Investment" value for the stat, before transformations are performed to turn this raw stat into stats that are displayed in the game UI.
        /// </summary>
        [JsonPropertyName("value")]
        public int Value { get; init; }
        /// <summary>
        /// If this is true, the stat will only be applied on the item in certain game state conditions, and we can't know statically whether or not this stat will be applied. Check the "live" API data instead for whether this value is being applied on a specific instance of the item in question, and you can use this to decide whether you want to show the stat on the generic view of the item, or whether you want to show some kind of caveat or warning about the stat value being conditional on game state.
        /// </summary>
        [JsonPropertyName("isConditionallyActive")]
        public bool IsConditionallyActive { get; init; }

        public bool DeepEquals(DestinyItemInvestmentStatDefinition other)
        {
            return other != null &&
                   StatType.DeepEquals(other.StatType) &&
                   Value == other.Value &&
                   IsConditionallyActive == other.IsConditionallyActive;
        }
    }
}
