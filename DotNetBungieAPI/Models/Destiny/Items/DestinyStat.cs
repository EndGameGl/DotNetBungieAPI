using System.Text.Json.Serialization;
using DotNetBungieAPI.Models.Destiny.Definitions.Stats;

namespace DotNetBungieAPI.Models.Destiny.Items
{
    /// <summary>
    ///     Represents a stat on an item *or* Character (NOT a Historical Stat, but a physical attribute stat like Attack,
    ///     Defense etc...)
    /// </summary>
    public sealed record DestinyStat
    {
        /// <summary>
        ///     The hash identifier for the Stat. Use it to look up the DestinyStatDefinition for static data about the stat.
        /// </summary>
        [JsonPropertyName("statHash")]
        public DefinitionHashPointer<DestinyStatDefinition> Stat { get; init; } =
            DefinitionHashPointer<DestinyStatDefinition>.Empty;

        /// <summary>
        ///     The current value of the Stat.
        /// </summary>
        [JsonPropertyName("value")]
        public int Value { get; init; }
    }
}