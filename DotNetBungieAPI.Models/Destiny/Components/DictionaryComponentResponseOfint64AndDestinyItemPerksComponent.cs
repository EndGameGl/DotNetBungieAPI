namespace DotNetBungieAPI.Models.Destiny.Components;

public sealed record DictionaryComponentResponseOfint64AndDestinyItemPerksComponent
    : ComponentResponse
{
    [JsonPropertyName("data")]
    public ReadOnlyDictionary<long, DestinyItemPerksComponent> Data { get; init; } =
        ReadOnlyDictionaries<long, DestinyItemPerksComponent>.Empty;
}
