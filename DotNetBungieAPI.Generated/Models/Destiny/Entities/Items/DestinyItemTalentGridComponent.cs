using System.Text.Json.Serialization;

namespace DotNetBungieAPI.Generated.Models.Destiny.Entities.Items;

public sealed class DestinyItemTalentGridComponent
{

    [JsonPropertyName("talentGridHash")]
    public uint TalentGridHash { get; init; }

    [JsonPropertyName("nodes")]
    public List<Destiny.DestinyTalentNode> Nodes { get; init; }

    [JsonPropertyName("isGridComplete")]
    public bool IsGridComplete { get; init; }

    [JsonPropertyName("gridProgression")]
    public Destiny.DestinyProgression GridProgression { get; init; }
}
