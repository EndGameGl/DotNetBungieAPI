namespace DotNetBungieAPI.Models.Destiny.Components;

public sealed record DictionaryComponentResponseOfint64AndDestinyCurrenciesComponent
    : ComponentResponse
{
    [JsonPropertyName("data")]
    public ReadOnlyDictionary<long, DestinyCurrenciesComponent> Data { get; init; } =
        ReadOnlyDictionary<long, DestinyCurrenciesComponent>.Empty;
}
