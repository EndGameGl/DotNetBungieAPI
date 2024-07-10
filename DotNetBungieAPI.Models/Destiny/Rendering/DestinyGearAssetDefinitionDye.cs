namespace DotNetBungieAPI.Models.Destiny.Rendering;

public sealed record DestinyGearAssetDefinitionDye
{
    [JsonPropertyName("hash")]
    public uint Hash { get; init; }

    [JsonPropertyName("investment_hash")]
    public uint InvestmentHash { get; init; }

    [JsonPropertyName("slot_type_index")]
    public int SlotTypeIndex { get; init; }

    [JsonPropertyName("cloth")]
    public bool Cloth { get; init; }

    [JsonPropertyName("material_properties")]
    public MaterialProperties MaterialProperties { get; init; }

    [JsonPropertyName("textures")]
    public DestinyGearAssetDefinitionDyeTextures Textures { get; init; }
}
