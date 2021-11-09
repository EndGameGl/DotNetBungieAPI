namespace DotNetBungieAPI.Models.Destiny.Components
{
    public sealed record SingleComponentResponseOfDestinyInventoryComponent : ComponentResponse
    {
        [JsonPropertyName("data")] public DestinyInventoryComponent Data { get; init; }
    }
}