namespace DotNetBungieAPI.Generated.Models.Destiny.Definitions;

/// <summary>
///     Defines a specific stat value on an item, and the minimum/maximum range that we could compute for the item based on our heuristics for how the item might be generated.
/// <para />
///     Not guaranteed to match real-world instances of the item, but should hopefully at least be close. If it's not close, let us know on the Bungie API forums.
/// </summary>
public class DestinyInventoryItemStatDefinition
{
    /// <summary>
    ///     The hash for the DestinyStatDefinition representing this stat.
    /// </summary>
    [JsonPropertyName("statHash")]
    public uint StatHash { get; set; }

    /// <summary>
    ///     This value represents the stat value assuming the minimum possible roll but accounting for any mandatory bonuses that should be applied to the stat on item creation.
    /// <para />
    ///     In Destiny 1, this was different from the "minimum" value because there were certain conditions where an item could be theoretically lower level/value than the initial roll. 
    /// <para />
    ///     In Destiny 2, this is not possible unless Talent Grids begin to be used again for these purposes or some other system change occurs... thus in practice, value and minimum should be the same in Destiny 2. Good riddance.
    /// </summary>
    [JsonPropertyName("value")]
    public int Value { get; set; }

    /// <summary>
    ///     The minimum possible value for this stat that we think the item can roll.
    /// </summary>
    [JsonPropertyName("minimum")]
    public int Minimum { get; set; }

    /// <summary>
    ///     The maximum possible value for this stat that we think the item can roll.
    /// <para />
    ///     WARNING: In Destiny 1, this field was calculated using the potential stat rolls on the item's talent grid. In Destiny 2, items no longer have meaningful talent grids and instead have sockets: but the calculation of this field was never altered to adapt to this change. As such, this field should be considered deprecated until we can address this oversight.
    /// </summary>
    [JsonPropertyName("maximum")]
    public int Maximum { get; set; }

    /// <summary>
    ///     The maximum possible value for the stat as shown in the UI, if it is being shown somewhere that reveals maximum in the UI (such as a bar chart-style view).
    /// <para />
    ///     This is pulled directly from the item's DestinyStatGroupDefinition, and placed here for convenience.
    /// <para />
    ///     If not returned, there is no maximum to use (and thus the stat should not be shown in a way that assumes there is a limit to the stat)
    /// </summary>
    [JsonPropertyName("displayMaximum")]
    public int? DisplayMaximum { get; set; }
}
