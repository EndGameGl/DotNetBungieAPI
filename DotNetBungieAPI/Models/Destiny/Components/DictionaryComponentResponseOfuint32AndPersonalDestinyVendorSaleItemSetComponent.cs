namespace DotNetBungieAPI.Models.Destiny.Components
{
    public sealed record
        DictionaryComponentResponseOfuint32AndPersonalDestinyVendorSaleItemSetComponent : ComponentResponse
    {
        [JsonPropertyName("data")]
        public ReadOnlyDictionary<uint, PersonalDestinyVendorSaleItemSetComponent> Data { get; init; } =
            ReadOnlyDictionaries<uint, PersonalDestinyVendorSaleItemSetComponent>.Empty;
    }
}