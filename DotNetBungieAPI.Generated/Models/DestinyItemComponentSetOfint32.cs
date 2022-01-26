namespace DotNetBungieAPI.Generated.Models;

public class DestinyItemComponentSetOfint32 : IDeepEquatable<DestinyItemComponentSetOfint32>
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

    public bool DeepEquals(DestinyItemComponentSetOfint32? other)
    {
        return other is not null &&
               (Instances is not null ? Instances.DeepEquals(other.Instances) : other.Instances is null) &&
               (RenderData is not null ? RenderData.DeepEquals(other.RenderData) : other.RenderData is null) &&
               (Stats is not null ? Stats.DeepEquals(other.Stats) : other.Stats is null) &&
               (Sockets is not null ? Sockets.DeepEquals(other.Sockets) : other.Sockets is null) &&
               (ReusablePlugs is not null ? ReusablePlugs.DeepEquals(other.ReusablePlugs) : other.ReusablePlugs is null) &&
               (PlugObjectives is not null ? PlugObjectives.DeepEquals(other.PlugObjectives) : other.PlugObjectives is null) &&
               (TalentGrids is not null ? TalentGrids.DeepEquals(other.TalentGrids) : other.TalentGrids is null) &&
               (PlugStates is not null ? PlugStates.DeepEquals(other.PlugStates) : other.PlugStates is null) &&
               (Objectives is not null ? Objectives.DeepEquals(other.Objectives) : other.Objectives is null) &&
               (Perks is not null ? Perks.DeepEquals(other.Perks) : other.Perks is null);
    }
}