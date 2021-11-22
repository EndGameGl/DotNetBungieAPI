namespace DotNetBungieAPI.Models.Destiny.Components
{
    public sealed record DictionaryComponentResponseOfuint32AndDestinyVendorCategoriesComponent : ComponentResponse
    {
        [JsonPropertyName("data")]
        public ReadOnlyDictionary<uint, DestinyVendorCategoriesComponent> Data { get; init; } =
            ReadOnlyDictionaries<uint, DestinyVendorCategoriesComponent>.Empty;
    }
}