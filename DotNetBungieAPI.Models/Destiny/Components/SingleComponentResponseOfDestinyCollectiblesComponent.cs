namespace DotNetBungieAPI.Models.Destiny.Components;

public sealed record SingleComponentResponseOfDestinyCollectiblesComponent : ComponentResponse
{
    [JsonPropertyName("data")]
    public DestinyCollectiblesComponent Data { get; init; }
}
