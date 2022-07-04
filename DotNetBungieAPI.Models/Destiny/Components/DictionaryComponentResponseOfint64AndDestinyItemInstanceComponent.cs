namespace DotNetBungieAPI.Models.Destiny.Components;

public sealed record DictionaryComponentResponseOfint64AndDestinyItemInstanceComponent : ComponentResponse
{
    [JsonPropertyName("data")]
    public ReadOnlyDictionary<long, DestinyItemInstanceComponent> Data { get; init; } =
        ReadOnlyDictionaries<long, DestinyItemInstanceComponent>.Empty;
}