namespace DotNetBungieAPI.Models.Destiny.Components;

public sealed record DictionaryComponentResponseOfint64AndDestinyItemSocketsComponent : ComponentResponse
{
    [JsonPropertyName("data")]
    public ReadOnlyDictionary<long, DestinyItemSocketsComponent> Data { get; init; } =
        ReadOnlyDictionaries<long, DestinyItemSocketsComponent>.Empty;
}