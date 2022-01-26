namespace DotNetBungieAPI.Generated.Models.Destiny.Definitions;

/// <summary>
///     Describes the way that an Item Stat (see DestinyStatDefinition) is transformed using the DestinyStatGroupDefinition related to that item. See both of the aforementioned definitions for more information about the stages of stat transformation.
/// <para />
///     This represents the transformation of a stat into a "Display" stat (the closest value that BNet can get to the in-game display value of the stat)
/// </summary>
public class DestinyStatDisplayDefinition : IDeepEquatable<DestinyStatDisplayDefinition>
{
    /// <summary>
    ///     The hash identifier for the stat being transformed into a Display stat.
    /// <para />
    ///     Use it to look up the DestinyStatDefinition, or key into a DestinyInventoryItemDefinition's stats property.
    /// </summary>
    [JsonPropertyName("statHash")]
    public uint StatHash { get; set; }

    /// <summary>
    ///     Regardless of the output of interpolation, this is the maximum possible value that the stat can be. It should also be used as the upper bound for displaying the stat as a progress bar (the minimum always being 0)
    /// </summary>
    [JsonPropertyName("maximumValue")]
    public int MaximumValue { get; set; }

    /// <summary>
    ///     If this is true, the stat should be displayed as a number. Otherwise, display it as a progress bar. Or, you know, do whatever you want. There's no displayAsNumeric police.
    /// </summary>
    [JsonPropertyName("displayAsNumeric")]
    public bool DisplayAsNumeric { get; set; }

    /// <summary>
    ///     The interpolation table representing how the Investment Stat is transformed into a Display Stat. 
    /// <para />
    ///     See DestinyStatDefinition for a description of the stages of stat transformation.
    /// </summary>
    [JsonPropertyName("displayInterpolation")]
    public List<Interpolation.InterpolationPoint> DisplayInterpolation { get; set; }

    public bool DeepEquals(DestinyStatDisplayDefinition? other)
    {
        return other is not null &&
               StatHash == other.StatHash &&
               MaximumValue == other.MaximumValue &&
               DisplayAsNumeric == other.DisplayAsNumeric &&
               DisplayInterpolation.DeepEqualsList(other.DisplayInterpolation);
    }
}