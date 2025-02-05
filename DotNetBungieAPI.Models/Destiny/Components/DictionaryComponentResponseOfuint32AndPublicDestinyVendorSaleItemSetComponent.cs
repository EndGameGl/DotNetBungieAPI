namespace DotNetBungieAPI.Models.Destiny.Components;

public sealed record DictionaryComponentResponseOfuint32AndPublicDestinyVendorSaleItemSetComponent
    : ComponentResponse
{
    [JsonPropertyName("data")]
    public ReadOnlyDictionary<uint, PublicDestinyVendorSaleItemSetComponent> Data { get; init; } =
        ReadOnlyDictionary<uint, PublicDestinyVendorSaleItemSetComponent>.Empty;
}
