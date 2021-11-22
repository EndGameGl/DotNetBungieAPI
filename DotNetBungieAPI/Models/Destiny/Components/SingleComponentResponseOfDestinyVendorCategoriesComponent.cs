namespace DotNetBungieAPI.Models.Destiny.Components
{
    public sealed record SingleComponentResponseOfDestinyVendorCategoriesComponent : ComponentResponse
    {
        [JsonPropertyName("data")] public DestinyVendorCategoriesComponent Data { get; init; }
    }
}