namespace DotNetBungieAPI.Models.Destiny.Components;

public sealed record DictionaryComponentResponseOfint32AndDestinyVendorSaleItemComponent
    : ComponentResponse
{
    [JsonPropertyName("data")]
    public ReadOnlyDictionary<int, DestinyVendorSaleItemComponent> Data { get; init; } =
        ReadOnlyDictionary<int, DestinyVendorSaleItemComponent>.Empty;
}
