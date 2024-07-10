namespace DotNetBungieAPI.Models.Destiny.Components;

public sealed record DictionaryComponentResponseOfint64AndDestinyItemReusablePlugsComponent
    : ComponentResponse
{
    [JsonPropertyName("data")]
    public ReadOnlyDictionary<long, DestinyItemReusablePlugsComponent> Data { get; init; } =
        ReadOnlyDictionaries<long, DestinyItemReusablePlugsComponent>.Empty;
}
