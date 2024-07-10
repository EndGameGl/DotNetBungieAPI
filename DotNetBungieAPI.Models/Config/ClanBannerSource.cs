using DotNetBungieAPI.Models.Destiny;

namespace DotNetBungieAPI.Models.Config;

public sealed record ClanBannerSource
{
    [JsonPropertyName("clanBannerDecals")]
    public ReadOnlyDictionary<uint, ClanBannerDecals> ClanBannerDecals { get; init; } =
        ReadOnlyDictionaries<uint, ClanBannerDecals>.Empty;

    [JsonPropertyName("clanBannerDecalPrimaryColors")]
    public ReadOnlyDictionary<uint, DestinyColor> ClanBannerDecalPrimaryColors { get; init; } =
        ReadOnlyDictionaries<uint, DestinyColor>.Empty;

    [JsonPropertyName("clanBannerDecalSecondaryColors")]
    public ReadOnlyDictionary<uint, DestinyColor> ClanBannerDecalSecondaryColors { get; init; } =
        ReadOnlyDictionaries<uint, DestinyColor>.Empty;

    [JsonPropertyName("clanBannerGonfalons")]
    public ReadOnlyDictionary<uint, BungieNetResource> ClanBannerGonfalons { get; init; } =
        ReadOnlyDictionaries<uint, BungieNetResource>.Empty;

    [JsonPropertyName("clanBannerGonfalonColors")]
    public ReadOnlyDictionary<uint, DestinyColor> ClanBannerGonfalonColors { get; init; } =
        ReadOnlyDictionaries<uint, DestinyColor>.Empty;

    [JsonPropertyName("clanBannerGonfalonDetails")]
    public ReadOnlyDictionary<uint, BungieNetResource> ClanBannerGonfalonDetails { get; init; } =
        ReadOnlyDictionaries<uint, BungieNetResource>.Empty;

    [JsonPropertyName("clanBannerGonfalonDetailColors")]
    public ReadOnlyDictionary<uint, DestinyColor> ClanBannerGonfalonDetailColors { get; init; } =
        ReadOnlyDictionaries<uint, DestinyColor>.Empty;

    [JsonPropertyName("clanBannerDecalsSquare")]
    public ReadOnlyDictionary<uint, ClanBannerDecals> ClanBannerDecalsSquare { get; init; } =
        ReadOnlyDictionaries<uint, ClanBannerDecals>.Empty;

    [JsonPropertyName("clanBannerGonfalonDetailsSquare")]
    public ReadOnlyDictionary<
        uint,
        BungieNetResource
    > ClanBannerGonfalonDetailsSquare { get; init; } =
        ReadOnlyDictionaries<uint, BungieNetResource>.Empty;
}
