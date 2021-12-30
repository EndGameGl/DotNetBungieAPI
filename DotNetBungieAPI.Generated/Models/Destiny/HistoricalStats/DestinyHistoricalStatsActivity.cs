using System.Text.Json.Serialization;

namespace DotNetBungieAPI.Generated.Models.Destiny.HistoricalStats;

public sealed class DestinyHistoricalStatsActivity
{

    [JsonPropertyName("referenceId")]
    public uint ReferenceId { get; init; }

    [JsonPropertyName("directorActivityHash")]
    public uint DirectorActivityHash { get; init; }

    [JsonPropertyName("instanceId")]
    public long InstanceId { get; init; }

    [JsonPropertyName("mode")]
    public Destiny.HistoricalStats.Definitions.DestinyActivityModeType Mode { get; init; }

    [JsonPropertyName("modes")]
    public List<Destiny.HistoricalStats.Definitions.DestinyActivityModeType> Modes { get; init; }

    [JsonPropertyName("isPrivate")]
    public bool IsPrivate { get; init; }

    [JsonPropertyName("membershipType")]
    public BungieMembershipType MembershipType { get; init; }
}
