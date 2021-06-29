using System.Text.Json.Serialization;

namespace NetBungieAPI.Models.Destiny.Components
{
    public sealed record SingleComponentResponseOfDestinyVendorCategoriesComponent : ComponentResponse
    {
        [JsonPropertyName("data")] public DestinyVendorCategoriesComponent Data { get; init; }
    }
}