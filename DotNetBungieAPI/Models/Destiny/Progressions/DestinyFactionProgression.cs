using DotNetBungieAPI.Models.Destiny.Definitions.Factions;

namespace DotNetBungieAPI.Models.Destiny.Progressions
{
    /// <summary>
    ///     Mostly for historical purposes, we segregate Faction progressions from other progressions. This is just a
    ///     DestinyProgression with a shortcut for finding the DestinyFactionDefinition of the faction related to the
    ///     progression.
    /// </summary>
    public sealed record DestinyFactionProgression : DestinyProgression
    {
        /// <summary>
        ///     The hash identifier of the Faction related to this progression. Use it to look up the DestinyFactionDefinition for
        ///     more rendering info.
        /// </summary>
        [JsonPropertyName("factionHash")]
        public DefinitionHashPointer<DestinyFactionDefinition> Faction { get; init; } =
            DefinitionHashPointer<DestinyFactionDefinition>.Empty;

        /// <summary>
        ///     The index of the Faction vendor that is currently available. Will be set to -1 if no vendors are available.
        /// </summary>
        [JsonPropertyName("factionVendorIndex")]
        public int FactionVendorIndex { get; init; }
    }
}