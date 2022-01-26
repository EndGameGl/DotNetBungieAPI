namespace DotNetBungieAPI.Generated.Models.Content;

public class ContentItemPublicContract : IDeepEquatable<ContentItemPublicContract>
{
    [JsonPropertyName("contentId")]
    public long ContentId { get; set; }

    [JsonPropertyName("cType")]
    public string CType { get; set; }

    [JsonPropertyName("cmsPath")]
    public string CmsPath { get; set; }

    [JsonPropertyName("creationDate")]
    public DateTime CreationDate { get; set; }

    [JsonPropertyName("modifyDate")]
    public DateTime ModifyDate { get; set; }

    [JsonPropertyName("allowComments")]
    public bool AllowComments { get; set; }

    [JsonPropertyName("hasAgeGate")]
    public bool HasAgeGate { get; set; }

    [JsonPropertyName("minimumAge")]
    public int MinimumAge { get; set; }

    [JsonPropertyName("ratingImagePath")]
    public string RatingImagePath { get; set; }

    [JsonPropertyName("author")]
    public User.GeneralUser Author { get; set; }

    [JsonPropertyName("autoEnglishPropertyFallback")]
    public bool AutoEnglishPropertyFallback { get; set; }

    /// <summary>
    ///     Firehose content is really a collection of metadata and "properties", which are the potentially-but-not-strictly localizable data that comprises the meat of whatever content is being shown.
    /// <para />
    ///     As Cole Porter would have crooned, "Anything Goes" with Firehose properties. They are most often strings, but they can theoretically be anything. They are JSON encoded, and could be JSON structures, simple strings, numbers etc... The Content Type of the item (cType) will describe the properties, and thus how they ought to be deserialized.
    /// </summary>
    [JsonPropertyName("properties")]
    public Dictionary<string, object> Properties { get; set; }

    [JsonPropertyName("representations")]
    public List<Content.ContentRepresentation> Representations { get; set; }

    /// <summary>
    ///     NOTE: Tags will always be lower case.
    /// </summary>
    [JsonPropertyName("tags")]
    public List<string> Tags { get; set; }

    [JsonPropertyName("commentSummary")]
    public Content.CommentSummary CommentSummary { get; set; }

    public bool DeepEquals(ContentItemPublicContract? other)
    {
        return other is not null &&
               ContentId == other.ContentId &&
               CType == other.CType &&
               CmsPath == other.CmsPath &&
               CreationDate == other.CreationDate &&
               ModifyDate == other.ModifyDate &&
               AllowComments == other.AllowComments &&
               HasAgeGate == other.HasAgeGate &&
               MinimumAge == other.MinimumAge &&
               RatingImagePath == other.RatingImagePath &&
               (Author is not null ? Author.DeepEquals(other.Author) : other.Author is null) &&
               AutoEnglishPropertyFallback == other.AutoEnglishPropertyFallback &&
               Properties.DeepEqualsDictionaryNaive(other.Properties) &&
               Representations.DeepEqualsList(other.Representations) &&
               Tags.DeepEqualsListNaive(other.Tags) &&
               (CommentSummary is not null ? CommentSummary.DeepEquals(other.CommentSummary) : other.CommentSummary is null);
    }
}