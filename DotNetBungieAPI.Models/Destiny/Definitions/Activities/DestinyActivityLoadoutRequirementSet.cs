namespace DotNetBungieAPI.Models.Destiny.Definitions.Activities;

public sealed record DestinyActivityLoadoutRequirementSet
    : IDeepEquatable<DestinyActivityLoadoutRequirementSet>
{
    /// <summary>
    ///     The set of requirements that will be applied on the activity if this requirement set is active.
    /// </summary>
    [JsonPropertyName("requirements")]
    public ReadOnlyCollection<DestinyActivityLoadoutRequirement> Requirements { get; init; } =
        ReadOnlyCollection<DestinyActivityLoadoutRequirement>.Empty;

    public bool DeepEquals(DestinyActivityLoadoutRequirementSet other)
    {
        return other != null && Requirements.DeepEqualsReadOnlyCollection(other.Requirements);
    }
}
