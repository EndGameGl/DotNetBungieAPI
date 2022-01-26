namespace DotNetBungieAPI.Generated.Models.Destiny.Definitions.Director;

/// <summary>
///     When a Graph needs to show active Objectives, this defines those objectives as well as an identifier.
/// </summary>
public class DestinyActivityGraphDisplayObjectiveDefinition : IDeepEquatable<DestinyActivityGraphDisplayObjectiveDefinition>
{
    /// <summary>
    ///     $NOTE $amola 2017-01-19 This field is apparently something that CUI uses to manually wire up objectives to display info. I am unsure how it works.
    /// </summary>
    [JsonPropertyName("id")]
    public uint Id { get; set; }

    /// <summary>
    ///     The objective being shown on the map.
    /// </summary>
    [JsonPropertyName("objectiveHash")]
    public uint ObjectiveHash { get; set; }

    public bool DeepEquals(DestinyActivityGraphDisplayObjectiveDefinition? other)
    {
        return other is not null &&
               Id == other.Id &&
               ObjectiveHash == other.ObjectiveHash;
    }
}