namespace DotNetBungieAPI.Generated.Models.Content.Models;

public class ContentTypeDefaultValue : IDeepEquatable<ContentTypeDefaultValue>
{
    [JsonPropertyName("whenClause")]
    public string WhenClause { get; set; }

    [JsonPropertyName("whenValue")]
    public string WhenValue { get; set; }

    [JsonPropertyName("defaultValue")]
    public string DefaultValue { get; set; }

    public bool DeepEquals(ContentTypeDefaultValue? other)
    {
        return other is not null &&
               WhenClause == other.WhenClause &&
               WhenValue == other.WhenValue &&
               DefaultValue == other.DefaultValue;
    }
}