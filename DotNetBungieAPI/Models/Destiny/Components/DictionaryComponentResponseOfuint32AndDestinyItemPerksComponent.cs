namespace DotNetBungieAPI.Models.Destiny.Components
{
    public sealed record DictionaryComponentResponseOfuint32AndDestinyItemPerksComponent : ComponentResponse
    {
        [JsonPropertyName("data")]
        public ReadOnlyDictionary<uint, DestinyItemPerksComponent> Data { get; init; } =
            ReadOnlyDictionaries<uint, DestinyItemPerksComponent>.Empty;
    }
}