namespace DotNetBungieAPI.Models.Content;

public sealed record ContentTypePropertySection
{
    [JsonPropertyName("name")]
    public string Name { get; init; }

    [JsonPropertyName("readableName")]
    public string ReadableName { get; init; }

    [JsonPropertyName("collapsed")]
    public bool Collapsed { get; init; }
}
