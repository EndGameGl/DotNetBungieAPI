namespace DotNetBungieAPI.Generated.Models.Destiny.Definitions;

public class DestinyActivityLoadoutRequirementSet
{
    /// <summary>
    ///     The set of requirements that will be applied on the activity if this requirement set is active.
    /// </summary>
    [JsonPropertyName("requirements")]
    public Destiny.Definitions.DestinyActivityLoadoutRequirement[]? Requirements { get; set; }
}
