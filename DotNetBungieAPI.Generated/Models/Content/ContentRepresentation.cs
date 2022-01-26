namespace DotNetBungieAPI.Generated.Models.Content;

public class ContentRepresentation : IDeepEquatable<ContentRepresentation>
{
    [JsonPropertyName("name")]
    public string Name { get; set; }

    [JsonPropertyName("path")]
    public string Path { get; set; }

    [JsonPropertyName("validationString")]
    public string ValidationString { get; set; }

    public bool DeepEquals(ContentRepresentation? other)
    {
        return other is not null &&
               Name == other.Name &&
               Path == other.Path &&
               ValidationString == other.ValidationString;
    }
}