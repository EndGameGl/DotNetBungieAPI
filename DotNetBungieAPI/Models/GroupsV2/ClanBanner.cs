using System.Text.Json.Serialization;

namespace DotNetBungieAPI.Models.GroupsV2
{
    public sealed record ClanBanner
    {
        [JsonPropertyName("decalId")] public uint DecalId { get; init; }

        [JsonPropertyName("decalColorId")] public uint DecalColorId { get; init; }

        [JsonPropertyName("decalBackgroundColorId")]
        public uint DecalBackgroundColorId { get; init; }

        [JsonPropertyName("gonfalonId")] public uint GonfalonId { get; init; }

        [JsonPropertyName("gonfalonColorId")] public uint GonfalonColorId { get; init; }

        [JsonPropertyName("gonfalonDetailId")] public uint GonfalonDetailId { get; init; }

        [JsonPropertyName("gonfalonDetailColorId")]
        public uint GonfalonDetailColorId { get; init; }
    }
}