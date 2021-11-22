namespace DotNetBungieAPI.Models.Destiny.Components
{
    public sealed record SingleComponentResponseOfDestinyCharacterProgressionComponent : ComponentResponse
    {
        [JsonPropertyName("data")] public DestinyCharacterProgressionComponent Data { get; init; }
    }
}