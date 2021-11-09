namespace DotNetBungieAPI.Models.Destiny.Components
{
    public sealed record DictionaryComponentResponseOfuint32AndDestinyItemPlugObjectivesComponent : ComponentResponse
    {
        [JsonPropertyName("data")]
        public ReadOnlyDictionary<uint, DestinyItemPlugObjectivesComponent> Data { get; init; } =
            ReadOnlyDictionaries<uint, DestinyItemPlugObjectivesComponent>.Empty;
    }
}