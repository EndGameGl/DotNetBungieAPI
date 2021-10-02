using System.Text.Json.Serialization;

namespace DotNetBungieAPI.Models.Destiny.Components
{
    public sealed record SingleComponentResponseOfDestinyItemReusablePlugsComponent : ComponentResponse
    {
        [JsonPropertyName("data")] public DestinyItemReusablePlugsComponent Data { get; init; }
    }
}