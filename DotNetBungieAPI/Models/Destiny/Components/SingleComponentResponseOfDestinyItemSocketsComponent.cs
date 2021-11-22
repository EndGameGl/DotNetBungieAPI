namespace DotNetBungieAPI.Models.Destiny.Components
{
    public sealed record SingleComponentResponseOfDestinyItemSocketsComponent : ComponentResponse
    {
        [JsonPropertyName("data")] public DestinyItemSocketsComponent Data { get; init; }
    }
}