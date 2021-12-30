using System.Text.Json.Serialization;

namespace DotNetBungieAPI.Generated.Models.Destiny.Definitions;

public sealed class DestinyActivityLoadoutRequirementSet
{

    /// <summary>
    ///     The set of requirements that will be applied on the activity if this requirement set is active.
    /// </summary>
    [JsonPropertyName("requirements")]
    public List<Destiny.Definitions.DestinyActivityLoadoutRequirement> Requirements { get; init; }
}
