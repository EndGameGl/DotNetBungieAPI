namespace DotNetBungieAPI.Models.Destiny.Components;

public sealed record DictionaryComponentResponseOfint64AndDestinyItemInstanceComponent
    : ComponentResponse
{
    [JsonPropertyName("data")]
    public ReadOnlyDictionary<long, DestinyItemInstanceComponent> Data { get; init; } =
        ReadOnlyDictionary<long, DestinyItemInstanceComponent>.Empty;
}
