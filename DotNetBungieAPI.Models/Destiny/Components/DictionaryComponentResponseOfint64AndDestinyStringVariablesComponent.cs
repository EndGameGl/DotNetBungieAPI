namespace DotNetBungieAPI.Models.Destiny.Components;

public sealed record DictionaryComponentResponseOfint64AndDestinyStringVariablesComponent
    : ComponentResponse
{
    [JsonPropertyName("data")]
    public ReadOnlyDictionary<long, DestinyStringVariablesComponent> Data { get; init; } =
        ReadOnlyDictionaries<long, DestinyStringVariablesComponent>.Empty;
}
