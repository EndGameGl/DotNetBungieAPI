using System.Text.Json.Serialization;

namespace DotNetBungieAPI.Models.Destiny.Components
{
    public sealed record DestinyBaseItemComponentSetOfuint32
    {
        [JsonPropertyName("objectives")]
        public DictionaryComponentResponseOfuint32AndDestinyItemObjectivesComponent Objectives { get; init; }

        [JsonPropertyName("perks")]
        public DictionaryComponentResponseOfuint32AndDestinyItemPerksComponent Perks { get; init; }
    }
}