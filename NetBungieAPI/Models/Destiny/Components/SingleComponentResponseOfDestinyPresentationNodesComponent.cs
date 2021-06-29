using System.Text.Json.Serialization;

namespace NetBungieAPI.Models.Destiny.Components
{
    public sealed record SingleComponentResponseOfDestinyPresentationNodesComponent : ComponentResponse
    {
        [JsonPropertyName("data")] public DestinyPresentationNodesComponent Data { get; init; }
    }
}