using System.Collections.ObjectModel;
using System.Text.Json.Serialization;
using DotNetBungieAPI.Attributes;
using DotNetBungieAPI.Defaults;

namespace DotNetBungieAPI.Models.Destiny.Definitions.StatGroups
{
    /// <summary>
    ///     When an inventory item (DestinyInventoryItemDefinition) has Stats (such as Attack Power), the item will refer to a
    ///     Stat Group. This definition enumerates the properties used to transform the item's "Investment" stats into
    ///     "Display" stats.
    ///     <para />
    ///     See DestinyStatDefinition's documentation for information about the transformation of Stats, and the meaning of an
    ///     Investment vs. a Display stat.
    ///     <para />
    ///     If you don't want to do these calculations on your own, fear not: pulling live data from the BNet endpoints will
    ///     return display stat values pre-computed and ready for you to use. I highly recommend this approach, saves a lot of
    ///     time and also accounts for certain stat modifiers that can't easily be accounted for without live data (such as
    ///     stat modifiers on Talent Grids and Socket Plugs)
    /// </summary>
    [DestinyDefinition(DefinitionsEnum.DestinyStatGroupDefinition)]
    public sealed record DestinyStatGroupDefinition : IDestinyDefinition, IDeepEquatable<DestinyStatGroupDefinition>
    {
        /// <summary>
        ///     The maximum possible value that any stat in this group can be transformed into.
        ///     <para />
        ///     This is used by stats that *don't* have scaledStats entries below, but that still need to be displayed as a
        ///     progress bar, in which case this is used as the upper bound for said progress bar. (the lower bound is always 0)
        /// </summary>
        [JsonPropertyName("maximumValue")]
        public int MaximumValue { get; init; }

        /// <summary>
        ///     This apparently indicates the position of the stats in the UI? I've returned it in case anyone can use it, but it's
        ///     not of any use to us on BNet. Something's being lost in translation with this value.
        /// </summary>
        [JsonPropertyName("uiPosition")]
        public int UiPosition { get; init; }

        /// <summary>
        ///     Any stat that requires scaling to be transformed from an "Investment" stat to a "Display" stat will have an entry
        ///     in this list. For more information on what those types of stats mean and the transformation process, see
        ///     DestinyStatDefinition.
        ///     <para />
        ///     In retrospect, I wouldn't mind if this was a dictionary keyed by the stat hash instead. But I'm going to leave it
        ///     be because [[After Apple Picking]].
        /// </summary>
        [JsonPropertyName("scaledStats")]
        public ReadOnlyCollection<DestinyStatDisplayDefinition> ScaledStats { get; init; } =
            ReadOnlyCollections<DestinyStatDisplayDefinition>.Empty;

        /// <summary>
        ///     The game has the ability to override, based on the stat group, what the localized text is that is displayed for
        ///     Stats being shown on the item.
        ///     <para />
        ///     Mercifully, no Stat Groups use this feature currently. If they start using them, we'll all need to start using them
        ///     (and those of you who are more prudent than I am can go ahead and start pre-checking for this.)
        /// </summary>
        [JsonPropertyName("overrides")]
        public ReadOnlyDictionary<uint, DestinyStatOverrideDefinition> Overrides { get; init; } =
            ReadOnlyDictionaries<uint, DestinyStatOverrideDefinition>.Empty;

        public bool DeepEquals(DestinyStatGroupDefinition other)
        {
            return other != null &&
                   MaximumValue == other.MaximumValue &&
                   UiPosition == other.UiPosition &&
                   ScaledStats.DeepEqualsReadOnlyCollections(other.ScaledStats) &&
                   Overrides.DeepEqualsReadOnlyDictionaryWithSimpleKeyAndEquatableValue(other.Overrides) &&
                   Blacklisted == other.Blacklisted &&
                   Hash == other.Hash &&
                   Index == other.Index &&
                   Redacted == other.Redacted;
        }

        public DefinitionsEnum DefinitionEnumValue => DefinitionsEnum.DestinyStatGroupDefinition;
        [JsonPropertyName("blacklisted")] public bool Blacklisted { get; init; }
        [JsonPropertyName("hash")] public uint Hash { get; init; }
        [JsonPropertyName("index")] public int Index { get; init; }
        [JsonPropertyName("redacted")] public bool Redacted { get; init; }

        public void MapValues()
        {
            foreach (var stat in ScaledStats) stat.Stat.TryMapValue();

            foreach (var value in Overrides.Values) value.Stat.TryMapValue();
        }

        public void SetPointerLocales(BungieLocales locale)
        {
            foreach (var stat in ScaledStats) stat.Stat.SetLocale(locale);

            foreach (var value in Overrides.Values) value.Stat.SetLocale(locale);
        }

        public override string ToString()
        {
            return $"{Hash} {MaximumValue}";
        }
    }
}