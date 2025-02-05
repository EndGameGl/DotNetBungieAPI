namespace DotNetBungieAPI.Models.Destiny.Components;

public sealed record DictionaryComponentResponseOfint64AndDestinyCraftablesComponent
    : ComponentResponse
{
    [JsonPropertyName("data")]
    public ReadOnlyDictionary<long, DestinyCraftablesComponent> Data { get; init; } =
        ReadOnlyDictionary<long, DestinyCraftablesComponent>.Empty;
}
