namespace DotNetBungieAPI.Models.Destiny.Components
{
    public sealed record DictionaryComponentResponseOfint32AndDestinyItemStatsComponent : ComponentResponse
    {
        [JsonPropertyName("data")]
        public ReadOnlyDictionary<int, DestinyItemStatsComponent> Data { get; init; } =
            ReadOnlyDictionaries<int, DestinyItemStatsComponent>.Empty;
    }
}