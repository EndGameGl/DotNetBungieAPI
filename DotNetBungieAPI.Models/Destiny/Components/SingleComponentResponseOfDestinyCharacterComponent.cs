namespace DotNetBungieAPI.Models.Destiny.Components;

public sealed record SingleComponentResponseOfDestinyCharacterComponent : ComponentResponse
{
    [JsonPropertyName("data")]
    public DestinyCharacterComponent Data { get; init; }
}
