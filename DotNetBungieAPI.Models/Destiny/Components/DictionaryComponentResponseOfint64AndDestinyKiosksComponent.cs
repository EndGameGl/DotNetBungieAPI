namespace DotNetBungieAPI.Models.Destiny.Components;

public sealed record DictionaryComponentResponseOfint64AndDestinyKiosksComponent : ComponentResponse
{
    [JsonPropertyName("data")]
    public ReadOnlyDictionary<long, DestinyKiosksComponent> Data { get; init; } =
        ReadOnlyDictionary<long, DestinyKiosksComponent>.Empty;
}
