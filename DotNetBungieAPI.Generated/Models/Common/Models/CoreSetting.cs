namespace DotNetBungieAPI.Generated.Models.Common.Models;

public class CoreSetting
{
    [JsonPropertyName("identifier")]
    public string? Identifier { get; set; }

    [JsonPropertyName("isDefault")]
    public bool? IsDefault { get; set; }

    [JsonPropertyName("displayName")]
    public string? DisplayName { get; set; }

    [JsonPropertyName("summary")]
    public string? Summary { get; set; }

    [JsonPropertyName("imagePath")]
    public string? ImagePath { get; set; }

    [JsonPropertyName("childSettings")]
    public List<Common.Models.CoreSetting> ChildSettings { get; set; }
}
