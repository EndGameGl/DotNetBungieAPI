namespace DotNetBungieAPI.Models.Destiny.Components;

public sealed record SingleComponentResponseOfDestinyItemPlugObjectivesComponent : ComponentResponse
{
    [JsonPropertyName("data")] public DestinyItemPlugObjectivesComponent Data { get; init; }
}