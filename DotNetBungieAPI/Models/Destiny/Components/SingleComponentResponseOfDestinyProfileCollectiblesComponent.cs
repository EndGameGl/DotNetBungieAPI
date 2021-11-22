namespace DotNetBungieAPI.Models.Destiny.Components
{
    public sealed record SingleComponentResponseOfDestinyProfileCollectiblesComponent : ComponentResponse
    {
        [JsonPropertyName("data")] public DestinyProfileCollectiblesComponent Data { get; init; }
    }
}