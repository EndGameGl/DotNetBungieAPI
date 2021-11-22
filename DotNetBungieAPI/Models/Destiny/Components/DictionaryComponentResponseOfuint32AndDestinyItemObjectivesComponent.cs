namespace DotNetBungieAPI.Models.Destiny.Components
{
    public sealed record DictionaryComponentResponseOfuint32AndDestinyItemObjectivesComponent : ComponentResponse
    {
        [JsonPropertyName("data")]
        public ReadOnlyDictionary<uint, DestinyItemObjectivesComponent> Data { get; init; } =
            ReadOnlyDictionaries<uint, DestinyItemObjectivesComponent>.Empty;
    }
}