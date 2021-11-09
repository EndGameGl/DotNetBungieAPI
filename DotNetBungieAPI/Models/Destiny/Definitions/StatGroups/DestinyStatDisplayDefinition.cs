using DotNetBungieAPI.Models.Destiny.Definitions.Stats;
using DotNetBungieAPI.Models.Interpolation;

namespace DotNetBungieAPI.Models.Destiny.Definitions.StatGroups
{
    /// <summary>
    ///     Describes the way that an Item Stat (see DestinyStatDefinition) is transformed using the DestinyStatGroupDefinition
    ///     related to that item. See both of the aforementioned definitions for more information about the stages of stat
    ///     transformation.
    ///     <para />
    ///     This represents the transformation of a stat into a "Display" stat (the closest value that BNet can get to the
    ///     in-game display value of the stat)
    /// </summary>
    public sealed record DestinyStatDisplayDefinition : IDeepEquatable<DestinyStatDisplayDefinition>
    {
        /// <summary>
        ///     If this is true, the stat should be displayed as a number. Otherwise, display it as a progress bar. Or, you know,
        ///     do whatever you want. There's no displayAsNumeric police.
        /// </summary>
        [JsonPropertyName("displayAsNumeric")]
        public bool DisplayAsNumeric { get; init; }

        /// <summary>
        ///     The interpolation table representing how the Investment Stat is transformed into a Display Stat.
        ///     <para />
        ///     See DestinyStatDefinition for a description of the stages of stat transformation.
        /// </summary>
        [JsonPropertyName("displayInterpolation")]
        public ReadOnlyCollection<InterpolationPoint> DisplayInterpolation { get; init; } =
            ReadOnlyCollections<InterpolationPoint>.Empty;

        /// <summary>
        ///     Regardless of the output of interpolation, this is the maximum possible value that the stat can be. It should also
        ///     be used as the upper bound for displaying the stat as a progress bar (the minimum always being 0)
        /// </summary>
        [JsonPropertyName("maximumValue")]
        public int MaximumValue { get; init; }

        /// <summary>
        ///     DestinyStatDefinition for the stat being transformed into a Display stat.
        /// </summary>
        [JsonPropertyName("statHash")]
        public DefinitionHashPointer<DestinyStatDefinition> Stat { get; init; } =
            DefinitionHashPointer<DestinyStatDefinition>.Empty;

        public bool DeepEquals(DestinyStatDisplayDefinition other)
        {
            return other != null &&
                   DisplayAsNumeric == other.DisplayAsNumeric &&
                   DisplayInterpolation.DeepEqualsReadOnlyCollections(other.DisplayInterpolation) &&
                   MaximumValue == other.MaximumValue &&
                   Stat.DeepEquals(other.Stat);
        }
    }
}