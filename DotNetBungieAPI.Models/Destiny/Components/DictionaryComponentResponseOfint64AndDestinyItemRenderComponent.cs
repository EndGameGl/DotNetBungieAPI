namespace DotNetBungieAPI.Models.Destiny.Components;

public sealed record DictionaryComponentResponseOfint64AndDestinyItemRenderComponent
    : ComponentResponse
{
    [JsonPropertyName("data")]
    public ReadOnlyDictionary<long, DestinyItemRenderComponent> Data { get; init; } =
        ReadOnlyDictionary<long, DestinyItemRenderComponent>.Empty;
}
