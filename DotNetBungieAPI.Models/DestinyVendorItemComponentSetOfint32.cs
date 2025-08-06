namespace DotNetBungieAPI.Models;

public sealed class DestinyVendorItemComponentSetOfint32
{
    [JsonPropertyName("itemComponents")]
    public DictionaryComponentResponseOfint32AndDestinyItemComponent? ItemComponents { get; init; }

    [JsonPropertyName("instances")]
    public DictionaryComponentResponseOfint32AndDestinyItemInstanceComponent? Instances { get; init; }

    [JsonPropertyName("renderData")]
    public DictionaryComponentResponseOfint32AndDestinyItemRenderComponent? RenderData { get; init; }

    [JsonPropertyName("stats")]
    public DictionaryComponentResponseOfint32AndDestinyItemStatsComponent? Stats { get; init; }

    [JsonPropertyName("sockets")]
    public DictionaryComponentResponseOfint32AndDestinyItemSocketsComponent? Sockets { get; init; }

    [JsonPropertyName("reusablePlugs")]
    public DictionaryComponentResponseOfint32AndDestinyItemReusablePlugsComponent? ReusablePlugs { get; init; }

    [JsonPropertyName("plugObjectives")]
    public DictionaryComponentResponseOfint32AndDestinyItemPlugObjectivesComponent? PlugObjectives { get; init; }

    [JsonPropertyName("talentGrids")]
    public DictionaryComponentResponseOfint32AndDestinyItemTalentGridComponent? TalentGrids { get; init; }

    [JsonPropertyName("plugStates")]
    public DictionaryComponentResponseOfuint32AndDestinyItemPlugComponent? PlugStates { get; init; }

    [JsonPropertyName("objectives")]
    public DictionaryComponentResponseOfint32AndDestinyItemObjectivesComponent? Objectives { get; init; }

    [JsonPropertyName("perks")]
    public DictionaryComponentResponseOfint32AndDestinyItemPerksComponent? Perks { get; init; }
}
