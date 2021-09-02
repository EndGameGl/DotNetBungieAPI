using System.Text.Json.Serialization;

namespace NetBungieAPI.Models.Config
{
    public sealed record ClanBannerDecals
    {
        [JsonPropertyName("foregroundPath")]
        public DestinyResource ForegroundPath { get; init; } = DestinyResource.Empty;

        [JsonPropertyName("backgroundPath")]
        public DestinyResource BackgroundPath { get; init; } = DestinyResource.Empty;
    }
}