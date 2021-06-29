using System.Text.Json.Serialization;

namespace NetBungieAPI.Models.Destiny.Components
{
    public sealed record DestinyBaseItemComponentSetOfuint32
    {
        [JsonPropertyName("objectives")]
        public DictionaryComponentResponseOfuint32AndDestinyItemObjectivesComponent Objectives { get; init; }
    }
}