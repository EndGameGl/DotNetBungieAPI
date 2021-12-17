namespace DotNetBungieAPI.Models.Destiny.Rendering;

public sealed record DestinyGearAssetDefinitionDyeTextures
{
    [JsonPropertyName("diffuse")] 
    public TextureReference Diffuse { get; init; }
    
    [JsonPropertyName("normal")] 
    public TextureReference Normal { get; init; }
    
    [JsonPropertyName("primary_diffuse")] 
    public TextureReference PrimaryDiffuse { get; init; }

    [JsonPropertyName("secondary_diffuse")]
    public TextureReference SecondaryDiffuse { get; init; }
}