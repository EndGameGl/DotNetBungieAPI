namespace DotNetBungieAPI.Models.Destiny.Components;

public sealed record SingleComponentResponseOfDestinyCharacterActivitiesComponent
    : ComponentResponse
{
    [JsonPropertyName("data")]
    public DestinyCharacterActivitiesComponent Data { get; init; }
}
