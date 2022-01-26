namespace DotNetBungieAPI.Generated.Models.Config.ClanBanner;

public class ClanBannerDecal : IDeepEquatable<ClanBannerDecal>
{
    [JsonPropertyName("identifier")]
    public string Identifier { get; set; }

    [JsonPropertyName("foregroundPath")]
    public string ForegroundPath { get; set; }

    [JsonPropertyName("backgroundPath")]
    public string BackgroundPath { get; set; }

    public bool DeepEquals(ClanBannerDecal? other)
    {
        return other is not null &&
               Identifier == other.Identifier &&
               ForegroundPath == other.ForegroundPath &&
               BackgroundPath == other.BackgroundPath;
    }
}