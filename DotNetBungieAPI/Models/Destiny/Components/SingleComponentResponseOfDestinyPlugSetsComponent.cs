namespace DotNetBungieAPI.Models.Destiny.Components;

public sealed record SingleComponentResponseOfDestinyPlugSetsComponent : ComponentResponse
{
    [JsonPropertyName("data")] public DestinyPlugSetsComponent Data { get; init; }
}