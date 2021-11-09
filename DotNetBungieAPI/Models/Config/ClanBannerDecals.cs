namespace DotNetBungieAPI.Models.Config
{
    public sealed record ClanBannerDecals
    {
        [JsonPropertyName("foregroundPath")]
        public BungieNetResource ForegroundPath { get; init; } = BungieNetResource.Empty;

        [JsonPropertyName("backgroundPath")]
        public BungieNetResource BackgroundPath { get; init; } = BungieNetResource.Empty;
    }
}