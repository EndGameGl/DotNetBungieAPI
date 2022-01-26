namespace DotNetBungieAPI.Generated.Models.Content.Models;

public class ContentTypePropertySection : IDeepEquatable<ContentTypePropertySection>
{
    [JsonPropertyName("name")]
    public string Name { get; set; }

    [JsonPropertyName("readableName")]
    public string ReadableName { get; set; }

    [JsonPropertyName("collapsed")]
    public bool Collapsed { get; set; }

    public bool DeepEquals(ContentTypePropertySection? other)
    {
        return other is not null &&
               Name == other.Name &&
               ReadableName == other.ReadableName &&
               Collapsed == other.Collapsed;
    }
}