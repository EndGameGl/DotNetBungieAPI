using System.Text.Json.Serialization;

namespace DotNetBungieAPI.Generated.Models.Destiny.Entities.Items;

public sealed class DestinyItemStatsComponent
{

    [JsonPropertyName("stats")]
    public Dictionary<uint, Destiny.DestinyStat> Stats { get; init; }
}
