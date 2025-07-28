namespace DotNetBungieAPI.Generated.Models.Destiny.Definitions.Director;

/// <summary>
///     When a Graph needs to show active Objectives, this defines those objectives as well as an identifier.
/// </summary>
public class DestinyActivityGraphDisplayObjectiveDefinition
{
    /// <summary>
    ///     $NOTE $amola 2017-01-19 This field is apparently something that CUI uses to manually wire up objectives to display info. I am unsure how it works.
    /// </summary>
    [JsonPropertyName("id")]
    public uint Id { get; set; }

    /// <summary>
    ///     The objective being shown on the map.
    /// </summary>
    [Destiny2Definition<Destiny.Definitions.DestinyObjectiveDefinition>("Destiny.Definitions.DestinyObjectiveDefinition")]
    [JsonPropertyName("objectiveHash")]
    public uint ObjectiveHash { get; set; }
}
