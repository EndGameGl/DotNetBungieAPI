using System.Text.Json.Serialization;

namespace NetBungieAPI.Models.Responses
{
    public sealed record DestinyEquipItemResult
    {
        [JsonPropertyName("itemInstanceId")]
        public long ItemInstanceId { get; init; }
        [JsonPropertyName("equipStatus")]
        public PlatformErrorCodes EquipStatus { get; init; }
    }
}