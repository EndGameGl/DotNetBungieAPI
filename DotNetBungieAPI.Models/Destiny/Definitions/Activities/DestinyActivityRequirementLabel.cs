namespace DotNetBungieAPI.Models.Destiny.Definitions.Activities;

public sealed record DestinyActivityRequirementLabel
{
    [JsonPropertyName("displayString")]
    public string? DisplayString { get; init; }
}
