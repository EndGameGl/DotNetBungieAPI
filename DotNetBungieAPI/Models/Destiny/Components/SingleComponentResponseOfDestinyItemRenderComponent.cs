namespace DotNetBungieAPI.Models.Destiny.Components
{
    public sealed record SingleComponentResponseOfDestinyItemRenderComponent : ComponentResponse
    {
        [JsonPropertyName("data")] public DestinyItemRenderComponent Data { get; init; }
    }
}