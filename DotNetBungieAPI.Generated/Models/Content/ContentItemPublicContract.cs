using System.Text.Json.Serialization;

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

    [JsonPropertyName("properties")]
    public Dictionary<string, object> Properties { get; init; }

    [JsonPropertyName("representations")]
    public List<Content.ContentRepresentation> Representations { get; init; }

    [JsonPropertyName("tags")]
    public List<string> Tags { get; init; }

    [JsonPropertyName("commentSummary")]
    public Content.CommentSummary CommentSummary { get; init; }
}
