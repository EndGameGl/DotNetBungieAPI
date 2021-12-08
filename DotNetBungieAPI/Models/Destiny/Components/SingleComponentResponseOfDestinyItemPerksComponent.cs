namespace DotNetBungieAPI.Models.Destiny.Components;

public sealed record SingleComponentResponseOfDestinyItemPerksComponent : ComponentResponse
{
    [JsonPropertyName("data")] public DestinyItemPerksComponent Data { get; init; }
}