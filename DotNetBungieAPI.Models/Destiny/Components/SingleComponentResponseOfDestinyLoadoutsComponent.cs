namespace DotNetBungieAPI.Models.Destiny.Components;

public sealed record SingleComponentResponseOfDestinyLoadoutsComponent : ComponentResponse
{
    [JsonPropertyName("data")]
    public DestinyLoadoutsComponent Data { get; init; }
}
