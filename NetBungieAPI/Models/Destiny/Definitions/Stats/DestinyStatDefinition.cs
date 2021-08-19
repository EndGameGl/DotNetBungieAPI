using System.Text.Json.Serialization;
using NetBungieAPI.Attributes;
using NetBungieAPI.Models.Destiny.Definitions.Common;

namespace NetBungieAPI.Models.Destiny.Definitions.Stats
{
    /// <summary>
    ///     This represents a stat that's applied to a character or an item (such as a weapon, piece of armor, or a vehicle).
    ///     <para />
    ///     An example of a stat might be Attack Power on a weapon.
    ///     <para />
    ///     Stats go through a complex set of transformations before they end up being shown to the user as a number or a
    ///     progress bar, and those transformations are fundamentally intertwined with the concept of a "Stat Group"
    ///     (DestinyStatGroupDefinition). Items have both Stats and a reference to a Stat Group, and it is the Stat Group that
    ///     takes the raw stat information and gives it both rendering metadata (such as whether to show it as a number or a
    ///     progress bar) and the final transformation data (interpolation tables to turn the raw investment stat into a
    ///     display stat). Please see DestinyStatGroupDefinition for more information on that transformational process.
    ///     <para />
    ///     Stats are segregated from Stat Groups because different items and types of items can refer to the same stat, but
    ///     have different "scales" for the stat while still having the same underlying value. For example, both a Shotgun and
    ///     an Auto Rifle may have a "raw" impact stat of 50, but the Auto Rifle's Stat Group will scale that 50 down so that,
    ///     when it is displayed, it is a smaller value relative to the shotgun. (this is a totally made up example, don't
    ///     assume shotguns have naturally higher impact than auto rifles because of this)
    ///     <para />
    ///     A final caveat is that some stats, even after this "final" transformation, go through yet another set of
    ///     transformations directly in the game as a result of dynamic, stateful scripts that get run. BNet has no access to
    ///     these scripts, nor any way to know which scripts get executed. As a result, the stats for an item that you see
    ///     in-game - particularly for stats that are often impacted by Perks, like Magazine Size - can change dramatically
    ///     from what we return on Bungie.Net. This is a known issue with no fix coming down the pipeline. Take these stats
    ///     with a grain of salt.
    ///     <para />
    ///     Stats actually go through four transformations, for those interested:
    ///     <para />
    ///     1) "Sandbox" stat, the "most raw" form. These are pretty much useless without transformations applied, and thus are
    ///     not currently returned in the API. If you really want these, we can provide them. Maybe someone could do something
    ///     cool with it?
    ///     <para />
    ///     2) "Investment" stat (the stat's value after DestinyStatDefinition's interpolation tables and aggregation logic is
    ///     applied to the "Sandbox" stat value)
    ///     <para />
    ///     3) "Display" stat (the stat's base UI-visible value after DestinyStatGroupDefinition's interpolation tables are
    ///     applied to the Investment Stat value. For most stats, this is what is displayed.)
    ///     <para />
    ///     4) Underlying in-game stat (the stat's actual value according to the game, after the game runs dynamic scripts
    ///     based on the game and character's state. This is the final transformation that BNet does not have access to. For
    ///     most stats, this is not actually displayed to the user, with the exception of Magazine Size which is then piped
    ///     back to the UI for display in-game, but not to BNet.)
    /// </summary>
    [DestinyDefinition(DefinitionsEnum.DestinyStatDefinition)]
    public sealed record DestinyStatDefinition : IDestinyDefinition, IDeepEquatable<DestinyStatDefinition>
    {
        [JsonPropertyName("displayProperties")]
        public DestinyDisplayPropertiesDefinition DisplayProperties { get; init; }

        /// <summary>
        ///     Stats can exist on a character or an item, and they may potentially be aggregated in different ways. The
        ///     DestinyStatAggregationType enum value indicates the way that this stat is being aggregated.
        /// </summary>
        [JsonPropertyName("aggregationType")]
        public DestinyStatAggregationType AggregationType { get; init; }

        /// <summary>
        ///     True if the stat is computed rather than being delivered as a raw value on items.
        ///     <para />
        ///     For instance, the Light stat in Destiny 1 was a computed stat.
        /// </summary>
        [JsonPropertyName("hasComputedBlock")]
        public bool HasComputedBlock { get; init; }

        /// <summary>
        ///     The category of the stat, according to the game.
        /// </summary>
        [JsonPropertyName("statCategory")]
        public DestinyStatCategory StatCategory { get; init; }

        [JsonPropertyName("interpolate")] public bool Interpolate { get; init; }

        public bool DeepEquals(DestinyStatDefinition other)
        {
            return other != null &&
                   AggregationType == other.AggregationType &&
                   DisplayProperties.DeepEquals(other.DisplayProperties) &&
                   HasComputedBlock == other.HasComputedBlock &&
                   Interpolate == other.Interpolate &&
                   StatCategory == other.StatCategory &&
                   Blacklisted == other.Blacklisted &&
                   Hash == other.Hash &&
                   Index == other.Index &&
                   Redacted == other.Redacted;
        }

        public DefinitionsEnum DefinitionEnumValue => DefinitionsEnum.DestinyStatDefinition;
        [JsonPropertyName("blacklisted")] public bool Blacklisted { get; init; }
        [JsonPropertyName("hash")] public uint Hash { get; init; }
        [JsonPropertyName("index")] public int Index { get; init; }
        [JsonPropertyName("redacted")] public bool Redacted { get; init; }

        public void MapValues()
        {
        }

        public void SetPointerLocales(BungieLocales locale)
        {
        }

        public override string ToString()
        {
            return $"{Hash} {DisplayProperties.Name}: {DisplayProperties.Description}";
        }
    }
}