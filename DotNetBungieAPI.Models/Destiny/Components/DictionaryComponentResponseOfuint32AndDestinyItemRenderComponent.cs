namespace DotNetBungieAPI.Models.Destiny.Components;

public sealed record DictionaryComponentResponseOfuint32AndDestinyItemRenderComponent
    : ComponentResponse
{
    [JsonPropertyName("data")]
    public ReadOnlyDictionary<uint, DestinyItemRenderComponent> Data { get; init; } =
        ReadOnlyDictionary<uint, DestinyItemRenderComponent>.Empty;
}
