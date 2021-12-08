namespace DotNetBungieAPI.Models.Destiny.Components;

public sealed record DictionaryComponentResponseOfint32AndDestinyItemPlugObjectivesComponent : ComponentResponse
{
    [JsonPropertyName("data")]
    public ReadOnlyDictionary<int, DestinyItemPlugObjectivesComponent> Data { get; init; } =
        ReadOnlyDictionaries<int, DestinyItemPlugObjectivesComponent>.Empty;
}