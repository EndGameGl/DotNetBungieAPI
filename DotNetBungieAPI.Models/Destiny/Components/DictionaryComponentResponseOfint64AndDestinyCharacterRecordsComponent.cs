namespace DotNetBungieAPI.Models.Destiny.Components;

public sealed record DictionaryComponentResponseOfint64AndDestinyCharacterRecordsComponent
    : ComponentResponse
{
    [JsonPropertyName("data")]
    public ReadOnlyDictionary<long, DestinyCharacterRecordsComponent> Data { get; init; } =
        ReadOnlyDictionary<long, DestinyCharacterRecordsComponent>.Empty;
}
