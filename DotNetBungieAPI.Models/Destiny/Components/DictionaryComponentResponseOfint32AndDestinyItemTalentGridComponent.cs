namespace DotNetBungieAPI.Models.Destiny.Components;

public sealed record DictionaryComponentResponseOfint32AndDestinyItemTalentGridComponent : ComponentResponse
{
    [JsonPropertyName("data")]
    public ReadOnlyDictionary<int, DestinyItemTalentGridComponent> Data { get; init; } =
        ReadOnlyDictionaries<int, DestinyItemTalentGridComponent>.Empty;
}