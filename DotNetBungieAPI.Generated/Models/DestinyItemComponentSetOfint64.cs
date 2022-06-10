namespace DotNetBungieAPI.Generated.Models;

public class DestinyItemComponentSetOfint64
{
    [JsonPropertyName("instances")]
    public DictionaryComponentResponseOfint64AndDestinyItemInstanceComponent? Instances { get; set; }

    [JsonPropertyName("renderData")]
    public DictionaryComponentResponseOfint64AndDestinyItemRenderComponent? RenderData { get; set; }

    [JsonPropertyName("stats")]
    public DictionaryComponentResponseOfint64AndDestinyItemStatsComponent? Stats { get; set; }

    [JsonPropertyName("sockets")]
    public DictionaryComponentResponseOfint64AndDestinyItemSocketsComponent? Sockets { get; set; }

    [JsonPropertyName("reusablePlugs")]
    public DictionaryComponentResponseOfint64AndDestinyItemReusablePlugsComponent? ReusablePlugs { get; set; }

    [JsonPropertyName("plugObjectives")]
    public DictionaryComponentResponseOfint64AndDestinyItemPlugObjectivesComponent? PlugObjectives { get; set; }

    [JsonPropertyName("talentGrids")]
    public DictionaryComponentResponseOfint64AndDestinyItemTalentGridComponent? TalentGrids { get; set; }

    [JsonPropertyName("plugStates")]
    public DictionaryComponentResponseOfuint32AndDestinyItemPlugComponent? PlugStates { get; set; }

    [JsonPropertyName("objectives")]
    public DictionaryComponentResponseOfint64AndDestinyItemObjectivesComponent? Objectives { get; set; }

    [JsonPropertyName("perks")]
    public DictionaryComponentResponseOfint64AndDestinyItemPerksComponent? Perks { get; set; }
}
