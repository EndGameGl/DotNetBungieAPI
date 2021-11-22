namespace DotNetBungieAPI.Models.Destiny.Components
{
    public sealed record DictionaryComponentResponseOfuint32AndDestinyVendorComponent : ComponentResponse
    {
        [JsonPropertyName("data")]
        public ReadOnlyDictionary<uint, DestinyVendorComponent> Data { get; init; } =
            ReadOnlyDictionaries<uint, DestinyVendorComponent>.Empty;
    }
}