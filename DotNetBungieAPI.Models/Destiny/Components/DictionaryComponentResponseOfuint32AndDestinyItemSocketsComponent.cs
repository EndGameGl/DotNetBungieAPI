namespace DotNetBungieAPI.Models.Destiny.Components;

public sealed record DictionaryComponentResponseOfuint32AndDestinyItemSocketsComponent
    : ComponentResponse
{
    [JsonPropertyName("data")]
    public ReadOnlyDictionary<uint, DestinyItemSocketsComponent> Data { get; init; } =
        ReadOnlyDictionary<uint, DestinyItemSocketsComponent>.Empty;
}
