namespace DotNetBungieAPI.Generated.Models.GroupsV2;

public class ClanBanner : IDeepEquatable<ClanBanner>
{
    [JsonPropertyName("decalId")]
    public uint DecalId { get; set; }

    [JsonPropertyName("decalColorId")]
    public uint DecalColorId { get; set; }

    [JsonPropertyName("decalBackgroundColorId")]
    public uint DecalBackgroundColorId { get; set; }

    [JsonPropertyName("gonfalonId")]
    public uint GonfalonId { get; set; }

    [JsonPropertyName("gonfalonColorId")]
    public uint GonfalonColorId { get; set; }

    [JsonPropertyName("gonfalonDetailId")]
    public uint GonfalonDetailId { get; set; }

    [JsonPropertyName("gonfalonDetailColorId")]
    public uint GonfalonDetailColorId { get; set; }

    public bool DeepEquals(ClanBanner? other)
    {
        return other is not null &&
               DecalId == other.DecalId &&
               DecalColorId == other.DecalColorId &&
               DecalBackgroundColorId == other.DecalBackgroundColorId &&
               GonfalonId == other.GonfalonId &&
               GonfalonColorId == other.GonfalonColorId &&
               GonfalonDetailId == other.GonfalonDetailId &&
               GonfalonDetailColorId == other.GonfalonDetailColorId;
    }
}