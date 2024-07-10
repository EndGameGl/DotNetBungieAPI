namespace DotNetBungieAPI.Models.Destiny.Components;

public sealed record SingleComponentResponseOfDestinyCharacterRecordsComponent : ComponentResponse
{
    [JsonPropertyName("data")]
    public DestinyCharacterRecordsComponent Data { get; init; }
}
