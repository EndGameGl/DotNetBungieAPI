namespace DotNetBungieAPI.Models.Destiny.Components
{
    public sealed record DictionaryComponentResponseOfuint32AndDestinyItemPlugComponent : ComponentResponse
    {
        [JsonPropertyName("data")]
        public ReadOnlyDictionary<uint, DestinyItemPlugComponent> Data { get; init; } =
            ReadOnlyDictionaries<uint, DestinyItemPlugComponent>.Empty;
    }
}