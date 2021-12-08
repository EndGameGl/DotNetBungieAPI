namespace DotNetBungieAPI.Models.Destiny.Components;

public sealed record SingleComponentResponseOfDestinyProfileRecordsComponent : ComponentResponse
{
    [JsonPropertyName("data")] public DestinyProfileRecordsComponent Data { get; init; }
}