using System.Text.Json.Serialization;

namespace NetBungieAPI.Models.Destiny.Components
{
    public sealed record SingleComponentResponseOfDestinyCurrenciesComponent : ComponentResponse
    {
        [JsonPropertyName("data")] public DestinyCurrenciesComponent Data { get; init; }
    }
}