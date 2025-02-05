namespace DotNetBungieAPI.Models.Destiny.Components;

public sealed record DictionaryComponentResponseOfint32AndDestinyItemObjectivesComponent
    : ComponentResponse
{
    [JsonPropertyName("data")]
    public ReadOnlyDictionary<int, DestinyItemObjectivesComponent> Data { get; init; } =
        ReadOnlyDictionary<int, DestinyItemObjectivesComponent>.Empty;
}
