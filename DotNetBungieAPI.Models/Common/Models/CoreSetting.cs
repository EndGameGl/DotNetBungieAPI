namespace DotNetBungieAPI.Models.Common.Models;

public sealed class CoreSetting
{
    [JsonPropertyName("identifier")]
    public string Identifier { get; init; }

    [JsonPropertyName("isDefault")]
    public bool IsDefault { get; init; }

    [JsonPropertyName("displayName")]
    public string DisplayName { get; init; }

    [JsonPropertyName("summary")]
    public string Summary { get; init; }

    [JsonPropertyName("imagePath")]
    public string ImagePath { get; init; }

    [JsonPropertyName("childSettings")]
    public Common.Models.CoreSetting[]? ChildSettings { get; init; }
}
