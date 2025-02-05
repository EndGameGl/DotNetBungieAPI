namespace DotNetBungieAPI.Models.Destiny.Components;

public sealed record DictionaryComponentResponseOfint64AndDestinyPresentationNodesComponent
    : ComponentResponse
{
    [JsonPropertyName("data")]
    public ReadOnlyDictionary<long, DestinyPresentationNodesComponent> Data { get; init; } =
        ReadOnlyDictionary<long, DestinyPresentationNodesComponent>.Empty;
}
