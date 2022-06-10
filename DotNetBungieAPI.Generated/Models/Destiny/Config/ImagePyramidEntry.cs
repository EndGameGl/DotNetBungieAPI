namespace DotNetBungieAPI.Generated.Models.Destiny.Config;

public class ImagePyramidEntry
{
    /// <summary>
    ///     The name of the subfolder where these images are located.
    /// </summary>
    [JsonPropertyName("name")]
    public string? Name { get; set; }

    /// <summary>
    ///     The factor by which the original image size has been reduced.
    /// </summary>
    [JsonPropertyName("factor")]
    public float? Factor { get; set; }
}
