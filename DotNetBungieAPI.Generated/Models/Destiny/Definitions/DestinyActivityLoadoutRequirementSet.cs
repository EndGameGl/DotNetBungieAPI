using System.Text.Json.Serialization;

namespace DotNetBungieAPI.Generated.Models.Destiny.Definitions;

public sealed class DestinyActivityLoadoutRequirementSet
{

    [JsonPropertyName("requirements")]
    public List<Destiny.Definitions.DestinyActivityLoadoutRequirement> Requirements { get; init; }
}
