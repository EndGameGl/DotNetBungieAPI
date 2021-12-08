namespace DotNetBungieAPI.Models.Destiny.Components;

public sealed record DictionaryComponentResponseOfint64AndDestinyCurrenciesComponent : ComponentResponse
{
    [JsonPropertyName("data")]
    public ReadOnlyDictionary<long, DestinyCurrenciesComponent> Data { get; init; } =
        ReadOnlyDictionaries<long, DestinyCurrenciesComponent>.Empty;
}