namespace DotNetBungieAPI.Models.Destiny.Components;

public sealed record DictionaryComponentResponseOfint64AndDestinyCharacterProgressionComponent
    : ComponentResponse
{
    [JsonPropertyName("data")]
    public ReadOnlyDictionary<long, DestinyCharacterProgressionComponent> Data { get; init; } =
        ReadOnlyDictionaries<long, DestinyCharacterProgressionComponent>.Empty;
}
