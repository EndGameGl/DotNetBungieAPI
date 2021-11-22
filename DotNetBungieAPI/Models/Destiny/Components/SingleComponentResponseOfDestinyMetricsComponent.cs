namespace DotNetBungieAPI.Models.Destiny.Components
{
    public sealed record SingleComponentResponseOfDestinyMetricsComponent : ComponentResponse
    {
        [JsonPropertyName("data")] public DestinyMetricsComponent Data { get; init; }
    }
}