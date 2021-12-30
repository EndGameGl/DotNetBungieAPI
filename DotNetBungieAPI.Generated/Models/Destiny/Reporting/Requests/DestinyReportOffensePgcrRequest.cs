using System.Text.Json.Serialization;

namespace DotNetBungieAPI.Generated.Models.Destiny.Reporting.Requests;

public sealed class DestinyReportOffensePgcrRequest
{

    [JsonPropertyName("reasonCategoryHashes")]
    public List<uint> ReasonCategoryHashes { get; init; }

    [JsonPropertyName("reasonHashes")]
    public List<uint> ReasonHashes { get; init; }

    [JsonPropertyName("offendingCharacterId")]
    public long OffendingCharacterId { get; init; }
}
