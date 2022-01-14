namespace DotNetBungieAPI.Generated.Models.Content;

public sealed class ContentItemPublicContract
{

    [JsonPropertyName("contentId")]
    public long ContentId { get; init; }

    [JsonPropertyName("cType")]
    public string CType { get; init; }

    [JsonPropertyName("cmsPath")]
    public string CmsPath { get; init; }

    [JsonPropertyName("creationDate")]
    public DateTime CreationDate { get; init; }

    [JsonPropertyName("modifyDate")]
    public DateTime ModifyDate { get; init; }

    [JsonPropertyName("allowComments")]
    public bool AllowComments { get; init; }

    [JsonPropertyName("hasAgeGate")]
    public bool HasAgeGate { get; init; }

    [JsonPropertyName("minimumAge")]
    public int MinimumAge { get; init; }

    [JsonPropertyName("ratingImagePath")]
    public string RatingImagePath { get; init; }

    [JsonPropertyName("author")]
    public User.GeneralUser Author { get; init; }

    [JsonPropertyName("autoEnglishPropertyFallback")]
    public bool AutoEnglishPropertyFallback { get; init; }

    /// <summary>
    ///     Firehose content is really a collection of metadata and "properties", which are the potentially-but-not-strictly localizable data that comprises the meat of whatever content is being shown.
    /// <para />
    ///     As Cole Porter would have crooned, "Anything Goes" with Firehose properties. They are most often strings, but they can theoretically be anything. They are JSON encoded, and could be JSON structures, simple strings, numbers etc... The Content Type of the item (cType) will describe the properties, and thus how they ought to be deserialized.
    /// </summary>
    [JsonPropertyName("properties")]
    public Dictionary<string, object> Properties { get; init; }

    [JsonPropertyName("representations")]
    public List<Content.ContentRepresentation> Representations { get; init; }

    /// <summary>
    ///     NOTE: Tags will always be lower case.
    /// </summary>
    [JsonPropertyName("tags")]
    public List<string> Tags { get; init; }

    [JsonPropertyName("commentSummary")]
    public Content.CommentSummary CommentSummary { get; init; }
}
