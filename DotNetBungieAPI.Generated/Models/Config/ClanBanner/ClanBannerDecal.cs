using System.Text.Json.Serialization;

namespace DotNetBungieAPI.Generated.Models.Config.ClanBanner;

public sealed class ClanBannerDecal
{

    [JsonPropertyName("identifier")]
    public string Identifier { get; init; }

    [JsonPropertyName("foregroundPath")]
    public string ForegroundPath { get; init; }

    [JsonPropertyName("backgroundPath")]
    public string BackgroundPath { get; init; }
}
