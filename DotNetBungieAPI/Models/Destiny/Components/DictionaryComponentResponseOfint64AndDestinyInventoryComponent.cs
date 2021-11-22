namespace DotNetBungieAPI.Models.Destiny.Components
{
    public sealed record DictionaryComponentResponseOfint64AndDestinyInventoryComponent : ComponentResponse
    {
        [JsonPropertyName("data")]
        public ReadOnlyDictionary<long, DestinyInventoryComponent> Data { get; init; } =
            ReadOnlyDictionaries<long, DestinyInventoryComponent>.Empty;
    }
}