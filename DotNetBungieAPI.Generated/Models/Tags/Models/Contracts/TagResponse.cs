namespace DotNetBungieAPI.Generated.Models.Tags.Models.Contracts;

public class TagResponse : IDeepEquatable<TagResponse>
{
    [JsonPropertyName("tagText")]
    public string TagText { get; set; }

    [JsonPropertyName("ignoreStatus")]
    public Ignores.IgnoreResponse IgnoreStatus { get; set; }

    public bool DeepEquals(TagResponse? other)
    {
        return other is not null &&
               TagText == other.TagText &&
               (IgnoreStatus is not null ? IgnoreStatus.DeepEquals(other.IgnoreStatus) : other.IgnoreStatus is null);
    }
}