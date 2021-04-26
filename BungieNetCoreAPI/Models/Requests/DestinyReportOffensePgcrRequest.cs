using System.Text.Json.Serialization;

namespace NetBungieAPI.Models.Requests
{
    public sealed class DestinyReportOffensePgcrRequest
    {
        [JsonPropertyName("reasonCategoryHashes")]
        public uint[] ReasonCategoryHashes { get; }
        [JsonPropertyName("reasonHashes")]
        public uint[] ReasonHashes { get; }
        [JsonPropertyName("offendingCharacterId")]
        public long OffendingCharacterId { get; }

        public DestinyReportOffensePgcrRequest(uint[] reasonCategoryHashes, uint[] reasonHashes,
            long offendingCharacterId)
        {
            ReasonCategoryHashes = reasonCategoryHashes;
            ReasonHashes = reasonHashes;
            OffendingCharacterId = offendingCharacterId;
        }
    }
}