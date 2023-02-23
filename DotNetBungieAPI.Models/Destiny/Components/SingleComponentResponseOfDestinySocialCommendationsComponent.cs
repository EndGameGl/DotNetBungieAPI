namespace DotNetBungieAPI.Models.Destiny.Components;

public sealed record SingleComponentResponseOfDestinySocialCommendationsComponent : ComponentResponse
{
    [JsonPropertyName("data")]
    public DestinySocialCommendationsComponent Data { get; init; }
}
