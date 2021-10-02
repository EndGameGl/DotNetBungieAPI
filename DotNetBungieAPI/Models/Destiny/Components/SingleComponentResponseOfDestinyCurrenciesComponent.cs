using System.Text.Json.Serialization;

namespace DotNetBungieAPI.Models.Destiny.Components
{
    public sealed record SingleComponentResponseOfDestinyCurrenciesComponent : ComponentResponse
    {
        [JsonPropertyName("data")] public DestinyCurrenciesComponent Data { get; init; }
    }
}