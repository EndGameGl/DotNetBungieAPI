using System.Text.Json.Serialization;

namespace NetBungieAPI.Models.Destiny.Components
{
    public sealed record DestinyItemComponentSetOfint64
    {
        [JsonPropertyName("instances")]
        public DictionaryComponentResponseOfint64AndDestinyItemInstanceComponent Instances { get; init; }
        [JsonPropertyName("perks")]
        public DictionaryComponentResponseOfint64AndDestinyItemPerksComponent Perks { get; init; }
        [JsonPropertyName("renderData")]
        public DictionaryComponentResponseOfint64AndDestinyItemRenderComponent RenderData { get; init; }
        [JsonPropertyName("stats")]
        public DictionaryComponentResponseOfint64AndDestinyItemStatsComponent Stats { get; init; }
        [JsonPropertyName("sockets")]
        public DictionaryComponentResponseOfint64AndDestinyItemSocketsComponent Sockets { get; init; }
        [JsonPropertyName("reusablePlugs")]
        public DictionaryComponentResponseOfint64AndDestinyItemReusablePlugsComponent ReusablePlugs { get; init; }
        [JsonPropertyName("plugObjectives")]
        public DictionaryComponentResponseOfint64AndDestinyItemPlugObjectivesComponent PlugObjectives { get; init; }
        [JsonPropertyName("talentGrids")]
        public DictionaryComponentResponseOfint64AndDestinyItemTalentGridComponent TalentGrids { get; init; }
        [JsonPropertyName("plugStates")]
        public DictionaryComponentResponseOfuint32AndDestinyItemPlugComponent PlugStates { get; init; }
        [JsonPropertyName("objectives")]
        public DictionaryComponentResponseOfint64AndDestinyItemObjectivesComponent Objectives { get; init; }
    }
}
