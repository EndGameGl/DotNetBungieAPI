namespace DotNetBungieAPI.Models.Destiny.Components;

public sealed record SingleComponentResponseOfDestinyItemStatsComponent : ComponentResponse
{
    [JsonPropertyName("data")] public DestinyItemStatsComponent Data { get; init; }
}