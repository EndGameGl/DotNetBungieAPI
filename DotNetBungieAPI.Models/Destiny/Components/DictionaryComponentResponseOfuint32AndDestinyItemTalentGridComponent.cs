namespace DotNetBungieAPI.Models.Destiny.Components;

public sealed record DictionaryComponentResponseOfuint32AndDestinyItemTalentGridComponent
    : ComponentResponse
{
    [JsonPropertyName("data")]
    public ReadOnlyDictionary<uint, DestinyItemTalentGridComponent> Data { get; init; } =
        ReadOnlyDictionary<uint, DestinyItemTalentGridComponent>.Empty;
}
