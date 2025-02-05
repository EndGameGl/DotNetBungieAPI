namespace DotNetBungieAPI.Models.Destiny.Components;

public sealed record DictionaryComponentResponseOfuint32AndPersonalDestinyVendorSaleItemSetComponent
    : ComponentResponse
{
    [JsonPropertyName("data")]
    public ReadOnlyDictionary<uint, PersonalDestinyVendorSaleItemSetComponent> Data { get; init; } =
        ReadOnlyDictionary<uint, PersonalDestinyVendorSaleItemSetComponent>.Empty;
}
