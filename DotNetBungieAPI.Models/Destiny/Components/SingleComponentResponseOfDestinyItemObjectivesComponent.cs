namespace DotNetBungieAPI.Models.Destiny.Components;

public sealed record SingleComponentResponseOfDestinyItemObjectivesComponent : ComponentResponse
{
    [JsonPropertyName("data")] public DestinyItemObjectivesComponent Data { get; init; }
}