namespace DotNetBungieAPI.Models.Destiny.Components;

public sealed record SingleComponentResponseOfDestinyItemInstanceComponent : ComponentResponse
{
    [JsonPropertyName("data")] public DestinyItemInstanceComponent Data { get; init; }
}