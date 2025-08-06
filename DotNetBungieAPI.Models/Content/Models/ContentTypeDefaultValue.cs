namespace DotNetBungieAPI.Models.Content.Models;

public sealed class ContentTypeDefaultValue
{
    [JsonPropertyName("whenClause")]
    public string WhenClause { get; init; }

    [JsonPropertyName("whenValue")]
    public string WhenValue { get; init; }

    [JsonPropertyName("defaultValue")]
    public string DefaultValue { get; init; }
}
