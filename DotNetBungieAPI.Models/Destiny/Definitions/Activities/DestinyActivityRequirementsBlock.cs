namespace DotNetBungieAPI.Models.Destiny.Definitions.Activities;

public sealed record class DestinyActivityRequirementsBlock
{
    /// <summary>
    ///     If being a fireteam Leader in this activity is gated, this is the gate being checked.
    /// </summary>
    [JsonPropertyName("leaderRequirementLabels")]
    public ReadOnlyCollection<DestinyActivityRequirementLabel> LeaderRequirementLabels { get; init; } =
        ReadOnlyCollections<DestinyActivityRequirementLabel>.Empty;

    /// <summary>
    ///     If being a fireteam member in this activity is gated, this is the gate being checked.
    /// </summary>
    [JsonPropertyName("fireteamRequirementLabels")]
    public ReadOnlyCollection<DestinyActivityRequirementLabel> FireteamRequirementLabels { get; init; } =
        ReadOnlyCollections<DestinyActivityRequirementLabel>.Empty;
}
