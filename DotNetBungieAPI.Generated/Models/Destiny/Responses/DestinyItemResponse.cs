using System.Text.Json.Serialization;

namespace DotNetBungieAPI.Generated.Models.Destiny.Responses;

public sealed class DestinyItemResponse
{

    [JsonPropertyName("characterId")]
    public long? CharacterId { get; init; }

    [JsonPropertyName("item")]
    public SingleComponentResponseOfDestinyItemComponent Item { get; init; }

    [JsonPropertyName("instance")]
    public SingleComponentResponseOfDestinyItemInstanceComponent Instance { get; init; }

    [JsonPropertyName("objectives")]
    public SingleComponentResponseOfDestinyItemObjectivesComponent Objectives { get; init; }

    [JsonPropertyName("perks")]
    public SingleComponentResponseOfDestinyItemPerksComponent Perks { get; init; }

    [JsonPropertyName("renderData")]
    public SingleComponentResponseOfDestinyItemRenderComponent RenderData { get; init; }

    [JsonPropertyName("stats")]
    public SingleComponentResponseOfDestinyItemStatsComponent Stats { get; init; }

    [JsonPropertyName("talentGrid")]
    public SingleComponentResponseOfDestinyItemTalentGridComponent TalentGrid { get; init; }

    [JsonPropertyName("sockets")]
    public SingleComponentResponseOfDestinyItemSocketsComponent Sockets { get; init; }

    [JsonPropertyName("reusablePlugs")]
    public SingleComponentResponseOfDestinyItemReusablePlugsComponent ReusablePlugs { get; init; }

    [JsonPropertyName("plugObjectives")]
    public SingleComponentResponseOfDestinyItemPlugObjectivesComponent PlugObjectives { get; init; }
}
