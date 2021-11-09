namespace DotNetBungieAPI.Models.Destiny.Components
{
    public sealed record SingleComponentResponseOfDestinyItemComponent : ComponentResponse
    {
        [JsonPropertyName("data")] public DestinyItemComponent Data { get; init; }
    }
}