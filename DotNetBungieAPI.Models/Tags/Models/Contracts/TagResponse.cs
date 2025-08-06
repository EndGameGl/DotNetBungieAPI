namespace DotNetBungieAPI.Models.Tags.Models.Contracts;

public sealed class TagResponse
{
    [JsonPropertyName("tagText")]
    public string TagText { get; init; }

    [JsonPropertyName("ignoreStatus")]
    public Ignores.IgnoreResponse? IgnoreStatus { get; init; }
}
