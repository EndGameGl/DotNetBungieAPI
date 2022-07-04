namespace DotNetBungieAPI.Models.Destiny.Components;

public sealed record DictionaryComponentResponseOfint64AndDestinyCharacterRecordsComponent : ComponentResponse
{
    [JsonPropertyName("data")]
    public ReadOnlyDictionary<long, DestinyCharacterRecordsComponent> Data { get; init; } =
        ReadOnlyDictionaries<long, DestinyCharacterRecordsComponent>.Empty;
}