using System.Text.Json.Serialization;

namespace DotNetBungieAPI.Models.Destiny.Components
{
    public sealed record SingleComponentResponseOfDestinyPresentationNodesComponent : ComponentResponse
    {
        [JsonPropertyName("data")] public DestinyPresentationNodesComponent Data { get; init; }
    }
}