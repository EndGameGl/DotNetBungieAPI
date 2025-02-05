namespace DotNetBungieAPI.Models.Destiny.Components;

public sealed record DictionaryComponentResponseOfuint32AndDestinyItemReusablePlugsComponent
    : ComponentResponse
{
    [JsonPropertyName("data")]
    public ReadOnlyDictionary<uint, DestinyItemReusablePlugsComponent> Data { get; init; } =
        ReadOnlyDictionary<uint, DestinyItemReusablePlugsComponent>.Empty;
}
