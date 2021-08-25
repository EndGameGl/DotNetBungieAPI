using System.Collections.ObjectModel;
using System.Text.Json.Serialization;
using NetBungieAPI.Models.Destiny;

namespace NetBungieAPI.Models.Config
{
    public sealed record ClanBannerSource
    {
        [JsonPropertyName("clanBannerDecals")]
        public ReadOnlyDictionary<uint, ClanBannerDecals> ClanBannerDecals { get; init; } =
            Defaults.EmptyReadOnlyDictionary<uint, ClanBannerDecals>();

        [JsonPropertyName("clanBannerDecalPrimaryColors")]
        public ReadOnlyDictionary<uint, DestinyColor> ClanBannerDecalPrimaryColors { get; init; } =
            Defaults.EmptyReadOnlyDictionary<uint, DestinyColor>();
        
        [JsonPropertyName("clanBannerDecalSecondaryColors")]
        public ReadOnlyDictionary<uint, DestinyColor> ClanBannerDecalSecondaryColors { get; init; } =
            Defaults.EmptyReadOnlyDictionary<uint, DestinyColor>();
        
        [JsonPropertyName("clanBannerGonfalons")]
        public ReadOnlyDictionary<uint, DestinyResource> ClanBannerGonfalons { get; init; } =
            Defaults.EmptyReadOnlyDictionary<uint, DestinyResource>();
        
        [JsonPropertyName("clanBannerGonfalonColors")]
        public ReadOnlyDictionary<uint, DestinyColor> ClanBannerGonfalonColors { get; init; } =
            Defaults.EmptyReadOnlyDictionary<uint, DestinyColor>();
        
        [JsonPropertyName("clanBannerGonfalonDetails")]
        public ReadOnlyDictionary<uint, DestinyResource> ClanBannerGonfalonDetails { get; init; } =
            Defaults.EmptyReadOnlyDictionary<uint, DestinyResource>();
        
        [JsonPropertyName("clanBannerGonfalonDetailColors")]
        public ReadOnlyDictionary<uint, DestinyColor> ClanBannerGonfalonDetailColors { get; init; } =
            Defaults.EmptyReadOnlyDictionary<uint, DestinyColor>();
        
        [JsonPropertyName("clanBannerDecalsSquare")]
        public ReadOnlyDictionary<uint, ClanBannerDecals> ClanBannerDecalsSquare { get; init; } =
            Defaults.EmptyReadOnlyDictionary<uint, ClanBannerDecals>();
        
        [JsonPropertyName("clanBannerGonfalonDetailsSquare")]
        public ReadOnlyDictionary<uint, DestinyResource> ClanBannerGonfalonDetailsSquare { get; init; } =
            Defaults.EmptyReadOnlyDictionary<uint, DestinyResource>();
    }
}