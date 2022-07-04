namespace DotNetBungieAPI.Models.Destiny.Components;

public sealed record SingleComponentResponseOfDestinyProfileComponent : ComponentResponse
{
    [JsonPropertyName("data")] public DestinyProfileComponent Data { get; init; }
}