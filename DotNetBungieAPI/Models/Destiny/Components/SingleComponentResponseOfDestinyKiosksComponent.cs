namespace DotNetBungieAPI.Models.Destiny.Components
{
    public sealed record SingleComponentResponseOfDestinyKiosksComponent : ComponentResponse
    {
        [JsonPropertyName("data")] public DestinyKiosksComponent Data { get; init; }
    }
}