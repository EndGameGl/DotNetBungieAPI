namespace DotNetBungieAPI.Generated.Models;

public class DestinyItemComponentSetOfint32
{
    [JsonPropertyName("instances")]
    public DictionaryComponentResponseOfint32AndDestinyItemInstanceComponent Instances { get; set; }

    [JsonPropertyName("renderData")]
    public DictionaryComponentResponseOfint32AndDestinyItemRenderComponent RenderData { get; set; }

    [JsonPropertyName("stats")]
    public DictionaryComponentResponseOfint32AndDestinyItemStatsComponent Stats { get; set; }

    [JsonPropertyName("sockets")]
    public DictionaryComponentResponseOfint32AndDestinyItemSocketsComponent Sockets { get; set; }

    [JsonPropertyName("reusablePlugs")]
    public DictionaryComponentResponseOfint32AndDestinyItemReusablePlugsComponent ReusablePlugs { get; set; }

    [JsonPropertyName("plugObjectives")]
    public DictionaryComponentResponseOfint32AndDestinyItemPlugObjectivesComponent PlugObjectives { get; set; }

    [JsonPropertyName("talentGrids")]
    public DictionaryComponentResponseOfint32AndDestinyItemTalentGridComponent TalentGrids { get; set; }

    [JsonPropertyName("plugStates")]
    public DictionaryComponentResponseOfuint32AndDestinyItemPlugComponent PlugStates { get; set; }

    [JsonPropertyName("objectives")]
    public DictionaryComponentResponseOfint32AndDestinyItemObjectivesComponent Objectives { get; set; }

    [JsonPropertyName("perks")]
    public DictionaryComponentResponseOfint32AndDestinyItemPerksComponent Perks { get; set; }
}
