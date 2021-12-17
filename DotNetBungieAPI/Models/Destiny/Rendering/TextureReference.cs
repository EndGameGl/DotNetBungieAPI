namespace DotNetBungieAPI.Models.Destiny.Rendering;

public sealed record TextureReference
{
    [JsonPropertyName("name")]
    public string Name { get; init; }
    
    [JsonPropertyName("reference_id")]
    public string ReferenceId { get; init; }
}