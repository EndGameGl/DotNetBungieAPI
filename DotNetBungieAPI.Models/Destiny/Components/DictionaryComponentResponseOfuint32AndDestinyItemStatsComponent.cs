namespace DotNetBungieAPI.Models.Destiny.Components;

public sealed record DictionaryComponentResponseOfuint32AndDestinyItemStatsComponent
    : ComponentResponse
{
    [JsonPropertyName("data")]
    public ReadOnlyDictionary<uint, DestinyItemStatsComponent> Data { get; init; } =
        ReadOnlyDictionary<uint, DestinyItemStatsComponent>.Empty;
}
