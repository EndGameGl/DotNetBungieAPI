using System.Text.Json.Serialization;

namespace DotNetBungieAPI.Generated.Models.Destiny.Definitions;

public sealed class DestinyEquipmentSlotDefinition
{

    [JsonPropertyName("displayProperties")]
    public Destiny.Definitions.Common.DestinyDisplayPropertiesDefinition DisplayProperties { get; init; }

    [JsonPropertyName("equipmentCategoryHash")]
    public uint EquipmentCategoryHash { get; init; }

    [JsonPropertyName("bucketTypeHash")]
    public uint BucketTypeHash { get; init; }

    [JsonPropertyName("applyCustomArtDyes")]
    public bool ApplyCustomArtDyes { get; init; }

    [JsonPropertyName("artDyeChannels")]
    public List<Destiny.Definitions.DestinyArtDyeReference> ArtDyeChannels { get; init; }

    [JsonPropertyName("hash")]
    public uint Hash { get; init; }

    [JsonPropertyName("index")]
    public int Index { get; init; }

    [JsonPropertyName("redacted")]
    public bool Redacted { get; init; }
}
