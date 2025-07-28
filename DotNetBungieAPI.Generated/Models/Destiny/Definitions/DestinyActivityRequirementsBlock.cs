namespace DotNetBungieAPI.Generated.Models.Destiny.Definitions;

public class DestinyActivityRequirementsBlock
{
    /// <summary>
    ///     If being a fireteam Leader in this activity is gated, this is the gate being checked.
    /// </summary>
    [JsonPropertyName("leaderRequirementLabels")]
    public Destiny.Definitions.DestinyActivityRequirementLabel[]? LeaderRequirementLabels { get; set; }

    /// <summary>
    ///     If being a fireteam member in this activity is gated, this is the gate being checked.
    /// </summary>
    [JsonPropertyName("fireteamRequirementLabels")]
    public Destiny.Definitions.DestinyActivityRequirementLabel[]? FireteamRequirementLabels { get; set; }
}
