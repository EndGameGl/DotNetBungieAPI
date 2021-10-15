using System.Text.Json.Serialization;

namespace DotNetBungieAPI.Models.Destiny.Components
{
    public sealed record DestinyItemComponentSetOfuint32
    {
        [JsonPropertyName("instances")]
        public DictionaryComponentResponseOfuint32AndDestinyItemInstanceComponent Instances { get; init; }

        [JsonPropertyName("renderData")]
        public DictionaryComponentResponseOfuint32AndDestinyItemRenderComponent RenderData { get; init; }

        [JsonPropertyName("stats")]
        public DictionaryComponentResponseOfuint32AndDestinyItemStatsComponent Stats { get; init; }

        [JsonPropertyName("sockets")]
        public DictionaryComponentResponseOfuint32AndDestinyItemSocketsComponent Sockets { get; init; }

        [JsonPropertyName("reusablePlugs")]
        public DictionaryComponentResponseOfuint32AndDestinyItemReusablePlugsComponent ReusablePlugs { get; init; }

        [JsonPropertyName("plugObjectives")]
        public DictionaryComponentResponseOfuint32AndDestinyItemPlugObjectivesComponent PlugObjectives { get; init; }

        [JsonPropertyName("talentGrids")]
        public DictionaryComponentResponseOfuint32AndDestinyItemTalentGridComponent TalentGrids { get; init; }

        [JsonPropertyName("plugStates")]
        public DictionaryComponentResponseOfuint32AndDestinyItemPlugComponent PlugStates { get; init; }

        [JsonPropertyName("objectives")]
        public DictionaryComponentResponseOfuint32AndDestinyItemObjectivesComponent Objectives { get; init; }

        [JsonPropertyName("perks")]
        public DictionaryComponentResponseOfuint32AndDestinyItemPerksComponent Perks { get; init; }
    }
}