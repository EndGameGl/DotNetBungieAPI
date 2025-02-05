namespace DotNetBungieAPI.Models.Destiny.Components;

public sealed record DictionaryComponentResponseOfint64AndDestinyLoadoutsComponent
    : ComponentResponse
{
    [JsonPropertyName("data")]
    public ReadOnlyDictionary<long, DestinyLoadoutsComponent> Data { get; init; } =
        ReadOnlyDictionary<long, DestinyLoadoutsComponent>.Empty;
}
