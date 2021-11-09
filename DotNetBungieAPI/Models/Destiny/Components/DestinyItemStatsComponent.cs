using DotNetBungieAPI.Models.Destiny.Definitions.Stats;
using DotNetBungieAPI.Models.Destiny.Items;

namespace DotNetBungieAPI.Models.Destiny.Components
{
    /// <summary>
    ///     If you want the stats on an item's instanced data, get this component.
    ///     <para />
    ///     These are stats like Attack, Defense etc... and *not* historical stats.
    ///     <para />
    ///     Note that some stats have additional computation in-game at runtime - for instance, Magazine Size - and thus these
    ///     stats might not be 100% accurate compared to what you see in-game for some stats. I know, it sucks. I hate it too.
    /// </summary>
    public sealed record DestinyItemStatsComponent
    {
        /// <summary>
        ///     If the item has stats that it provides (damage, defense, etc...), it will be given here.
        /// </summary>
        [JsonPropertyName("stats")]
        public ReadOnlyDictionary<DefinitionHashPointer<DestinyStatDefinition>, DestinyStat> Stats { get; init; } =
            ReadOnlyDictionaries<DefinitionHashPointer<DestinyStatDefinition>, DestinyStat>.Empty;
    }
}