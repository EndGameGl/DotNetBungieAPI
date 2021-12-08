namespace DotNetBungieAPI.Models.Destiny.Components;

public sealed record DictionaryComponentResponseOfint64AndDestinyCollectiblesComponent : ComponentResponse
{
    [JsonPropertyName("data")]
    public ReadOnlyDictionary<long, DestinyCollectiblesComponent> Data { get; init; } =
        ReadOnlyDictionaries<long, DestinyCollectiblesComponent>.Empty;
}