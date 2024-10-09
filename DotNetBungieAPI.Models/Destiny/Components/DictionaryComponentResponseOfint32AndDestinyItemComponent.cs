namespace DotNetBungieAPI.Models.Destiny.Components;

public sealed record DictionaryComponentResponseOfint32AndDestinyItemComponent : ComponentResponse
{
    [JsonPropertyName("data")]
    public ReadOnlyDictionary<int, DestinyItemComponent> Data { get; init; } =
        ReadOnlyDictionaries<int, DestinyItemComponent>.Empty;
}
