namespace DotNetBungieAPI.Models.Destiny.Components
{
    public sealed record DictionaryComponentResponseOfint64AndDestinyCharacterActivitiesComponent : ComponentResponse
    {
        [JsonPropertyName("data")]
        public ReadOnlyDictionary<long, DestinyCharacterActivitiesComponent> Data { get; init; } =
            ReadOnlyDictionaries<long, DestinyCharacterActivitiesComponent>.Empty;
    }
}