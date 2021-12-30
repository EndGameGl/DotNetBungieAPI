using System.Text.Json.Serialization;

namespace DotNetBungieAPI.Generated.Models.Destiny;

public sealed class DestinyEquipItemResults
{

    [JsonPropertyName("equipResults")]
    public List<Destiny.DestinyEquipItemResult> EquipResults { get; init; }
}
